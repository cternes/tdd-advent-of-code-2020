namespace app
{
    using System;
    using System.Collections.Generic;

    public static class Program
    {
        public static void Main()
        {
            SolvePartOne();
            SolvePartTwo();
        }

        private static void SolvePartOne()
        {
            Console.WriteLine("Part I");
            var game = new Game(new List<int> {8,0,17,4,1,12});

            // Act
            var result = -1;
            for (var i = 0; i < 2020; i++)
            {
                result = game.Play();
            }

            Console.WriteLine($"result: {result}");
        }
        
        private static void SolvePartTwo()
        {
            Console.WriteLine("Part II");
            var game = new Game(new List<int> {8,0,17,4,1,12});

            // Act
            var result = -1;
            for (var i = 0; i < 30000000; i++)
            {
                if (i % 1000 == 0)
                {
                    Console.WriteLine($"Iteration {i}");
                }
                result = game.Play();
            }

            Console.WriteLine($"result: {result}");
        }
    }
}