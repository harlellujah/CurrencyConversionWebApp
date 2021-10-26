using CurrencyConverter.Business.Entities.Api;
using CurrencyConverter.Common.AppSettings;
using CurrencyConverter.Common.Types;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CurrencyConverter.Business.ApiManagement
{
    public class ApiService : IApiService
    {
        private readonly AppSettings _appSettings;

        private HttpWebRequest request;

        private Dictionary<string, dynamic> parameters;

        public ApiService(IOptions<AppSettings> appSettings)
        {
            this._appSettings = appSettings.Value;
        }

        public ConvertResponse Convert(CurrencyType baseCurrency, CurrencyType targetCurrency, double baseValue)
        {
            parameters = new Dictionary<string, dynamic>();
            parameters.Add("baseCurrency", baseCurrency);
            parameters.Add("targetCurrency", targetCurrency);
            parameters.Add("baseValue", baseValue);

            SetupRequest("convert");

            ConvertResponse response = GetResponse<ConvertResponse>();

            return response;
        }

        private void SetupRequest(string command)
        {
            string requestString = $"{_appSettings.CurrencyApiUrl}{command}";

            foreach (var parameter in parameters)
            {
                requestString += $"/{parameter.Value}";
            }

            request = (HttpWebRequest)WebRequest.Create(requestString);

            request.Accept = "application/json";
        }

        private T GetResponse<T>()
        {
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string responseFromServer = reader.ReadToEnd();
                            return JsonSerializer.Deserialize<T>(responseFromServer);
                        }
                    }
                }

                throw new Exception(response.StatusDescription);
            }
        }
    }
}
