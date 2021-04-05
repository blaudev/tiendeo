using System.Text;

namespace Tiendeo.DataProviders
{
    public class HorizontalDataProvider : IDataProvider
    {
        /// <summary>
        /// Create as many drones as the height of the area.
        /// Each drone is positioned at the beginning of the x-axis and the y-axis according to the height of the area.
        /// Each drone has a number of 'M' actions equal to the width of the area.
        /// </summary>
        /// <param name="areaWidth"></param>
        /// <param name="areaHeight"></param>
        /// <returns></returns>
        public string CreateData(int areaWidth, int areaHeight)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{areaWidth} {areaHeight}");

            var actions = "".PadRight(areaWidth, 'M');

            for (int y = 0; y < areaHeight; y++)
            {
                sb.AppendLine($"0 {y} E");
                sb.AppendLine(actions);
            }

            return sb.ToString();
        }
    }
}
