namespace TagsApp
{
    public struct FromToCoords
    {
        public FromToCoords(uint fx, uint fy, uint tx, uint ty)
        {
            FromX = fx;
            FromY = fy;
            ToX = tx;
            ToY = ty;
        }

        public uint FromX { get; }
        public uint FromY { get; }
        public uint ToX { get; set; }
        public uint ToY { get; set; }
    }
}