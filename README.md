# Welcome to MyAnimeListSharp
## The "Easiest" way to search Anime/Manga on MyAnimeList.net

* **What**: .NET library for accessing MyAnimeList.net Web API ([API Documentation](http://myanimelist.net/modules.php?go=api))
* **Framework**: .NET 4.5.2
* **Contact Info**: [@dance2die](https://twitter.com/dance2die)
* **License**: [The MIT License](http://opensource.org/licenses/MIT)


## Overview
### Facade makes the coding "Simple" and "Easy" to use.
There is a 1:1 matching between the Web API and the source code.
![Image of Facade](http://i.imgur.com/IwUvS8w.jpg)

These four [facade](https://github.com/dance2die/Project.MyAnimeList/tree/master/Project.MyAnimeList/Project.MyAnimeList/Facade) classes are the only classes you need to deal with.
* [AccountMethods.cs](https://github.com/dance2die/Project.MyAnimeList/blob/master/Project.MyAnimeList/Project.MyAnimeList/Facade/AccountMethods.cs)
* [AnimeListMethods.cs](https://github.com/dance2die/Project.MyAnimeList/blob/master/Project.MyAnimeList/Project.MyAnimeList/Facade/AnimeListMethods.cs)
* [MangaListMethods.cs](https://github.com/dance2die/Project.MyAnimeList/blob/master/Project.MyAnimeList/Project.MyAnimeList/Facade/MangaListMethods.cs)
* [SearchMethods.cs](https://github.com/dance2die/Project.MyAnimeList/blob/master/Project.MyAnimeList/Project.MyAnimeList/Facade/SearchMethods.cs)
 

## How to Install
### Nuget
[Install-Package MyAnimeListSharp](https://www.nuget.org/packages/MyAnimeListSharp/)


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

### Add Anime
```c#
	var methods = new AnimeListMethods(credential);
	var animeValues = new AnimeValues
	{
		AnimeStatus = AnimeStatus.Watching,
		Comments = "It was a great series."
	};
	var responseText = methods.AddAnime(ANIME_ID, animeValues);
	Console.WriteLine(responseText);
```

### Add Manga
```c#
	var methods = new MangaListMethods(credential);
	var mangaValues = new MangaValues
	{
		MangaStatus = MangaStatus.Reading,
		Comments = "I am planning to read this"
	};
	var responseText = methods.AddManga(MANGA_ID, mangaValues);
	Console.WriteLine(responseText);
```


## Plan for the Next Release
* Search/Add/Update [Asynchronously](https://github.com/dance2die/Project.MyAnimeList/tree/master/Project.MyAnimeList/Project.MyAnimeList/Facade/Async)
* Convert Deserialized response objects to different formats like JSON or XML: will be performed using Extension methods
