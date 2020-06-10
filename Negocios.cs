using Newtonsoft.Json;  
using RestSharp;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace teste1
{
    internal class Negocios
    {
        public string Titulo { get; set; }
        public double IdCliente { get; set; }
        public double ValorNegocio { get; set; }
        public double IdNegocio { get; set; }

        public string PostNegocios()
        {

            try
            {
                var client = new RestClient("https://api2.ploomes.com/");
                client.Timeout = -1;
                var request = new RestRequest("Deals?$select=Title,ContactName,Amount", Method.POST);
                request.AddHeader("User-Key", "586341D988E1F74999493B348F11082A5AA487DE656804469F0283080433608C366F95EDF05AEB83B5F45B2AA8CC37DB43291456C327E51AE4F09B265AC0D4DF");

                var json = "{ 'Title':" + "'" + this.Titulo + "'" + ", 'ContactId':" + this.IdCliente + ", 'Amount':" + this.ValorNegocio + " }";

                request.AddParameter("application/json", json, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                var convert = response.Content;
                dynamic text = JsonConvert.DeserializeObject<dynamic>(convert);
                return Convert.ToString(convert);
            }
            catch (Exception e)
            {

                return Convert.ToString("ERROR NO CADASTRO!!   " + e.Message);
            }

        }
        public string PatchNegocios()
        {
            try
            {
                var client = new RestClient("https://api2.ploomes.com/");
                client.Timeout = -1;
                var request = new RestRequest("Deals("+ this.IdNegocio + ")?$select=Title,ContactName,Amount", Method.PATCH);
                request.AddHeader("User-Key", "586341D988E1F74999493B348F11082A5AA487DE656804469F0283080433608C366F95EDF05AEB83B5F45B2AA8CC37DB43291456C327E51AE4F09B265AC0D4DF");

                var json = "{  'Amount':"+ this.ValorNegocio + " }";

                request.AddParameter("application/json", json, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                var convert = response.Content;
                dynamic text = JsonConvert.DeserializeObject<dynamic>(convert);
                return Convert.ToString(text);
            }
            catch (Exception e)
            {

                return Convert.ToString("ERROR NO CADASTRO!!   " + e.Message);
            }
        }
    }
}
