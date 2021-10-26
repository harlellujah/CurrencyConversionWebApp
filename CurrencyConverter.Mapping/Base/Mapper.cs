using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Mapping.Base
{
    public class Mapper<TEntity, TModel> : IMapper<TEntity, TModel>
    where TEntity : class, new()
    where TModel : new()
    {
        public virtual TModel MapTo(TEntity entity)
        {
            TModel model = new TModel();
            model.InjectFrom(entity);

            return model;
        }

        public virtual TEntity MapTo(TModel model)
        {
            TEntity entity = new TEntity();
            entity.InjectFrom(model);

            return entity;
        }
    }
}
