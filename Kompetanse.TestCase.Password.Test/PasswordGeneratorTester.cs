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