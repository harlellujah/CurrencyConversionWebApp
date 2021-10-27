using CurrencyConverter.Business.ApiManagement;
using CurrencyConverter.Business.Entities.Api;
using CurrencyConverter.Business.Entities.Conversion;
using CurrencyConverter.DataAccess.Repository;
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

        private readonly IRepository _repository;

        private readonly IMapper<ConversionEntity, ConversionModel> _conversionMapper;

        public CurrencyService(IApiService apiService, IRepository repository, IMapper<ConversionEntity, ConversionModel> conversionMapper)
        {
            this._apiService = apiService;
            this._repository = repository;
            this._conversionMapper = conversionMapper;
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
                ConversionEntity conversion = new ConversionEntity()
                {
                    SessionId = model.SessionId,
                    BaseSymbol = model.SelectedBaseSymbol,
                    TargetSymbol = model.SelectedTargetSymbol,
                    BaseValue = model.BaseValue,
                    ExchangeRate = result.ExchangeRate,
                    ConvertedValue = result.ConvertedValue
                };

                _repository.AddConversion(conversion);

                model.SessionConversions = new List<ConversionModel>();

                _repository.GetConversionsForSession(model.SessionId).ForEach(c => model.SessionConversions.Add(_conversionMapper.MapTo(c)));
            }
        }
    }
}
