using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace easyPOSSolution.Utility
{
    class FieldValidationHelper
    {
        private static string _expression;
        private static Match _match;
        private static Regex _regex;

        public static bool IsValidString(string fieldValue)
        {
            //regular expression to handle sql injections
            // string expression = "(\\%)|(\\=)|(\\--)|(\\+)|(\\;)|(\\()|(\\))|(\\>)|(\\<)"; old code 

            //new code Janaka 03 10 2008 
            string expression = "(\\%)|(\\=)|(\\--)|(\\+)|(\\;)|(\\()|(\\))|(\\>)|(\\<)|(')|('')";


            Regex regex = new Regex(expression);
            Match match = regex.Match(fieldValue);

            if (match.Success)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsValidIntegerRange(string fieldValue)
        {
            int value;

            try
            {
                value = Int32.Parse(fieldValue);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool IsValidDecimal(string fieldValue)
        {
            //_expression = "^([1-9]{1}[0-9]{0,}(\\.[0-9]{0,2})?|0(\\.[0-9]{0,2})?|\\.[0-9]{1,2})$";
            string expression = "^(((\\d{1,3})(,\\d{3})*)|(\\d+))(\\.\\d{1,2})?$";

            Regex regex = new Regex(expression);
            Match match = regex.Match(fieldValue);

            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidEmail(string fieldValue)
        {
            //comment by Janaka -system get stuck in sometime
            // _expression = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@(([0-9a-zA-Z])+([-\\w]*[0-9a-zA-Z])*\\.)+[a-zA-Z]{2,9})$"; 
            _expression = "^\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$";

            _regex = new Regex(_expression);
            _match = _regex.Match(fieldValue);

            if (_match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidPhoneOrFaxNumber(string fieldValue)
        {
            //regular expression to handle sql injections 
            _expression = "([a-zA-Z])|(\\~)|(\\!)|(\\#)|(\\$)|(\\^)|(\\%)|(\\')|(\\&)|(\\*)|(\\=)|(\\`)|(\\?)|(\\;)|(\\>)|(\\<)|(\\@)|(\\\")|(\\|)|(\\{)|(\\})|(\\[)|(\\])|(\\.)";
            _regex = new Regex(_expression);
            _match = _regex.Match(fieldValue);

            if (_match.Success)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Comment: added by Janaka
        public static bool IsValidWebUrl(string fieldValue)
        {
            //regular expression to handle sql injections 
            _expression = "^(ht|f)tp(s?)\\:\\/\\/[0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*(:(0-9)*)*(\\/?)([a-zA-Z0-9\\-\\.\\?\\,\'\\/\\+&amp;%\\$#_]*)?$";
            _regex = new Regex(_expression);
            _match = _regex.Match(fieldValue);

            if (_match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
