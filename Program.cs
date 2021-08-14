using System;
using System.Drawing;
using Pastel;

namespace RhythmsGonnaGetYou
{
    class Program
    {
        static void DisplayGreeting()
        {
            // Hippo from https://www.asciiart.eu/animals/other-land & Ascii text from https://www.ascii-art-generator.org/
            Console.Clear();
            Console.WriteLine($"{"#     #              ".Pastel(Color.SeaGreen)}{"      ".Pastel(Color.SteelBlue)}{" ###       ".Pastel(Color.LightSkyBlue)}{" ######                            ".Pastel(Color.MediumVioletRed)} {@"      c~~p ,---------.    ".Pastel(Color.SteelBlue)}");
            Console.WriteLine($"{"#     #  ####  ##### ".Pastel(Color.SeaGreen)}{"      ".Pastel(Color.SteelBlue)}{"  #  ##### ".Pastel(Color.LightSkyBlue)}{" #     # ######   ##   #####  #### ".Pastel(Color.MediumVioletRed)} {@" ,---'".Pastel(Color.SteelBlue)}{"oo".Pastel(Color.ForestGreen)}{@"  )           \".Pastel(Color.SteelBlue)}");
            Console.WriteLine($"{"#     # #    # #    #".Pastel(Color.SeaGreen)}{"      ".Pastel(Color.SteelBlue)}{"  #  #    #".Pastel(Color.LightSkyBlue)}{" #     # #       #  #    #   #     ".Pastel(Color.MediumVioletRed)} {@"(".Pastel(Color.SteelBlue)}{" O O".Pastel(Color.DimGray)}{"                  )/ ".Pastel(Color.SteelBlue)}");
            Console.WriteLine($"{"####### #    # #    #".Pastel(Color.SeaGreen)}{" #####".Pastel(Color.Violet)}{"  #  #    #".Pastel(Color.LightSkyBlue)}{" ######  #####  #    #   #    #### ".Pastel(Color.MediumVioletRed)} {@" `".Pastel(Color.SteelBlue)}{"=".Pastel(Color.WhiteSmoke)}{"^".Pastel(Color.LightPink)}{"=".Pastel(Color.WhiteSmoke)}{@"'                 /".Pastel(Color.SteelBlue)}");
            Console.WriteLine($"{"#     # #    # ##### ".Pastel(Color.SeaGreen)}{"      ".Pastel(Color.SteelBlue)}{"  #  ##### ".Pastel(Color.LightSkyBlue)}{" #     # #      ######   #        #".Pastel(Color.MediumVioletRed)} {@"       \    ,     .   /   ".Pastel(Color.SteelBlue)}");
            Console.WriteLine($"{"#     # #    # #     ".Pastel(Color.SeaGreen)}{"      ".Pastel(Color.SteelBlue)}{"  #  #     ".Pastel(Color.LightSkyBlue)}{" #     # #      #    #   #   #    #".Pastel(Color.MediumVioletRed)} {@"       \".Pastel(Color.DimGray)}{@"\".Pastel(Color.SteelBlue)}{@"  |-----'|  /    ".Pastel(Color.SteelBlue)}");
            Console.WriteLine($"{"#     #  ####  #     ".Pastel(Color.SeaGreen)}{"      ".Pastel(Color.SteelBlue)}{" ### #     ".Pastel(Color.LightSkyBlue)}{" ######  ###### #    #   #    #### ".Pastel(Color.MediumVioletRed)} {@"       |".Pastel(Color.DimGray)}{"|__|".Pastel(Color.SteelBlue)}    {"|_".Pastel(Color.DimGray)}{"|__|".Pastel(Color.SteelBlue)}\n");
            Console.WriteLine($"{"############################################################################################################".Pastel(Color.DarkGoldenrod)}");
            Console.WriteLine($"{"############################################################################################################".Pastel(Color.DarkGoldenrod)}");
        }

        static char PressAnyKey(string prompt)
        {
            Console.WriteLine(prompt);
            var keyPressed = Console.ReadKey().KeyChar;
            return keyPressed;
        }

        static void Main(string[] args)
        {
            var keepGoing = true;

            Console.Clear();
            DisplayGreeting();

            var newBand = new Band();

            while (keepGoing && !newBand.BandExists)
            {
                Console.Write("\nWhat do you want to do?\n(C)reate Band\n(V)iew band\n(L)ist all Bands\n(R)emove Band\n(S)igned Bands\n(U)nsigned Bands\n(Q)uit\n: ");
                var choices = Console.ReadLine().ToUpper();

                switch (choices)
                {
                    case "C":
                        // Console.Clear();
                        newBand.CreateBand();
                        PressAnyKey("\nPress Any Key to Continue! ");
                        keepGoing = false;
                        break;
                    case "V":
                        // Console.Clear();
                        PressAnyKey("\nPress Any Key to Continue! ");
                        keepGoing = false;
                        break;
                    case "L":
                        // Console.Clear();
                        PressAnyKey("\nPress Any Key to Continue! ");
                        keepGoing = false;
                        break;
                    case "R":
                        // Console.Clear();
                        PressAnyKey("\nPress Any Key to Continue! ");
                        keepGoing = false;
                        break;
                    case "S":
                        // Console.Clear();
                        PressAnyKey("\nPress Any Key to Continue! ");
                        keepGoing = false;
                        break;
                    case "U":
                        // Console.Clear();
                        PressAnyKey("\nPress Any Key to Continue! ");
                        keepGoing = false;
                        break;
                    case "Q":
                        // Console.Clear();
                        // DisplayExit();
                        Environment.Exit(0);
                        keepGoing = false;
                        break;
                    default:
                        Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                        PressAnyKey("\nPress Any Key to Continue! ");
                        Console.Clear();
                        DisplayGreeting();
                        break;
                }

            }

            var keepPrompting = true;

            Console.Clear();
            DisplayGreeting();

            while (keepPrompting)
            {
                Console.Write("\nWhat do you want to do?\n(V)iew all Albums\n(N)ew Album\n(E)dit Album\n(R)esign Band\n(L)ist Albums by Release Date\n(M)ain Menu\n(Q)uit\n: ");
                var choices = Console.ReadLine().ToUpper();

                switch (choices)
                {
                    case "V":
                        // Console.Clear();
                        PressAnyKey("\nPress Any Key to Continue! ");
                        keepGoing = false;
                        break;
                    case "N":
                        // Console.Clear();
                        PressAnyKey("\nPress Any Key to Continue! ");
                        keepGoing = false;
                        break;
                    case "E":
                        // Console.Clear();
                        PressAnyKey("\nPress Any Key to Continue! ");
                        keepGoing = false;
                        break;
                    case "R":
                        // Console.Clear();
                        PressAnyKey("\nPress Any Key to Continue! ");
                        keepGoing = false;
                        break;
                    case "L":
                        // Console.Clear();
                        PressAnyKey("\nPress Any Key to Continue! ");
                        keepGoing = false;
                        break;
                    case "M":
                        // Console.Clear();
                        PressAnyKey("\nPress Any Key to Continue! ");
                        keepGoing = false;
                        break;
                    case "Q":
                        Console.Clear();
                        // DisplayExit();
                        Environment.Exit(0);
                        keepGoing = false;
                        break;
                    default:
                        Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                        PressAnyKey("\nPress Any Key to Continue! ");
                        Console.Clear();
                        DisplayGreeting();
                        break;
                }

            }

        }
    }
}
