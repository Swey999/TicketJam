using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.APIClient
{
    public interface IRestClient
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        bool DeleteOrder(int id);
        Order AddOrder(Order OrderToAdd);
        Order UpdateOrder(Order OrderToUpdate);

    }
}
