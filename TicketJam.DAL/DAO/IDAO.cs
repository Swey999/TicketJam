using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketJam.DAL.DAO
{
    public interface IDAO<TEntity> where TEntity : class
    {
        TEntity Create(TEntity entity);
        IEnumerable<TEntity> Read();
        TEntity GetById(int id);
        TEntity Update(TEntity entity);
        bool Delete(int id);

    }
}
