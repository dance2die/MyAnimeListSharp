using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Parameters;

namespace MyAnimeListSharp.Facade
{
	/// <summary>
	/// Represents a "Manga List Methods" section in MyAnimeList.net specification.
	/// <see cref="http://myanimelist.net/modules.php?go=api"/>
	/// </summary>
	public class MangaListMethods : MyAnimeListMethods
	{
		public MangaListMethods(ICredentialContext credentialContext)
			: base(credentialContext)
		{
		}

		/// <summary>
		/// Add Manga info by ID
		/// </summary>
		/// <param name="id">Manga ID on MyAnimeList.net</param>
		/// <param name="data">XML string specified on MyAnimeList.net</param>
		/// <returns>
		/// Response from the server in raw string whether manga was added correctly or not
		/// </returns>
		public string AddManga(int? id, string data)
		{
			return GetResponseText(new AddMangaRequestParameters(CredentialContext, id, data));
		}

		/// <summary>
		/// Add Manga info by ID
		/// </summary>
		/// <param name="id">Manga ID on MyAnimeList.net</param>
		/// <param name="mangaValues">object that represents XML specification</param>
		/// <returns>
		/// Response from the server in raw string whether manga was added correctly or not
		/// </returns>
		public string AddManga(int? id, MangaValues mangaValues)
		{
			var data = GetDataStringFromMyAnimeListValues(mangaValues);
			return AddManga(id, data);
		}

		/// <summary>
		/// Update Manga info by ID
		/// </summary>
		/// <param name="id">Manga ID on MyAnimeList.net</param>
		/// <param name="data">XML string specified on MyAnimeList.net</param>
		/// <returns>Response from the server in raw string whether manga was added correctly or not</returns>
		public string UpdateManga(int? id, string data)
		{
			return GetResponseText(new UpdateMangaRequestParameters(CredentialContext, id, data));
		}

		/// <summary>
		/// Update Manga info by ID
		/// </summary>
		/// <param name="id">Manga ID on MyAnimeList.net</param>
		/// <param name="mangaValues">object that represents XML specification</param>
		/// <returns>Response from the server in raw string whether manga was added correctly or not</returns>
		public string UpdateManga(int? id, MangaValues mangaValues)
		{
			var data = GetDataStringFromMyAnimeListValues(mangaValues);
			return UpdateManga(id, data);
		}

		/// <summary>
		/// Delete Manga info by ID
		/// </summary>
		/// <param name="id">Manga review to delete</param>
		public string DeleteManga(int? id)
		{
			return GetResponseText(new DeleteMangaRequestParameters(CredentialContext, id));
		}
	}
}