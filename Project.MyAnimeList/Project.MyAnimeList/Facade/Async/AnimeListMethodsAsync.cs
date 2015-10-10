using MyAnimeListSharp.Auth;

namespace MyAnimeListSharp.Facade.Async
{
	public class AnimeListMethodsAsync
	{
		private ICredentialContext credentialContext;

		public AnimeListMethodsAsync(ICredentialContext credentialContext)
		{
			this.credentialContext = credentialContext;
		}
	}
}