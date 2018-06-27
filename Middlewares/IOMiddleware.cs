using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using App.Library.Logger;
using App.Library.Logger.Handlers;
using App.Library.Logger.Formatters;
using Microsoft.AspNetCore.Http.Internal;

namespace App.Middlewares
{
    public class IOMiddleware
    {
        private readonly RequestDelegate _next;
        private Logger logger;

        public IOMiddleware(RequestDelegate next)
        {
            _next = next;

            logger = new Logger("SRPAGO-OXXO");
            var formatter = new WebFormatter();

            var handler = new StdoutHandler();
            handler.SetFormatter(formatter);

            logger.AddHandler(handler);
        }

        public async Task Invoke(HttpContext context)
        {
            var contentLenth = context.Request.ContentLength.ToString();
            contentLenth = contentLenth == "" ? "-" : contentLenth;

            var info = new Dictionary<string, string>()
            {
                {"{code}", "200"},
                {"{clientIp}", context.User.ToString()},
                {"{method}", context.Request.Method},
                {"{path}", context.Request.Path.Value},
                {"{bodyLength}", contentLenth},
                {"{message}", await GetJsonRequest(context)},
            };

            logger.Info(info);

            await _next.Invoke(context);
        }

        private async Task<string> GetJsonRequest(HttpContext context)
        {
            var body = context.Request.Body;
            context.Request.EnableRewind();

            var request = context.Request;

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);

            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body = body;

            if (bodyAsText == "")
            {
                bodyAsText = "{}";
            }

            return bodyAsText;
        }
    }
}
