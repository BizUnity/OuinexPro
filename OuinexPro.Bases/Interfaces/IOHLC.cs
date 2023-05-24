namespace OuinexPro.Bases.Interfaces;

public interface IOHLC
{
    DateTime Time { get; }

    decimal Open { get; }

    decimal High { get; }

    decimal Low { get; }

    decimal Close { get; }

    decimal Volumes { get; }
}

