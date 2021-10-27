using CurrencyConverter.Business.Entities.Conversion;
using CurrencyConverter.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.DataAccess.Repository
{
    public class SQLRepository : IRepository
    {
        private readonly IDbContextFactory<CurrencyConversionContext> _contextFactory;

        public SQLRepository(IDbContextFactory<CurrencyConversionContext> contextFactory)
        {
            this._contextFactory = contextFactory;
        }

        public void AddConversion(ConversionEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), $"parameter '{entity}' cannot be null in SQLRepository.AddConversion");
            }

            using (var context = _contextFactory.CreateDbContext())
            {
                context.Conversions.Add(entity);
                context.SaveChanges();
            }
        }

        public List<ConversionEntity> GetConversionsForSession(Guid sessionId)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Conversions.Where(c => c.SessionId == sessionId).ToList();
            }
        }
    }
}
