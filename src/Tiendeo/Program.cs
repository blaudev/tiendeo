using System;
using System.Threading.Tasks;

namespace Tiendeo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello Tiendeo!");
            await Task.CompletedTask;
        }
    }
}
