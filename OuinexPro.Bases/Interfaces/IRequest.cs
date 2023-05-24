namespace OuinexPro.Bases.Interfaces;

public interface IRequest<T>
{
    T Result { get; }

    bool Success { get; }

    string ErrorDescription { get; }
}

