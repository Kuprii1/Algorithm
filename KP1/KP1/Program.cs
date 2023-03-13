using System.Diagnostics;

class TA1
{
    static void Main()
    {
        string locate = Environment.CurrentDirectory;
        locate = locate.Remove(locate.Length - 16);
        int flag = 0;
        try
        {

            Console.WriteLine("1.Input in console");
            Console.WriteLine("2.Read from file");
            flag = Convert.ToInt32(Console.ReadLine());
            Input(locate + "in.txt", out int n, out int[] array, flag);
            var timer = new Stopwatch();//m
            timer.Start();
            SwapMinAndMax(n, array);
            timer.Stop();
            Output(locate + "out", array, flag);
            Console.WriteLine("Time for working:" + timer.Elapsed);
            Console.ReadKey();
        }
        catch (Exception)
        {
            if (flag == 2)
                File.WriteAllText(locate + "out", "Помилка введених даних");
            else
                Console.WriteLine("Помилка введених даних");
        }
    }
    static void Input(in string locate, out int n, out int[] array, in int flag)
    {
        string[] lines = new string[2];
        if (flag == 2)
        {
            lines = File.ReadAllLines(locate);
            n = Convert.ToInt32(lines[0]);
        }
        else
        {
            Console.Write("n:");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Array:");
            lines[1] = Console.ReadLine()!;
        }
        array = new int[n];
        if (lines[1] == "random")
        {
            var rand = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < n; i++)
            {
                array[i] = rand.Next(-100, 100);
            }
            lines[1] = string.Join(" ", array);
            if (flag == 2)
                File.WriteAllLines(locate, lines);
            else
            {
                Console.Write("Random array:");
                Console.WriteLine(lines[1]);
            }
        }
        else
        {
            string[] data = lines[1].Split();
            for (int i = 0; i < data.Length; i++)
            {
                array[i] = Convert.ToInt32(data[i]);
            }
        }
    }
    static void SwapMinAndMax(in int n, in int[] array)
    {
        int minpos = 0, maxpos = 0, minval = array[0], maxval = array[0];
        for (int i = 1; i < n; i++)
        {
            if (array[i] < minval)
            {
                minpos = i;
                minval = array[i];
            }
            if (array[i] > maxval)
            {
                maxpos = i;
                maxval = array[i];
            }
        }
        (array[minpos], array[maxpos]) = (maxval, minval);
    }
    static async void Output(string locate, int[] array, int flag)
    {
        string? line = string.Join(" ", array);
        if (flag == 2)
            await File.WriteAllTextAsync(locate, line);
        else
        {
            Console.Write("Output array:");
            Console.WriteLine(line);
        }
    }

}