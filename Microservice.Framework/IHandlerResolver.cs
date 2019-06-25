using System;
using System.Collections.Generic;
using System.Linq;

namespace Microservice.Framework
{
    public interface IHandlerResolver
    {
        IRequestHandler<TRequest, TResponse> GetRequestHandler<TRequest, TResponse>() where TRequest : IRequestData<TResponse>;
    }

    public class HandlerResolver : IHandlerResolver
    {
        private readonly Dictionary<Type, Type> _requestHandlerTypes;

        public HandlerResolver(Type[] types)
        {
            _requestHandlerTypes = types                    
                    .Where(t => !t.IsAbstract)
                    .Select(t => new
                    {
                        HandlerType = t,
                        RequestType = GetHandledRequestType(t)
                    })
                    .Where(x => x.RequestType != null)
                    .ToDictionary(
                        x => x.RequestType,
                        x => x.HandlerType
                    );
        }

        private static Type GetHandledRequestType(Type type)
        {
            var handlerInterface = type.GetInterfaces()
                .FirstOrDefault(i =>
                    i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));

            return handlerInterface == null ? null : handlerInterface.GetGenericArguments()[0];
        }

        public IRequestHandler<TRequest, TResponse> GetRequestHandler<TRequest, TResponse>() where TRequest : IRequestData<TResponse>
        {
            if (!_requestHandlerTypes.ContainsKey(typeof(TRequest)))
                throw new ApplicationException("No handler registered for type: " + typeof(TRequest).FullName);

            var handlerType = _requestHandlerTypes[typeof(TRequest)];

            return (IRequestHandler<TRequest, TResponse>)Activator.CreateInstance(handlerType);
            // var handler = 
            //return handler.Handle(request);
        }
    }
}
