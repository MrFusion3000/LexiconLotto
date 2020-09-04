using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace LexiconLotto
{
    class Program
    {
        static void Main(string[] args)
        {
            //int i = 1;
            ArrayList lottoRader = new ArrayList();
            string getInput = " ";

            // [ ]  Mata in valfritt antal rader för valfritt antal användare
            Console.WriteLine("Välkommen till LOTTO2000 - vinn stort, virtuellt!");

            while (getInput != "")
            {
                Console.WriteLine("Ange din lottorad (Namn,N1,N2,N3,N4,N5,N6,N7): ");

                getInput = Console.ReadLine();

                if (getInput != "")     // get out of while loop if <return>
                {
                var checkIt = StripName(getInput);     // Check if numbers are in range (1-35)

                    if (checkIt.Item1 == true)
                    {
                    lottoRader.Add(getInput);
                    }
                    else
                    {
                        Console.WriteLine("Raden innehåller ej valbara nummer!");
                    }
                }
                //Console.WriteLine("   {0}", getInput);          
            }

            foreach (string rad in lottoRader)
            {
                // *** debug
                Console.Write("   {0}", rad);
                Console.WriteLine();
                // debug end ***
            }


            // [ ]  Avbryt vid tom rad(endast<Enter>
            Console.WriteLine("Slut!");

            // [ ]  Generera rätt rad

            // [ ]  Data sorteras

            // [ ]  Data rättas

            // [ ]  Spara resultaten i texfil

        
        }

        // Sorterar bort namnt från textsträngen och lämnar talen
        public static ArrayList CheckValues(IEnumerable myList)
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

        public static Tuple<bool, int[]> StripName(string _getInput)
        {
            string getInput = _getInput;
            string lottoRowNoName;

            lottoRowNoName = getInput.Substring(getInput.IndexOf(",") + 1);

            string[] correctFormat = lottoRowNoName.Split(",");
            int[] numbersToCheck = new int[7];
            int j = 0;

            foreach (string input in correctFormat)
            {
                numbersToCheck[j] = Convert.ToInt32(input);

                if (numbersToCheck[j] <= 0 | numbersToCheck[j] >= 36)
                {
                    return new Tuple<bool, int[]> (false, numbersToCheck);
                }
                j++;
            }
            return new Tuple<bool, int[]> (true, numbersToCheck);
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
