namespace Tiendeo.Models
{
    public record Drone
    {
        public Position Position { get; init; }
        public char Direction { get; init; }
        public char[] Actions { get; init; }
    }
}
