using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Inventory.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace Inventory.Repositories
{
    internal class ProductRepository
    {
        #region Data Members

        private readonly DocumentDbSettings _documentDbSettings;
        private readonly DocumentClient _documentClient;

        #endregion

        #region Constructors

        public ProductRepository(DocumentDbSettings settings)
        {
            // Save the document db settings into a private data member and 
            // instantiate an instance of the client.
            _documentDbSettings = settings;
            _documentClient = new DocumentClient(new Uri(_documentDbSettings.Endpoint),
                _documentDbSettings.AuthKey);
        }

        public ProductRepository() : this(DocumentDbSettings.GetDbSettings())
        {
        }

        #endregion

        #region Public Methods

        public async Task Initialize()
        {
            // Create the database and collection if they 
            // do not already exist.
            await CreateDatabaseIfNotExistsAsync();
            await CreateCollectionIfNotExistsAsync();

            // Seed the collection with some products to work with. 
            var product1 = new Product() { Id = "1", Count = 5, Name = "Ninja Stars" };
            CreateProductDocumentIfNotExists(product1).Wait();

            var product2 = new Product() { Id = "2", Count = 12, Name = "Sword" };
            CreateProductDocumentIfNotExists(product2).Wait();

            var product3 = new Product() { Id = "3", Count = 12, Name = "Nunchucks" };
            CreateProductDocumentIfNotExists(product3).Wait();
        }

        public Product GetProductById(string productId)
        {
            var queryOptions = new FeedOptions { MaxItemCount = -1 };
            var query = _documentClient.CreateDocumentQuery<Product>(this.CollectionUri, queryOptions)
                    .Where(p => p.Id.ToLower() == productId.ToLower()).ToList();
            return query.FirstOrDefault();
        }

        public List<Product> GetAllProducts()
        {
            var results = _documentClient.CreateDocumentQuery<Product>(this.CollectionUri);
            return results.ToList();
        }

        public async Task<bool> DecrementProductCount(string productId, int count)
        {
            var product = GetProductById(productId);
            if (product == null) return false;

            product.Count -= count;
            var documentUri = UriFactory.CreateDocumentUri(_documentDbSettings.DatabaseId, _documentDbSettings.CollectionId, product.Id);
            await _documentClient.ReplaceDocumentAsync(documentUri, product);

            return true;
        }

        public async Task<bool> IncrementProductCount(string productId, int count)
        {
            var product = GetProductById(productId);
            if (product == null) return false;

            product.Count += count;
            var documentUri = UriFactory.CreateDocumentUri(_documentDbSettings.DatabaseId, _documentDbSettings.CollectionId, product.Id);
            await _documentClient.ReplaceDocumentAsync(documentUri, product);

            return true;
        }

        #endregion

        #region Private Methods

        private async Task CreateDatabaseIfNotExistsAsync()
        {
            try
            {
                var databaseUri = UriFactory.CreateDatabaseUri(_documentDbSettings.DatabaseId);
                await _documentClient.ReadDatabaseAsync(databaseUri);
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    var database = new Database { Id = _documentDbSettings.DatabaseId };
                    await _documentClient.CreateDatabaseAsync(database);
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task CreateCollectionIfNotExistsAsync()
        {
            try
            {
                var collectionUri = UriFactory.CreateDocumentCollectionUri(_documentDbSettings.DatabaseId, _documentDbSettings.CollectionId);
                await _documentClient.ReadDocumentCollectionAsync(collectionUri);
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    var databaseUri = UriFactory.CreateDatabaseUri(_documentDbSettings.DatabaseId);
                    await _documentClient.CreateDocumentCollectionAsync(databaseUri,
                        new DocumentCollection { Id = _documentDbSettings.CollectionId },
                        new RequestOptions { OfferThroughput = 400 });
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task CreateProductDocumentIfNotExists(Product product)
        {
            try
            {
                var documentUri = UriFactory.CreateDocumentUri(_documentDbSettings.DatabaseId, _documentDbSettings.CollectionId, product.Id);
                await _documentClient.ReadDocumentAsync(documentUri);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    var documentCollectionUri = UriFactory.CreateDocumentCollectionUri(_documentDbSettings.DatabaseId, _documentDbSettings.CollectionId);
                    await _documentClient.CreateDocumentAsync(documentCollectionUri, product);
                }
                else
                {
                    throw;
                }
            }
        }

        #endregion

        #region Properties

        private Uri CollectionUri => UriFactory.CreateDocumentCollectionUri(_documentDbSettings.DatabaseId, _documentDbSettings.CollectionId);

        #endregion
    }
}
