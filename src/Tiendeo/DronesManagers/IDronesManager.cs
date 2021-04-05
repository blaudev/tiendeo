using System.Collections.Generic;
using System.Threading.Tasks;

using Tiendeo.Models;

namespace Tiendeo.DronesManagers
{
    public interface IDronesManager
    {
        /// <summary>
        /// Create drones and their position, direction and actions
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        List<Drone> CreateDrones(string data);

        /// <summary>
        /// Execute all drone actions and update his position and direction
        /// </summary>
        /// <param name="drone"></param>
        /// <returns></returns>
        Task<Drone> ExecuteActionsAsync(Drone drone);
    }
}
