using MyAnimeListSharp.Facade;
using Project.MyAnimeList.Test.Fixture;
using Xunit.Abstractions;

namespace Project.MyAnimeList.Test.Tests
{
	public class MangaValuesTest : CredentialCollectionTest
	{
		private const string XML_DECLARATION = @"<?xml version=""1.0"" encoding=""UTF-8""?>";

		private readonly ITestOutputHelper _output;
		private readonly MangaValues _sut;

		private readonly string _data =
				XML_DECLARATION +
			@"<entry>
				<chapter>6</chapter>
				<volume>1</volume>
				<status>1</status>
				<score>8</score>
				<downloaded_chapters></downloaded_chapters>
				<times_reread></times_reread>
				<reread_value></reread_value>
				<date_start></date_start>
				<date_finish></date_finish>
				<priority></priority>
				<enable_discussion></enable_discussion>
				<enable_rereading></enable_rereading>
				<comments></comments>
				<scan_group></scan_group>
				<tags></tags>
				<retail_volumes></retail_volumes>
			</entry>";


		public MangaValuesTest(CredentialContextFixture credentialContextFixture, ITestOutputHelper output) 
			: base(credentialContextFixture)
		{
			_output = output;
			_sut = new MangaValues();
		}


	}
}
