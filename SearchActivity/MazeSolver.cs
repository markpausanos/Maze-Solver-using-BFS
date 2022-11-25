using System.Text;

namespace SearchActivity
{
    public class MazeSolver
    {
        private int[] mazeArray;
        private int row;
        private int col;
        public MazeSolver(int row, int col, List<int> blocks)
        {
            this.row = row;
            this.col = col;

            int size = row * col + 1;
            mazeArray = new int[size];

            foreach (int block in blocks)
            {
                if (block <= size)
                {
                    mazeArray[block] = -1;
                }
            }
            PrintMaze();
        }

        public void PrintMaze()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n--LEGEND--");
            Console.WriteLine("0 - Unvisited");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("X - Unpassable block");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Arrows - Path");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("S - Start");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("F - Finish\n");

            for (int i = 1; i < mazeArray.Length; i++)
            {
                switch(mazeArray[i])
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("S" + "\t");
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("F" + "\t");
                        break;
                    case -1:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X" + "\t");
                        break;
                    case -2:
                        Console.OutputEncoding = Encoding.Unicode;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("↑" + "\t");
                        break;
                    case -3:
                        Console.OutputEncoding = Encoding.Unicode;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("↓" + "\t");
                        break;
                    case -4:
                        Console.OutputEncoding = Encoding.Unicode;
                        Console.ForegroundColor = ConsoleColor.Yellow; 
                        Console.Write("←" + "\t");
                        break;
                    case -5:
                        Console.OutputEncoding = Encoding.Unicode;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("→" + "\t");
                        break;
                    case -6:
                        Console.OutputEncoding = Encoding.Unicode;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("↗" + "\t");
                        break;
                    case -7:
                        Console.OutputEncoding = Encoding.Unicode;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("↖" + "\t");
                        break;
                    case -8:
                        Console.OutputEncoding = Encoding.Unicode;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("↘" + "\t");
                        break;
                    case -9:
                        Console.OutputEncoding = Encoding.Unicode;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("↙" + "\t");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(mazeArray[i] + "\t");
                        break;

                }
                if (i % col == 0)
                {
                    Console.WriteLine();
                }
            }
        }
        public void SolveMaze(int start, int end, bool allowDiagonals = false)
        {
            if (mazeArray[start] == -1 || mazeArray[end] == -1)
            {
                Console.WriteLine("Maze is not solvable!");
            }

            bool isFound = false;

            Dictionary<int, int> visitedBlocks = new Dictionary<int, int>();
            Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>>();

            queue.Enqueue(new KeyValuePair<int, int>(start, -1));
            visitedBlocks.Add(start, -1);

            while(queue.Count > 0)
            {
                var top = queue.Dequeue().Key;

                if (top == end)
                {
                    isFound = true;
                    break;
                }

                if (top - col > 0 && 
                    mazeArray[top - col] != -1 && 
                    !visitedBlocks.ContainsKey(top - col))
                {
                    KeyValuePair<int, int> pair = new(top - col, top);
                    queue.Enqueue(pair);
                    visitedBlocks.Add(pair.Key, pair.Value);
                }

                if (top + col < mazeArray.Length && 
                    mazeArray[top + col] != -1 && 
                    !visitedBlocks.ContainsKey(top + col))
                {
                    KeyValuePair<int, int> pair = new(top + col, top);
                    queue.Enqueue(pair);
                    visitedBlocks.Add(pair.Key, pair.Value);
                }

                if (top - 1 > 0 && 
                    mazeArray[top - 1] != -1 &&
                    top % col != 1 &&
                    !visitedBlocks.ContainsKey(top - 1))
                {
                    KeyValuePair<int, int> pair = new(top - 1, top);
                    queue.Enqueue(pair);
                    visitedBlocks.Add(pair.Key, pair.Value);
                }

                if (top + 1 < mazeArray.Length && 
                    mazeArray[top + 1] != -1 &&
                    top % col != 0 &&
                    !visitedBlocks.ContainsKey(top + 1))
                {
                    KeyValuePair<int, int> pair = new(top + 1, top);
                    queue.Enqueue(pair);
                    visitedBlocks.Add(pair.Key, pair.Value);
                }

                if (!allowDiagonals)
                {
                    continue;
                }
                // Diagonals
                if (top - col - 1 > 0 &&
                    mazeArray[top - col - 1 ] != -1 &&
                    top % col != 1 &&
                    !visitedBlocks.ContainsKey(top - col - 1))
                {
                    KeyValuePair<int, int> pair = new(top - col - 1, top);
                    queue.Enqueue(pair);
                    visitedBlocks.Add(pair.Key, pair.Value);
                }

                if (top - col + 1 > 0 &&
                    mazeArray[top - col + 1] != -1 &&
                    top % col != 0 &&
                    !visitedBlocks.ContainsKey(top - col + 1))
                {
                    KeyValuePair<int, int> pair = new(top - col + 1, top);
                    queue.Enqueue(pair);
                    visitedBlocks.Add(pair.Key, pair.Value);
                }

                if (top + col - 1 < mazeArray.Length &&
                    mazeArray[top + col - 1] != -1 &&
                    top % col != 1 &&
                    !visitedBlocks.ContainsKey(top + col - 1))
                {
                    KeyValuePair<int, int> pair = new(top + col - 1, top);
                    queue.Enqueue(pair);
                    visitedBlocks.Add(pair.Key, pair.Value);
                }

                if (top + col + 1 < mazeArray.Length &&
                    mazeArray[top + col + 1] != -1 &&
                    top % col != 0 &&
                    !visitedBlocks.ContainsKey(top + col + 1))
                {
                    KeyValuePair<int, int> pair = new(top + col + 1, top);
                    queue.Enqueue(pair);
                    visitedBlocks.Add(pair.Key, pair.Value);
                }
            }

            if (!isFound)
            {
                Console.WriteLine($"No paths are possible from block {start} to {end}.");
                return;
            }

            if (isFound)
            {
                List<int> path = new();
                int top = end;
                while(true)
                {
                    int previous = top;
                    path.Add(previous);
                    top = visitedBlocks[top];

                    if (top == -1)
                    {
                        break;
                    }
                    else if (top == previous - col)
                    {
                        mazeArray[previous] = -3;
                    }
                    else if (top == previous + col)
                    {
                        mazeArray[previous] = -2;
                    }
                    else if (top == previous - 1)
                    {
                        mazeArray[previous] = -5;
                    }
                    else if (top == previous + 1)
                    {
                        mazeArray[previous] = -4;
                    }

                    if(!allowDiagonals)
                    {
                        continue;
                    }
                    // Diagonals
                    else if (top == previous - col + 1)
                    {
                        mazeArray[previous] = -9;
                    }
                    else if (top == previous - col - 1)
                    {
                        mazeArray[previous] = -8;
                    }
                    else if (top == previous + col + 1)
                    {
                        mazeArray[previous] = -7;
                    }
                    else if (top == previous + col - 1)
                    {
                        mazeArray[previous] = -6;
                    }

                }
                mazeArray[start] = 1;
                mazeArray[end] = 2;

                PrintMaze();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("PATH:");
                for (int i = path.Count() - 1; i >= 0; i--)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (i == 0)
                    {
                        Console.Write(path[i]);
                    }
                    else
                    {
                        Console.Write(path[i] + " -> ");
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            
        }
    }
}
