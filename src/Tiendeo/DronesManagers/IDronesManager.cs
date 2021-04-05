using System.Collections.Generic;

using Tiendeo.Models;

namespace Tiendeo.DronesManagers
{
    public interface IDronesManager
    {
        List<Drone> CreateDrones(string data);
    }
}
