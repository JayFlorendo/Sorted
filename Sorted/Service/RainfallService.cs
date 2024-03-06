using Newtonsoft.Json;
using RestSharp;
using Sorted.Interface;
using Sorted.Model;
using Sorted.Schema;
using Sorted.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            _restClient = new RestClient($"http://environment.data.gov.uk/flood-monitoring/");
        }

        public async Task<dynamic> GetRainfallReading (int StationID)
        {
            dynamic oResponse; 

            try
            {
                RestRequest oRestRequest = new RestRequest($"/id/stations/" + StationID + $"/readings", Method.Get);
                oRestRequest.AddHeader("Content-Type", "application/json");

                RestResponse oRestResponse = await _restClient.ExecuteAsync(oRestRequest);
                List<RainfallReading> oReadings = new List<RainfallReading>();

                if (oRestResponse != null)
                {
                    

                    var oJson = JsonConvert.DeserializeObject<dynamic>(oRestResponse.Content);

                    var oItems = oJson["items"];

                    foreach (var item in oItems)
                    {
                        RainfallReading oReading = new RainfallReading();
                        
                        oReading.DateMeasured = item["dateTime"].ToString();
                        oReading.AmountMeasured = Decimal.Parse(item["value"].ToString());

                        oReadings.Add(oReading);
                    }

                    
                }

                oResponse = new RainfallReadingResponse();
                oResponse.RainfallReadings = oReadings;
            }
            catch (Exception ex)
            {

                oResponse = new ErrorResponse();

                List<ErrorDetail> oErrors = new List<ErrorDetail>();
                ErrorDetail oError = new ErrorDetail();

                oError.PropertyName = ex.Source.ToString();
                oError.Message = ex.Message;
                oErrors.Add(oError);

                oResponse.Errors = oErrors;
            }

            return oResponse;
        }
    } 
}
