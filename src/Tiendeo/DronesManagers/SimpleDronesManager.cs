using System;
using System.Collections.Generic;

using Tiendeo.Models;

namespace Tiendeo.DronesManagers
{
    public class SimpleDronesManager : IDronesManager
    {
        public List<Drone> CreateDrones(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentException("data must be a valid data");
            }

            var drones = new List<Drone>();

            var dataList = PrepareData(data);

            return drones;
        }

        /// <summary>
        /// Remove line breaks and returns only drones data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string[] PrepareData(string data)
        {
            data = data.Replace("\r\n", "|").Trim('|');
            var dronesdata = data.Split('|')[1..];

            return dronesdata;
        }
    }
}
