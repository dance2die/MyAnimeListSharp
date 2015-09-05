using System;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Facade;

namespace Project.MyAnimeList.Demo
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// Step 1: Enter UserName and Password information
			ICredentialContext credential = new CredentialContext
			{
				UserName = "<MyAnimeList.NET UserName>",
				Password = "<MyAnimeList.NET Password>"
			};

			// Step 2: Create a method object
			var searchMethods = new SearchMethods(credential);

			// Step 3: Search using the search term ("Full Metal" in this case)
			string mangaResponse = searchMethods.SearchManga("Code Geass");
			Console.WriteLine(mangaResponse);

			// Step 3: Search using the search term ("Full Metal" in this case)
			string animeResponse = searchMethods.SearchAnime("Full Metal");
			Console.WriteLine(animeResponse);


			//TestCredentials(credential);

			Console.WriteLine("Press ENTER to continue...");
			Console.ReadLine();
		}


		//private static void TestCredentials(ICredentialContext credential)
		//{
		//	string responseFromServer  = new AccountMethods(credential).VerifyCredentials();

		//	Console.WriteLine(responseFromServer);
		//}
	}
}
