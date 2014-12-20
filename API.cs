using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SyncThingTray
{
	static class API
	{
		public static async Task<string> CallAPIPost(string Query)
		{
			if (string.IsNullOrWhiteSpace(Program.APIUrl)) return "Syncthing address unavailable";
			try
			{
				HttpClient client = new HttpClient();
				client.BaseAddress = new Uri(Program.APIUrl);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Add("X-API-Key", Program.APIKey);
				HttpContent cnt = new ByteArrayContent(new byte[0]);
				var res = await client.PostAsync("rest/" + Query, cnt);
				return res.IsSuccessStatusCode ? null : "Error: " + res.ToString();
			}
			catch (HttpRequestException x)
			{
				var i = x.InnerException;
				if (i != null) return "Exception: " + i.Message;
				return "Exception: " + x.Message;
			}
		}

		public static string CallAPIPostSync(string Query, int Timeout, string Default)
		{
			var res = CallAPIPost(Query);
			if (res.Wait(Timeout))
				return res.Result;
			else
				return Default;
		}

		public static bool IsAvailable
		{
			get
			{
				var res = CallAPIPost("ping");
				if (!res.Wait(1000)) return false;
				return res.Result == null;
			}
		}

	}
}
