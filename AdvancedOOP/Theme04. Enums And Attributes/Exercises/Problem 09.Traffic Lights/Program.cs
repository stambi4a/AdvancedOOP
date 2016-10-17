namespace Problem_09.Traffic_Lights
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var countSignals = input.Length;
            var lights = new List<TrafficLight>();
            for (var i = 0; i < countSignals; i++)
            {
                TrafficLight light;
                if (Enum.TryParse(input[i], out light))
                {
                    lights.Add(light);
                }
            }

            var countChanges = int.Parse(Console.ReadLine());
            for (var i = 0; i < countChanges; i++)
            {
                for (var j = 0; j < countSignals; j++)
                {
                    var value = (TrafficLight)((int)(lights[j] + 2) % 3);
                    lights[j] = value;
                }

                Console.WriteLine(string.Join(" ", lights));
            }
        }
    }

    public enum TrafficLight
    {
        Red,
        Yellow,
        Green
    }
}
