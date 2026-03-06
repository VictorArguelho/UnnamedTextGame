using Game.Mathematics;

namespace Game.ScreenUI
{
    public static class ScreenBuffer
    {
        private readonly static HashSet<Vector2Int> _dirtyCells = [];
        private static ScreenCell[,]? _buffer = null;
        private static bool _needsFullRender = false;
        public static int Width { get; private set; }
        public static int Height { get; private set; }

        public static void ResizeBuffer(int width, int height)
        {
            Width = width;
            Height = height;
            _buffer = new ScreenCell[width, height];
            ClearBuffer();
        }

        public static void ClearBuffer()
        {
            ResetBufferCells();
            _needsFullRender = true;
        }

        #region SetCell overloads

        public static void SetCellChr(
            Vector2Int position,
            char chr
        )
        {
            ref var cell = ref GetCell(position);     

            if(cell.SetCell(
                    chr, 
                    cell.ChrColor, 
                    cell.BackgroundColor
                )
            )
                _dirtyCells.Add(position);
        }

        public static void SetCellChrColor(
            Vector2Int position,
            ConsoleColor chrColor
        )
        {
            ref var cell = ref GetCell(position);     

            if(cell.SetCell(
                    cell.Chr, 
                    chrColor, 
                    cell.BackgroundColor
                )
            )
                _dirtyCells.Add(position);
        }

        public static void SetCellBackgroundColor(
            Vector2Int position,
            ConsoleColor backgroundColor
        )
        {
            ref var cell = ref GetCell(position);     

            if(cell.SetCell(
                    cell.Chr, 
                    cell.ChrColor, 
                    backgroundColor
                )
            )
                _dirtyCells.Add(position);
        }

        #endregion

        public static DirtyScreenCell[] GetDirtyCells()
        {
            if (_needsFullRender)
            {
                _needsFullRender = false;
                return GetAllCellsForRender();
            }
               
            return CollectDirtyCells();
        }

        private static void ResetBufferCells()
        {
            if(_buffer == null)
                throw new InvalidOperationException("Buffer não inicializado");

            for(int x = 0; x < Width; x++)
                for(int y = 0; y < Height; y++)
                    _buffer[x, y] = new();
        }

        private static ref ScreenCell GetCell(Vector2Int position)
        {
            if (_buffer == null)
                throw new InvalidOperationException("Buffer não inicializado");

            if (position.X < 0 || position.X >= Width ||
                position.Y < 0 || position.Y >= Height
            )
                throw new ArgumentOutOfRangeException(nameof(position));

            return ref _buffer[position.X, position.Y];
        }

        private static DirtyScreenCell[] GetAllCellsForRender()
        {
            if(_buffer == null)
                throw new InvalidOperationException("Buffer não inicializado");

            var dirtyCells = new DirtyScreenCell[Width, Height];

                for(int x = 0; x < Width; x++)
                    for(int y = 0; y < Height; y++)
                        dirtyCells[x, y] = new(
                                _buffer[x, y],
                                new(x, y)
                            );       

                return [.. dirtyCells];
        }

        private static DirtyScreenCell[] CollectDirtyCells()
        {
            if(_buffer == null)
                throw new InvalidOperationException("Buffer não inicializado");

            var dirty = _dirtyCells
                .Select(pos => 
                    new DirtyScreenCell(
                        _buffer[pos.X, pos.Y], 
                        pos)
                )
                .ToArray();
            _dirtyCells.Clear();

            return dirty;
        }
    }
}