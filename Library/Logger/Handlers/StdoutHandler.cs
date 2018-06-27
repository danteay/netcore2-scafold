using System;
using System.Collections.Generic;
using App.Library.Logger.Utils;

namespace App.Library.Logger.Handlers
{
    public class StdoutHandler : AbstractHandler
    {
        public override void Write(Dictionary<string, string> data, string[] extras)
        {
            if (Formatter == null)
            {
                var tmp = FormatUtil.MakeExtraFields(extras);

                foreach (var entry in data) 
                {
                    tmp = entry.Value + " " + tmp;
                }

                Console.WriteLine(tmp);
            }
            else 
            {
                Formatter.SetLevel(Level);
                Formatter.SetName(Name);
                var textFormated = Formatter.Format(data, extras);

                Console.WriteLine(textFormated);
            }
        }
    }
}
