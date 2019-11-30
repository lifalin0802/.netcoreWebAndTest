using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=seismiclivedocteststg;AccountKey=hf83dv6xLFy8IubWkZMeV0xJzmGP2stbUOJVaGkLyWYka8JkcgpTwI8VFnO8/zkbj5Om0v8nNEY3232n7tYtOg==;EndpointSuffix=core.windows.net");
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("pbdoc01-collaboration");
            container.CreateIfNotExists(); 
        }
    }
}
