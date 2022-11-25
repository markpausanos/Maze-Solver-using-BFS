using SearchActivity;

Console.Write("Enter number of rows: ");
int rows = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter number of columns: ");
int columns = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("\n--Unpassable blocks--");
Console.WriteLine("Enter 0 to stop taking inputs\n");

List<int> blocks = new();
while (true)
{
    Console.Write($"Enter number to block ({blocks.Count() + 1}): ");
    int x = Convert.ToInt32(Console.ReadLine());
    if (x == 0)
    {
        break;
    }
    blocks.Add(x);
}

MazeSolver MazeSolver = new MazeSolver(rows, columns, blocks);

Console.WriteLine();
Console.Write("Enter start: ");
int start = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter end: ");
int end = Convert.ToInt32(Console.ReadLine());

Console.Write("Allow Diagonals (Y/N): ");
char response = (char)Console.Read();

bool diagonals = false;
if (response == 'Y')
{
    diagonals = true;
}
MazeSolver.SolveMaze(start, end, diagonals);