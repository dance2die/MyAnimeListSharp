using System.IO;
using System.Net;
using Project.MyAnimeList.Web;

namespace Project.MyAnimeList.Facade
{
	public abstract class MyAnimeListMethods
	{
		public RequestParameters RequestParameters { get; set; }

		protected string GetResponseText(HttpWebRequest request)
		{
			using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
			using (Stream responseStream = response.GetResponseStream())
			using (StreamReader reader = new StreamReader(responseStream))
			{
				return reader.ReadToEnd();
			}
		}
	}
}