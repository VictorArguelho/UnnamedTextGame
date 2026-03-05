using System.Diagnostics.CodeAnalysis;

namespace Game.Mathematics
{
    public readonly struct Vector2Int(
        int x,
        int y
    ) 
    : IEquatable<Vector2Int>
    {
        public readonly int X { get; } = x;
        public readonly int Y { get; } = y;

        #region Constants
        public static Vector2Int Zero => new(0, 0);
        public static Vector2Int One => new(1, 1);
        public static Vector2Int Up => new(0, 1);
        public static Vector2Int Down => new(0, -1);
        public static Vector2Int Left => new(-1, 0);
        public static Vector2Int Right => new(1, 0);

        #endregion

        #region Operators

        public static Vector2Int operator +(
            Vector2Int a, 
            Vector2Int b
        ) =>
            new(
                a.X + b.X, 
                a.Y + b.Y
            );
        
        public static Vector2Int operator -(
            Vector2Int a, 
            Vector2Int b
        ) =>
            new(
                a.X - b.X, 
                a.Y - b.Y
            );
        
        public static Vector2Int operator *(
            Vector2Int a, 
            Vector2Int b
        ) =>
            new(
                a.X * b.X, 
                a.Y * b.Y
            );

        public static Vector2Int operator *(
            Vector2Int a, 
            int b
        ) =>
            new(
                a.X * b, 
                a.Y * b
            );
        
        public static Vector2Int operator /(
            Vector2Int a, 
            Vector2Int b
        ) =>
            new(
                a.X / b.X, 
                a.Y / b.Y
            );

        public static Vector2Int operator /(
            Vector2Int a, 
            int b
        ) =>
            new(
                a.X / b, 
                a.Y / b
            );

        public static bool operator ==(
            Vector2Int a, 
            Vector2Int b
        ) =>
            a.Equals(b);

        public static bool operator !=(
            Vector2Int a, 
            Vector2Int b
        ) =>
            !a.Equals(b);

        #endregion

        #region Overrides

        public override string ToString() =>
            $"({X} , {Y})";

        public bool Equals(Vector2Int other) =>
            X == other.X &&
            Y == other.Y;

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Vector2Int other)
                return Equals(other);
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        #endregion
    }
}