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
    #region INIT

    public int mistakes = 0;
    /// <summary>
    /// value returns "true" if closer way to goal passes through fitted cell.
    /// </summary>
    bool avoid = false;
    /// <summary>
    /// Contains sequence of cube's rotation (Vertical or Horizontal block that formed by two near cubes)
    /// </summary>
    List<Cube> MovesChain = new List<Cube>();
    /// <summary>
    /// Contains all fitted cells at current moment.
    /// </summary>
    List<Point> fit = new List<Point>();
    /// <summary>
    /// Current cell's number.
    /// </summary>
    byte Current { get; set; }
    /// <summary>
    /// space - blank cell
    /// target - cell with current number
    /// goal - needed place for current cell
    /// </summary>
    public Point space, target, goal;
    /// <summary>
    /// Cell geometry size
    /// </summary>
    public int btnSize = 10;
    /// <summary>
    /// Contains structure of plotted cells
    /// </summary>
    public Dictionary<Point, byte> table = new Dictionary<Point,byte>();
    /// <summary>
    /// Presents order of cells for reach solution
    /// </summary>
    byte[] solveSeq = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 13, 10, 14, 11, 15, 12 };
    /// <summary>
    /// Needed order of cells
    /// </summary>
    byte[] order = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };
    #endregion
    public Game(byte[] mas,int s=40)
    {
        btnSize = s;
        Current = 1;
        
        int n = 0;
            for (int j = 0; j < 4; j ++)
                for (int i = 0; i < 4; i++)  
                {
                    Point p = new Point(i * btnSize, j * btnSize);
                    table[p] = mas[n];
                    n++;
                    if (table[p] == 0) space = p;
                }
    }
    /// <summary>
    /// Returns true if all cells on needed places
    /// </summary>
    /// <returns></returns>
    public bool Win()
    {
        for (int i = 0; i < 16; i++)
        {
            if (table.Values.ToArray()[i] != order[i]) return false;
        }
        return true;
    }
    /// <summary>
    /// Returns list of moves witout overloop mistakes.
    /// </summary>
    public List<Point> Process()
    {
        List<Point> Solution = new List<Point>();
        int i = 0; 
        while (!Win()|| i > 250) 
        {
            Rotation();
            Swap();
            i++;
            if (Solution.Count > 2 && Solution[Solution.Count - 2] == target)
            {
                mistakes++;
                Solution.RemoveAt(Solution.Count - 1);
            }
            else Solution.Add(target);
        }
        return Solution;
    }
    /// <summary>
    /// Detrminates in what cell's place do next move(target).
    /// </summary>
    public void Rotation()
    {
        #region Sector INIT
        // For the process sequence - remembers pre-last goal position to avoid misstatement for last rotation
        // |S1|S2| S0-2 - sequence of moves.
        // |S0|G | 
        // (do not go through goal place in last rotation)
        Point block = new Point(-1, -1);

        fit.Clear();
        for (int i = 0; i < order.Length; i++)
        {
            // Fills by elements according to order of solution sequence.
            if (order[solveSeq[i] - 1] == table.Values.ToArray()[solveSeq[i] - 1])
            {
                fit.Add(table.Keys.ToArray()[solveSeq[i] - 1]);
                Current = solveSeq[i + 1];
            }
            else break;
        }
        /// |1|2|5| | 1-4 - Sectors[0]
        /// |3|4|6| | 2,4,5,6 - Sectors[1]
        /// |7|8| | | 3,4,7,8 - Sectors[3]
        /// | | | | | total 9 sectors
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
                    c.Points.Add(item.Key);
                }
            }
            sectors.Add(c);
        }

        /// Determinates goal&target points in Vertical or Horizontal block.

        if (MovesChain.Count > 0)
        {
            foreach (var item in table)
            {
                if (item.Value == MovesChain[0].targ) target = item.Key;
            }
            goal = MovesChain[0].goal;
            // Removes current sequence from chain if target reaches goal.
            if (target == goal)
            {
                if (MovesChain.Count == 1) block = goal;
                MovesChain.RemoveAt(0);
            }
        }

        // Determinates goal&target in case - chain is empty after previous logic; chain is empty at beginning  
        if (MovesChain.Count == 0)
        {
            foreach (var item in table)
            {
                if (item.Value == Current) target = item.Key;
            }

            goal = (avoid) ? goal : table.Keys.ElementAt(Current - 1);
        }
        
        // options - all cubes where rotation is allowed(possible)
        List<Cube> options = new List<Cube>();

        foreach (Cube sec in sectors)
        {
            if (sec.Points.Contains(target) && sec.Points.Contains(space)) options.Add(sec);
        }

        /// After removing element from chain. Redetermination space&target by new values of next sequence.
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
        // value helps to find closer way between points
        double len = 5 * btnSize;
        // keeps new value for the target
        Point newTarget = new Point();

        #endregion

        #region OUTCUBE LOGIC
        // Move space to the cube that contains target
        // | |  |  |  |
        // |T|  |  |  |
        // | |S3|S2|  |
        // | |  |S1|S0|
        if ((target-space).Length > 1.5*btnSize)
        {
                foreach (Point place in table.Keys)
                {
                    if ((place - space).Length == btnSize && len > (place - target).Length && place != target && place != space && !fit.Contains(place) && place != block) 
                       
                    { newTarget = place; len = (target - place).Length; }
                }
            target = newTarget;

        }
        #endregion

        else
        {
            #region IN CUBE LOGIC
            // If cube contains target&Space:
            // | | | | |
            // | | | | |
            // |.|S| | |
            // |T|.| | |

            Cube cube = new Cube();
            if (MovesChain.Count == 0)
            {
                Point best = new Point();
                double ln = 5 * btnSize;

                // Equipotential case:
                // |F|G| | | A,B - possible moves
                // | |T| | | A->G = B->G
                // |A|S|B| |
                // | | | | | B - prefer target (avoiding F)
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
                    // Determinates are exist any vertical or horizontal blocks

                    // |F|*|*| 
                    // |G|*|*| 

                    /// |F|G| F- fitted cell
                    /// |*|*| G - goal cell
                    /// |*|*| * - possible places for T(target) and S(space)

                    if (target != goal && HorizBlock() || VertBlock())
                    {   
                        Cube c0 = new Cube();
                        Cube c1 = new Cube();
                        Cube c2 = new Cube();

                        foreach (var c in sectors)
                        {
                            if (c.Points.Contains(fit[fit.Count-1]) && c.Points.Contains(goal)) { c1 = c; }
                            if (c.Points.Contains(target)) // && c.Points.Contains(space))
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
                            // |.|.|  |.|T| | 
                            // |T| |  |.| |G|  T -> G
                            // | |G|
                            c0.Points = c2.Points;
                            c0.goal = c2.Points[3];
                            c0.targ = table[target];
                            if (c2.Points[3] != target) MovesChain.Add(c0);

                            // |F|G|  |F| |.| 
                            // | | |  |G| |.|  F -> G
                            // |.|.|
                            if (VertBlock())
                                c1.goal = c1.Points[1];
                            else if (HorizBlock())
                                c1.goal = c1.Points[2];
                            c1.targ = table[fit[fit.Count - 1]];
                            MovesChain.Add(c1);

                            // |.|F|  |.| | | 
                            // | |G|  |F|G|T|  T -> G
                            // | |T|
                            if (VertBlock())
                                c2.goal = c2.Points[1];
                            else if (HorizBlock())
                                c2.goal = c2.Points[2];
                            c2.targ = table[target];
                            MovesChain.Add(c2);

                            // |.|F|  |.|.|.| 
                            // |.|T|  |F|T|.|  
                            // |.|.|
                        }
                    }

                    if (MovesChain.Count == 0) 
                    {
                        if (goal == space && (goal - target).Length > btnSize)
                        {
                            // Equipotential case:
                            // |   | T |
                            // |G=S|   |
                            double l1 = (space-table.Keys.ElementAt(table[new Point(target.X, space.Y)]-1)).Length;
                            double l2 = (space-table.Keys.ElementAt(table[new Point(target.Y, space.X)]-1)).Length;
                            target = (l1<l2)?new Point(target.X, space.Y):new Point(target.Y, space.X);
                        }
                        else
                        {
                            foreach (Cube c in options)
                            {
                                foreach (Point point in c.Points)
                                {
                                    // |F|G| |
                                    // |S|T|*|
                                    // |*|*|*| * - space's moves
                                    if (fit.Any(item => item == point))
                                    {
                                        avoid = true;
                                        break;
                                    }
                                    if (len >= (goal - point).Length && !fit.Contains(point) &&point != target && point != space)
                                    { newTarget = point; len = (goal - point).Length; }
                                }
                            }
                            goal = newTarget;
                        }
                    }
                }
            }

            // If in previous logic exists any block - renew values target&goal
            if (MovesChain.Count > 0)
            {
                foreach (var item in table)
                {
                    if (item.Value == MovesChain[0].targ) target = item.Key;
                }
                goal = MovesChain[0].goal;

                // In case where space and target are on diametrical places in block
                // |T| |S|
                // | | | |
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
                // |G|T|  | |T|
                // | | |  | |G|
                if ((space - target).Length == btnSize)
                {
                    // |G=S|T|  |S|T  |
                    // |   |S|  | |G=S|

                    if (space != goal)
                    {
                        // |G|T|  |S|T|
                        // |*|S|  |*|G|  * - prefer move
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
                        // |G=S|T|  | |T  |
                        // |   | |  | |G=S|  T - prefer move
                    }
                }
                else
                {
                    // |G|T|  | |T|
                    // |S| |  |S|G| G - prefer move
                    target = goal;
                }
            }
            else if(avoid)
            {
                // Rotation processes in cube without fitted cells (but G, T and S in same cube)
                // |F|F|F|
                // | |.|T|
                // | |G|.|
                avoid = false;
            }
            else
            {
                ///Horizontal queue bridge between blocks
                /// | |  |  | |
                /// | |  |  | | G - T > btnSize
                /// |F|T1|T2| | T1-3 - possible cases
                /// |G|* |T3| | * - prefer move
                    
                if (goal.Y == 3 * btnSize && fit.Contains(new Point(goal.X, goal.Y - btnSize)))
                    target = new Point(goal.X + btnSize, goal.Y);

                ///Vertical queue bridge between blocks
                /// | | |  |  |
                /// | | |F | G| G - T > btnSize
                /// | | |T1| *| T1-3 - possible cases
                /// | | |T2|T3| * - prefer move
                
                else if (goal.X == 3 * btnSize && fit.Contains(new Point(goal.X - btnSize, goal.Y)))
                    target = new Point(goal.X, goal.Y + btnSize);  
            }

            #endregion
        }  
         
    }
    /// <summary>
    /// Determinates next situation:
    /// |F|G| F- fitted cell
    /// |*|*| G - goal cell
    /// |*|*| * - possible places for T(target) and S(space)
    /// </summary>
    /// <returns></returns>
    public bool VertBlock()
    {
        if (goal.X == 3 * btnSize && goal.Y < 2 * btnSize && target.X >= goal.X - btnSize && space.X >= goal.X - btnSize && fit.Contains(new Point(goal.X - btnSize, goal.Y)))
        { if (space.Y > goal.Y && space.Y < goal.Y + 2 * btnSize && target.Y > goal.Y && target.Y <= goal.Y + 2 * btnSize) return true; }
        return false;

    }
    /// <summary>
    /// Determinates next situation:
    /// |F|*|*| F- fitted cell
    /// |G|*|*| G - goal cell
    ///  * - possible places for T(target) and S(space)
    /// </summary>
    /// <returns></returns>
    public bool HorizBlock()
    {
        if (goal.Y == 3 * btnSize && goal.X < 2 * btnSize && target.Y >= goal.Y - btnSize && space.Y >= goal.Y - btnSize && fit.Contains(new Point(goal.X, goal.Y - btnSize)))
        { if (space.X > goal.X && space.X < goal.X + 2 * btnSize && target.X > goal.X && target.X <= goal.X + 2 * btnSize) return true; }
        return false;

    }
    /// <summary>
    /// If space is near by the target returns true. 
    /// Replaces space&target places in "table" between each other and equals space as target
    /// </summary>
    /// <returns></returns>
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
