using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.MyAnimeList.Test.Fixture;

namespace Project.MyAnimeList.Test.Tests
{
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// <see cref="http://stackoverflow.com/a/23004036/4035"/>
	/// </remarks>
	public class AnimeSearchMethods : CredentialCollectionTest
	{
		public AnimeSearchMethods(CredentialContextFixture credentialContextFixture) 
			: base(credentialContextFixture)
		{
		}
	}
}
