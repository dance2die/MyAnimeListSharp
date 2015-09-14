using System;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Parameters;

namespace MyAnimeListSharp.Facade
{
	public class MangaListMethods : MyAnimeListMethods
	{
		public MangaListMethods(ICredentialContext credentialContext)
			: base(credentialContext)
		{
		}

		public string AddManga(int? id, string data)
		{
			return GetResponseText(new AddMangaRequestParameters(CredentialContext, id, data));
		}

		public string AddManga(int? id, MangaValues mangaValues)
		{
			string data = GetDataStringFromMyAnimeListValues(mangaValues);
			return AddManga(id, data);
		}

		public string UpdateManga(int? id, string data)
		{
			return GetResponseText(new UpdateMangaRequestParameters(CredentialContext, id, data));
		}

		public string UpdateManga(int? id, MangaValues mangaValues)
		{
			string data = GetDataStringFromMyAnimeListValues(mangaValues);
			return UpdateManga(id, data);
		}

		public string DeleteManga(int? id)
		{
			return GetResponseText(new DeleteMangaRequestParameters(CredentialContext, id));
		}
	}
}