using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AfInvest.Krunch;

namespace AfInvest.Krunch.TestKrunch
{
    /// <summary>
    /// This method test that input unkrunched word must have Capital letters, blank and standard punctuation.
    /// </summary>
    [TestClass]
    public class TestMakeKrunchWordWithGeneralAttributes
    {
        [TestMethod]
        public void The_Input_UnKrunched_Phrase_Must_Have_Only_Capital_Letters_Blank_Character_And_Standard_Punctuation()
        {
            //arrange
            MakeKrunchWordWithGeneralAttributes makeKrunchWord = new MakeKrunchWordWithGeneralAttributes("THIS IS invalid input, Because It contains small letter and special characters also #@! ?");
            //act
            bool IsInputValid = makeKrunchWord.IsKrunchInputValid();

            //assert
            Assert.AreEqual(false, IsInputValid);

        }

        /// <summary>
        /// this method test whether length of unkrunched input is between 2 and 70 characters long
        /// </summary>
        [TestMethod]
        public void The_Length_Of_UnKrunched_Phrase_Must_Be_2_And_70_Characters_Long()
        {

            //arrange
            MakeKrunchWordWithGeneralAttributes makeKrunchWord = new MakeKrunchWordWithGeneralAttributes("THIS INPUT UNKRUNCHED PHRASE IS SEVENTY CHARACTERS LONG. BECAUSE WE NEED TO TEST WHETHER SYSTEM THROWS AN EXCEPTION IF INPUT IS SEVENTY CHARACTERS LONG");
            //act
            bool IsInputValid = makeKrunchWord.IsKrunchInputValid();

            //assert
            Assert.AreEqual(false, IsInputValid);

        }

        /// <summary>
        /// This method check whether we have instantiated krunch word attribute object, before applying GetKrunchedWord() Operation.
        /// </summary>
        [TestMethod]
        public void Throw_ArgumentNullException_If_Instance_Of_KrunchWordAttributes_Is_Null_When_You_Try_To_Get_Krunch_Word()
        {

            KrunchWordWithGeneralAttributes krunchWordWithGeneralAttributes = null;
            MakeKrunchWordWithGeneralAttributes makeKrunchWord = new MakeKrunchWordWithGeneralAttributes("THIS IS VALID INPUT?");
            Assert.ThrowsException<ArgumentNullException>(() => makeKrunchWord.GetKrunchWord(krunchWordWithGeneralAttributes));

        }

        /*
         * Following are there core methods for krunch application. We need to remove vowels
         * Then we need to remove duplicate letters
         * Then we need to remove blank before and after word. As well as before any punctuation mark.
         * There will be single space between each of word in final krunched phrase.
         * First we test these three core methods separately. Then after we test these policies in single method.
         */
       
        /// <summary>
        /// This method only test remove vowel logic. here we are not testing duplicate letters and remove blank logic.
        /// </summary>
        [TestMethod]
        public void Remove_Vowels_Must_Remove_Vowels_From_UnKrunchedPhrase()
        {
            string unKrunchedPhrase = @"I HAVE AN ORANGE .
YOU HAVE AN APPLE.
SO WHAT ARE WE GOING TO MAKE ?";
            KrunchWordAttributes krunchWordAttributes = new KrunchWordWithGeneralAttributes();
            krunchWordAttributes.NeedToRemoveVowels = true;//we only remove vowels this time
            krunchWordAttributes.NeedToRemoveBlank = false;//we are not removing blank also.
            krunchWordAttributes.NeedToRemoveDuplicateLetters = false;//we are allowing duplicate letter
            MakeKrunchWord makeKrunchWord = new MakeKrunchWordWithGeneralAttributes(unKrunchedPhrase);
            makeKrunchWord.GetKrunchWord(krunchWordAttributes);
            Assert.AreEqual("HV N RNG . Y HV N PPL. S WHT R W GNG T MK ?", makeKrunchWord.KrunchedPhrase);
        }


        /// <summary>
        /// This method only test removing duplicate letters logic. here we are not testing removing vowels or blank.
        /// </summary>
        [TestMethod]
        public void After_Removing_Duplicate_Letter_Each_Letter_Must_Appear_Once_In_Krunched_Phrase()
        {
            string unKrunchedPhrase = @"I HAVE AN ORANGE .
YOU HAVE AN APPLE.
SO WHAT ARE WE GOING TO MAKE ?";
            KrunchWordAttributes krunchWordAttributes = new KrunchWordWithGeneralAttributes();
            krunchWordAttributes.NeedToRemoveVowels = false;//we do not remove vowel.
            krunchWordAttributes.NeedToRemoveBlank = false;//we are not removing blank also.
            krunchWordAttributes.NeedToRemoveDuplicateLetters = true;//we are NOT allowing duplicate letter this time.
            MakeKrunchWord makeKrunchWord = new MakeKrunchWordWithGeneralAttributes(unKrunchedPhrase);
            makeKrunchWord.GetKrunchWord(krunchWordAttributes);
            Assert.AreEqual("I HAVE N ORG . YU   PLS WT     MK ?", makeKrunchWord.KrunchedPhrase);
        }

        /// <summary>
        /// This method only test removing blank logic. so there won't be any space before and after krunched phrase
        /// As well as before punctuation mark. There also be only single space between each word in krunched  phrase
        /// </summary>
        [TestMethod]
        public void After_Removing_Blank_No_Blank_Must_Appear_Before_After_And_Before_Punctuation_Mark()
        {
            string unKrunchedPhrase = @"I HAVE AN ORANGE .
YOU HAVE AN APPLE.
SO WHAT ARE WE GOING TO MAKE ?";
            KrunchWordAttributes krunchWordAttributes = new KrunchWordWithGeneralAttributes();
            krunchWordAttributes.NeedToRemoveVowels = false;//we do not remove vowel.
            //We are removing blank before and after Krunched phrase.
            //There must be single blank between each word in krunched phrase.
            //There must be no blank before punctuation mark
            krunchWordAttributes.NeedToRemoveBlank = true;//
            krunchWordAttributes.NeedToRemoveDuplicateLetters = false;//we are allowing duplicate letter.
            MakeKrunchWord makeKrunchWord = new MakeKrunchWordWithGeneralAttributes(unKrunchedPhrase);
            makeKrunchWord.GetKrunchWord(krunchWordAttributes);
            Assert.AreEqual("I HAVE AN ORANGE. YOU HAVE AN APPLE. SO WHAT ARE WE GOING TO MAKE?", makeKrunchWord.KrunchedPhrase);
        }

        /// <summary>
        /// Here we apply all policies for making krunch phrase
        /// 1. remove vowels
        /// 2. remove duplicate letters
        /// 3. remove redundant blanks
        /// This method test whether we can get final Krunched phrase or not.
        /// </summary>
        [TestMethod]
        public void After_Applying_Krunch_Phrase_Policy_The_Krunched_Phrase_Must_Not_Have_Vowel_Duplicate_Letter_And_Blank_Before_And_After_Word()
        {

            string unKrunchedPhrase = @"NOW IS THE
TIME FOR ALL GOOD MEN TO COME TO THE AID OF THEIR
COUNTRY";
            KrunchWordAttributes krunchWordAttributes = new KrunchWordWithGeneralAttributes();
            krunchWordAttributes.NeedToRemoveVowels = true;
            krunchWordAttributes.NeedToRemoveBlank = true;
            krunchWordAttributes.NeedToRemoveDuplicateLetters = true;
            MakeKrunchWord makeKrunchWord = new MakeKrunchWordWithGeneralAttributes(unKrunchedPhrase);
            makeKrunchWord.GetKrunchWord(krunchWordAttributes);
            Assert.AreEqual("NW S TH M FR L GD C Y", makeKrunchWord.KrunchedPhrase);
        }
    }
}
