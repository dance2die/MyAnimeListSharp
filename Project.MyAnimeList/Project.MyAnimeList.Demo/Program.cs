using System;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Facade;

namespace Project.MyAnimeList.Demo
{
	public class Program
	{
		/// <summary>
		/// Gate: Jieitai Kanochi nite, Kaku Tatakaeri
		/// http://myanimelist.net/anime/28907/Gate:_Jieitai_Kanochi_nite_Kaku_Tatakaeri
		/// </summary>
		private const int ID = 28907;

		private static readonly string _data =
			@"<? xml version = ""1.0"" encoding = ""UTF -8"" ?>
				<entry>
					<episode>9</episode>
					<status>1</status>
					<score>9</score>
					<downloaded_episodes></downloaded_episodes>
					<storage_type></storage_type>
					<storage_value></storage_value>
					<times_rewatched></times_rewatched>
					<rewatch_value></rewatch_value>
					<date_start></date_start>
					<date_finish></date_finish>
					<priority></priority>
					<enable_discussion></enable_discussion>
					<enable_rewatching></enable_rewatching>
					<comments></comments>
					<fansub_group></fansub_group>
					<tags>test tag, 2nd tag</tags>
				</ entry>";


		public static void Main(string[] args)
		{
			ICredentialContext credential = new CredentialContext();

			//TestSearch();
			//TestCredentials(credential);
			TestAddAnime(credential);

			Console.WriteLine("Press ENTER to continue...");
			Console.ReadLine();
		}

		private static void TestAddAnime(ICredentialContext credential)
		{
			var methods = new AnimeListMethods(credential);
			methods.AddAnime(ID, _data);
		}

		private static void TestSearch()
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
		}


		//private static void TestCredentials(ICredentialContext credential)
		//{
		//	string responseFromServer  = new AccountMethods(credential).VerifyCredentials();

		//	Console.WriteLine(responseFromServer);
		//}
	}
}
