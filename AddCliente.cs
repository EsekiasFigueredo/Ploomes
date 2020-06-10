using Newtonsoft.Json;
using RestSharp;
using System;


class AddCliente
{
    public string Nome { get; set; }
    public int Type { get; set; }


    public string Post()
    {

        try
        {
            var client = new RestClient("https://api2.ploomes.com/Contacts?$select=Name,Id");
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);
            request.AddHeader("User-Key", "586341D988E1F74999493B348F11082A5AA487DE656804469F0283080433608C366F95EDF05AEB83B5F45B2AA8CC37DB43291456C327E51AE4F09B265AC0D4DF");
            request.AddHeader("Content-Type", "application/json");

            var json = "{ 'Name':" + "'" + this.Nome + "'" + ", 'TypeId':" + this.Type + ", 'ContactId':" + this.Type + " }";

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