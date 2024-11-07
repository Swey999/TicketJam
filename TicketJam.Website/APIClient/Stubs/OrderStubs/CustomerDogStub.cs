using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.APIClient.Stubs.OrderStubs
{
    public class CustomerDogStub
    {
        private static List<CustomerDog> _customerDog = new List<CustomerDog>()
        {
            new CustomerDog
            () {
            Id = 1,
            FirstName = "Boxen",
            LastName = "Herning",
            PhoneNo = "1234567890",
            Email = "dog@hund.dk",
            Password = "password",
            }
        };
        public IEnumerable<CustomerDog> GetAll()
        {
            return _customerDog;
        }
        public CustomerDog GetById(int id)
        {
            return _customerDog.SingleOrDefault(e => e.Id == id);
        }
    }
}
