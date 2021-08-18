using System;
using System.Drawing;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pastel;
using RhythmsGonnaGetYou.bin;

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
            var newAlbum = new Albums();
            var newSong = new Songs();
            var context = new RecordLabelContext();

            var keepGoing = true;

            Console.Clear();
            DisplayGreeting();

            Console.WriteLine("\nWhat is your name?");
            var name = Console.ReadLine();
            Console.WriteLine($"\nHope you are doing well today, {name}!");
            PressAnyKey("\nPress Any Key to Continue! ");

            
            bool mangagerView = MainMenu(newBand, context, ref keepGoing, name);

            ManagerView(context, newBand, newAlbum, newSong, mangagerView, name);


        }

        private static bool MainMenu(Bands newBand, RecordLabelContext context, ref bool keepGoing, string name)
        {
            Console.Clear();
            DisplayGreeting();

            // var choices = "";
            var mangagerView = false;

            while (keepGoing && !mangagerView)
            {
                Console.Write("\nWhat do you want to do?\n(C)reate Band\n(V)iew Bands (Manager View)\n(L)ist all Bands\n(R)emove Band\n(W)elcome Band Back\n(S)igned Bands\n(U)nsigned Bands\n(Q)uit\n: ");
                var choices = Console.ReadLine().ToUpper();

                switch (choices)
                {
                    case "C":
                        // Console.Clear();
                        newBand.CreateBand();
                        PressAnyKey("\nPress Any Key to Continue! ");
                        Console.Clear();
                        DisplayGreeting();
                        // keepGoing = false;
                        break;
                    case "V":
                        // Console.Clear();
                        // newBand.ExistingBand();

                        mangagerView = EditExistingBands(mangagerView, name);

                        PressAnyKey("\nPress Any Key to Continue! ");
                        Console.Clear();
                        DisplayGreeting();
                        // keepGoing = false;
                        break;
                    case "L":
                        // Console.Clear();

                        ListBands(context);

                        PressAnyKey("\nPress Any Key to Continue! ");
                        Console.Clear();
                        DisplayGreeting();
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

            return mangagerView;
        }

        private static void ManagerView(RecordLabelContext context, Bands newBand, Albums newAlbum, Songs newSong, bool mangagerView, string name)
        {
            var promptAgain = true;

            Console.Clear();
            DisplayGreeting();

            while (promptAgain)
            {

                if (mangagerView)
                {

                    Console.Write($"\nWelcome to {"Hop".Pastel(Color.SeaGreen)}{"-".Pastel(Color.Violet)}{"Ip".Pastel(Color.LightSkyBlue)} {"Beats".Pastel(Color.MediumVioletRed)} manager view, {name}!\n\nWhat do you want to do?\n(V)iew all Albums in Band\n(A)dd New Album to Band\n(E)dit Album in Band\n(L)ist Albums by Release Date for Band\n(G)enre Ordered List of Albums\n(M)ain Menu\n(Q)uit\n: ");
                    var choices = Console.ReadLine().ToUpper();

                    switch (choices)
                    {
                        case "V":
                            // Console.Clear();

                            AlbumsList(context, newBand);

                            PressAnyKey("\nPress Any Key to Continue! ");
                            Console.Clear();
                            DisplayGreeting();
                            // keepGoing = false;
                            break;
                        case "A":
                            // Console.Clear();

                            newAlbum.CreateAlbum();

                            PressAnyKey("\nPress Any Key to Continue! ");
                            Console.Clear();
                            DisplayGreeting();
                            // keepGoing = false;
                            break;
                        case "E":
                            // Console.Clear();

                            newSong.CreateSong();

                            PressAnyKey("\nPress Any Key to Continue! ");
                            Console.Clear();
                            DisplayGreeting();
                            // keepGoing = false;
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

                            ReleaseOrder(context, newBand);

                            PressAnyKey("\nPress Any Key to Continue! ");
                            Console.Clear();
                            DisplayGreeting();
                            // keepGoing = false;
                            break;
                        case "G":

                            GenreOrder(context, newBand);

                            PressAnyKey("\nPress Any Key to Continue! ");
                            Console.Clear();
                            DisplayGreeting();
                            break;
                        case "M":
                            // Console.Clear();
                            PressAnyKey("\nPress Any Key to Continue! ");
                            // keepGoing = false;
                            break;
                        case "Q":
                            Console.Clear();
                            // DisplayExit();
                            Environment.Exit(0);
                            // keepGoing = false;
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

        private static bool EditExistingBands(bool mangagerView, string name)
        {
            var correctAnswer = false;
            var correctChoice = "";
            while (!correctAnswer)
            {
                Console.WriteLine($"\nAre you sure you want to go into {"Hop".Pastel(Color.SeaGreen)}{"-".Pastel(Color.Violet)}{"Ip".Pastel(Color.LightSkyBlue)} {"Beats".Pastel(Color.MediumVioletRed)} mangager view, {name}? (Yes/No)");
                correctChoice = Console.ReadLine().ToUpper();

                if (correctChoice == "Y" || correctChoice == "YES")
                {
                    mangagerView = true;
                    break;
                }
                else if (correctChoice == "N" || correctChoice == "NO")
                {
                    mangagerView = false;
                    break;
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"Your choice must be".Pastel(Color.Red)} {"Yes".Pastel(Color.Yellow)} {"or".Pastel(Color.Red)} {"No".Pastel(Color.Yellow)}{"!".Pastel(Color.Red)}");
                }

            }

            return mangagerView;
        }

        private static void AlbumsList(RecordLabelContext context, Bands newBand)
        {
            var userTypedName = false;
            //  usersBand = "";
            while (!userTypedName)
            {
                Console.WriteLine($"\nWhich band's albums would you like to view?");
                var usersBand = Console.ReadLine();

                var bandExists = context.Bands.Any(band => band.Name == usersBand);
                if (bandExists)
                {
                    newBand = context.Bands.FirstOrDefault(band => band.Name == usersBand);
                    // newAlbum =

                    Console.WriteLine($"\n{$"{newBand.Name}'s".Pastel(Color.Yellow)} Albums:\n");
                    foreach (var album in context.Albums.Include(album => album.Band).Where(album => album.Band == newBand).OrderBy(album => album.Title))
                    {
                        // album.Description();
                        // Console.WriteLine();
                        Console.WriteLine($"{newBand.Name} has an album named {album.Title}");
                        // Console.WriteLine($"Album Title: {Title}, Genre: {Genre}, Explicit: {IsExplicit.ToString().ToUpper()}, Release Date: {ReleaseDate.ToString("d")}");
                    }

                    break;
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"You must select a band!".Pastel(Color.Red)}");
                }

            }
        }

        private static void GenreOrder(RecordLabelContext context, Bands newBand)
        {
            var userTypedName = false;
            //  usersBand = "";
            while (!userTypedName)
            {
                Console.WriteLine($"\nWhich genre would you like to view?");
                var usersStyle = Console.ReadLine();

                var styleExists = context.Bands.Any(band => band.Style == usersStyle);
                if (styleExists)
                {
                    newBand = context.Bands.FirstOrDefault(band => band.Style == usersStyle);
                    // newAlbum =

                    Console.WriteLine($"\n{"Hop".Pastel(Color.SeaGreen)}{"-".Pastel(Color.Violet)}{"Ip".Pastel(Color.LightSkyBlue)} {"Beats".Pastel(Color.MediumVioletRed)} {usersStyle} Albums:\n");
                    foreach (var album in context.Albums.Include(album => album.Band).Where(album => album.Band == newBand))
                    {
                        // album.Description();
                        // Console.WriteLine();
                        Console.WriteLine($"{newBand.Name} has an album named {album.Title}");
                        // Console.WriteLine($"Album Title: {Title}, Genre: {Genre}, Explicit: {IsExplicit.ToString().ToUpper()}, Release Date: {ReleaseDate.ToString("d")}");
                    }

                    break;
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"You must select a band!".Pastel(Color.Red)}");
                }

            }
        }

        private static void ReleaseOrder(RecordLabelContext context, Bands newBand)
        {
            var userTypedName = false;
            //  usersBand = "";
            while (!userTypedName)
            {
                Console.WriteLine($"\nWhich band's albums would you like to view?");
                var usersBand = Console.ReadLine();

                var bandExists = context.Bands.Any(band => band.Name == usersBand);
                if (bandExists)
                {
                    newBand = context.Bands.FirstOrDefault(band => band.Name == usersBand);
                    // newAlbum =

                    Console.WriteLine($"\n{$"{newBand.Name}'s".Pastel(Color.Yellow)} Albums Listed in Release Order:\n");
                    foreach (var album in context.Albums.Include(album => album.Band).Where(album => album.Band == newBand).OrderBy(album => album.ReleaseDate))
                    {
                        // album.Description();
                        // Console.WriteLine();
                        Console.WriteLine($"{newBand.Name} has an album named {album.Title} that was released on {album.ReleaseDate.ToLongDateString()}");
                        // Console.WriteLine($"Album Title: {Title}, Genre: {Genre}, Explicit: {IsExplicit.ToString().ToUpper()}, Release Date: {ReleaseDate.ToString("d")}");
                    }

                    break;
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"You must select a band!".Pastel(Color.Red)}");
                }

            }
        }

        private static void ReAddBand(RecordLabelContext context)
        {
            var userTypedName = false;
            var usersBand = "";
            while (!userTypedName)
            {
                Console.WriteLine($"\nWhat band would you like to welcome back?\nNote: This means {"Hop".Pastel(Color.SeaGreen)}{"-".Pastel(Color.Violet)}{"Ip".Pastel(Color.LightSkyBlue)} {"Beats".Pastel(Color.MediumVioletRed)} will support the selected band again!");
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
            Console.WriteLine($"\nBands not signed by {"Hop".Pastel(Color.SeaGreen)}{"-".Pastel(Color.Violet)}{"Ip".Pastel(Color.LightSkyBlue)} {"Beats".Pastel(Color.MediumVioletRed)}: \n");

            foreach (var band in unsignedBands)
            {
                Console.WriteLine($"{band.Name} is an unsigned band");
            }
        }

        private static void SignedBands(RecordLabelContext context)
        {
            var signedBands = context.Bands.Where(band => band.IsSigned == true);
            Console.WriteLine($"\nBands signed by {"Hop".Pastel(Color.SeaGreen)}{"-".Pastel(Color.Violet)}{"Ip".Pastel(Color.LightSkyBlue)} {"Beats".Pastel(Color.MediumVioletRed)}: \n");

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
                Console.WriteLine($"\nWhat band would you like to let go?\nNote: This means {"Hop".Pastel(Color.SeaGreen)}{"-".Pastel(Color.Violet)}{"Ip".Pastel(Color.LightSkyBlue)} {"Beats".Pastel(Color.MediumVioletRed)} will no longer support the selected band!");
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
            Console.WriteLine($"\nBands Signed by {"Hop".Pastel(Color.SeaGreen)}{"-".Pastel(Color.Violet)}{"Ip".Pastel(Color.LightSkyBlue)} {"Beats".Pastel(Color.MediumVioletRed)}:\n");
            var signedBands = context.Bands.Where(band => band.IsSigned == true);
            // var bandNames = context.Bands;

            foreach (var band in signedBands)
            {
                Console.WriteLine($"There is a band named {band.Name}");
            }

            Console.WriteLine($"\nBands not currently signed by {"Hop".Pastel(Color.SeaGreen)}{"-".Pastel(Color.Violet)}{"Ip".Pastel(Color.LightSkyBlue)} {"Beats".Pastel(Color.MediumVioletRed)}:\n");
            var unsignedBands = context.Bands.Where(band => band.IsSigned == false);

            foreach (var band in unsignedBands)
            {
                Console.WriteLine($"There is a band named {band.Name}");
            }
        }
    }
}


