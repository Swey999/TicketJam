using TicketJam.Website.APIClient.DTO;
using static Dapper.SqlMapper;

namespace TicketJam.Website.APIClient
{
    public interface IRestClient<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        bool Delete(int id);
        TEntity Add(TEntity orderToAdd);
        TEntity Update(TEntity orderToUpdate);

    }
}
