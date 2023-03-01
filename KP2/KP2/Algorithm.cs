using System;


namespace KP2;

class Algorithm
{
    private Dictionary<int, string> Way = new Dictionary<int, string>()
    {
        [1] = "Червоний унiверситет",
        [2] = "Андiївська церква",
        [3] = "Михайлiвський собор",
        [4] = "Золотi ворота",
        [5] = "Лядськi ворота",
        [6] = "Фунiкулер",
        [7] = "Київська полiтехнiка",
        [8] = "Фонтан на Хрещатику",
        [9] = "Софiя київська",
        [10] = "Нацiональна фiлармонiя",
        [11] = "Музей однiєї вулицi"
    };

    private static int minDistance(int[] dist, bool[] visited, int vertices)
    {
        int min = int.MaxValue, minIndex = -1;

        for (int v = 0; v < vertices; v++)
        {
            if (!visited[v] && dist[v] <= min)
            {
                min = dist[v];
                minIndex = v;
            }
        }

        return minIndex;
    }
    public void Dijkstra(int[,] graph, int source, int vertices)
    {
        int[] dist = new int[vertices];
        bool[] visited = new bool[vertices];

        for (int i = 0; i < vertices; i++)
        {
            dist[i] = int.MaxValue;
            visited[i] = false;
        }

        dist[source] = 0;

        for (int count = 0; count < vertices - 1; count++)
        {
            int u = minDistance(dist, visited, vertices);

            visited[u] = true;

            for (int v = 0; v < vertices; v++)
            {
                if (!visited[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                {
                    dist[v] = dist[u] + graph[u, v];
                }
            }
        }

        Console.WriteLine("Vertex \t\t\t  Distance from Source");

        for (int i = 0; i < vertices; i++)
        {
            Console.WriteLine(Way[i+1] + " \t\t " + dist[i]);
        }
    }

}
