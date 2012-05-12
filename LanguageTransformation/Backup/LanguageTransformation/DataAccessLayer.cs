using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanguageTransformation
{
    class DataAccessLayer
    {
        private DictionaryDataSet.DictionaryDataTable _dictionary;

        public DataAccessLayer()
        {
            DictionaryDataSetTableAdapters.DictionaryTableAdapter dt = new LanguageTransformation.DictionaryDataSetTableAdapters.DictionaryTableAdapter();
            _dictionary = dt.GetData();
        }
        
        public string GetCTGWord(string value)
        {
            DictionaryDataSet.DictionaryRow ss = _dictionary.Where(p => p.Bangla == value).FirstOrDefault();

            if (ss == null || ss.CTG == null)
                return "";

            return ss.CTG;
        }

        public string GetSuddoFromCTGWord(string value)
        {
            DictionaryDataSet.DictionaryRow ss = _dictionary.Where(p => p.CTG == value).FirstOrDefault();

            if (ss == null || ss.Bangla == null)
                return "";

            return ss.Bangla;
        }

        public string GetBarishalWord(string value)
        {
            DictionaryDataSet.DictionaryRow ss = _dictionary.Where(p => p.Bangla == value).FirstOrDefault();

            if (ss == null || ss.Barishal == null)
                return "";

            return ss.Barishal;
        }

        public string GetSuddoFromBarishalWord(string value)
        {
            DictionaryDataSet.DictionaryRow ss = _dictionary.Where(p => p.Barishal == value).FirstOrDefault();

            if (ss == null || ss.Bangla == null)
                return "";

            return ss.Bangla;
        }

        public string GetNowakhaliWord(string value)
        {
            DictionaryDataSet.DictionaryRow ss = _dictionary.Where(p => p.Bangla == value).FirstOrDefault();

            if (ss == null || ss.Nowakhali == null)
                return "";

            return ss.Nowakhali;
        }

        public string GetSuddoFromNowakhaliWord(string value)
        {
            DictionaryDataSet.DictionaryRow ss = _dictionary.Where(p => p.Nowakhali == value).FirstOrDefault();

            if (ss == null || ss.Bangla == null)
                return "";

            return ss.Bangla;
        }

        /*
        public string GetRajshahiWord(string value)
        {
            DictionaryDataSet.DictionaryRow ss = _dictionary.Where(p => p.Bangla == value).FirstOrDefault();

            if (ss == null || ss.Rajshahi == null)
                return "";

            return ss.Rajshahi;
        }

        public string GetSuddoFromRajshahiWord(string value)
        {
            DictionaryDataSet.DictionaryRow ss = _dictionary.Where(p => p.Rajshahi == value).FirstOrDefault();

            if (ss == null || ss.Bangla == null)
                return "";
            return ss.Bangla;
        }
        */
    }
}
