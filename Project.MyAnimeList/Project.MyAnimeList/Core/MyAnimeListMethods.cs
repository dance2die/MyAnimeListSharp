using System.IO;
using System.Net;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Formatters;
using MyAnimeListSharp.Parameters;
using MyAnimeListSharp.Util;

namespace MyAnimeListSharp.Core
{
	public abstract class MyAnimeListMethods
	{
		protected ICredentialContext CredentialContext { get; }

		protected MyAnimeListMethods(ICredentialContext credentialContext)
		{
			CredentialContext = credentialContext;
		}

		/// <summary>
		///     Template method to return response text
		/// </summary>
		protected string GetResponseText(RequestParameters requestParameters)
		{
			var requestBuilder = new WebRequestBuilder(requestParameters);
			var request = requestBuilder.BuildWebRequest();

			using (var response = request.GetResponse() as HttpWebResponse)
			using (var responseStream = response.GetResponseStream())
			using (var reader = new StreamReader(responseStream))
			{
				return reader.ReadToEnd();
			}
		}

		protected string GetDataStringFromMyAnimeListValues(MyAnimeListValues values)
		{
			var formatterFactory = new ValuesFormatterFactory();
			dynamic formatter = formatterFactory.Create(values);

			// https://coding.abel.nu/2012/04/dynamic-overload-resolution/
			return formatter.Format((dynamic)values);
		}
	}
}