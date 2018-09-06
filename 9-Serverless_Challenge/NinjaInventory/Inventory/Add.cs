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
    public static class Add
    {
        [FunctionName("add")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "add/{productId:int}/{count:int}")]HttpRequestMessage req,
            int productId,
            int count,
            TraceWriter log)
        {
            log.Info("Add function triggered.");

            // Look up the product - return a 404 if it 
            // can't be found in the repository.
            var repository = new ProductRepository();
            var product = repository.GetProductById(productId.ToString());
            if (product == null)
            {
                return req.CreateResponse(HttpStatusCode.NotFound, "Could not find the product.");
            }

            // Increment the product count
            await repository.IncrementProductCount(productId.ToString(), count);

            return req.CreateResponse(HttpStatusCode.OK);
        }
    }
}
