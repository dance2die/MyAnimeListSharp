using MyAnimeListSharp.Auth;

namespace MyAnimeListSharp.Core
{
	/// <summary>
	/// Provides Async version of methods for MyAnimeListMethods
	/// </summary>
	public class MyAnimeListMethodsAsync : MyAnimeListMethods
	{
		protected MyAnimeListMethodsAsync(ICredentialContext credentialContext) 
			: base(credentialContext)
		{
		}
	}
}