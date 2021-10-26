using CurrencyConverter.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Models.Conversion
{
    public class ConversionModel
    {
        public ConversionModel()
        {

        }

        public CurrencyType BaseSymbol { get; set; }

        public CurrencyType TargetSymbol { get; set; }

        public double BaseValue { get; set; }

        public double ExchangeRate { get; set; }

        public double ConvertedValue { get; set; }
    }
}
