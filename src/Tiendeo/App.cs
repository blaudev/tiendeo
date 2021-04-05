using System;
using System.Threading.Tasks;

using Tiendeo.DataProviders;

namespace Tiendeo
{
    public class App
    {
        private readonly IDataProvider dataProvider;

        public App(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }
        public async Task RunAsync(int areaWidth, int areaHeight)
        {
            var data = dataProvider.CreateData(areaWidth, areaHeight);
            Console.WriteLine(data);

            await Task.CompletedTask;
        }
    }
}
