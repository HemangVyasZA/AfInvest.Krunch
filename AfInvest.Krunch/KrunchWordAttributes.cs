using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfInvest.Krunch
{
    /// <summary>
    /// This class represents Krunch word's general attributes. Like Krunch word won't have Vowels etc.
    /// The main reason to make this parent abstract class is if child class needs to redefine characteristics 
    /// let say if child wants to allow vowels also, it can redefine characteristics.
    /// </summary>
    public abstract class  KrunchWordAttributes
    {
        /// <summary>
        /// Check if Vowels need to remove or not.
        /// Define virtual because if child class wants to allow vowels,
        /// it can redefine this property which return always false.
        /// </summary>
        public virtual bool NeedToRemoveVowels
        {
            get;set;
        }

        /// <summary>
        /// Check if Duplicate letters need to remove or not. 
        /// Define virtual because if child class wants to allow duplicate letters,
        /// it can redefine this property which return always false.
        /// </summary>
        public virtual bool NeedToRemoveDuplicateLetters
        {
            get; set;
        }
        /// <summary>
        /// Check if blank need to remove or not. 
        /// Define virtual because if child class does not want to remove blank
        /// it can redefine this property which return always false.
        /// </summary>
        public virtual bool NeedToRemoveBlank
        {
            get; set;
        }


    }
}
