using lunch.Models;
using Microsoft.Azure.Documents.Client;
using Microsoft.Owin;
using Newtonsoft.Json;
using Owin;
using System.IO;

[assembly: OwinStartupAttribute(typeof(lunch.Startup))]
namespace lunch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            LoadData();
        }

        public async void LoadData()
        {
            //DocumentDB supports strongly typed POCO objects and also dynamic objects
            Restaurant testRestaurant = JsonConvert.DeserializeObject<Restaurant>(File.ReadAllText("./App_Data/test.json"));
            //dynamic dynamicObject = JsonConvert.DeserializeObject(File.ReadAllText(@".\App_Data\test2.json"));

            //persist the documents in DocumentDB
            await DocumentDBRepository<Restaurant>.CreateItemAsync(testRestaurant);
        }
    }
}
