using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Pastel;

namespace RhythmsGonnaGetYou.bin
{
    public class Albums
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsExplicit { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int BandId { get; set; }

        public Bands Band { get; set; }
        public List<Songs> Songs { get; set; }

        private RecordLabelContext context = new RecordLabelContext();

        public void CreateAlbum()
        {
            var newAlbum = new Albums();
            var newBand = new Bands();

            var userTypedAlbum = false;
            var usersAlbum = "";
            while (!userTypedAlbum)
            {
                Console.WriteLine("\nWhat is the album's name?");
                usersAlbum = Console.ReadLine();

                if (usersAlbum != "")
                {
                    if (context.Albums.Any(album => album.Title == usersAlbum))
                    {
                        Console.WriteLine($"{"That album name is taken. Please Try again!".Pastel(Color.Yellow)}");
                        continue;
                    }
                    newAlbum.Title = usersAlbum;
                    break;
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"You must have an album name!".Pastel(Color.Red)}");
                }
            }

            var correctAnswer = false;
            var isExplicit = "";
            while (!correctAnswer)
            {
                Console.WriteLine($"\nIs {newAlbum.Title} explicit? (Yes/No)");
                isExplicit = Console.ReadLine().ToUpper();

                if (isExplicit == "Y" || isExplicit == "YES")
                {
                    newAlbum.IsExplicit = true;
                    break;
                }
                else if (isExplicit == "N" || isExplicit == "NO")
                {
                    newAlbum.IsExplicit = false;
                    break;
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"Your choice must be".Pastel(Color.Red)} {"Yes".Pastel(Color.Yellow)} {"or".Pastel(Color.Red)} {"No".Pastel(Color.Yellow)}{"!".Pastel(Color.Red)}");
                }
            }

            var correctDate = false;
            var releaseDate = "";
            while (!correctDate)
            {
                Console.WriteLine($"\nWhen did {newAlbum.Title} come out?\nWas is today? (Yes/No) ");
                releaseDate = Console.ReadLine().ToUpper();

                if (releaseDate == "Y" || releaseDate == "YES")
                {
                    newAlbum.ReleaseDate = DateTime.Now;
                    Console.WriteLine($"\n{newAlbum.Title} was released on {newAlbum.ReleaseDate.ToLongDateString()}");
                    break;
                }
                else if (releaseDate == "N" || releaseDate == "NO")
                {

                    Console.WriteLine($"\nWhen did {newAlbum.Title} come out? Ex.(01/01/2000) ");
                    // var newReleaseDate = DateTime.Parse(Console.ReadLine());

                    // var formattedDate = newReleaseDate;


                    var newReleaseDate = default(DateTime);
                    var isThisGoodInput = DateTime.TryParse(Console.ReadLine(), out newReleaseDate);

                    if (isThisGoodInput)
                    {
                        newAlbum.ReleaseDate = newReleaseDate;
                        Console.WriteLine($"\n{newAlbum.Title} was released on {newAlbum.ReleaseDate.ToLongDateString()}");
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
                Console.WriteLine($"\nWhich band is {newAlbum.Title} album for? ");
                usersBand = Console.ReadLine();

                if (usersBand != "")
                {
                    if (context.Bands.FirstOrDefault(band => band.Name == usersBand) != null)
                    {
                        newBand = context.Bands.FirstOrDefault(band => band.Name == usersBand);
                        Console.WriteLine($"\n{newAlbum.Title} assigned to {newBand.Name}");
                        newAlbum.BandId = newBand.Id;
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

            // context.Albums.Add(newAlbum);
            context.SaveChanges();


        }

    }
}