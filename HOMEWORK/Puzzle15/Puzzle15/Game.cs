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
        public Point space, target, goal;
        public int btnSize = 10;
        public Dictionary<Point, byte> table = new Dictionary<Point,byte>();
        
        byte[,] mas = new byte[4, 4];
        byte[] order = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };
        public Game(int s=40)
        {
            temp = new byte[16] {3,2,4,7,1,11,6,5,13,0,9,12,10,15,8,14};
            btnSize = s;
            int n = 0;
                for (int j = 0; j < 4; j ++)
                    for (int i = 0; i < 4; i++)  
                    {
                        mas[i, j] = temp[n];
                        table[new Point(i * btnSize, j * btnSize)] = temp[n];
                        n++;
                        if (mas[i, j] == 0) space = new Point(i * btnSize, j * btnSize);
                        if (mas[i, j] == 1) target = new Point(i * btnSize, j * btnSize);
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
            for (int i = 1; i < table.Count; i++)
            {
                if (table.Values.ToArray()[i] != order[i])
                {

                }

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
                Cube c = new Cube();
                foreach (var item in table)
                {
                    if ((sectorGrid[i] - item.Key).Length < btnSize * 1.5 / 2)
                        c.children.Add(item.Value);
                        c.Points.Add(item.Key);
                }
                sectors.Add(c);
            }
#endregion

            List<Point> spacePlace = new List<Point>();
            foreach (var point in table.Keys)
            {
                if ((point - space).Length == btnSize) spacePlace.Add(point);
            }
            Cube cube = new Cube();
            foreach (Cube item in sectors)
            {
                if (item.children.Contains(0) && item.children.Contains(table.Values.ToArray()[current - 1]) && item.children.Contains(current)) cube = item;    
            }
            foreach (var item in table)
            {
                if (item.Value == current) target = item.Key;
            }

            if (cube.children.Count == 0) 
            {
                double len = 5*btnSize;
                Point newTarget = new Point();
                foreach (var place in spacePlace)
                {
                    if (len > (target - place).Length) { newTarget = place; len = (target - place).Length; }
                }
                target = (newTarget!=space)?newTarget:target;
            }
            else
            {
                foreach (var item in table)
	            {
		            if (item.Value == current) goal = item.Key;
	            }
                List<Point> move = new List<Point>();
                foreach (var point in cube.Points)
                {
                     if ((point - space).Length == btnSize) move.Add(point);
                }

                if ((goal - target).Length >= 1.3 * btnSize) 
                {
                    if ((target.X == goal.X || target.Y == goal.Y)&&((space-target).Length == btnSize))
                    {
                        foreach (var item in move)
	                        {
		                        if (item != goal|| item != target) target = item;
	                        }
                    }

                }
                
                //if (children.Contains(0))
                //    if (cw)
                //    {
                //        byte n = children[0];
                //        children[0] = children[1];
                //        children[1] = children[3];
                //        children[3] = children[2];
                //        children[2] = n;
                //    }
                //    else
                //    {
                //        byte n = children[0];
                //        children[0] = children[2];
                //        children[2] = children[3];
                //        children[3] = children[1];
                //        children[2] = n;
                //    } 
            }
           
           
            
        }


        public bool Swap() 
        {
            if ((space-target).Length == btnSize)
            {
                byte b = table[space];
                table[space] = table[target];
                table[target] = b;
                return true;
            }
            return false;
        }
    }
}
