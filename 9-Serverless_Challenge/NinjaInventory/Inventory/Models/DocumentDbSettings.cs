using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    internal class DocumentDbSettings
    {
        #region Properties

        public string DatabaseId { get; set; }

        public string CollectionId { get; set; }

        public string AuthKey { get; set; }

        public string Endpoint { get; set; }

        #endregion

        #region Public Methods

        internal static DocumentDbSettings GetDbSettings()
        {
            var settings = new DocumentDbSettings
            {
                AuthKey = Environment.GetEnvironmentVariable("DocumentDbAuthKey"),
                CollectionId = Environment.GetEnvironmentVariable("DocumentDbCollectionId"),
                Endpoint = Environment.GetEnvironmentVariable("DocumentDbEndpoint"),
                DatabaseId = Environment.GetEnvironmentVariable("DocumentDbDatabaseId")
            };

            return settings;
        }

        #endregion
    }
}
