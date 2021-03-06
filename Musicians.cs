using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Pastel;

namespace RhythmsGonnaGetYou
{
    public class Musicians
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Instrument { get; set; }
        public bool CurrentMember { get; set; }
        public int BandId { get; set; }

        public Bands Band { get; set; }

        private RecordLabelContext context = new RecordLabelContext();

        public void CreateMusician()
        {
            var newBand = new Bands();
            var newMusician = new Musicians();

            // Instrument list from https://github.com/Domanator13/RhythmsGonnaGetYou/blob/trunk/INSTRUMENTS.md
            var instruments = new List<string>() { "Accordion", "Acoustic Guitar", "Bagpipes", "Banjo", "Baritone Sax", "Baritone",
            "Bass Clarinet", "Bass Guitar", "Bassoon", "Bongos", "Cello", "Clarinet", "Congas", "Cowbell", "Double Bass", "Drums",
            "Electric Guitar", "Euphonium", "Flute", "French Horn", "Guitar", "Harmonica", "Keyboard", "Oboe", "Organ", "Percussion",
            "Piano", "Piccolo", "Recorder", "Sarangi", "Saxophone", "Snare Drums", "Soprano Saxophone", "Synthesizer", "Timpani",
            "Triangle", "Trombone", "Trumpet", "Tuba", "Turntables", "Ukulele", "Viola", "Violin", "Vocalist", "Xylophone" };

            var userTypedName = false;
            var usersMusician = "";
            while (!userTypedName)
            {
                Console.WriteLine("\nWhat is the musician's name?");
                usersMusician = Console.ReadLine();

                if (usersMusician != "")
                {
                    newMusician.Name = usersMusician;
                    break;
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"You must have a name!".Pastel(Color.Red)}");
                }
            }

            var userTypedAge = false;
            var usersAge = 0;
            while (!userTypedAge)
            {
                Console.WriteLine($"\nHow old is {newMusician.Name}?");

                var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out usersAge);
                if (isThisGoodInput && usersAge >= 18)
                {
                    newMusician.Age = usersAge;
                    Console.WriteLine($"\n{newMusician.Name} Is {newMusician.Age} years old!");
                    break;
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"You must have an age of 18 or greater!".Pastel(Color.Red)}");
                }
            }

            var userTypedInstrument = false;
            var usersInstrument = "";
            while (!userTypedInstrument)
            {
                Console.WriteLine($"\nWhat instrument does {newMusician.Name} use?");
                usersInstrument = Console.ReadLine();

                if (instruments.Contains(usersInstrument))
                {
                    newMusician.Instrument = usersInstrument;
                    if (usersInstrument == "Vocalist")
                    {
                        Console.WriteLine($"\n{newMusician.Name} is a {newMusician.Instrument}");
                    }
                    else
                    {
                        Console.WriteLine($"\n{newMusician.Name} plays the {newMusician.Instrument}");
                    }
                    break;
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"We currently support".Pastel(Color.Red)} {$"{instruments.Count()}".Pastel(Color.LimeGreen)} {"different instruments!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"Please see".Pastel(Color.Red)} {"https://github.com/Domanator13/RhythmsGonnaGetYou/blob/trunk/INSTRUMENTS.md".Pastel(Color.FromArgb(51, 102, 187))}{" for a list of supported instruments!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"Press".Pastel(Color.Red)} {"Ctrl".Pastel(Color.Yellow)} {"and".Pastel(Color.Red)} {"Click".Pastel(Color.Yellow)} {"the above link to view the website!".Pastel(Color.Red)}");
                }
            }

            var correctAnswer = false;
            var bandmember = "";
            while (!correctAnswer)
            {
                Console.WriteLine($"\nIs {newMusician.Name} currently a bandmember? (Yes/No)");
                bandmember = Console.ReadLine().ToUpper();

                if (bandmember == "Y" || bandmember == "YES")
                {
                    newMusician.CurrentMember = true;
                    break;
                }
                else if (bandmember == "N" || bandmember == "NO")
                {
                    newMusician.CurrentMember = false;
                    break;
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"Your choice must be".Pastel(Color.Red)} {"Yes".Pastel(Color.Yellow)} {"or".Pastel(Color.Red)} {"No".Pastel(Color.Yellow)}{"!".Pastel(Color.Red)}");
                }
            }

            var userTypedBand = false;
            var usersBand = "";
            while (!userTypedBand)
            {
                Console.WriteLine($"\nWhich band is {newMusician.Name} part of? ");
                usersBand = Console.ReadLine();

                if (usersBand != "")
                {
                    if (context.Bands.FirstOrDefault(band => band.Name == usersBand) != null)
                    {
                        newBand = context.Bands.FirstOrDefault(band => band.Name == usersBand);
                        Console.WriteLine($"\n{newMusician.Name} added to {newBand.Name}");
                        newMusician.BandId = newBand.Id;
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

            context.Musicians.Add(newMusician);
            context.SaveChanges();
        }
    }
}
