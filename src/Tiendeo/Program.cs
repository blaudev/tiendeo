using System;
using System.Threading.Tasks;

using Tiendeo.DataProviders;

namespace Tiendeo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IDataProvider dataProvider = new TestDataProvider();
            var data = dataProvider.CreateData(5, 5);
            Console.WriteLine(data);

            var app = new App();
            await app.RunAsync();
        }
    }
}
