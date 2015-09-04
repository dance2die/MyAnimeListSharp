﻿using Project.MyAnimeList.Auth;

namespace Project.MyAnimeList.Web
{
	public class MangaSearchRequestParameters : SearchRequestParameters
	{
		public override string BaseUri { get; set; } = "http://myanimelist.net/api/manga/search.xml";

		public MangaSearchRequestParameters(ICredentialContext credentialContext, string searchTerm)
			: base(credentialContext, searchTerm)
		{
		}
	}
}