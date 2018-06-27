using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Gets the json request.
        /// </summary>
        /// <returns>The json request in a string.</returns>
        protected string GetJsonRequest()
        {
            var request = this.HttpContext.Request;
            var stream = new StreamReader(request.Body);
            var body = stream.ReadToEnd().Replace("\n", "").Replace("\t", "");

            return body;
        }
    }
}
