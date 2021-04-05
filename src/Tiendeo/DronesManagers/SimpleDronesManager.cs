using System;
using System.Collections.Generic;
using System.Linq;

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

            string[] dataList = PrepareData(data);
            List<Drone> drones = new();

            for (int i = 0; i < dataList.Length; i += 2)
            {
                string position = dataList[i];
                string direction = dataList[i];
                string actions = dataList[i + 1];

                Drone drone = new()
                {
                    Position = ParsePosition(position),
                    Direction = ParseDirection(direction),
                    Actions = ParseActions(actions)
                };

                drones.Add(drone);
            }

            return drones;
        }

        private Position ParsePosition(string position)
        {
            var parts = position.Split(' ');

            return new Position
            {
                X = int.Parse(parts[0]),
                Y = int.Parse(parts[1])
            };
        }

        private char ParseDirection(string direction)
        {
            var parts = direction.Split(' ');
            return parts[2][0];
        }

        private char[] ParseActions(string actions)
        {
            return actions.ToCharArray();
        }

        /// <summary>
        /// Remove line breaks and returns only drones data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string[] PrepareData(string data)
        {
            data = data.Replace("\r\n", "|").Trim('|');
            string[] dronesdata = data.Split('|')[1..];

            return dronesdata;
        }
    }
}
