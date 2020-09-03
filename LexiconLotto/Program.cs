using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace LexiconLotto
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            ArrayList lottoRader = new ArrayList();

            // [ ]  Mata in valfritt antal rader för valfritt antal användare
            Console.WriteLine("Välkommen till LOTTO2000 - vinn stort, virtuellt!");

            while (i != 0)
            {
                Console.WriteLine("Ange din lottorad (Namn,N1,N2,N3,N4,N5,N6,N7): ");

                string getInput = Console.ReadLine();

                if (getInput == "")     // get out of while loop if <return>
                { 
                    i = 0; 
                }

                lottoRader.Add (getInput);

                //Console.WriteLine("   {0}", getInput);

                //getInput = CheckLottoNumbers(getInput);
            }

            PrintValues(lottoRader);



            // [ ]  Avbryt vid tom rad(endast<Enter>
            Console.WriteLine("Slut!");

            // [ ]  Generera rätt rad

            // [ ]  Data sorteras

            // [ ]  Data rättas

            // [ ]  Spara resultaten i texfil

        
        }

        // Sorterar bort namnt från textsträngen och lämnar talen
        public static ArrayList PrintValues(IEnumerable myList)
        {
            string lottoRowName;
            string lottoRowNoName;
            ArrayList lottoRaderStripped = new ArrayList();

            foreach (Object obj in myList)
            {
                lottoRowName = obj.ToString();
                lottoRowNoName = lottoRowName.Substring(lottoRowName.IndexOf(",") + 1 );

                Console.Write("   {0}", lottoRowNoName);

                Console.WriteLine();

                lottoRaderStripped.Add (lottoRowNoName);
            }

            return lottoRaderStripped;
        }

        // **** Kontroll av godkända tecken och blockering av annat än siffror ****
        public int Check_Valid(int _antalMenyval)
        {
            int antalMenyval = _antalMenyval;
            int _menyVal;
            while (!int.TryParse(Console.ReadLine(), out _menyVal))
            {
                Console.WriteLine("Endast något av menyvalen 0 - " + (antalMenyval--) + " är giltiga.");
            }
            return _menyVal;
        }   // **** End Check_Valid() ****

        public string CheckLottoNumbers(string _getInput)
        {
            int countNumbers = 0;
            string getInput = _getInput;
            string[] correctFormat = getInput.Split(",");
            ArrayList numbersToSort = new ArrayList() ;
            int j = 0;
            
            foreach (string input in correctFormat)
            {
                numbersToSort[j] = Convert.ToInt32(input);

                if (countNumbers >= 1 && countNumbers <= 35)
                { 
                
                }
                j++;
            }
            return getInput;
        }

        static string CleanInput(string strIn)
        {
            // Replace invalid characters with empty strings.
            try
            {
                return Regex.Replace(strIn, @"[^\w\.@-]", "",
                                     RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            // If we timeout when replacing invalid characters,
            // we should return Empty.
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }
    }
}
