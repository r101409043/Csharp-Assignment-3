public class WorkingWithMethods
{
    public static void One()
    {
        Console.WriteLine("Input(e.g. 1,2,3,4,5,6,7,8,9,10): ");
        int[] numbers = GenerateNumbers();
        Reverse(numbers);
        PrintNumbers(numbers);

        static int[] GenerateNumbers()
        {
            int[] input = Array.ConvertAll(Console.ReadLine()?.Trim().Split(",")!, s => int.Parse(s));
            return input;
        }

        static int[] Reverse(int[] numbers)
        {
            int[] reverse = numbers;
            int temp = 0;
            for (int i = 0; i < reverse.Length / 2; i++)
            {
                temp = reverse[i];
                reverse[i] = reverse[reverse.Length - 1 - i];
                reverse[reverse.Length - 1 - i] = temp;
                //(reverse[i], reverse[reverse.Length - 1 - i]) = (reverse[reverse.Length - 1 - i], reverse[i]); < Tuple method
            }

            return reverse;
        }

        static void PrintNumbers(int[] numbers)
        {
            Console.WriteLine(string.Join(",", numbers));
        }
    }

    public static void Two()
    {
        Console.WriteLine("Input(e.g. 3): ");
        int input = int.Parse(Console.ReadLine()!);
        for (int i = 1; i <= 10; i++)
        {
            if (i > 1)
            {
                Console.Write(",");
            }
            Console.Write(Fibonacci(i));
        }

        Console.WriteLine($"\nFibonacci({input}) = {Fibonacci(input)}");

        static ulong Fibonacci(int num)
        {
            //Recursion - Fibonacci(High numbers) -> Crash
            if (num == 1 || num == 2)
            {
                return 1;
            } else
            {
                return Fibonacci(num - 1) + Fibonacci(num - 2);
            }
            //Loop - Won't Crash
            /* ulong a = 1, b = 1;
            for (int i = 3; i <= num; i++)
            {
                ulong temp = a + b;
                a = b;
                b = temp;
            }
            return b; */
        }
    }
}
