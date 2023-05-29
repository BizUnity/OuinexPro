namespace OuinexPro.Bases.Interfaces
{
    public delegate void BarAdded(IOHLC bar);
    public delegate void BarChanged(IOHLC bar);

    public interface IOHLCs
    {
        event BarAdded OnBarAdded;
        event BarChanged OnBarChanged;

        IReadOnlyList<IOHLC> Bars { get; }
    }
}

