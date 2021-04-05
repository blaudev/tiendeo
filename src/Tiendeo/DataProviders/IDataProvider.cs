namespace Tiendeo.DataProviders
{
    public interface IDataProvider
    {
        /// <summary>
        /// Returns a codifified string with the area and a list of positions and actions of the drones
        /// </summary>
        /// <param name="areaWidth"></param>
        /// <param name="areaHeight"></param>
        /// <returns></returns>
        string CreateData(int areaWidth, int areaHeight);
    }
}
