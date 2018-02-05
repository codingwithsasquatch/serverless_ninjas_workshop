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
    public static class Remove
    {
        [FunctionName("remove")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "remove/{productId:int}/{count:int}")]HttpRequestMessage req,
            int productId,
            int count,
            TraceWriter log)
        {
            log.Info("Remove function triggered.");

            // Look up the product - return a 404 if it 
            // can't be found in the repository.
            var repository = new ProductRepository();
            var product = repository.GetProductById(productId.ToString());
            if (product == null)
            {
                return req.CreateResponse(HttpStatusCode.NotFound, "Could not find the product.");
            }

            // Decrement the product count
            await repository.DecrementProductCount(productId.ToString(), count);

            return req.CreateResponse(HttpStatusCode.OK);
        }
    }
}
