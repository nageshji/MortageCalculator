using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Business.Contracts
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        // Methods
        IEnumerable<TEntity> GetAll();
        TEntity GetId(object id);
    }
}
