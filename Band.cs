using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Pastel;

namespace RhythmsGonnaGetYou
{
    public class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Website { get; set; }
        public string Style { get; set; }
        public bool IsSigned { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }

        public bool BandExists = false;

        public void CreateBand()
        {
            var context = new RecordLabelContext();
            var newBand = new Band();

            var correctAnswer = false;
            var realCountry = false;
            var correctPhoneLength = false;

            // Country list from https://en.wikipedia.org/wiki/List_of_countries_and_dependencies_by_area
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
            "Yemen", "Zambia", "Zimbabwe"};

            Console.WriteLine("\nWhat is the band's name?");
            newBand.Name = Console.ReadLine();

            while (!realCountry)
            {
                Console.WriteLine($"\nWhere is {newBand.Name} from?");
                var country = Console.ReadLine();

                // Console.WriteLine($"{$"Number of countries: {countries.Count()}".Pastel(Color.LimeGreen)}");

                if (countries.Contains(country))
                {
                    newBand.CountryOfOrigin = country;
                    Console.WriteLine($"{$"{newBand.CountryOfOrigin}".Pastel(Color.LimeGreen)}");
                    break;
                }
                else
                {
                    Console.WriteLine($"\n{"Your answer was invalid. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"We currently support".Pastel(Color.Red)} {$"{countries.Count()}".Pastel(Color.LimeGreen)} {"different countries!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"Please see".Pastel(Color.Red)} {"https://en.wikipedia.org/wiki/List_of_countries_and_dependencies_by_area".Pastel(Color.FromArgb(51, 102, 187))}{" for a list of supported countries!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"Press".Pastel(Color.Red)} {"Ctrl".Pastel(Color.Yellow)} {"and".Pastel(Color.Red)} {"Click".Pastel(Color.Yellow)} {"the above link to view the website!".Pastel(Color.Red)}");

                }


            }

            Console.WriteLine($"\nWhat is {newBand.Name}'s website?");
            newBand.Website = Console.ReadLine();

            Console.WriteLine($"\nWhat style of music does {newBand.Name} do?");
            newBand.Style = Console.ReadLine();

            while (!correctAnswer)
            {
                Console.WriteLine($"\nIs {newBand.Name} signed? (Yes/No)");
                var signed = Console.ReadLine().ToUpper();

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
                }
            }

            Console.WriteLine($"\nWho is the contact for {newBand.Name}?");
            newBand.ContactName = Console.ReadLine();

            while (!correctPhoneLength)
            {
                Console.WriteLine($"\nWhat is {newBand.ContactName}'s phone number? Ex.[(123)-456-7890]");
                var phoneNumber = Console.ReadLine();

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
                    var formattedPhoneNumber = String.Format("{0:(###)-###-####}", "1" + phoneNumber);
                    newBand.ContactPhoneNumber = formattedPhoneNumber;

                    Console.WriteLine(formattedPhoneNumber);
                    break;
                }
                else
                {
                    Console.WriteLine($"{"\nIncorrect phone number. Please try again!".Pastel(Color.Red)}");
                    Console.WriteLine($"{"Your choice must 10 characters long".Pastel(Color.Red)}");
                }
            }


        }

        public void ExistingBand()
        {

        }

    }
}