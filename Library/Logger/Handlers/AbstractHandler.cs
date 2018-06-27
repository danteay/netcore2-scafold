using System;
using System.Collections.Generic;
using App.Library.Logger.Formatters;

namespace App.Library.Logger.Handlers
{
    public abstract class AbstractHandler
    {
        protected AbstractFormatter Formatter;
        protected string Level;
        protected string Name;

        public void SetLevel(string level)
        {
            Level = level;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetFormatter(AbstractFormatter formatter)
        {
            Formatter = formatter;
            Formatter.SetName(Name);
            Formatter.SetLevel(Level);
        }

        public abstract void Write(Dictionary<string,string> data, string[] extras);
    }
}
