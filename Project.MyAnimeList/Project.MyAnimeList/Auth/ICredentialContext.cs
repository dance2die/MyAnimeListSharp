namespace Project.MyAnimeList.Auth
{
	public interface ICredentialContext
	{
		string UserName { get; set; }
		string Password { get; set; }
	}
}
