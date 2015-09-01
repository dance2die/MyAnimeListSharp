using System;
using Project.MyAnimeList.Auth;
using Project.MyAnimeList.Facade;

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
			string responseFromServer  = new AccountMethods(credential).VerifyCredentials();

			Console.WriteLine(responseFromServer);
		}
	}
}
