using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Pastel;

namespace RhythmsGonnaGetYou
{
    public class Bands
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Website { get; set; }
        public string Style { get; set; }
        public bool IsSigned { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }

        private RecordLabelContext context = new RecordLabelContext();
        public Bands newBand = new Bands();

        // public Band SingularBand = new Band();
        public bool BandExists = false;

        public void CreateBand()
        {


            // Country list from https://github.com/Domanator13/RhythmsGonnaGetYou/blob/trunk/COUNTRIES.md
            var countries = new List<string>() { "Afghanistan", "Albania", "Algeria", "Andorra", "Angola", "Antigua and Barbuda", "Argentina", "Armenia", "Australia", "Austria", "Azerbaijan",
            "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bhutan", "Bolivia", "Bosnia and Herzegovina", "Botswana", "Brazil", "Brunei", "Bulgaria",
            "Burkina Faso", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Central African Republic", "Chad", "Chile", "China", "Colombia", "Comoros", "Costa Rica", "Croatia",
            "Cuba", "Cyprus", "Czech Republic", "Democratic Republic of the Congo", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "East Timor", "Ecuador", "Egypt", "El Salvador",
            "Equatorial Guinea", "Eritrea", "Estonia", "Eswatini", "Ethiopia", "Federated States of Micronesia", "Fiji", "Finland", "France", "Gabon", "Georgia", "Germany", "Ghana", "Greece",
            "Grenada", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Honduras", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Israel", "Italy",
            "Ivory Coast", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Kosovo", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya",
            "Liechtenstein", "Lithuania", "Luxembourg", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Mauritania", "Mauritius", "Mexico", "Moldova",
            "Monaco", "Mongolia", "Montenegro", "Morocco", "Mozambique", "Myanmar", "Namibia", "Nauru", "Nepal", "Netherlands", "New Zealand", "Nicaragua", "Niger", "Nigeria", "North Korea",
            "North Macedonia", "Norway", "Oman", "Pakistan", "Palau", "Panama", "Papa New Guinea", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Qatar", "Republic of Congo", "Romania",
            "Russia", "Rwanda", "Saint Kitts and Nevis", "Saint Lucia", "Saint Vincent and the Grenadines", "Samoa", "San Marino", "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Serbia",
            "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South Korea", "South Sudan", "Spain", "Sri Lanka", "State of Palestine",
            "Sudan", "Suriname", "Swedan", "Switzerland", "Syria", "Tajikistan", "Tanzania", "Thailand", "The Bahamas", "The Gambia", "Togo", "Tonga", "Trinidad and Tobago", "Tunisia", "Turkey",
            "Turkmenistan", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "United States", "Uruguay", "Uzbekistan", "Vanuatu", "Vatican City", "Venezuela", "Vietnam",
            "Yemen", "Zambia", "Zimbabwe" };

            // Genre list from https://github.com/Domanator13/RhythmsGonnaGetYou/blob/trunk/MUSICALGENRES.md
            var musicGenres = new List<string>() {"Acoustic", "Blues", "Classical", "Country", "Dance", "Easy Listening", "EDM", "Electronic Dance Music", "Folk", "Hip-hop", "Jazz", "Latin",
            "Metal", "New Age", "Pop", "R & B", "Rap", "Rock", "Traditional Folk", "World"};

            var userTypedName = false;
            var usersBand = "";
            while (!userTypedName)
            {
                Console.WriteLine("\nWhat is the band's name?");
                usersBand = Console.ReadLine();

                if (usersBand != "")
                {
                    if (context.Bands.Any(user => newBand.Name == usersBand))
                    {
                        Console.WriteLine($"{"That band name is taken. Please Try again!".Pastel(Color.Yellow)}");
                        continue;
                    }
                    newBand.Name = usersBand;
                    break;
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"You must have a band name!".Pastel(Color.Red)}");
                }
            }

            var realCountry = false;
            var country = "";
            while (!realCountry)
            {
                Console.WriteLine($"\nWhat country is {newBand.Name} from?");
                country = Console.ReadLine();

                if (countries.Contains(country))
                {
                    newBand.CountryOfOrigin = country;
                    Console.WriteLine($"{$"Your county, {newBand.CountryOfOrigin}, is a real country!".Pastel(Color.LimeGreen)}");
                    break;
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"We currently support".Pastel(Color.Red)} {$"{countries.Count()}".Pastel(Color.LimeGreen)} {"different countries!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"Please see".Pastel(Color.Red)} {"https://github.com/Domanator13/RhythmsGonnaGetYou/blob/trunk/COUNTRIES.md".Pastel(Color.FromArgb(51, 102, 187))}{" for a list of supported countries!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"Press".Pastel(Color.Red)} {"Ctrl".Pastel(Color.Yellow)} {"and".Pastel(Color.Red)} {"Click".Pastel(Color.Yellow)} {"the above link to view the website!".Pastel(Color.Red)}");
                }
            }

            var correctWebsiteFormat = false;
            var usersWebsite = "";
            while (!correctWebsiteFormat)
            {
                Console.WriteLine($"\nWhat is {newBand.Name}'s website?");
                usersWebsite = Console.ReadLine();

                if (usersWebsite.Contains(".com") && !usersWebsite.Contains(" ") && usersWebsite.Length > 4)
                {
                    newBand.Website = usersWebsite;
                    break;
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"Your website must contain a".Pastel(Color.Red)} {".com".Pastel(Color.Yellow)} {"ending!".Pastel(Color.Red)}");
                }
            }

            var realGenre = false;
            var genre = "";
            while (!realGenre)
            {
                Console.WriteLine($"\nWhat style of music does {newBand.Name} do?");
                genre = Console.ReadLine();

                if (musicGenres.Contains(genre))
                {
                    newBand.Style = genre;
                    Console.WriteLine($"{$"Your style, {newBand.Style}, is a real style of music!".Pastel(Color.LimeGreen)}");
                    break;
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"We currently support".Pastel(Color.Red)} {$"{musicGenres.Count()}".Pastel(Color.LimeGreen)} {"different styles!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"Please see".Pastel(Color.Red)} {"https://github.com/Domanator13/RhythmsGonnaGetYou/blob/trunk/MUSICALGENRES.md".Pastel(Color.FromArgb(51, 102, 187))}{" for a list of supported countries!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"Press".Pastel(Color.Red)} {"Ctrl".Pastel(Color.Yellow)} {"and".Pastel(Color.Red)} {"Click".Pastel(Color.Yellow)} {"the above link to view the website!".Pastel(Color.Red)}");
                }

            }

            var correctAnswer = false;
            var signed = "";
            while (!correctAnswer)
            {
                Console.WriteLine($"\nIs {newBand.Name} signed? (Yes/No)");
                signed = Console.ReadLine().ToUpper();

                if (signed == "Y" || signed == "YES")
                {
                    newBand.IsSigned = true;
                    break;
                }
                else if (signed == "N" || signed == "NO")
                {
                    newBand.IsSigned = false;
                    break;
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"Your choice must be".Pastel(Color.Red)} {"Yes".Pastel(Color.Yellow)} {"or".Pastel(Color.Red)} {"No".Pastel(Color.Yellow)}{"!".Pastel(Color.Red)}");
                }
            }

            Console.WriteLine($"\nWho is the contact for {newBand.Name}?");
            newBand.ContactName = Console.ReadLine();

            var correctPhoneLength = false;
            var phoneNumber = "";
            while (!correctPhoneLength)
            {
                Console.WriteLine($"\nWhat is {newBand.ContactName}'s phone number? Ex.[(123)-456-7890]");
                phoneNumber = Console.ReadLine();

                // StringBuilder formattedPhoneNumber = new StringBuilder();
                // while (true)
                // {
                //     var keyPressed = Console.ReadKey(true);

                //     if (keyPressed.Key == ConsoleKey.Enter)
                //     {
                //         break;
                //     }
                //     if (keyPressed.Key == ConsoleKey.Backspace)
                //     {
                //         if (formattedPhoneNumber.Length > 0)
                //         {
                //             Console.Write("\b \b");
                //             formattedPhoneNumber.Length--;
                //         }
                //         continue;
                //     }
                //     Console.Write($"{keyPressed.KeyChar}");
                //     formattedPhoneNumber.Append(keyPressed.KeyChar);
                // }
                // phoneNumber += formattedPhoneNumber;

                // var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out phoneNumber);

                if (phoneNumber.Length == 10)
                {
                    var isThisGoodInput = phoneNumber.Any(x => !char.IsLetter(x));
                    if (isThisGoodInput)
                    {
                        var formattedPhoneNumber = String.Format("{0:+1(###)-###-####}", Int64.Parse(phoneNumber));
                        newBand.ContactPhoneNumber = formattedPhoneNumber;

                        Console.WriteLine(formattedPhoneNumber);
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{"\nIncorrect phone number. Please try again!".Pastel(Color.Red)}");
                        Console.WriteLine($"{"Your choice must 10 numbers long".Pastel(Color.Red)}");
                    }
                }
                else
                {
                    Console.WriteLine($"{"\nIncorrect phone number. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"Your choice must 10 characters long".Pastel(Color.Red)}");
                }
                context.Bands.Add(newBand);
                context.SaveChanges();
            }

            // SingularBand.Name =

        }

        public void ExistingBand()
        {
            // var context = new RecordLabelContext();
            var existingUserBand = "";

            Console.WriteLine("\nPlease enter your band name ");
            existingUserBand = Console.ReadLine();

            while (!BandExists)
            {
                if (context.Bands.Any(user => newBand.Name == existingUserBand))
                {
                    Console.Write($"{"Band found!".Pastel(Color.LimeGreen)}\n");
                    break;
                }
                else
                {
                    Console.WriteLine($"{"Incorrect band name. Please try again!".Pastel(Color.Red)}");
                }
            }
            BandExists = true;

        }

    }
}