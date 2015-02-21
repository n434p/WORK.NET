using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Puzzle15
{
class Game
{
    public byte[] temp;
    bool avoid = false;
    bool collision = false;
    public List<Cube> colList = new List<Cube>();
    public Dictionary<byte, Point> change = new Dictionary<byte, Point>();
    public List<Point> fit = new List<Point>();
    public byte Current { get; set; }
    public Point space, target, goal;
    public int btnSize = 10;
    public Dictionary<Point, byte> table = new Dictionary<Point,byte>();
    byte[] order = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };
        
    public Game(int s=40)
    {
        temp = new byte[16] {3,2,4,7,1,11,6,5,13,0,9,12,10,15,8,14};
        btnSize = s;
        Current = 1;
        
        int n = 0;
            for (int j = 0; j < 4; j ++)
                for (int i = 0; i < 4; i++)  
                {
                    Point p = new Point(i * btnSize, j * btnSize);
                    table[p] = temp[n];
                    n++;
                    if (table[p] == 0) space = p;
                    if (table[p] == 1) target = p;
                    if (i == 0 && j == 0) goal = p;
                }
    }

    public bool Win()
    {
        for (int i = 0; i < 16; i++)
        {
            if (table.Values.ToArray()[i] != order[i]) return false;
        }
        return true;
    }

    public void Process() 
    {
        fit.Clear();
        for (int i = 0; i < order.Length; i++)
        {
            if (order[i] == table.Values.ToArray()[i])
            { 
                fit.Add(table.Keys.ToArray()[i]);
                Current = (byte)(i + 2);
            }
            else break;
        }
    }
    public void Rotation(byte current)
    {
        #region Sector INIT
        List<Cube> sectors = new List<Cube>();
        List<Point> sectorGrid = new List<Point>();
        for (int j = 0; j < 3; j++)
            for (int k = 0; k < 3; k++)
            {
                sectorGrid.Add(new Point((k + 0.5f) * btnSize, (j + 0.5f) * btnSize));
            }

        for (int i = 0; i < sectorGrid.Count; i++)
        {
            Cube c = new Cube() { Number = i};
            foreach (var item in table)
            {
                if ((sectorGrid[i] - item.Key).Length < btnSize * 1.5 / 2)
                {
                    c.center = sectorGrid[i];
                    c.children.Add(item.Value);
                    c.Points.Add(item.Key);
                }
            }
            sectors.Add(c);
        }

            foreach (var item in table)
            {
                if (item.Value == current) target = item.Key;
            }

            goal = (avoid) ? goal : table.Keys.ElementAt(current - 1);

        List<Cube> options = new List<Cube>();

        foreach (Cube sec in sectors)
        {
            if (sec.Points.Contains(target) && sec.Points.Contains(space)) options.Add(sec);
        }
        double len = 5 * btnSize;
        Point newTarget = new Point();

        #endregion

        if ((target-space).Length >= 1.5*btnSize && change.Count == 0)
        {
                foreach (Point place in table.Keys)
                {
                    if ((place - space).Length == btnSize && len > (place - target).Length && place != target && place != space)
                    { newTarget = place; len = (target - place).Length; }
                }
            target = newTarget;
        }
        else
        {
            Cube cube = new Cube();

            Point best = new Point();
            double ln = 0;

            #region DETERMINATION
            if (avoid && goal == space)
            {
                foreach (Cube item in options)
                    foreach (Point point in item.Points)
                    {
                        if ((point - space).Length == btnSize)
                            foreach (var p in fit)
                            {
                                if (ln < (p - point).Length)
                                { best = point; ln = (p - point).Length; }
                            }
                    }
                target = best;
                avoid = false;
            }
            else
            {
                if ((space-target).Length == btnSize && (space-goal).Length == btnSize && (goal-target).Length == 2*btnSize && change.Count ==0)
               
                {

                    Point bl1 = new Point();
                    Point bl2 = new Point();
                    Point pass = new Point();
                    Cube c1 = new Cube();
                    Cube c2 = new Cube();
                    foreach (var p in fit)
                    foreach (var item in sectors)
                    {
                        if (item.Points.Contains(goal) && item.Points.Contains(space) && item.Points.Contains(p))
                        {c1 = item; pass = p;}
                    }
                    foreach (var item in c1.Points)
                    {
                        if (item != goal && item != space && item != pass)
                            bl1 = item;
                    }
                    c1.target = goal;
                    c1.goal = bl1;
                    foreach (var item in sectors)
                    {
                        if (item.Points.Contains(bl1) && item.Points.Contains(space) && item.Points.Contains(target))
                        { c2 = item; }
                    }
                    foreach (var item in c2.Points)
                    {
                        if (item != bl1 && item != space && item != target)
                            bl2 = item;
                    }
                    foreach (var item in table)
	                {
		                if (item.Key == goal) change[item.Value] = bl1;
                        if (item.Key == bl2) change[item.Value] = target;
	                }
                    //change[]
                    c2.target = bl2;
                    c2.goal = target;
                    colList.Add(c1);
                    colList.Add(c2);   
                }

                foreach (Cube c in options)
                {
                    foreach (Point point in c.Points)
                    {
                        if (fit.Any(item => item == point))
                        {
                            avoid = true;
                            break;
                        }
                        if (len > (goal - point).Length && !fit.Contains(point) && point != target && point != space)
                        { newTarget = point; len = (goal - point).Length; }
                    }
                }
                goal = newTarget;
            }
            #endregion

            if (change.Count >= 1)
            {
                foreach (var item in table)
                {
                    if (item.Value == change.ElementAt(0).Key) target = item.Key;
                }
                goal = change.ElementAt(0).Value;

                options.Clear();
                options.Add(colList[0]);

                if (change.Count > 0 && target == goal)
                {
                    colList.RemoveAt(0);
                    change.Remove(change.ElementAt(0).Key);
                }

                if (change.Count == 0)
                {
                    foreach (var item in table)
                    {
                        if (item.Value == current) target = item.Key;
                    }

                    goal = (avoid) ? goal : table.Keys.ElementAt(current - 1);
                }
            }

            foreach (Cube c in options)
                if (c.children.Contains(0) && c.Points.Contains(target) && c.Points.Contains(goal))
                { cube = c; }

            if ((goal - target).Length == btnSize)
            { 
                if ((space - target).Length == btnSize)
                {
                    if (space != goal)
                    {
                        foreach (var point in cube.Points)
                        {
                            if ((point - space).Length == btnSize && point != goal && point != target)
                            {
                                target = point;
                                if (colList.Count > 0)
                                {
                                    colList[0].target = point;
                                }
                                break;
                            }
                        }
                    }
                    else
                    {

                    }
                }
                else
                {
                    target = goal;
                    if (colList.Count > 0)
                    {
                        colList[0].target = goal;
                    }
                }
            }       
            else
            { 
              
            }
                
           
          


        }

        
            
    }


   
    public bool Swap() 
    {
        if ((space-target).Length == btnSize)
        {
            byte b = table[space];
            table[space] = table[target];
            table[target] = b;
            space = target;
            
            return true;
        }
        return false;
    }
}
}
