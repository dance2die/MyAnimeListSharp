#There was a breaking MAL API changes.
## A new version 1.3.2 was released which addresses changes made in MAP API on November 2016.


# Welcome to MyAnimeListSharp
## The "Easiest" way to search Anime/Manga

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
 
### Asynchronous versions of facades are added in Version 1.3
####The difference between Synchronous and Asynchronous version:
`SearchMethods` is separated into two different files (subject to change in later version): 

1. [MangaSearchMethodsAsync.cs](https://github.com/dance2die/Project.MyAnimeList/blob/master/Project.MyAnimeList/Project.MyAnimeList/Facade/Async/MangaSearchMethodsAsync.cs)
2. [AnimeListMethodsAsync.cs](https://github.com/dance2die/Project.MyAnimeList/blob/master/Project.MyAnimeList/Project.MyAnimeList/Facade/Async/AnimeListMethodsAsync.cs)
![Image of Comparison](http://i.imgur.com/vNGVgQf.png)

###Source is located under
[Project.MyAnimeList/Project.MyAnimeList/Project.MyAnimeList/Facade/Async](https://github.com/dance2die/Project.MyAnimeList/tree/master/Project.MyAnimeList/Project.MyAnimeList/Facade/Async)


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

### Search Manga Asynchronously: New* in Version 1.3
```c#
	ICredentialContext credential = new CredentialContext
	{
		UserName = "<MyAnimeList.NET UserName>",
		Password = "<MyAnimeList.NET Password>"
	};
	
	var asyncMangaSearcher = new MangaSearchMethodsAsync(credential);
	var response = await asyncMangaSearcher.SearchAsync("Dagashi Kashi");
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

### Search Anime Asynchronously: New* in Version 1.3
```c#
	ICredentialContext credential = new CredentialContext
	{
		UserName = "<MyAnimeList.NET UserName>",
		Password = "<MyAnimeList.NET Password>"
	};

	var asyncAnimeSearcher = new AnimeSearchMethodsAsync(credential);
	var response = await asyncAnimeSearcher.SearchAsync("Naruto");
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


### Convert Response object to XML/JSON strings: New* in Version 1.3.1
```c#
	var asyncMangaSearcher = new MangaSearchMethodsAsync(credential);
	MangaSearchResponse response = await asyncMangaSearcher.SearchDeserializedAsync("Dagashi Kashi");

	Console.WriteLine(response.ToJson());
	Console.WriteLine(response.ToXml());
```
