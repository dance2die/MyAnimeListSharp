using System.IO;
using System.Net;
using System.Threading.Tasks;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Parameters;
using MyAnimeListSharp.Util;

namespace MyAnimeListSharp.Core
{
	/// <summary>
	/// Provides Async version of methods for MyAnimeListMethods
	/// </summary>
	public class MyAnimeListMethodsAsync : MyAnimeListMethods
	{
		protected MyAnimeListMethodsAsync(ICredentialContext credentialContext) 
			: base(credentialContext)
		{
		}

		protected async Task<string> GetResponseTextAsync(RequestParameters requestParameters)
		{
			var requestBuilder = new HttpWebRequestBuilder(requestParameters);
			var request = await requestBuilder.BuildWebRequestAsync();

			using (HttpWebResponse response = (HttpWebResponse) await Task.Factory.FromAsync<WebResponse>(
				request.BeginGetResponse, request.EndGetResponse, request).ConfigureAwait(false))
			using (Stream responseStream = response.GetResponseStream())
			using (StreamReader reader = new StreamReader(responseStream))
			{
				return await reader.ReadToEndAsync().ConfigureAwait(false);
			}
		}
	}
}