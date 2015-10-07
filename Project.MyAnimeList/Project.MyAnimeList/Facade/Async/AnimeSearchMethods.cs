using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;

namespace MyAnimeListSharp.Facade.Async
{
	public class AnimeSearchMethods : MyAnimeListMethodsAsync
	{
		public AnimeSearchMethods(ICredentialContext credentialContext) 
			: base(credentialContext)
		{
		}
	}
}