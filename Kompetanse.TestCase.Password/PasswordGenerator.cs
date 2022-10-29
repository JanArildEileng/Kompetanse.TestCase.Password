namespace Kompetanse.TestCase.Password
{
    /*
        Oppgaven går ut på å lage tilfeldige passord 

       16 tegn (akkurat 16 tegn)
       Bestå av minst ett tegn av hver av følgende kategorier: 
       stor bokstav
       liten bokstav 
       siffer
       følgende spesialtegn: #, !, ?, +, &, (, ), / 
       Skal ikke innehilde: stor-O, 0, liten L og I, og norske spesialbokstaver æ, ø og å
  */

    public class PasswordGenerator : IPasswordGenerator
    {
        private const int PasswordLength = 16;

        // A password must contain at least one of each of the following character categories, and no other characters than the ones listed here.
        public static readonly char[] LowerCaseChars = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        public static readonly char[] UpperCaseChars = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
        public static readonly char[] Digits = { '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        public static readonly char[] SpecialChars = { '#', '!', '?', '+', '&', '(', ')', '/' };

        // Array holding all the arrays with characters
        private readonly char[][] _allowedChars = { LowerCaseChars, UpperCaseChars, Digits, SpecialChars };

        // Array with the number of characters in each category
        private readonly int[] _numberOfCharsInCategories = { LowerCaseChars.Length, UpperCaseChars.Length, Digits.Length, SpecialChars.Length };

        private readonly Random _rng = new Random((int) DateTime.Now.Ticks);

        public string Genererate()
        {
            int numberOfCategories = _numberOfCharsInCategories.Length;
            // Array to keep track of which categories that are represented with at least one character in the password
            bool[] usedCategories = {false, false, false, false};

            string password = "";

            // Generate each character in the password randomly.
            for (int i = 0; i < PasswordLength; i++)
            {
                // First, pick a category (lowercase, uppercase, digits or special chars)
                int category = -1;
                // On the last characters, check if we're missing some categories and make sure to include them if so
                if (i >= PasswordLength - numberOfCategories + 1)
                {
                    category = Array.IndexOf(usedCategories, false);
                }
                if (category == -1)
                    // Pick a category randomly
                    category = _rng.Next(0, numberOfCategories);

                // Mark category as used
                usedCategories[category] = true;

                // Pick a character randomly from the category
                int index = _rng.Next(0, _numberOfCharsInCategories[category] - 1);

                // Add the new character to the password
                password += _allowedChars[category][index];
            }

            return password;
        }

    }
}