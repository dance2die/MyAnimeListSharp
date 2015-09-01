using System;
using Project.MyAnimeList.Auth;
using Project.MyAnimeList.Facade;
using Project.MyAnimeList.Web;

namespace Project.MyAnimeList.Demo
{
	public class Program
	{
		public static void Main(string[] args)
		{
			ICredentialContext credential = new CredentialContext();

			TestCredentials(credential);

			Console.WriteLine("Press ENTER to continue...");
			Console.ReadLine();
		}

		private static void TestCredentials(ICredentialContext credential)
		{
			RequestParameters requestParameters = new VerifyCredentialsRequestParameters(credential);
			string responseFromServer  = new AccountMethods(requestParameters).VerifyCredentials();

			Console.WriteLine(responseFromServer);
		}
	}
}
