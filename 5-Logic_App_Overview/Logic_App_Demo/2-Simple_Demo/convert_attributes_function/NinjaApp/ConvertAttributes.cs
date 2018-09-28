using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Text.RegularExpressions;
using System;
using System.Text;

namespace NinjaApp
{
    public static class ConvertAttributes
    {
        [FunctionName("ConvertAttributes")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {

            string jsonContent = await req.Content.ReadAsStringAsync();

           
            Regex pattern = new Regex("\\|");
            string output = pattern.Replace(jsonContent, "\",\"");

            Regex patternstart = new Regex("\"\\[");
            output = patternstart.Replace(output, "[\"");

            Regex patternend = new Regex("]\"");
            output = patternend.Replace(output, "\"]");

            return req.CreateResponse(HttpStatusCode.OK, output);
        }
    }
}
