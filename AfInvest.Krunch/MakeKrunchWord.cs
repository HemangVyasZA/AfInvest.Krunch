using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfInvest.Krunch
{
    /// <summary>
    /// This class generated Krunch word from UnKrunched word.
    /// The class has default implementation to generate Krunch word.
    /// </summary>
   public abstract class MakeKrunchWord
    {
        private static char[] _vowels = new[] { 'a', 'e','i','o','u','A','E','I','O','U' };
        
        public virtual string UnKrunchedPhrase
        {
            get;
            set;
        }
        public virtual string KrunchedPhrase
        {
            get;
             set;
        }
        public virtual void GetKrunchWord(KrunchWordAttributes krunchWordAttributes)
        {
            if (krunchWordAttributes == null)
            {
                throw new ArgumentNullException("KrunchWordAttributes is null.");
            }
            if (string.IsNullOrEmpty(UnKrunchedPhrase) || UnKrunchedPhrase.Trim().Length == 0)
            {
                throw new ArgumentNullException("Unkrunched input is null or empty.");
            }

            KrunchedPhrase = new string(UnKrunchedPhrase.ToCharArray());
            if (krunchWordAttributes.NeedToRemoveVowels)
            {
                RemoveVowels();
            }
            if (krunchWordAttributes.NeedToRemoveDuplicateLetters)
            {
                RemoveDuplicateLetters();
            }
            if (krunchWordAttributes.NeedToRemoveBlank)
            {
                RemoveBlanks();
            }
            KrunchedPhrase= KrunchedPhrase.Replace("\r\n", " ");
        }

        private void RemoveVowels()
        {
            var charactersAfterRemovingVowels = from ch in KrunchedPhrase
                                            where !_vowels.Contains(ch)
                                            select ch;
            KrunchedPhrase = new string(charactersAfterRemovingVowels.ToArray()).Trim();
        }
        private void RemoveDuplicateLetters()
        {
            var charactersAfterRemovingDuplicateLetters = new List<char>();
            foreach (char character in KrunchedPhrase)
            {
                if (!charactersAfterRemovingDuplicateLetters.Contains(character) || character == ' ' )
                {
                    charactersAfterRemovingDuplicateLetters.Add(character);
                }
            }
            KrunchedPhrase = new string(charactersAfterRemovingDuplicateLetters.ToArray()).Trim();
        }
        private void RemoveBlanks()
        {
            KrunchedPhrase = KrunchedPhrase.Trim();
            var phraseSeperatedBySpaces = KrunchedPhrase.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var phreasesAfterRemoveSpaces = from phrase in phraseSeperatedBySpaces
                                            where !string.IsNullOrWhiteSpace(phrase)
                                            select phrase.Trim();
            KrunchedPhrase = string.Join(" ", phreasesAfterRemoveSpaces);
            KrunchedPhrase= KrunchedPhrase.Replace(" ?", "?");
            KrunchedPhrase = KrunchedPhrase.Replace(" .", ".");
            KrunchedPhrase = KrunchedPhrase.Replace(" ,", ",");
        }
    }
}
