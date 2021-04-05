using System.Collections.Generic;
using System.Threading.Tasks;

using Tiendeo.Models;

namespace Tiendeo.DronesManagers
{
    public interface IDronesManager
    {
        List<Drone> CreateDrones(string data);
        Task<Drone> ExecuteActionsAsync(Drone drone);
    }
}
