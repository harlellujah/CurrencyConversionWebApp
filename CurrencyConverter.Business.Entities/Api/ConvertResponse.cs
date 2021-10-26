using CurrencyConverter.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrencyConverter.Business.Entities.Api
{
    public class ConvertResponse
    {
        [JsonPropertyName("baseCurrency")]
        public CurrencyType BaseCurrency { get; set; }

        [JsonPropertyName("targetCurrency")]
        public CurrencyType TargetCurrency { get; set; }

        [JsonPropertyName("exchangeRate")]
        public double ExchangeRate { get; set; }

        [JsonPropertyName("baseValue")]
        public double BaseValue { get; set; }

        [JsonPropertyName("convertedValue")]
        public double ConvertedValue { get; set; }
    }
}
