using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfInvest.Krunch
{
    /// <summary>
    /// This class is child of MakeKrunchWord class. 
    /// Right now we are using default mechanism to generate Krunch word. This mechanism defined in MakeKrunchWord class
    /// if you want to implement different logic to generate Krunch word, here you can implement it.
    /// </summary>
    public class MakeKrunchWordWithGeneralAttributes : MakeKrunchWord,IKrunchInputConstraints
    {
        private MakeKrunchWordWithGeneralAttributes()
        {
            UnKrunchedPhrase = string.Empty;
        }
        public MakeKrunchWordWithGeneralAttributes(string UnKrunchedPhrase)
        {
                this.UnKrunchedPhrase = UnKrunchedPhrase;
        }
        public bool IsKrunchInputValid()
        {
            if (!string.IsNullOrEmpty(UnKrunchedPhrase)  && UnKrunchedPhrase.Trim().Length > 0 )
            {
                if (UnKrunchedPhrase.Length >= 2 && UnKrunchedPhrase.Length <= 70)
                {
                    return UnKrunchedPhrase.All(ch => ch == 32 || ch == 44 || ch == 46 || ch == 63 || (ch >= 65 && ch <= 90) || ch == 10 || ch == 13);
                }
                return false;
            }
            return false;
        }
        public override void GetKrunchWord(KrunchWordAttributes krunchWordAttributes)
        {
            if (IsKrunchInputValid())
            {
                base.GetKrunchWord(krunchWordAttributes);
            }
            else
            {
                throw new ArgumentException("The input unkrunched phrase is invalid, Your input must have capital letters, blanks and standard punctuation mark");
            }
        }
         
    }
}
