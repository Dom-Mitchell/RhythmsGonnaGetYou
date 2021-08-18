using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Pastel;
using RhythmsGonnaGetYou.bin;

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

            var instruments = new List<string>() { "Drums", "Electric Guitar", "Bass Guitar", "Keyboard", "Double Bass", "Piano", "Clarinet", "Trumpet", "Violin", "Saxophone", "Flute", "Trombone", "Acoustic Guitar", "Tuba", "French Horn", "Euphonium", "Cowbell", "Oboe", "Harmonica", "Synthesizer", "Triangle", "Organ", "Bassoon", "Bass Clarinet", "Ukulele", "Percussion", "Xylophone", "Bagpipes", "Cello", "Vocalist", "Baritone Sax", "Timpani", "Accordion", "Viola", "Turntables", "Snare Drums", "Guitar", "Bongos", "Sarangi", "Piccolo", "Recorder", "Banjo", "Soprano Saxophone", "Congas", "Baritone" };

            var userTypedName = false;
            var usersBand = "";
            while (!userTypedName)
            {
                Console.WriteLine("\nWhat is the musician's name?");
                usersBand = Console.ReadLine();

                if (usersBand != "")
                {
                    newMusician.Name = usersBand;
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
                    Console.WriteLine($"{newMusician.Name} Is {newMusician.Age} years old!");
                    newMusician.Age = usersAge;
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
                // var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out usersAge);
                usersInstrument = Console.ReadLine();

                if (instruments.Contains(usersInstrument))
                {
                    newMusician.Instrument = usersInstrument;
                    if (usersInstrument == "Vocalist")
                    {
                        Console.WriteLine($"{newMusician.Name} is a {newMusician.Instrument}");
                    }
                    else
                    {
                        Console.WriteLine($"{newMusician.Name} uses the {newMusician.Instrument}");
                    }
                    break;
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"We currently support".Pastel(Color.Red)} {$"{instruments.Count()}".Pastel(Color.LimeGreen)} {"different instruments!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"Please see".Pastel(Color.Red)} {"https://github.com/Domanator13/RhythmsGonnaGetYou/blob/trunk/COUNTRIES.md".Pastel(Color.FromArgb(51, 102, 187))}{" for a list of supported instruments!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"Press".Pastel(Color.Red)} {"Ctrl".Pastel(Color.Yellow)} {"and".Pastel(Color.Red)} {"Click".Pastel(Color.Yellow)} {"the above link to view the website!".Pastel(Color.Red)}");
                }
            }


        }
    }
}
