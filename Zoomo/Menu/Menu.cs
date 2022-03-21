using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using Zoomo.Problem1;
using Zoomo.Problem2;
using Zoomo.Problem3;

namespace Zoomo.Menu
{
    public class Menu
    {
        public bool DisplayAndStartProgram()
        {
            PrintMenu();
            switch (Console.ReadLine())
            {
                case "1":
                    Problem1();
                    return true;
                case "2":
                    Problem2();
                    return true;
                case "3":
                    Problem3();
                    return true;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Thanks for using. Bye.... :)");
                    return false;
                default:
                    return true;
            }
        }

        #region ProblemDisplayers
          private void Problem1()
        {
            Console.WriteLine("Enter a string or value to test:");
            var str = Console.ReadLine();
            Console.WriteLine("The function returned: " + str.IsStringNullOrEmpty());
            ProblemFinishedExecution();
        }

        private void Problem2()
        {
            var sides = GetSidesOfTriangle();
            try
            {
                Console.WriteLine("Area of triangle is: {0}", Triangle.GetArea(sides[0], sides[1], sides[2]));
            }
            catch (InvalidTriangleException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            ProblemFinishedExecution();
        }

        private void Problem3()
        {
            Console.WriteLine("Please enter path to an HTML file:");
            var path = Console.ReadLine();
            if (path is not null)
            {
                if (File.Exists(path))
                {
                    try
                    {
                        var responseModel = UrlScanner.ScanHtmlFile(path);
                        if (responseModel is not null)
                        {
                            var ts = responseModel.TimeElapsed;
                            var elapsedTime =
                                $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";

                            Console.WriteLine("Links Working: {0}", responseModel.LinksWorking);
                            Console.WriteLine("Links not Working: {0}", responseModel.LinksNotWorking);
                            Console.WriteLine("RunTime: {0}", elapsedTime);
                            Console.WriteLine();
                            Console.WriteLine("Enter 1 to view Working Links.");
                            Console.WriteLine("Enter 2 to view Non Working Links.");
                            Console.WriteLine("Enter 3 to view both Working and Non Working Links.");
                            Console.WriteLine("Enter anything else to quit to menu.");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    PrintWorkingLinks(responseModel.LinksWorkingList);
                                    break;
                                case "2":
                                    PrintNonWorkingLinks(responseModel.LinksNotWorkingList);
                                    break;
                                case "3":
                                    PrintWorkingLinks(responseModel.LinksWorkingList);
                                    Console.WriteLine();
                                    PrintNonWorkingLinks(responseModel.LinksNotWorkingList);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Specified file path does not exists.");
                }
            }
            else
            {
                Console.WriteLine("Path cannot be empty.");
            }

            ProblemFinishedExecution();
        }
        #endregion

        #region Printers
        private void PrintWorkingLinks(List<string> links)
        {
            Console.WriteLine("--------------Working links--------------");
            PrintStringList(links);
        }

        private void PrintNonWorkingLinks(List<string> links)
        {
            Console.WriteLine("--------------Non Working links--------------");
            PrintStringList(links);
        }

        private void PrintStringList(List<string> strings)
        {
            strings.ForEach(Console.WriteLine);
        }
        private void ProblemFinishedExecution()
        {
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }

        private void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("----------------Zoomo Assessment by Karan Bhatia----------------");
            Console.WriteLine("Please select a problem to test:");
            Console.WriteLine("1. IsStringNullOrEmpty() function.");
            Console.WriteLine("2. Area of a triangle.");
            Console.WriteLine("3. Html Url Checker.");
            Console.WriteLine("4. Exit.");
        }
        #endregion
      

        

        private double[] GetSidesOfTriangle()
        {
            var sides = new double[3];
            for (var i = 0; i < 3;)
            {
                Console.WriteLine("Enter Side {0} of triangle: ", i + 1);
                var str = Console.ReadLine();
                if (double.TryParse(str, out sides[i]))
                {
                    i++;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter a valid number.");
                    Console.WriteLine();
                }
            }

            return sides;
        }

        
    }
}