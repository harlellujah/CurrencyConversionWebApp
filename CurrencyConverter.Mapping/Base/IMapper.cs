using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Mapping.Base
{
    public interface IMapper<TEntity, TModel>
    where TEntity : class, new()
    where TModel : new()
    {
        TModel MapTo(TEntity entity);

        TEntity MapTo(TModel entity);
    }
}
