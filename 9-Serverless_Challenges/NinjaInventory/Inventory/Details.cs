using System;
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
    public static class Details
    {
        [FunctionName("details")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "details/{productId:int}")]HttpRequestMessage req,
            int productId,
            TraceWriter log)
        {
            log.Info("Details function triggered.");

            // Retrieve the product
            var repository = new ProductRepository();
            var product = repository.GetProductById(productId.ToString());

            // Return Not Found if we can't find the product, otherwise
            // return an OK and the product information.
            return product == null ? req.CreateResponse(HttpStatusCode.NotFound) : req.CreateResponse(HttpStatusCode.OK, product);
        }
    }
}
