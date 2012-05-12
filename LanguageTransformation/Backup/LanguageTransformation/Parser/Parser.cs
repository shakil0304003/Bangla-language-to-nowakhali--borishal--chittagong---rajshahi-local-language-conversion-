using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanguageTransformation.Parser
{
    public class Parser
    {
        private static Parser _instance;

        public static Parser Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Parser();

                return _instance;
            }
        }

        private Parser()
        { 
        }

        private string Converter(string value, string language, string sourceLanguage)
        {
            string[] words = new string[109];
            int wordsNumber = 0;
            DataAccessLayer dal = new DataAccessLayer();

            string[] aa = value.Split(' ');

            for (int i = 0; i < aa.Length; i++)
                if (aa[i] != "")
                {
                    words[wordsNumber] = aa[i];
                    wordsNumber++;
                }

            string outputSentence = "";

            int start = 0;

            while (start < wordsNumber)
            {

                Boolean flag = false;

                for (int i = wordsNumber - 1; i >= start; i--)
                {
                    string temp = "";

                    for (int j = start; j <= i; j++)
                    {
                        if (j != start)
                            temp += " ";
                        temp += words[j];
                    }

                    if (language[0].ToString().ToLower() == "c")
                    {
                        if (sourceLanguage[0].ToString().ToLower() == "l")
                            temp = dal.GetSuddoFromCTGWord(temp);
                        else
                            temp = dal.GetCTGWord(temp);
                    }
                    else if (language[0].ToString().ToLower() == "b")
                    {
                        if (sourceLanguage[0].ToString().ToLower() == "l")
                            temp = dal.GetSuddoFromBarishalWord(temp);
                        else
                            temp = dal.GetBarishalWord(temp);
                    }
                    else if (language[0].ToString().ToLower() == "n")
                    {
                        if (sourceLanguage[0].ToString().ToLower() == "l")
                            temp = dal.GetSuddoFromNowakhaliWord(temp);
                        else
                            temp = dal.GetNowakhaliWord(temp);
                    }
                    /*
                    else if (language[0].ToString().ToLower() == "r")
                    {
                        if (sourceLanguage[0].ToString().ToLower() == "l")
                            temp = dal.GetSuddoFromRajshahiWord(temp);
                        else
                            temp = dal.GetRajshahiWord(temp);
                    }
                    */
                    if (temp != "")
                    {
                        outputSentence += temp + " ";
                        start = i + 1;
                        flag = true;
                        break;
                    }
                }

                if (flag == false)
                {
                    outputSentence += words[start] + " ";
                    start++;
                }
            }

            outputSentence = outputSentence.Trim();

            return outputSentence;
        }

        private string translator(string value, string language, string sourceLanguage)
        {
            string outputSentence = "";
            string temp = "";

            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == '?' || value[i] == '।' || value[i] == ',' || value[i] == '.')
                {
                    outputSentence += Converter(temp, language, sourceLanguage);
                    outputSentence += value[i].ToString();
                    temp = "";
                }
                else
                    temp += value[i].ToString();
            }

            if (temp != "")
                outputSentence += Converter(temp, language, sourceLanguage);

            return outputSentence;
        }

        public string LanguageTransformation(string value, string sourceLanguage,string destinationLanguage)
        {
            string input = value;

            if (sourceLanguage.Substring(0,3).ToString().ToUpper()!="BAN")
            {
                input = translator(input, sourceLanguage, "l");
            }

            if (destinationLanguage.Substring(0,3).ToString().ToUpper() != "BAN")
            {
                input = translator(input, destinationLanguage, "s");
            }

            return input;
        }

    }
}
