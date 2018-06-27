using System;

namespace App.Models
{
    public class Response
    {
        public string Object { get; set; }
        public int code { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public long request { get; set; }
        public string url { get; set; }
        public object data { get; set; }

        /// <summary>
        /// Generates the structure of the response Json Object
        /// </summary>
        /// <returns>The Response object</returns>
        /// <param name="code">Code.</param>
        /// <param name="status">Status.</param>
        /// <param name="message">Message.</param>
        /// <param name="url">URL.</param>
        /// <param name="data">Data.</param>
        public Response Get(int code, string status, string message, string url, object data = null)
        {
            DateTime localDateTime, univDateTime;
            localDateTime = DateTime.Now;
            univDateTime = localDateTime.ToUniversalTime();
            var millis = (long)(univDateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

            var appName = Environment.GetEnvironmentVariable("APP_NAME");
            appName = string.IsNullOrEmpty(appName) ? "APLICATION" : appName;

            this.Object = appName;
            this.code = code;
            this.status = status;
            this.message = message;
            this.request = millis;
            this.url = url;
            this.data = data;

            return this;
        }
    }
}
