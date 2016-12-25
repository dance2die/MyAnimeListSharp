using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
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
            var requestBuilder = new HttpWebRequestBuilder(requestParameters);
            var request = requestBuilder.BuildWebRequest();

            try
            {
                var response = request.GetResponse() as HttpWebResponse;
                using (var responseStream = response.GetResponseStream())
                using (var reader = new StreamReader(responseStream))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (WebException wex)
            {
                // http://stackoverflow.com/a/7618390/4035
                if (wex.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse) wex.Response)
                    using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                    {
                        string error = reader.ReadToEnd();
                        return error;
                    }
                }
            }

            throw new InvalidOperationException();
        }

        protected async Task<string> GetResponseTextAsync(RequestParameters requestParameters)
        {
            var requestBuilder = new HttpWebRequestBuilder(requestParameters);
            var request = await requestBuilder.BuildWebRequestAsync();

            try
            {
                using (HttpWebResponse response = (HttpWebResponse) await Task.Factory.FromAsync<WebResponse>(
                    request.BeginGetResponse, request.EndGetResponse, request).ConfigureAwait(false))
                using (Stream responseStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    return await reader.ReadToEndAsync().ConfigureAwait(false);
                }
            }
            catch (WebException wex)
            {
                // http://stackoverflow.com/a/7618390/4035
                if (wex.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse) wex.Response)
                    using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                    {
                        string error = reader.ReadToEnd();
                        return error;
                    }
                }
            }

            throw new InvalidOperationException();
        }

        protected string GetDataStringFromMyAnimeListValues(MyAnimeListValues values)
        {
            var formatterFactory = new ValuesFormatterFactory();
            dynamic formatter = formatterFactory.Create(values);

            // https://coding.abel.nu/2012/04/dynamic-overload-resolution/
            return formatter.Format((dynamic) values);
        }
    }
}