using Project.MyAnimeList.Web;

namespace Project.MyAnimeList.Facade
{
	public class AccountMethods : MyAnimeListMethods
	{
		public AccountMethods(RequestParameters requestParameters)
		{
			RequestParameters = requestParameters;
		}

		public string VerifyCredentials()
		{
			return GetResponseText(WebRequestBuilder.BuildWebRequest(RequestParameters));
		}
	}
}