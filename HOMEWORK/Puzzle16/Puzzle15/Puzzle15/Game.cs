﻿using System;
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
    public List<Cube> MovesChain = new List<Cube>();
    public List<Point> fit = new List<Point>();
    public byte Current { get; set; }
    public Point space, target, goal;
    public int btnSize = 10;
    public Dictionary<Point, byte> table = new Dictionary<Point,byte>();
    byte[] solveSeq = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 13, 10, 14, 15, 12 };
    byte[] order = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };
        
    public Game(int s=40)
    {
        temp = new byte[16] { 7, 1, 15, 6, 10, 9, 5, 4, 13, 2, 0, 3, 14, 8, 12, 11 };
            /// {12,7,3,8,2,13,15,0,1,5,4,10,6,14,11,9}
            /// {3,2,4,7,1,11,6,5,13,0,9,12,10,15,8,14}
            /// {1,2,3,4,5,6,7,8,9,10,15,12,13,0,11,14} - issue backward move!
        /// { 5, 7, 3, 10, 4, 8, 6, 2, 0, 1, 14, 11, 9, 12, 15, 13 } - bw issue
            /// {1,2,3,4,5,6,7,8,9,0,11,15,14,10,13,12}
            /// {5,7,3,10,4,8,6,2,0,1,14,11,9,12,15,13}
            /// {7,1,15,6,10,9,5,4,13,2,0,3,14,8,12,11}
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

    public void Rotation()
    {
        #region Sector INIT

        Point block = new Point(-1, -1);

        fit.Clear();
        for (int i = 0; i < order.Length; i++)
        {
            if (order[solveSeq[i] - 1] == table.Values.ToArray()[solveSeq[i] - 1])
            {
                fit.Add(table.Keys.ToArray()[solveSeq[i] - 1]);
                Current = solveSeq[i + 1];
            }
            else break;
        }

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

        if (MovesChain.Count > 0)
        {
            foreach (var item in table)
            {
                if (item.Value == MovesChain[0].targ) target = item.Key;
            }
            goal = MovesChain[0].goal;

            if (target == goal)
            {
                if (MovesChain.Count == 1) block = goal;
                MovesChain.RemoveAt(0);
            }
        }

        if (MovesChain.Count == 0)
        {
            foreach (var item in table)
            {
                if (item.Value == Current) target = item.Key;
            }

            goal = (avoid) ? goal : table.Keys.ElementAt(Current - 1);
        }

        List<Cube> options = new List<Cube>();

        foreach (Cube sec in sectors)
        {
            if (sec.Points.Contains(target) && sec.Points.Contains(space)) options.Add(sec);
        }

        if (MovesChain.Count > 0)
        {
            foreach (var item in table)
            {
                if (item.Value == MovesChain[0].targ) target = item.Key;
            }
            goal = MovesChain[0].goal;

            options.Clear();
            options.Add(MovesChain[0]);
        }

        double len = 5 * btnSize;
        Point newTarget = new Point();

        #endregion

        if ((target-space).Length >= 1.5*btnSize)
        {
                foreach (Point place in table.Keys)
                {
                    if ((place - space).Length == btnSize && len > (place - target).Length && place != target && place != space && !fit.Contains(place) && place != block) 
                       
                    { newTarget = place; len = (target - place).Length; }
                }
            target = newTarget;

        }
        else
        {
            #region IN CUBE LOGIC
            Cube cube = new Cube();
            if (MovesChain.Count == 0)
            {
                Point best = new Point();
                double ln = 5 * btnSize;
           
                if (avoid && goal == space)
                {
                    Point g = table.Keys.ElementAt(Current - 1);
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

                    if (target != goal && HorizBlock() || VertBlock())
                    {
                        if (HorizBlock()) 
                        { }

                        Cube c0 = new Cube();
                        Cube c1 = new Cube();
                        Cube c2 = new Cube();
                        foreach (var c in sectors)
                        {
                            if (c.Points.Contains(fit[fit.Count-1]) && c.Points.Contains(goal)) { c1 = c; }
                            if (c.Points.Contains(target) && c.Points.Contains(space))
                            {
                                if (HorizBlock() && c.center.X == c1.center.X+btnSize)
                                {
                                    c2 = c; 
                                }
                                if (VertBlock() && c.center.Y == c1.center.Y + btnSize)
                                {
                                    c2 = c;
                                }
                            }
                        }
                        if (c1.Points.Count > 0 && c2.Points.Count > 0)
                        {
                            c0.Points = c2.Points;
                            c0.goal = c2.Points[3];
                            c0.targ = table[target];
                            if (c2.Points[3] != target) MovesChain.Add(c0);
                            
                            if (VertBlock())
                                c1.goal = c1.Points[1];
                            else if (HorizBlock())
                                c1.goal = c1.Points[2];
                            c1.targ = table[fit[fit.Count - 1]];
                            MovesChain.Add(c1);

                            if (VertBlock())
                                c2.goal = c2.Points[1];
                            else if (HorizBlock())
                                c2.goal = c2.Points[2];
                            c2.targ = table[target];
                            MovesChain.Add(c2);
                        }
                    }

                    if (MovesChain.Count == 0 && goal != space)
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

            if (MovesChain.Count > 0)
            {
                foreach (var item in table)
                {
                    if (item.Value == MovesChain[0].targ) target = item.Key;
                }
                goal = MovesChain[0].goal;

                if ((space - target).Length == 2 * btnSize)
                { target = new Point(space.X - btnSize, space.Y); return; }
                options.Clear();
                options.Add(MovesChain[0]);
            }

         
            #endregion

            #region IN CUBE MOVE

            foreach (Cube c in options)
                if (c.Points.Contains(space) && c.Points.Contains(target) && c.Points.Contains(goal))
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
            else if(avoid)
            {
                avoid = false;
            }
            else
            {
                if (goal.Y == 3 * btnSize && fit.Contains(new Point(goal.X, goal.Y - btnSize)))
                    target = new Point(goal.X + btnSize, goal.Y);        
            }

            #endregion

        }  
         
    }
    public bool VertBlock()
    {
        if (goal.X == 3 * btnSize && target.X >= goal.X-btnSize && space.X >= goal.X-btnSize && fit.Contains(new Point(goal.X - btnSize, goal.Y)))
        { if ( space.Y > goal.Y && space.Y < goal.Y + 2 * btnSize && target.Y > goal.Y && target.Y <= goal.Y + 2 * btnSize) return true; }
        return false;
    }

    public bool HorizBlock()
    {
        if (goal.Y == 3 * btnSize && target.Y >= goal.Y - btnSize && space.Y >= goal.Y - btnSize && fit.Contains(new Point(goal.X, goal.Y - btnSize)))
        { if ( space.X > goal.X && space.X < goal.X + 2 * btnSize && target.X > goal.X && target.X <= goal.X + 2 * btnSize) return true; }
        return false;
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
