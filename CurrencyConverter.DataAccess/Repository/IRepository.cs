using CurrencyConverter.Business.Entities.Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.DataAccess.Repository
{
    public interface IRepository
    {
        void AddConversion(ConversionEntity entity);

        List<ConversionEntity> GetConversionsForSession(Guid sessionId);
    }
}
