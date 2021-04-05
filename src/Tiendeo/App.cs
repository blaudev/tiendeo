﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public App(IDataProvider dataProvider, IDronesManager dronesManager)
        {
            this.dataProvider = dataProvider;
            this.dronesManager = dronesManager;
        }
        public async Task RunAsync(int areaWidth, int areaHeight)
        {
            var data = dataProvider.CreateData(areaWidth, areaHeight);
            var drones = dronesManager.CreateDrones(data);
            drones = await ExecuteAllDronesActionsAsync(drones);
        }

        private async Task<List<Drone>> ExecuteAllDronesActionsAsync(List<Drone> drones)
        {
            var tasks = drones.Select(drone => dronesManager.ExecuteActionsAsync(drone));
            await Task.WhenAll(tasks);
            return tasks.Select(drone => drone.Result).ToList();
        }
    }
}
