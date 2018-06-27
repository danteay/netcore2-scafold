using System;
using System.Linq;
using System.Collections.Generic;
using App.Library.Logger.Utils;

namespace App.Library.Logger.Formatters
{
    public class WebFormatter : AbstractFormatter
    {
        private string[] Keys = { 
            "{epoch}",
            "{epochmilli}",
            "{time}",
            "{datetime}",
            "{service}",
            "{level}",
            "{code}",
            "{clientIp}",
            "{method}",
            "{path}",
            "{bodyLength}",
            "{reqTime}",
            "{message}",
            "{extras}"
        };

        public WebFormatter(string format = "")
        {
            if (format == "")
            {
                FormatString = "{epochmilli} {name} {level} {code} {clientIp} {method} {path} {bodyLength} {reqTime} {message} {extras}";
            }
            else 
            {
                FormatString = format;
            }
        }

        public string[] GetFormatKeys()
        {
            return Keys;
        }

        public override string Format(Dictionary<string, string> data, string[] extras = null)
        {
            var info = new Dictionary<string, string>()
            {
                {"{epoch}", GetEpoch().ToString()},
                {"{epochmilli}", GetEpochMilli().ToString()},
                {"{time}", DateTime.Now.ToString("yyyy-MM-dd")},
                {"{datetime}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                {"{name}", Name},
                {"{level}", Level},
                {"{code}", "200"},
                {"{clientIp}", "127.0.0.1"},
                {"{method}", "LOGGER"},
                {"{path}", "logger"},
                {"{bodyLength}", "0"},
                {"{reqTime}", "0"},
                {"{message}", ""},
                {"{extras}", FormatUtil.MakeExtraFields(extras)}
            };

            var dataKeys = data.Keys;

            foreach (var key in dataKeys)
            {
                if (Keys.Contains(key))
                {
                    info[key] = data[key];
                }
            }

            return FormatUtil.ReplaceKeys(FormatString, info);
        }

        private long GetEpochMilli()
        {
            DateTime localDateTime, univDateTime;
            localDateTime = DateTime.Now;
            univDateTime = localDateTime.ToUniversalTime();
            var millis = (long)(univDateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

            return millis;
        }

        private long GetEpoch()
        {
            DateTime localDateTime, univDateTime;
            localDateTime = DateTime.Now;
            univDateTime = localDateTime.ToUniversalTime();
            var millis = (long)(univDateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;

            return millis;
        }
    }
}
