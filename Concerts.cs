using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Pastel;
using RhythmsGonnaGetYou.bin;

namespace RhythmsGonnaGetYou
{
    public class Concerts
    {
        public int Id { get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }
        public int BandId { get; set; }

        public Bands Band { get; set; }

        private RecordLabelContext context = new RecordLabelContext();

        public void CreateConcert()
        {
            var newBand = new Bands();
            var newConcert = new Concerts();

            var userTypedPlace = false;
            var usersPlace = "";
            while (!userTypedPlace)
            {
                Console.WriteLine("\nWhere is the concert going to be held at?");
                usersPlace = Console.ReadLine();

                if (usersPlace != "")
                {
                    newConcert.Place = usersPlace;
                    break;
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"You must have a place to hold the concert!".Pastel(Color.Red)}");
                }
            }

            var correctDate = false;
            var releaseDate = "";
            while (!correctDate)
            {
                Console.WriteLine($"\nWhen will the concert be?\nIs it today? (Yes/No) ");
                releaseDate = Console.ReadLine().ToUpper();

                if (releaseDate == "Y" || releaseDate == "YES")
                {
                    newConcert.Date = DateTime.Now;
                    Console.WriteLine($"\nThe concert is on {newConcert.Date.ToLongDateString()}");
                    break;
                }
                else if (releaseDate == "N" || releaseDate == "NO")
                {

                    Console.WriteLine($"\nWhen is the concert? Ex.(01/01/2000) ");
                    // var newReleaseDate = DateTime.Parse(Console.ReadLine());

                    // var formattedDate = newReleaseDate;


                    var newReleaseDate = default(DateTime);
                    var isThisGoodInput = DateTime.TryParse(Console.ReadLine(), out newReleaseDate);

                    if (isThisGoodInput)
                    {
                        newConcert.Date = newReleaseDate;
                        Console.WriteLine($"\nThe concert is on {newConcert.Date.ToLongDateString()}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                        Console.WriteLine($"{"Your choice must be a valid Date".Pastel(Color.Red)}");
                    }
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"Your choice must be".Pastel(Color.Red)} {"Yes".Pastel(Color.Yellow)} {"or".Pastel(Color.Red)} {"No".Pastel(Color.Yellow)}{"!".Pastel(Color.Red)}");
                }
            }

            var userTypedName = false;
            var usersBand = "";
            while (!userTypedName)
            {
                Console.WriteLine($"\nWhich band is performing? ");
                usersBand = Console.ReadLine();

                if (usersBand != "")
                {
                    if (context.Bands.FirstOrDefault(band => band.Name == usersBand) != null)
                    {
                        newBand = context.Bands.FirstOrDefault(band => band.Name == usersBand);
                        Console.WriteLine($"\n{newBand.Name} has a concert on {newConcert.Date}");
                        newConcert.BandId = newBand.Id;
                        // newAlbum.Genre = newBand.Style;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                        Console.WriteLine($"{"You must have an existing band name!".Pastel(Color.Red)}");
                    }
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"You must have a band name!".Pastel(Color.Red)}");
                }
            }

            context.Concerts.Add(newConcert);
            context.SaveChanges();

        }
    }
}
