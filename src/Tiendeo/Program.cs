using System;
using System.Threading.Tasks;

using Tiendeo.DataProviders;

namespace Tiendeo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            if (args is null || args.Length is not 2)
            {
                throw new ArgumentException("'area width' and 'area height' are required");
            }

            if (int.TryParse(args[0], out int areaWidth) is false || areaWidth is not > 1)
            {
                throw new ArgumentException("'area width' must be a valid number");
            }

            if (int.TryParse(args[1], out int areaHeight) is false || areaHeight is not > 1)
            {
                throw new ArgumentException("'area height' must be a valid number");
            }

            IDataProvider dataProvider = new TestDataProvider();

            var app = new App(dataProvider);
            await app.RunAsync(areaWidth, areaHeight);
        }
    }
}
