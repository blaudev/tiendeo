using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Tiendeo.Models;

namespace Tiendeo.DronesManagers
{
    public class SimpleDronesManager : IDronesManager
    {
        /// <summary>
        /// Create drones and their position, direction and actions
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Execute all drone actions and update his position and direction
        /// </summary>
        /// <param name="drone"></param>
        /// <returns></returns>
        public Task<Drone> ExecuteActionsAsync(Drone drone)
        {
            return Task.Run(() =>
            {
                var position = drone.Position;
                var direction = drone.Direction;

                foreach (var action in drone.Actions)
                {
                    (position, direction) = action switch
                    {
                        ActionType.Move => (Move(position, direction), direction),
                        ActionType.RotateRight => (position, RotateToRight(direction)),
                        ActionType.RotateLeft => (position, RotateToLeft(direction)),
                        _ => throw new Exception("Invalid action")
                    };
                }

                return drone with
                {
                    Position = position,
                    Direction = direction
                };
            });
        }

        private Position Move(Position position, int direction)
        {
            return direction switch
            {
                Direction.North => position with { Y = position.Y + 1 },
                Direction.East => position with { X = position.X + 1 },
                Direction.South => position with { Y = position.Y - 1 },
                Direction.West => position with { X = position.X - 1 },
                _ => throw new Exception("Invalid direction")
            };
        }

        private char RotateToRight(char direction)
        {
            return direction switch
            {
                Direction.North => Direction.East,
                Direction.East => Direction.South,
                Direction.South => Direction.West,
                Direction.West => Direction.North,
                _ => throw new Exception("Invalid direction")
            };
        }

        private char RotateToLeft(char direction)
        {
            return direction switch
            {
                Direction.North => Direction.West,
                Direction.East => Direction.North,
                Direction.South => Direction.East,
                Direction.West => Direction.South,
                _ => throw new Exception("Invalid direction")
            };
        }
    }
}
