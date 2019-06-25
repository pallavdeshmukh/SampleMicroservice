namespace Microservice.Framework
{
    public interface IRequestHandler<TRequest, TResponse> where TRequest : IRequestData<TResponse>
    {
        TResponse Handle(TRequest request);
    }
}
