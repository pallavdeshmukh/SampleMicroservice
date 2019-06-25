using Microservice.Framework;

namespace Microservice.Core
{
    public class BillRequestHandler : IRequestHandler<BillRequest, BillResponse>
    {
        public BillResponse Handle(BillRequest request)
        {
            return new BillResponse { Success = false };
        }
    }

    public class BillRequest : IRequestData<BillResponse>
    {
        public decimal Amount { get; set; }
    }
    public class BillResponse
    {
        public bool Success { get; set; }
    }
}
