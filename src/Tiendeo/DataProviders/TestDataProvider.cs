using System.Text;

namespace Tiendeo.DataProviders
{
    public class TestDataProvider : IDataProvider
    {
        public string CreateData(int areaWidth, int areaHeight)
        {
            var sb = new StringBuilder();

            // Area
            sb.AppendLine("5 5");

            // Drone 1
            sb.AppendLine("3 3 E");
            sb.AppendLine("L");

            // Drone 2
            sb.AppendLine("3 3 E");
            sb.AppendLine("MMRMMRMRRM");

            // Drone 3
            sb.AppendLine("1 2 N");
            sb.AppendLine("LMLMLMLMMLMLMLMLMM");

            return sb.ToString();
        }
    }
}
