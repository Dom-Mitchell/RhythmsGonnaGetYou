using System;
using System.Drawing;
using Pastel;

namespace RhythmsGonnaGetYou
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hippo from https://www.asciiart.eu/animals/other-land
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
    }
}
