using System.Collections.Generic;
using System.Threading.Tasks;

namespace Merawo.Core.Services.Interfaces
{
    public interface IMerawo<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
    }
}
