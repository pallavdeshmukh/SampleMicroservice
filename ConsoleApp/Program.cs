using System;
using Microservice.Framework;
using Microservice.Core;

namespace ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IHandlerResolver resolver = new HandlerResolver(typeof(CustomerRequestHandler).Assembly.GetTypes());

            var customerRequest = new CustomerRequest { Name = "Joe", Surname = "Bloggs" };
            var customerResponse = resolver.GetRequestHandler<CustomerRequest, CustomerResponse>().Handle(customerRequest);

            var billRequest = new BillRequest { Amount = 100m };
            var billResponse = resolver.GetRequestHandler<BillRequest, BillResponse>().Handle(billRequest);

            Console.WriteLine(billResponse.Success);
            Console.WriteLine(customerResponse.Success);
            Console.ReadKey();
        }
    }       
}
