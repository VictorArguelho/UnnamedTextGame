using Game.Mathematics;

namespace Game.ScreenUI
{
    public readonly struct DirtyScreenCell(
        ScreenCell cell,
        Vector2Int position
    ) : IEquatable<DirtyScreenCell>
    {
        public ScreenCell Cell { get; } = cell;
        public Vector2Int Position { get; } = position;
    
        public bool Equals(DirtyScreenCell other) =>
            Cell.Equals(other.Cell) &&
            Position.Equals(other.Position);

        public override bool Equals(object? obj) =>
            obj is DirtyScreenCell other && Equals(other);

        public override int GetHashCode() =>
            HashCode.Combine(Cell, Position);
    }
}