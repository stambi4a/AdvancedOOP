namespace Problem_10.Inferno_Infinity.Factories
{
    using System;

    using Problem_10.Inferno_Infinity.Enums;
    using Problem_10.Inferno_Infinity.Models;

    public class GemFactory
    {
        public static Gem CreateGem(string input)
        {
            var gemParams = input.Split();
            var type = gemParams[1];
            var clarity = (Clarity)Enum.Parse(typeof(Clarity),gemParams[0]);
            switch (type)
            {
                case "Ruby":
                    {
                        return new Ruby(clarity);
                    }

                case "Amethyst":
                    {
                        return new Amethyst(clarity);
                    }

                case "Emerald":
                    {
                        return new Emerald(clarity);
                    }

                default:
                    throw new ArgumentException("Invalid Gem Type!");
            }
        }
    }
}
