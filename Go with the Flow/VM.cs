/********************************************
 * Author: Brock Sawlor
 * 5558077
 * bsawlor8077@conestogac.on.ca
 * *****************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Go_with_the_Flow
{
    class VM : INotifyPropertyChanged
    {

        #region Property Change
        public event PropertyChangedEventHandler PropertyChanged;

        private void propChange([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion

        #region Data

        int maxwidth = 80;

        
        private string paragraph = "";

        public string Paragraph { get { return paragraph; } set { paragraph = value; propChange(); } }

        private string original = "";

        public string Original { get { return original; } set { original = value; propChange(); } }

        private string input = "";

        public string Input { get { return input; } set { input = value; propChange(); } }

        private string title = "";

        public string Title { get { return title; } set { title = value; propChange(); } }

        private string subtitle = "";

        public string SubTitle { get { return subtitle; } set { subtitle = value; propChange(); } }

        int numwords;

        public int NumWords { get { return numwords; } set { numwords = value; propChange(); } }

        int numwordscheck;
        int numlocation;

        int linewidth;

        public int LineWidth { get { return linewidth; } set { linewidth = value; propChange(); } }

        int riverlength;

        public int RiverLength { get { return riverlength; } set { riverlength = value; propChange(); } }

        private string numberwords = "";

        public string NumberWords { get { return numberwords; } set { numberwords = value; propChange(); } }

        int numberwordsthick = 0;

        public int NumberWordsThick { get { return numberwordsthick; } set { numberwordsthick = value; propChange(); } }

        #endregion

        #region Singleton

        private static VM vm;
        public static VM Instance { get { vm ??= new VM(); return vm; } }

        private VM()
        {
            
        }

        #endregion

        public void OpenFile()
        {
            Paragraph = "";

            numlocation = Input.IndexOf(" ");
            NumWords = Convert.ToInt32(Input.Substring(0, numlocation));

            Original = Input.Substring(numlocation + 1);

            string[] words = Original.Split(' ');
            numwordscheck = words.Length;

            if (numwordscheck == NumWords)
            {
                NumberWords = "Green";
                NumberWordsThick = 3;
            }
            else
            {
                NumberWords = "Red";
                NumberWordsThick = 3;
            }

            Paragraph = Original;
        }

        public void RiverCheck()
        {
            string[] words = Paragraph.Split(' ');

            int width = Convert.ToInt32(words.OrderByDescending(s => s.Length).First().Length);

            // In order to properly check, we'll have to insert new lines in the correct places to properly identify the rivers
            // check the maxwidth var in the top of the Data region to change if required
            string workinglines = "";
            LineWidth = 0;
            RiverLength = 0;
            maxwidth = Paragraph.Length;

            for (int i = width; i <= maxwidth; i++)
            {
                int starting = 0;
                int ending = 0;
                List<List<char>> Check = new List<List<char>>();
                int line = 0;

                do
                {
                    ending += i;

                    if (Original[ending] != ' ')
                    {
                        ending = Array.LastIndexOf(Original.ToCharArray(), ' ', ending - 1);
                    }

                    workinglines += Original.Substring(starting, ending);
                    Check[line].AddRange(Original.Substring(starting, ending).ToCharArray());
                    workinglines += Environment.NewLine;

                    starting = ending - 1;
                    line++;
                } while (ending <= Original.Length);

                Paragraph = workinglines;

                //Check needs to be iterated through to:
                // 1) ignore space at the end of a line
                // 2) locate spaces, and track through the 2d array (list), rivers that appear
                // update LineWidth and RiverLength with the set that provides the max riverlength
                // the labels should update automatically as this runs

                  [][x][]
                [][][][][]
                for (int y = 0; y < Check[].)

            }




            
        }
    }
}
