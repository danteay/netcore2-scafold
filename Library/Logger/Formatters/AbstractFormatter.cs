using System;
using System.Collections.Generic;

namespace App.Library.Logger.Formatters
{
    public abstract class AbstractFormatter
    {
        protected string FormatString;
        protected string Level;
        protected string Name;

        public void SetFormatString(string formatString)
        {
            FormatString = formatString;
        }

        public void SetLevel(string level)
        {
            Level = level;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public abstract string Format(Dictionary<string, string> data, string[] extras=null);
    }
}
