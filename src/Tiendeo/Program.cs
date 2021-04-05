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

            var app = new App(dataProvider);
            await app.RunAsync(5, 5);
        }
    }
}
