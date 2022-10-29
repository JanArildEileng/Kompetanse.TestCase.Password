using Xunit.Abstractions;

namespace Kompetanse.TestCase.Password.Test
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

    public class PasswordGeneratorSetup : IDisposable
    {
        public int NumOfPasswords => 1000;
        public string[] Passwords { get; }

        public PasswordGeneratorSetup()
        {
            IPasswordGenerator passwordGenerator = new PasswordGenerator();

            Passwords = new string[NumOfPasswords];
            for (int i = 0; i < NumOfPasswords; i++)
            {
                Passwords[i] = passwordGenerator.Genererate();
            }
        }

        public void Dispose() { }
    }

    /// <summary>
    /// Unit tests for the PasswordGenerator class.
    /// Uses a class fixture for one time setup of the test class.
    /// The fixture generates a specified number of passwords which are then all tested, ao. for uniqueness.
    /// </summary>
    public class PasswordGeneratorTester : IClassFixture<PasswordGeneratorSetup>
    {
        private readonly PasswordGeneratorSetup _classwideFixture;

        private int NumOfPasswords => _classwideFixture.NumOfPasswords;

        private string[] Passwords => _classwideFixture.Passwords;

        public PasswordGeneratorTester(PasswordGeneratorSetup fixture)
        {
            _classwideFixture = fixture;
        }

        [Fact]
        public void TestUniqueness()
        {
            for (int i = 0; i < NumOfPasswords; i++)
            {
                for (int j = i + 1; j < NumOfPasswords; j++)
                {
                    Assert.True(!Passwords[i].Equals(Passwords[j]));
                }
            }
        }

        [Fact]
        public void TestNoIllegalChars()
        {
            for (int i = 0; i < NumOfPasswords; i++)
            {
                var pwd = Passwords[i];
                Assert.False(pwd.Contains('O'));
                Assert.False(pwd.Contains('0'));
                Assert.False(pwd.Contains('l'));
                Assert.False(pwd.Contains('I'));
                Assert.False(pwd.Contains('æ', StringComparison.InvariantCultureIgnoreCase));
                Assert.False(pwd.Contains('ø', StringComparison.InvariantCultureIgnoreCase));
                Assert.False(pwd.Contains('å', StringComparison.InvariantCultureIgnoreCase));
            }
        }

        [Fact]
        public void TestContainsSpecialChar()
        {
            for (int i = 0; i < NumOfPasswords; i++)
            {
                Assert.True(Passwords[i].IndexOfAny(PasswordGenerator.SpecialChars) > -1);
            }
        }

        [Fact]
        public void TestContainsDigit()
        {
            for (int i = 0; i < NumOfPasswords; i++)
            {
                Assert.True(Passwords[i].IndexOfAny(PasswordGenerator.Digits) > -1);
            }
        }

        [Fact]
        public void TestContainsLowerCaseChar()
        {
            for (int i = 0; i < NumOfPasswords; i++)
            {
                Assert.True(Passwords[i].IndexOfAny(PasswordGenerator.LowerCaseChars) > -1);
            }
        }

        [Fact]
        public void TestContainsSpecialUpperCaseChar()
        {
            for (int i = 0; i < NumOfPasswords; i++)
            {
                Assert.True(Passwords[i].IndexOfAny(PasswordGenerator.UpperCaseChars) > -1);
            }
        }
    }
}