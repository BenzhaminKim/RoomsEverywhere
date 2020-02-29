using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TorontoRoonRentals.Common
{
    public class AzureConnection
    {
        const string accountName = "sqlvamstj45g4qye7y";
        const string accountKey = "E6nyG2TxpaEov9o4gYq4hnUPIk2P/ymKGPoeKNKffl4fApv8exiQdE/3gEIRm9auwYXiJal/65alAgohXsGeXw==";
        private readonly CloudStorageAccount storageAccount;
        private readonly CloudBlobClient blobClient;
        private readonly CloudBlobContainer container;
        public AzureConnection()
        {
            storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);

            blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference("images");

            container.CreateIfNotExistsAsync();
            container.SetPermissionsAsync(new BlobContainerPermissions()
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
        }

        public async Task UploadImageMemoryStream(string fileName, MemoryStream memoryStream)
        {
            var blob = container.GetBlockBlobReference(fileName);
         
            await blob.UploadFromStreamAsync(memoryStream);
          

        }


    }
}
