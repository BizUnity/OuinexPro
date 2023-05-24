namespace OuinexPro.Bases.Interfaces;

public interface ISymbol
{
    string ExchangeName { get; }

    string BaseCurrency { get; }

    string QuoteCurrency { get; }

    string NormalizedName { get; }

    decimal TickSize { get; }

    IPublicExchange Exchange { get; }
}

