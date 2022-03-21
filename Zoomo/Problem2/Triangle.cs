using System;

namespace Zoomo.Problem2
{
    public static class Triangle
    {
        public static double GetArea(double sideA, double sideB, double sideC)
        {
            if (CheckIfSidesAreValid(sideA, sideB, sideC))
            {
                var semiPerimeter = (sideA + sideB + sideC) * 0.5;
                var area = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) *
                                     (semiPerimeter - sideC)); //heron's formula
                
                return Math.Round(area, 3);
            }
            else
            {
                throw new InvalidTriangleException("The sides entered does not represent a Valid Triangle.");
            }
        }

        private static bool CheckIfSidesAreValid(double sideA, double sideB, double sideC)
        {
            return ValidateSides(sideA, sideB, sideC) && CheckAllSidesArePositive(sideA, sideB, sideC);
        }

        private static bool ValidateSides(double sideA, double sideB, double sideC)
        {
            return (sideA + sideB) > sideC && (sideB + sideC) > sideA && (sideC + sideA) > sideB;
        }

        private static bool CheckAllSidesArePositive(double sideA, double sideB, double sideC)
        {
            return sideA > 0 && sideB > 0 && sideC > 0;
        }
    }
}