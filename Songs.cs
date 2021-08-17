using System;
using System.Drawing;
using System.Linq;
using Pastel;
using RhythmsGonnaGetYou.bin;

namespace RhythmsGonnaGetYou
{
    public class Songs
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public int TrackNumber { get; set; }
        public int AlbumId { get; set; }

        public Albums Album { get; set; }

        private RecordLabelContext context = new RecordLabelContext();

        public void CreateSong()
        {
            var newAlbum = new Albums();
            // var newBand = new Bands();
            var newSong = new Songs();

            var userTypedSong = false;
            var usersSong = "";
            while (!userTypedSong)
            {
                Console.WriteLine("\nWhat is the song's name?");
                usersSong = Console.ReadLine();

                if (usersSong != "")
                {
                    if (context.Songs.Any(song => song.Title == usersSong))
                    {
                        Console.WriteLine($"\n{"That album name is taken. Please Try again!".Pastel(Color.Yellow)}");
                        continue;
                    }
                    newSong.Title = usersSong;
                    break;
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"You must have a song name!".Pastel(Color.Red)}");
                }

            }

            var correctDuration = false;
            var duration = "";
            while (!correctDuration)
            {
                Console.WriteLine($"\nHow long is {newSong.Title}? Ex.(10:30)");
                duration = Console.ReadLine();

                if (duration != "" && duration.Length <= 5 && duration.Contains(":"))
                {
                    var isThisGoodInput = duration.Any(x => !char.IsLetter(x));
                    if (isThisGoodInput)
                    {
                        newSong.Duration = TimeSpan.Parse(duration);
                        Console.WriteLine($"\n{newSong.Title} is {newSong.Duration} long");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                        Console.WriteLine($"{"Your song must have a duration!".Pastel(Color.Red)}");
                    }
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"Your song must have a duration and must be formatted as such (##:##)!".Pastel(Color.Red)}");
                }
            }

            var correctTrack = false;
            var trackNum = 0;
            while (!correctTrack)
            {
                Console.WriteLine($"\nWhat is the track number for {newSong.Title}? Ex.(10)");
                // trackNum = Console.ReadLine();

                var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out trackNum);
                if (isThisGoodInput && trackNum <= 10)
                {
                    newSong.TrackNumber = trackNum;
                    Console.WriteLine($"\n{newSong.Title} has the track number {newSong.TrackNumber}");
                    break;
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"Your song must have a track number of 10 or less!".Pastel(Color.Red)}");
                }
            }

            var userTypedName = false;
            var usersAlbum = "";
            while (!userTypedName)
            {
                Console.WriteLine($"\nWhich album is {newSong.Title} for? ");
                usersAlbum = Console.ReadLine();

                if (usersAlbum != "")
                {
                    if (context.Albums.FirstOrDefault(album => album.Title == usersAlbum) != null)
                    {
                        newAlbum = context.Albums.FirstOrDefault(album => album.Title == usersAlbum);
                        Console.WriteLine($"\n{newSong.Title} assigned to {newAlbum.Title}");
                        newSong.AlbumId = newAlbum.Id;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                        Console.WriteLine($"{"You must have an existing album name!".Pastel(Color.Red)}");
                    }
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"You must have a album name!".Pastel(Color.Red)}");
                }
            }

            // context.Songs.Add(newSong);
            context.SaveChanges();




        }



    }
}