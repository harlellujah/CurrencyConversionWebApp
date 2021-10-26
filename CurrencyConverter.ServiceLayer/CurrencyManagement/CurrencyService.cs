using CurrencyConverter.Business.ApiManagement;
using CurrencyConverter.Business.Entities.Api;
using CurrencyConverter.Mapping.Base;
using CurrencyConverter.Models.Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.ServiceLayer.CurrencyManagement
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IApiService _apiService;


        public CurrencyService(IApiService apiService)
        {
            this._apiService = apiService;
        }

        public void Convert(ConvertCurrencyModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), $"parameter '{nameof(model)}' cannot be null in CurrencyService.Convert");
            }

            ConvertResponse result = _apiService.Convert(model.SelectedBaseSymbol, model.SelectedTargetSymbol, model.BaseValue);

            if (result != null)
            {
                ConversionModel conversion = new ConversionModel()
                {
                    BaseSymbol = model.SelectedBaseSymbol,
                    TargetSymbol = model.SelectedTargetSymbol,
                    BaseValue = model.BaseValue,
                    ExchangeRate = result.ExchangeRate,
                    ConvertedValue = result.ConvertedValue
                };

                model.SessionConversions.Add(conversion);
            }
        }
    }
}
