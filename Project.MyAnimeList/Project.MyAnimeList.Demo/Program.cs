using System;
using System.Collections.Generic;
using System.Reflection;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Enums;
using MyAnimeListSharp.Facade;

namespace Project.MyAnimeList.Demo
{
	public class Program
	{
		/// <summary>
		/// Gate: Jieitai Kanochi nite, Kaku Tatakaeri
		/// http://myanimelist.net/anime/28907/Gate:_Jieitai_Kanochi_nite_Kaku_Tatakaeri
		/// http://myanimelist.net/manga/67879/Gate:_Jieitai_Kanochi_nite_Kaku_Tatakaeri
		/// </summary>
		private const int ANIME_ID = 28907;
		private const int MANGA_ID = 67879;

		private static readonly string _animeData =
			@"<?xml version = ""1.0"" encoding = ""UTF-8""?>
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
				</entry>";

		private static readonly string _mangaData =
			@"<?xml version=""1.0"" encoding=""UTF-8""?>
			<entry>
				<chapter>6</chapter>
				<volume>1</volume>
				<status>1</status>
				<score>8</score>
				<downloaded_chapters></downloaded_chapters>
				<times_reread></times_reread>
				<reread_value></reread_value>
				<date_start></date_start>
				<date_finish></date_finish>
				<priority>0</priority>
				<enable_discussion></enable_discussion>
				<enable_rereading></enable_rereading>
				<comments></comments>
				<scan_group></scan_group>
				<tags></tags>
				<retail_volumes></retail_volumes>
			</entry>";


		public static void Main(string[] args)
		{
			ICredentialContext credential = new CredentialContext();

			//TestSearch(credential);
			//TestCredentials(credential);
			//TestAddAnime(credential);
			//TestAddManga(credential);
			TestAddAnimeByObject(credential);

			Console.WriteLine("Press ENTER to continue...");
			Console.ReadLine();
		}

		private static void TestAddAnimeByObject(ICredentialContext credential)
		{
			var methods = new AnimeListMethods(credential);
			var animeValues = new AnimeValues
			{
				AnimeStatus = AnimeStatus.Watching,
				Comments = "It was a great series."
			};
			var responseText = methods.AddAnime(ANIME_ID, animeValues);

			Console.WriteLine(responseText);
		}

		private static void TestAddAnime(ICredentialContext credential)
		{
			var methods = new AnimeListMethods(credential);
			var responseText = methods.AddAnime(ANIME_ID, _animeData);

			Console.WriteLine(responseText);
		}

		private static void TestAddManga(ICredentialContext credential)
		{
			var methods = new MangaListMethods(credential);
			methods.AddManga(MANGA_ID, _mangaData);
		}

		private static void TestSearch(ICredentialContext credential)
		{
			//// Step 1: Enter UserName and Password information
			//ICredentialContext credential = new CredentialContext
			//{
			//	UserName = "<MyAnimeList.NET UserName>",
			//	Password = "<MyAnimeList.NET Password>"
			//};

			// Step 2: Create a method object
			var searchMethods = new SearchMethods(credential);

			// Step 3: Search using the search term ("Full Metal" in this case)
			string mangaResponse = searchMethods.SearchManga("Code Geass");
			Console.WriteLine(mangaResponse);

			// Step 3: Search using the search term ("Full Metal" in this case)
			string animeResponse = searchMethods.SearchAnime("Full Metal");
			Console.WriteLine(animeResponse);
		}

		private static void TestCredentials(ICredentialContext credential)
		{
			string responseFromServer = new AccountMethods(credential).VerifyCredentials();

			Console.WriteLine(responseFromServer);
		}
	}
}
