using System;
using System.Threading.Tasks;

using Tiendeo.DataProviders;
using Tiendeo.DronesManagers;

namespace Tiendeo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            if (args is null
                || (args[0] is not "test" && args[0] is not "horizontal")
                || args.Length is not 3)
            {
                throw new ArgumentException("'data provider name', 'area width' and 'area height' are required");
            }

            if (int.TryParse(args[1], out int areaWidth) is false || areaWidth is not > 1)
            {
                throw new ArgumentException("'area width' must be a valid number");
            }

            if (int.TryParse(args[2], out int areaHeight) is false || areaHeight is not > 1)
            {
                throw new ArgumentException("'area height' must be a valid number");
            }

            IDataProvider dataProvider = args[0] == "test" ? new TestDataProvider() : new HorizontalDataProvider();
            IDronesManager dronesManager = new SimpleDronesManager();

            var app = new App(dataProvider, dronesManager);
            await app.RunAsync(areaWidth, areaHeight);

            Console.WriteLine(app.Report());
        }
    }
}
