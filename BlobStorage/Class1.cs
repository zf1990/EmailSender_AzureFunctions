using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BlobStorage
{
    public class Storage
    {
        public MemoryStream FileStream { get; set; }
        public string FileName { get; set; }
        public string ConnectionString { get; set; }
        public string ContainerName { get; }

        public Storage(MemoryStream FileStream, string FileName, string ConnectionString, string ContainerName)
        {
            this.FileName = FileName;
            this.FileStream = FileStream;
            this.ConnectionString = ConnectionString;
            this.ContainerName = ContainerName;
        }

        public void UploadFile()
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(this.ConnectionString);
            CloudBlobClient blobClient = account.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(ContainerName);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(FileName);

            using(var filestream = FileStream)
            {
                blockBlob.UploadFromStreamAsync(filestream).Wait();
            }

        }

    }
}