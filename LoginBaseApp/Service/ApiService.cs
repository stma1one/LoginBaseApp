using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace LoginBaseApp.Service
{
   public class ApiService:ILoginService
    {
        HttpClient HttpClient
		{
			get; set;
		}

		public ApiService()
		{
			HttpClient = new HttpClient();
			HttpClient.BaseAddress = new Uri("https://localhost:44324/");
			HttpClient.DefaultRequestHeaders.Accept.Clear();
			HttpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		}
		public bool Login(string username, string password)
		{
			var user = HttpClient.GetFromJsonAsync<Models.User>($"api/users/{username}/{password}").Result;
			return user != null;
		}
	}
}
