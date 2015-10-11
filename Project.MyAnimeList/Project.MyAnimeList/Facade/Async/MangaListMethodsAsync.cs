using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;

namespace MyAnimeListSharp.Facade.Async
{
	public class MangaListMethodsAsync : MyAnimeListMethodsAsync
	{
		public MangaListMethodsAsync(ICredentialContext credentialContext) 
			: base(credentialContext)
		{
		}
	}
}