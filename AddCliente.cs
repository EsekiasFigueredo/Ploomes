using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using RestSharp.Deserializers;

namespace teste1
{
    class AddCliente
    {   
        [JsonProperty("Name")]
        private string Name;
        [JsonProperty("TypeId")]
        private int TypeId;

        public void SetNome(string nome)
        {
            this.Name = nome;

        }
        public void SetType(int type)
        {
            this.TypeId = type;
        }


        public string Post()
        {

            try
            {
                var client = new RestClient("https://api2.ploomes.com/");
                client.Timeout = -1;
                var request = new RestRequest("Contacts?$select=Name,Id", Method.POST);
                request.AddHeader("User-Key", "0DC60641F5F1E159A95D21E10C6CB2CC5567E03C1B066BD42FFDA749EB87991AA153675649DEB091B7CE75DE7A79633EB6545DB770A98BBC65AC00699B92BEBB");
                request.AddHeader("Content-Type", "application/json");

                var json = "{ 'Name':" + "'" + this.Name + "'" + ", 'TypeId':" + this.TypeId +" }" ;

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
