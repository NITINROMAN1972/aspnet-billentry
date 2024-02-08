using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class API_API : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public class Api
    {
        public string Command { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public string Connection { get; set; }
        public string AccessKey { get; set; }
    }

    private DataTable getApiCall(string sql, Dictionary<string, string> para)
    {
        Api mPara = new Api
        {
            Command = sql,
            Parameters = para,
            Connection = "Ginie"
        };

        string jsonContent = JsonConvert.SerializeObject(mPara);
        StringContent stringContent = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

        string apiUrl = "http://101.53.144.92/wms/api/Get/Table";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = client.PostAsync(apiUrl, stringContent).Result;

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = response.Content.ReadAsStringAsync().Result;

                DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonResponse);

                return dt;
            }
            else
            {
                return new DataTable();
            }
        }
    }
}