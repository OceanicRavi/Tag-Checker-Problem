using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TagCheckerProblem
{
    public class TagCheck
    {
        /*
         * regexPattern variable hold regular expression to match any possible matching open or closing tag given that
         * each open tag is enclosed by angular brackets with one Captial letter and
         * each closing tag is enclosed by angular brackets with one Capital letter preceded by symbol /.
         */
        public static string regexPattern = "<([A-Z])>|<(/[A-Z])>";
        /*
         * openTagPattern holds regular expression only to match open tags.
         */
        public static string openTagPattern = "<([A-Z])>";

        /// <summary>
        /// Performs Tag Checking for the given text and returns string showing whether the text is correctly tagged or 
        /// it will show most recent unmatched tag.
        /// </summary>
        /// <param name="textRead"></param>
        /// <returns></returns>
        public static string TagChecker(string textRead)
        {

            List<char> OpenTags = new List<char>();//List to hold the open tags encountered
            //Fetch all the possible open and closing tags from the given text in a list.
            MatchCollection matches = Regex.Matches(textRead, regexPattern);
            //parse each matched item
            foreach (Match item in matches)
            {
                //for open tag
                if (Regex.Match(item.Value, openTagPattern).Success)
                {
                    OpenTags.Add(item.Value[1]);//add only the charachter
                }
                else
                {
                    //for close tag
                    char closedTagValue = item.Value[2];
                    if (!OpenTags.Any())
                    {
                        //if no open tag exist for given closing tag
                        return "Expected # found " + item.Value;
                    }
                    char openTagValue = OpenTags[OpenTags.Count - 1];//Top of Stack
                    if (closedTagValue.Equals(openTagValue))
                    {
                        //if open tag charachter matches the closing tag charachter then remove open tag charachter from stack 
                        OpenTags.RemoveAt(OpenTags.Count - 1);
                    }
                    else
                    {
                        //if wrong closing tag encountered for the recent open tag
                        return "Expected </" + openTagValue + "> found " + item.Value;
                    }
                }
            }
            if (OpenTags.Any())
            {
                //if no closing tags encountered for recent open tag
                return "Expected </" + OpenTags[OpenTags.Count - 1] + "> found #";
            }
            else
            {
                //if all open tags have matching nested closing tags or
                //if the given text is empty or does not contain any tags
                return "Correctly tagged paragraph";
            }
        }
    }
}