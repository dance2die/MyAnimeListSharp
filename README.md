# Welcome to MyAnimeListSharp

* **What**: .NET library for accessing MyAnimeList.net Web API ([API Documentation](http://myanimelist.net/modules.php?go=api))
* **Framework**: .NET 4.5.2



## How to Install
### Nuget
[Install-Package MyAnimeListSharp](https://www.nuget.org/packages/MyAnimeListSharp/1.0.0)


## Examples
### Search Manga
			// Step 1: Enter UserName and Password information
			ICredentialContext credential = new CredentialContext
			{
				UserName = "<MyAnimeList.NET UserName>",
				Password = "<MyAnimeList.NET Password>"
			};

			// Step 2: Create a method object
			var searchMethods = new SearchMethods(credential);

			// Step 3: Search using the search term ("Full Metal" in this case)
			string response = searchMethods.SearchAnime("Full Metal");
			

### Search Anime
			// Step 1: Enter UserName and Password information
			ICredentialContext credential = new CredentialContext
			{
				UserName = "<MyAnimeList.NET UserName>",
				Password = "<MyAnimeList.NET Password>"
			};

			// Step 2: Create a method object
			var searchMethods = new SearchMethods(credential);

			// Step 3: Search using the search term ("Code Geass" in this case)
			string mangaResponse = searchMethods.SearchManga("Code Geass");
			Console.WriteLine(mangaResponse);



## Note
For some reason, Add/Update Anime methods return errors from MyAnimeList.net server.
I created unit tests under an assumption that they are not functional
