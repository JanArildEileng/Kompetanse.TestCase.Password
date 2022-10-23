namespace Kompetanse.TestCase.Password.Test
{
    /*
         Oppgaven g�r ut p� � lage tilfeldige passord 
     
        16 tegn (akkurat 16 tegn)
        Best� av minst ett tegn av hver av f�lgende kategorier: 
        stor bokstav
        liten bokstav 
        siffer
        f�lgende spesialtegn: #, !, ?, +, &, (, ), / 
        Skal ikke innehilde: stor-O, 0, liten L og I, og norske spesialbokstaver �, � og �
   */



    public class PasswordGeneratorTester
    {
   
        IPasswordGenerator passwordGenerator;

        public PasswordGeneratorTester()
        {
            passwordGenerator=new PasswordGenerator();
        }


        [Fact]
        [Trait("PasswordGenerator", "")]
        public void TestIsImplemented()
        {
           String password=passwordGenerator.Genererate();
            Assert.NotNull(password);
        }

        //TODO Lage komplett sett av tester..




    }
}