using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.APIClient.Stubs.OrderStubs
{
    public class CustomerDogStub
    {
        private static List<CustomerDTO> _customerDog = new List<CustomerDTO>()
        {
            new CustomerDTO
            () {
      
            FirstName = "Boxen",
            LastName = "Herning",
            PhoneNo = "1234567890",
            Email = "dog@hund.dk",
            
            }
        };
        public IEnumerable<CustomerDTO> GetAll()
        {
            return _customerDog;
        }
        //public CustomerDTO GetById(int id)
        //{
          //  return _customerDog.SingleOrDefault(e => e.Id == id);
        //}
    }
}
