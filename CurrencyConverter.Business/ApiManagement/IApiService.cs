using CurrencyConverter.Business.Entities.Api;
using CurrencyConverter.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Business.ApiManagement
{
    public interface IApiService
    {
        ConvertResponse Convert(CurrencyType baseCurrency, CurrencyType targetCurrency, double baseValue);
    }
}
