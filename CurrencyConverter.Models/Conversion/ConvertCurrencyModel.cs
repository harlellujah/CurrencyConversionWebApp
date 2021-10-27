using CurrencyConverter.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Models.Conversion
{
    public class ConvertCurrencyModel
    {
        public ConvertCurrencyModel()
        {
            SessionConversions = new List<ConversionModel>();
        }

        public Guid SessionId { get; set; }

        public CurrencyType SelectedBaseSymbol { get; set; }

        public CurrencyType SelectedTargetSymbol { get; set; }

        public double BaseValue { get; set; }

        public List<ConversionModel> SessionConversions { get; set; }
    }
}
