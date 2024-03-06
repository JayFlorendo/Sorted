using Newtonsoft.Json;
using RestSharp;
using Sorted.Interface;
using Sorted.Model;
using Sorted.Schema;
using Sorted.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorted.Service
{
    public class RainfallService : IRainfallService
    {
        private readonly RainfallSetting _setting;
        private readonly RestClient _restClient;

        public RainfallService ()
        {
            _restClient = new RestClient(_setting.Root);
        }

        public async Task<RainfallReadingResponse> GetRainfallReading (int StationID)
        {
            RainfallReadingResponse oResponse = new RainfallReadingResponse ();

            try
            {
                RestRequest oRestRequest = new RestRequest($"/rainfall/id/" + StationID + $"/readings", Method.Get);
                oRestRequest.AddHeader("Content-Type", "application/json");

                RestResponse oRestResponse = await _restClient.ExecuteAsync(oRestRequest);

                if (oRestResponse != null)
                {
                    var oJson = JsonConvert.DeserializeObject<dynamic>(oRestResponse.Content);

                    
                    foreach (var item in oJson)
                    {
                        RainfallReading oReading = new RainfallReading();
                        
                        oReading.DateMeasured = item["dateTime"].ToString();
                        oReading.AmountMeasured = Decimal.Parse(item["value"].ToString());

                        oResponse.RainfallReadings.Add(oReading);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

            return oResponse;
        }
    } 
}
