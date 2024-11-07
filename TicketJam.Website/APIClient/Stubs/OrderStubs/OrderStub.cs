using RestSharp;
using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.APIClient.Stubs.OrderStubs
{
    public class OrderStub : IRestClient
    {
        public static EventStub eventStub = new EventStub();
        public static VenueStub venueStub = new VenueStub();
        public static CustomerDogStub customerDogStub = new CustomerDogStub();
        public static OrderLineStub orderline = new OrderLineStub();
        private static List<Order> _orders = new List<Order>
    {
        new Order
        {
            Id = 1, 
            OrderNo = 1001, 
            OrderLines = orderline.GetAll().ToList(),
            //Customer = customerDogStub.GetById(1),
            //Event = eventStub.GetById(1),
            //Venue = venueStub.GetById(1)
        }
    };

        public Order AddOrder(Order OrderToAdd)
        {
            _orders.Add(OrderToAdd);
            return OrderToAdd;
        }

        public bool DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            return _orders;
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Order UpdateOrder(Order OrderToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
