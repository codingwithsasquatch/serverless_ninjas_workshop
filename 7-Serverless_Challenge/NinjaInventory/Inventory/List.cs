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
    public static class List
    {
        [FunctionName("list")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]HttpRequestMessage req,
            TraceWriter log)
        {
            log.Info("List function triggered.");

            // Retrieve the products from the repository
            var repository = new ProductRepository();
            var products = repository.GetAllProducts();

            // Return an OK status code along with the list of 
            // products in the message body. 
            return req.CreateResponse(HttpStatusCode.OK, products);
        }
    }
}
