using System;

namespace MyAnimeListSharp.Auth
{
	public class CredentialContext : ICredentialContext
	{
		public string UserName { get; set; } =
			Environment.GetEnvironmentVariable("Project_MyAnimeList.UserName", EnvironmentVariableTarget.User);
		public string Password { get; set; } =
			Environment.GetEnvironmentVariable("Project_MyAnimeList.Password", EnvironmentVariableTarget.User);
	}
}