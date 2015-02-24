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
    public List<Cube> cubes = new List<Cube>();
    public Dictionary<byte, Point> change = new Dictionary<byte, Point>();
    public List<Point> fit = new List<Point>();
    public byte Current { get; set; }
    public Point space, target, goal;
    public int btnSize = 10;
    public Dictionary<Point, byte> table = new Dictionary<Point,byte>();
    byte[] order = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };
        
    public Game(int s=40)
    {
        temp = new byte[16] { 12, 7, 3, 8, 2, 13, 15, 0, 1, 5, 4, 10, 6, 14, 11, 9 };
            /// {12,7,3,8,2,13,15,0,1,5,4,10,6,14,11,9}
        /// {3,2,4,7,1,11,6,5,13,0,9,12,10,15,8,14}
            ///
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
                    //if (table[p] == 1) target = p;
                    //if (i == 0 && j == 0) goal = p;
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
          //  else break;
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

        if (cubes.Count > 0)
        {
            foreach (var item in table)
            {
                if (item.Value == cubes[0].targ) target = item.Key;
            }
            goal = cubes[0].goal;

            if (target == goal)
                cubes.RemoveAt(0);
        }

        if (cubes.Count == 0)
        {
            foreach (var item in table)
            {
                if (item.Value == current) target = item.Key;
            }

            goal = (avoid) ? goal : table.Keys.ElementAt(current - 1);
        }

        List<Cube> options = new List<Cube>();

        foreach (Cube sec in sectors)
        {
            if (sec.Points.Contains(target) && sec.Points.Contains(space)) options.Add(sec);
        }
        double len = 5 * btnSize;
        Point newTarget = new Point();

        #endregion


        if ((target-space).Length >= 1.5*btnSize && cubes.Count == 0)
        {
                foreach (Point place in table.Keys)
                {
                    if ((place - space).Length == btnSize && len > (place - target).Length && place != target && place != space && !fit.Contains(place))
                    { newTarget = place; len = (target - place).Length; }
                }
            target = newTarget;
        }
        else
        {
            #region IN CUBE LOGIC
            Cube cube = new Cube();
            if (cubes.Count == 0)
            {
                Point best = new Point();
                double ln = 5 * btnSize;
           
                if (avoid && goal == space)
                {
                    Point g = table.Keys.ElementAt(current-1);
                    if (options.Count < 2)
                    {
                        avoid = false;
                    }
                    else
                    {
                        foreach (Cube item in options)
                            foreach (Point point in item.Points)
                            {
                                if (point != target && (point - space).Length == btnSize && ln >= (g - point).Length)
                                { best = point; ln = (g - point).Length; }
                            }
                        target = best;
                        avoid = false;
                    }
                }
                else
                {
                    if ((goal - target).Length == 2 * btnSize && (space - goal).Length == btnSize && (space - target).Length == btnSize)
                    {
                        Cube c1 = new Cube();
                        Cube c2 = new Cube();
                        foreach (var c in sectors)
                        {
                            if (c.Points.Contains(goal) && c.Points.Contains(space)) c1 = c;
                            if (c.Points.Contains(target) && c.Points.Contains(space)) c2 = c;
                        }
                        if (goal.X == space.X && space.X == target.X && space.X == 3 * btnSize)
                        {
                            c1.goal = new Point(space.X - btnSize, space.Y);
                            c1.targ = table[goal];
                            c2.goal = new Point(target.X - btnSize, target.Y);
                            c2.targ = c1.targ;
                            cubes.Add(c1);
                            cubes.Add(c2);

                        }
                        if (goal.Y == space.Y && space.Y == target.Y && space.Y == 3 * btnSize)
                        {
                            c1.goal = new Point(space.X, space.Y - btnSize);
                            c1.targ = table[goal];
                            c2.goal = new Point(target.X, target.Y - btnSize);
                            c2.targ = c1.targ;
                            cubes.Add(c1);
                            cubes.Add(c2);
                        }
                        
                    }

                    if (cubes.Count == 0)
                    {
                        foreach (Cube c in options)
                        {
                            foreach (Point point in c.Points)
                            {
                                if (fit.Any(item => item == point))
                                {
                                    avoid = true;
                                    break;
                                }
                                if (len >= (goal - point).Length && !fit.Contains(point) && point != target && point != space)
                                { newTarget = point; len = (goal - point).Length; }
                            }
                        }
                        goal = newTarget;
                    }
                }
            }

         
            #endregion

            

            if (cubes.Count > 0)
            {
                foreach (var item in table)
                {
                    if (item.Value == cubes[0].targ) target = item.Key;
                }
                goal = cubes[0].goal;

                options.Clear();
                options.Add(cubes[0]);
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
                }
            }       
            else
            {
                avoid = false;
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
