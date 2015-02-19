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
        public byte Current { get; set; }
        public Point space, target, goal;
        public int btnSize = 10;
        public Dictionary<Point, byte> table = new Dictionary<Point,byte>();
        
        byte[,] mas = new byte[4, 4];
        byte[] order = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };
        public Game(int s=40)
        {
            temp = new byte[16] {3,2,4,7,1,11,6,5,13,0,9,12,10,15,8,14};
            btnSize = s;
            Current = 0;
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
            for (byte i = 1; i <= table.Count; i++)
            {               
                if (table.Values.ToArray()[i-1] != order[i-1]) {Current = i; break;} 
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
                    {
                        c.children.Add(item.Value);
                        c.Points.Add(item.Key);
                    }
                }
                sectors.Add(c);
            }
            #endregion
            Point blank = new Point(-200,-200);
            
            // prev -предыдушая фишка - на своем ли месте?
            Point prev = (current > 1)? table.Keys.ElementAt(current - 2):blank;

            // spacePlace - все возможные ходы(соседние фишки) 
            List<Point> spacePlace = new List<Point>();
            foreach (var point in table.Keys)
            {
                if ((point - space).Length == btnSize) spacePlace.Add(point);
            }
            Cube cube = new Cube();
            // options -перечень секторов в которых есть - ИСКОМАЯ и ПРОБЕЛ
            List<Cube> options = new List<Cube>();
            

            foreach (Cube item in sectors)
            {
                if (item.children.Contains(0) && item.children.Contains(current)) 
                    options.Add(item);
            }
            // target - направление для ПРОБЕЛа. Поумолчанию - ИСКОМАЯ.
            foreach (var item in table)
            {
                if (item.Value == current) target = item.Key;
            }

            // goal - требуемое место для ИСКОМОЙ.
            goal = table.Keys.ElementAt(current - 1);

              
                double len = 5 * btnSize;
                Point newTarget = new Point();
                
            // Если ПРОБЕЛ не в секторе с ИСКОМОЙ - двигаем к ИСКОМОЙ
               
                Cube next = new Cube();
                
                   
                    
                    foreach (var c in sectors)
                    {
                        if (c.Points.Contains(target) && !c.Points.Contains(prev)) { next = c; }
                    }
                    //foreach (var place in spacePlace)
                    //    foreach (var point in next.Points)
                    //{
                    //    if (len > (place - point).Length && place != target && place != space) { newTarget = place; len = (point - place).Length; }
                    //}
                    //target = newTarget;
                    
                
                
                if ((target - space).Length > btnSize)
                    {
                    MessageBox.Show("Going to sector");
                  
                    foreach (var place in spacePlace)     
                    {
                        if (len > (place - target).Length && place != target && place != space) { newTarget = place; len = (target - place).Length; }
                    }
                    target = newTarget;
                    }
                else
	                {
                    MessageBox.Show("ELSE - quadrant options");

                    foreach (Cube item in sectors)
                    {
                        if (item.children.Contains(0) && item.children.Contains(current) && item.Points.Contains(goal))
                            cube = item;
                    }

                        foreach (Cube c in options)
                            foreach (Point p in c.Points)
                            {
                                if (len > (goal - p).Length && p != target && p != space) { newTarget = p; len = (goal - p).Length; }
                            }
                        goal = (cube.children.Count == 0)?newTarget:table.Keys.ElementAt(current - 1);



                        foreach (Cube item in sectors)
                        {
                            if (item.children.Contains(0) && item.children.Contains(current) && item.Points.Contains(goal))
                                cube = item;
                        }
                   
                List<Point> move = new List<Point>();
                foreach (var point in cube.Points)
                {
                     if ((point - space).Length == btnSize) move.Add(point);
                }

                if ((goal - target).Length == btnSize) 
                {
                    
                    if ((space - target).Length == btnSize)
                    {
                        if (space != goal)
                        {
                            foreach (var item in move)
                            {
                                if (item != goal && item != target)
                                {
                                    target = item;
                                    break;
                                }
                            }
                            MessageBox.Show("Blank cell");
                        }
                        else 
                        {
                            MessageBox.Show(string.Format("Fit place {0} {1}", target.X, target.Y));
                        }
                    }
                    else 
                    {
                        target = goal;
                        
                    }
                   

                //}
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
