using System;
using System.Diagnostics;

namespace KP2;

class Program
{
    static void Main()
    {
        Console.WriteLine("DijkstraAlgorithm");
        var time = new Stopwatch();
        int[,] graph = new int[,] {
            { 0, 0, 0, 1, 0, 0, 4, 1, 0,0 ,0},
            { 0, 0, 1, 0, 0, 0, 5, 0, 1,0 ,1 },
            { 0, 1, 0, 0, 1, 0, 0, 0, 1,0 ,0},
            { 1, 0, 0, 0, 0, 0, 5, 1, 1 ,0,0},
            { 0, 0, 1, 0, 0, 0, 0, 1, 1 ,1 ,0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 ,1,1},
            { 4, 5, 0, 5, 0, 0, 0, 0, 5 ,0,6},
            { 1, 0, 0, 1, 1, 0, 0, 0, 0 ,1,0},
            { 0, 1, 1, 1, 1, 0, 5, 0, 0 ,0,0},
            { 0, 0, 0, 0, 1, 1, 0, 1, 0 ,0,0},
            { 0, 1, 0, 0, 0, 1, 6, 0, 0 ,0,0}

        };
        time.Start();
        Dikstri a = new Dikstri();
        a.Dijkstra(graph, 6, 11);
        time.Stop();
        Console.WriteLine($"time is {time.ElapsedMilliseconds} ms");
        Console.WriteLine("WaveAlgorithm");
        time.Start();
        char[,] Grid = new char[,]
        {
            { ' ', ' ', ' ', 'X', ' ', ' ', 'X', 'X', ' ',' ' ,' '},
            { ' ', ' ', 'X', ' ', ' ', ' ', 'X', ' ', 'X',' ' ,'X' },
            { ' ', 'X', ' ', ' ', 'X', ' ', ' ', ' ', 'X',' ' ,' ' },
            { 'X', ' ', ' ', ' ', ' ', ' ', 'X', 'X', 'X',' ' ,' ' },
            {' ', ' ', 'X', ' ', ' ', ' ', ' ', 'X', 'X', 'X', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ','X' ,'X' },
            {'X', 'X', ' ', 'X', ' ', ' ', ' ', ' ', 'X',' ' ,'X' },
            {'X', ' ', ' ', 'X', 'X', ' ', ' ', ' ', ' ', 'X', ' '},
            {' ', 'X', 'X', 'X', 'X', ' ', 'X', ' ', ' ', ' ', ' '},
            { ' ', ' ', ' ', ' ', 'X', 'X', ' ', 'X', ' ',' ' ,' ' },
            { ' ', 'X', ' ', ' ', ' ', 'X', 'X', ' ', ' ',' ' ,' ' }
        };


        int shortestPath = FindShortestPath(Grid, 7, 7, 4, 4);
        Console.WriteLine("The shortest path between (7, 7) and (4, 4) is: " + shortestPath);
        time.Stop();
        Console.WriteLine($"time is {time.ElapsedMilliseconds} ms");
    }
    public static int FindShortestPath(char[,] grid, int startX, int startY, int endX, int endY)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);
        int[,] distances = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                distances[i, j] = -1;
            }
        }

        distances[startX, startY] = 0;
        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue((startX, startY));

        while (queue.Count > 0)
        {
            (int x, int y) = queue.Dequeue();

            if (x == endX && y == endY)
            {
                return distances[endX, endY];
            }

            int currentDistance = distances[x, y];
            List<(int, int)> neighbors = GetNeighbors(x, y, rows, cols);

            foreach ((int i, int j) in neighbors)
            {
                if (distances[i, j] == -1 && grid[i, j] == ' ')
                {
                    distances[i, j] = currentDistance + 1;
                    queue.Enqueue((i, j));
                }
            }
        }

        return -1;
    }

    private static List<(int, int)> GetNeighbors(int x, int y, int rows, int cols)
    {
        List<(int, int)> neighbors = new List<(int, int)>();

        if (x > 0)
        {
            neighbors.Add((x - 1, y));
        }

        if (x < rows - 1)
        {
            neighbors.Add((x + 1, y));
        }

        if (y > 0)
        {
            neighbors.Add((x, y - 1));
        }

        if (y < cols - 1)
        {
            neighbors.Add((x, y + 1));
        }

        return neighbors;
    }

}

