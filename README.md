# Welcome to MyAnimeListSharp

* **What**: .NET library for accessing MyAnimeList.net Web API ([API Documentation](http://myanimelist.net/modules.php?go=api))
* **Framework**: .NET 4.5.2
* **Contact Info**: [@dance2die](https://twitter.com/dance2die)
* **License**: [The MIT License](http://opensource.org/licenses/MIT)


## How to Install
### Nuget
[Install-Package MyAnimeListSharp](https://www.nuget.org/packages/MyAnimeListSharp/1.0.0)


## Examples
### Search Manga
```c#
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
```

### Search Anime
```c#
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
```


## Note
For some reason, Add/Update Anime methods return errors from MyAnimeList.net server.
I created unit tests under an assumption that they are not functional


## Overview
### Facade of MyAnimeList Web API
There is a 1:1 matching between the Web API and the source code.
Note that `MyAnimeListMethods` is a base class, which is not to be usually used by your code (unless you are implementing a factory class to return different type of *Methods object instance.)
![Image of Facade](http://i.imgur.com/iMbqzEj.png)

These four [facade](https://github.com/dance2die/Project.MyAnimeList/tree/master/Project.MyAnimeList/Project.MyAnimeList/Facade) classes are the only classes you need to be concerned with.
* [AccountMethods.cs](https://github.com/dance2die/Project.MyAnimeList/blob/master/Project.MyAnimeList/Project.MyAnimeList/Facade/AccountMethods.cs)
* [AnimeListMethods.cs](https://github.com/dance2die/Project.MyAnimeList/blob/master/Project.MyAnimeList/Project.MyAnimeList/Facade/AnimeListMethods.cs)
* [MangaListMethods.cs](https://github.com/dance2die/Project.MyAnimeList/blob/master/Project.MyAnimeList/Project.MyAnimeList/Facade/MangaListMethods.cs)
* [SearchMethods.cs](https://github.com/dance2die/Project.MyAnimeList/blob/master/Project.MyAnimeList/Project.MyAnimeList/Facade/SearchMethods.cs)


