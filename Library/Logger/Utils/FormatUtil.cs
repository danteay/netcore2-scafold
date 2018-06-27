using System;
using System.Collections.Generic;

namespace App.Library.Logger.Utils
{
    public class FormatUtil
    {
        public static string MakeExtraFields(string[] extras)
        {
            if (extras != null)
            {
                var aux = "";

                foreach (var value in extras)
                {
                    aux += (aux == "" ? value : " " + value);
                }

                return aux;
            }

            return "";
        }

        public static string ReplaceKeys(string text, Dictionary<string, string> data)
        {
            var keys = data.Keys;

            foreach (var key in keys)
            {
                text = text.Replace(key, data[key]);
            }

            return text;
        }
    }
}
