namespace OuinexPro.Bases.Interfaces;


public delegate void OnTick();

public interface ITicker
{
    event OnTick OnTickHandler;

    decimal High { get; }

    decimal Low { get; }

    decimal LastBidPrice { get; }

    decimal LastAskPrice { get; }

    decimal Spread { get; }

    ISymbol Symbol { get; }

    IPublicExchange Exchange { get; }
}

