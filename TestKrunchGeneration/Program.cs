using AfInvest.Krunch;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestKrunchGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter UnKrunched Phrase");
            var inputLine = Console.ReadLine();
            KrunchWordWithGeneralAttributes krunchWordWithGeneralAttributes = new KrunchWordWithGeneralAttributes();
            krunchWordWithGeneralAttributes.NeedToRemoveBlank = true;
            krunchWordWithGeneralAttributes.NeedToRemoveDuplicateLetters = true;
            krunchWordWithGeneralAttributes.NeedToRemoveVowels = true;
            MakeKrunchWordWithGeneralAttributes makeKrunchWordWithGeneralAttributes = new MakeKrunchWordWithGeneralAttributes(inputLine);
            makeKrunchWordWithGeneralAttributes.GetKrunchWord(krunchWordWithGeneralAttributes);
            Console.WriteLine("Krunched Phrase is {0}", makeKrunchWordWithGeneralAttributes.KrunchedPhrase);
            try
            {
                var filePath = Path.Combine(Environment.CurrentDirectory, "KrunchedPhrases.txt");
                File.WriteAllText(filePath, makeKrunchWordWithGeneralAttributes.KrunchedPhrase);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred while writing file. \n {0}",ex.Message);

            }
            Console.ReadLine();
        }
    }
}
