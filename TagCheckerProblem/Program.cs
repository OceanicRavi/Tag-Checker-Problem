using System;

namespace TagCheckerProblem
{
    /*
     * Author: Ravi Bhatt
     * Submission For: Percept Health Technical Test 
     */
    /// <summary>
    /// TagcheckerProblem will check that all the tags in a given piece of text (a paragraph) are correctly nested, 
    /// and that there are no missing or extra tags.
    /// An opening tag for this problem is enclosed by angle brackets,and contains exactly one upper case letter, for example<T>, <X>, <S>. 
    /// The corresponding closing tag will be the same letter preceded by the symbol /; for the examples above these would be</T>, </X>, </S>. 
    /// If the paragraph is correctly tagged then output the line “Correctly tagged paragraph”, otherwise output a line of the form “Expected<expected> found <unexpected>” where<expected> is the closing tag matching the most recent unmatched tag and <unexpected> is the closing tag encountered. 
    /// If either of these is the end of paragraph, i.e.there is either an unmatched opening tag or no matching closing tag at the end of the paragraph, then replace the tag or closing tag with #. 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Read a text from the console.Assuming the text does not have a new line.
             */
            Console.WriteLine("Paste your text below:");
            string textRead = Console.ReadLine();
            string result = TagCheck.TagChecker(textRead);
            Console.WriteLine(result);//Print the result
            Console.Read();
        }

    }
}
