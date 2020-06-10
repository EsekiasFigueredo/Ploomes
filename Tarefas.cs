using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace teste1
{
    class Tarefas
    {

        [JsonProperty("Title")]
        public string Titulo { get; set; }
        [JsonProperty("Description")]
        public string Descricao { get; set; }
        [JsonProperty("DateTime")]
        public DateTime Data { get; set; }
        [JsonProperty("ContactId")]
        public int IdCliente { get; set; }
        [JsonProperty("Id")]
        public int IdTarefa { get; set; }
        [JsonProperty("Finished")]
        public bool finished ;


        public string Post()
        {

            try
            {
                var client = new RestClient("https://api2.ploomes.com/Tasks?$select=Title,Description,DateTime");
                client.Timeout = -1;

                var request = new RestRequest( Method.POST);
                request.AddHeader("User-Key", "586341D988E1F74999493B348F11082A5AA487DE656804469F0283080433608C366F95EDF05AEB83B5F45B2AA8CC37DB43291456C327E51AE4F09B265AC0D4DF");
                request.AddHeader("Content-Type", "application/json");

                var json = "{ 'Title':" + "'" + this.Titulo + "'" + ", 'Description':" + this.Descricao + ", 'ContactId':" + this.IdCliente + " }";
                
                request.AddParameter("application/json",json, ParameterType.RequestBody);
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

        public string Finalizar() {

            try
            {
                var client = new RestClient("https://api2.ploomes.com/");
                client.Timeout = -1;

                var request = new RestRequest("Tasks("+ this.IdTarefa +")?$select=Finished", Method.POST);
                request.AddHeader("User-Key", "586341D988E1F74999493B348F11082A5AA487DE656804469F0283080433608C366F95EDF05AEB83B5F45B2AA8CC37DB43291456C327E51AE4F09B265AC0D4DF");
                request.AddHeader("Content-Type", "application/json");

                request.AddParameter("application/json", "{\r\n    \"Finished\": " + finished +  "\r\n}", ParameterType.RequestBody);
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

    }
}
