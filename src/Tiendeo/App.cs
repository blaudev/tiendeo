using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tiendeo.DataProviders;
using Tiendeo.DronesManagers;
using Tiendeo.Models;

namespace Tiendeo
{
    public class App
    {
        private readonly IDataProvider dataProvider;
        private readonly IDronesManager dronesManager;

        private string data = string.Empty;
        private List<Drone> drones = new();

        public App(IDataProvider dataProvider, IDronesManager dronesManager)
        {
            this.dataProvider = dataProvider;
            this.dronesManager = dronesManager;
        }

        /// <summary>
        /// Run the application
        /// </summary>
        /// <param name="areaWidth"></param>
        /// <param name="areaHeight"></param>
        /// <returns></returns>
        public async Task RunAsync(int areaWidth, int areaHeight)
        {
            data = dataProvider.CreateData(areaWidth, areaHeight);
            drones = dronesManager.CreateDrones(data);
            drones = await ExecuteAllDronesActionsAsync(drones);
        }

        /// <summary>
        /// Execute all drones actions
        /// </summary>
        /// <param name="drones"></param>
        /// <returns></returns>
        private async Task<List<Drone>> ExecuteAllDronesActionsAsync(List<Drone> drones)
        {
            var tasks = drones.Select(drone => dronesManager.ExecuteActionsAsync(drone));
            await Task.WhenAll(tasks);
            return tasks.Select(drone => drone.Result).ToList();
        }

        /// <summary>
        /// Report the final data
        /// </summary>
        /// <returns></returns>
        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine("Input:");
            sb.AppendLine();
            sb.AppendLine(data);

            sb.AppendLine();
            sb.AppendLine("Output:");
            sb.AppendLine();

            foreach (var drone in drones)
            {
                sb.AppendLine($"{drone.Position.X} {drone.Position.Y} {drone.Direction}");
            }

            return sb.ToString();
        }
    }
}
