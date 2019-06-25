using Microservice.Framework;

namespace Microservice.Core
{
    public class CustomerRequestHandler : IRequestHandler<CustomerRequest, CustomerResponse>
    {
        public CustomerResponse Handle(CustomerRequest request)
        {
            return new CustomerResponse { Success = true };
        }
    }

    public class CustomerRequest : IRequestData<CustomerResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class CustomerResponse
    {
        public bool Success { get; set; }
    }

}
