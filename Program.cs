using System;
using System.Drawing;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pastel;

namespace RhythmsGonnaGetYou
{
    class Program
    {
        static void DisplayGreeting()
        {
            // Hippo from https://www.asciiart.eu/animals/other-land & Ascii text from https://www.ascii-art-generator.org/
            Console.Clear();
            Console.WriteLine($"{"#     #              ".Pastel(Color.SeaGreen)}{"      ".Pastel(Color.Violet)}{" ###       ".Pastel(Color.LightSkyBlue)}{" ######                            ".Pastel(Color.MediumVioletRed)} {@"      c~~p ,---------.    ".Pastel(Color.SteelBlue)}");
            Console.WriteLine($"{"#     #  ####  ##### ".Pastel(Color.SeaGreen)}{"      ".Pastel(Color.Violet)}{"  #  ##### ".Pastel(Color.LightSkyBlue)}{" #     # ######   ##   #####  #### ".Pastel(Color.MediumVioletRed)} {@" ,---'".Pastel(Color.SteelBlue)}{"oo".Pastel(Color.ForestGreen)}{@"  )           \".Pastel(Color.SteelBlue)}");
            Console.WriteLine($"{"#     # #    # #    #".Pastel(Color.SeaGreen)}{"      ".Pastel(Color.Violet)}{"  #  #    #".Pastel(Color.LightSkyBlue)}{" #     # #       #  #    #   #     ".Pastel(Color.MediumVioletRed)} {@"(".Pastel(Color.SteelBlue)}{" O O".Pastel(Color.DimGray)}{"                  )/ ".Pastel(Color.SteelBlue)}");
            Console.WriteLine($"{"####### #    # #    #".Pastel(Color.SeaGreen)}{" #####".Pastel(Color.Violet)}{"  #  #    #".Pastel(Color.LightSkyBlue)}{" ######  #####  #    #   #    #### ".Pastel(Color.MediumVioletRed)} {@" `".Pastel(Color.SteelBlue)}{"=".Pastel(Color.WhiteSmoke)}{"^".Pastel(Color.LightPink)}{"=".Pastel(Color.WhiteSmoke)}{@"'                 /".Pastel(Color.SteelBlue)}");
            Console.WriteLine($"{"#     # #    # ##### ".Pastel(Color.SeaGreen)}{"      ".Pastel(Color.Violet)}{"  #  ##### ".Pastel(Color.LightSkyBlue)}{" #     # #      ######   #        #".Pastel(Color.MediumVioletRed)} {@"       \    ,     .   /   ".Pastel(Color.SteelBlue)}");
            Console.WriteLine($"{"#     # #    # #     ".Pastel(Color.SeaGreen)}{"      ".Pastel(Color.Violet)}{"  #  #     ".Pastel(Color.LightSkyBlue)}{" #     # #      #    #   #   #    #".Pastel(Color.MediumVioletRed)} {@"       \".Pastel(Color.DimGray)}{@"\".Pastel(Color.SteelBlue)}{@"  |-----'|  /    ".Pastel(Color.SteelBlue)}");
            Console.WriteLine($"{"#     #  ####  #     ".Pastel(Color.SeaGreen)}{"      ".Pastel(Color.Violet)}{" ### #     ".Pastel(Color.LightSkyBlue)}{" ######  ###### #    #   #    #### ".Pastel(Color.MediumVioletRed)} {@"       |".Pastel(Color.DimGray)}{"|__|".Pastel(Color.SteelBlue)}    {"|_".Pastel(Color.DimGray)}{"|__|".Pastel(Color.SteelBlue)}\n");
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
            // RecordLabelContext.Bands = MainMenu();

            var newBand = new Bands();
            var context = new RecordLabelContext();

            var keepGoing = true;

            Console.Clear();
            DisplayGreeting();

            while (keepGoing && !newBand.BandExists)
            {
                Console.Write("\nWhat do you want to do?\n(C)reate Band\n(V)iew band\n(L)ist all Bands\n(R)emove Band\n(W)elcome Band Back\n(S)igned Bands\n(U)nsigned Bands\n(Q)uit\n: ");
                var choices = Console.ReadLine().ToUpper();

                switch (choices)
                {
                    case "C":
                        // Console.Clear();
                        newBand.CreateBand();
                        PressAnyKey("\nPress Any Key to Continue! ");
                        // keepGoing = false;
                        break;
                    case "V":
                        // Console.Clear();
                        newBand.ExistingBand();
                        PressAnyKey("\nPress Any Key to Continue! ");
                        // keepGoing = false;
                        break;
                    case "L":
                        // Console.Clear();

                        ListBands(context);

                        PressAnyKey("\nPress Any Key to Continue! ");
                        // keepGoing = false;
                        break;
                    case "R":
                        // Console.Clear();

                        RemoveBand(context);

                        PressAnyKey("\nPress Any Key to Continue! ");
                        Console.Clear();
                        DisplayGreeting();
                        // keepGoing = false;
                        break;
                    case "W":
                        // Console.Clear();

                        ReAddBand(context);

                        PressAnyKey("\nPress Any Key to Continue! ");
                        Console.Clear();
                        DisplayGreeting();
                        // keepGoing = false;
                        break;
                    case "S":
                        // Console.Clear();

                        SignedBands(context);

                        PressAnyKey("\nPress Any Key to Continue! ");
                        Console.Clear();
                        DisplayGreeting();
                        // keepGoing = false;
                        break;
                    case "U":
                        // Console.Clear();

                        UnsignedBands(context);

                        PressAnyKey("\nPress Any Key to Continue! ");
                        Console.Clear();
                        DisplayGreeting();
                        // keepGoing = false;
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

            var promptAgain = true;

            Console.Clear();
            DisplayGreeting();

            while (promptAgain)
            {

                if (newBand.BandExists)
                {

                    Console.Write($"\nWelcome, {newBand.Name}!\n\nWhat do you want to do?\n(V)iew all Albums\n(N)ew Album\n(E)dit Album\n(L)ist Albums by Release Date\n(M)ain Menu\n(Q)uit\n: ");
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
                        // (R)esign Band
                        // case "R":
                        //     // Console.Clear();

                        //     var correctAnswer = false;
                        //     var signed = "";
                        //     while (!correctAnswer)
                        //     {
                        //         Console.WriteLine($"Are you sure you want to resign {newBand.Name}? ");
                        //         signed = Console.ReadLine().ToUpper();

                        //         if (signed == "Y" || signed == "YES")
                        //         {
                        //             newBand.IsSigned = true;
                        //             Console.WriteLine($"\n{"{usersBand} had been reactivated within the studio!".Pastel(Color.Yellow)}");
                        //             context.SaveChanges();
                        //             break;
                        //         }
                        //         else if (signed == "N" || signed == "NO")
                        //         {
                        //             newBand.IsSigned = false;
                        //             Console.WriteLine($"\n{"{usersBand} had not been resigned to the studio!".Pastel(Color.Yellow)}");
                        //             context.SaveChanges();
                        //             break;
                        //         }
                        //         else
                        //         {
                        //             Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                        //             Console.WriteLine($"{"Your choice must be".Pastel(Color.Red)} {"Yes".Pastel(Color.Yellow)} {"or".Pastel(Color.Red)} {"No".Pastel(Color.Yellow)}{"!".Pastel(Color.Red)}");
                        //         }
                        //     }

                        //     PressAnyKey("\nPress Any Key to Continue! ");
                        //     // keepGoing = false;
                        //     break;
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

        private static void ReAddBand(RecordLabelContext context)
        {
            var userTypedName = false;
            var usersBand = "";
            while (!userTypedName)
            {
                Console.WriteLine("\nWhat band would you like to welcome back? ");
                usersBand = Console.ReadLine();

                var isThisGoodInput = usersBand.Any(x => !char.IsNumber(x));
                if (isThisGoodInput)
                {
                    var bandExists = context.Bands.Any(band => band.Name == usersBand);
                    if (bandExists)
                    {
                        var letGoOfBand = context.Bands.FirstOrDefault(band => band.Name == usersBand);
                        letGoOfBand.IsSigned = true;
                        Console.WriteLine($"\n{$"{usersBand} was welcomed back to the studio!".Pastel(Color.Yellow)}");
                        context.SaveChanges();
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                        Console.WriteLine($"{"Your choice must be an existing band".Pastel(Color.Red)}");
                    }
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"Your choice must be an existing band".Pastel(Color.Red)}");
                }
            }
        }

        private static void UnsignedBands(RecordLabelContext context)
        {
            var unsignedBands = context.Bands.Where(band => band.IsSigned == false);
            Console.WriteLine($"\nUnsigned Bands: \n");

            foreach (var band in unsignedBands)
            {
                Console.WriteLine($"{band.Name} is an unsigned band");
            }
        }

        private static void SignedBands(RecordLabelContext context)
        {
            var signedBands = context.Bands.Where(band => band.IsSigned == true);
            Console.WriteLine($"\nSigned Bands: \n");

            foreach (var band in signedBands)
            {
                Console.WriteLine($"{band.Name} is a signed band");
            }
        }

        private static void RemoveBand(RecordLabelContext context)
        {
            var userTypedName = false;
            var usersBand = "";
            while (!userTypedName)
            {
                Console.WriteLine("\nWhat band would you like to let go? ");
                usersBand = Console.ReadLine();

                var isThisGoodInput = usersBand.Any(x => !char.IsNumber(x));
                if (isThisGoodInput)
                {
                    var bandExists = context.Bands.Any(band => band.Name == usersBand);
                    if (bandExists)
                    {
                        var letGoOfBand = context.Bands.FirstOrDefault(band => band.Name == usersBand);
                        letGoOfBand.IsSigned = false;
                        Console.WriteLine($"\n{$"{usersBand} was removed from studio!".Pastel(Color.Yellow)}");
                        context.SaveChanges();
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                        Console.WriteLine($"{"Your choice must be an existing band".Pastel(Color.Red)}");
                    }
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"Your choice must be an existing band".Pastel(Color.Red)}");
                }
            }
        }

        private static void ListBands(RecordLabelContext context)
        {
            var bandNames = context.Bands;
            Console.WriteLine();

            foreach (var band in bandNames)
            {
                Console.WriteLine($"There is a band named {band.Name}");
            }
        }
    }
}


