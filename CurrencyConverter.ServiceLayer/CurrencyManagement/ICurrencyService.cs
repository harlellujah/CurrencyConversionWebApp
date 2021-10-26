using CurrencyConverter.Models.Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.ServiceLayer.CurrencyManagement
{
    public interface ICurrencyService
    {
        void Convert(ConvertCurrencyModel model);
    }
}
