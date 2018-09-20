using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Inventory.Repositories;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace Inventory
{
    public static class Init
    {
        [FunctionName("init")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequestMessage req, 
            TraceWriter log)
        {
            log.Info("Init function triggered.");

            // Initialize the repository
            var productRepository = new ProductRepository();
            await productRepository.Initialize();

            return req.CreateResponse(HttpStatusCode.OK);
        }
    }
}
