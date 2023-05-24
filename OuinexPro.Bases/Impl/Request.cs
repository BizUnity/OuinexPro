using OuinexPro.Bases.Interfaces;

namespace OuinexPro.Bases.Impl
{
    public class Request<T> : IRequest<T>
    {
        public Request(T t, bool success, string error = "")
        {
            Result = t;
            Success = success;
            ErrorDescription= error;
        }

        public T Result { get; private set; }

        public bool Success { get; private set; }

        public string ErrorDescription { get; private set; }
    }
}
