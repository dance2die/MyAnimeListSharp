using System;
using MyAnimeListSharp.Parameters;
using MyAnimeListSharp.Util;
using Project.MyAnimeList.Test.Fixture;
using Xunit;
using Xunit.Abstractions;

namespace Project.MyAnimeList.Test.Tests
{
	public class MangaListMethodsTest : 
		CredentialCollectionTest, 
		IClassFixture<MangaValuesFixture>,
		IClassFixture<MangaListMethodsFixture>
	{
		private readonly ITestOutputHelper _output;
		private readonly MangaValuesFixture _mangaValuesFixture;
		private readonly MangaListMethodsFixture _mangaListMethodsFixture;

		/// <summary>
		/// Gate: Jieitai Kanochi nite, Kaku Tatakaeri
		/// http://myanimelist.net/manga/67879/Gate:_Jieitai_Kanochi_nite_Kaku_Tatakaeri
		/// </summary>
		private const int ID = 67879;

		private readonly string _data =
			@"<?xml version = ""1.0"" encoding=""UTF-8"" ?>
			<entry>
				<chapter>40</chapter>
				<volume>1</volume>
				<status>1</status>
				<score>9</score>
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

		public MangaListMethodsTest(
			CredentialContextFixture credentialContextFixture, 
			ITestOutputHelper output,
			MangaValuesFixture mangaValuesFixture,
			MangaListMethodsFixture mangaListMethodsFixture)
			: base(credentialContextFixture)
		{
			_output = output;
			_mangaValuesFixture = mangaValuesFixture;
			_mangaListMethodsFixture = mangaListMethodsFixture;
		}

		[Fact]
		public void AddMangaRequestParametersMethodReturnsPostHttpMethod()
		{
			var sut = new AddMangaRequestParameters(CredentialContextFixture.CredentialContext, ID, _data);

			Assert.Equal("POST", sut.HttpMethod);
		}

		[Fact]
		public void TestAddMangaRequestParametersBaseUri()
		{
			var requestParameters = new AddMangaRequestParameters(CredentialContextFixture.CredentialContext, ID, _data);
			var sut = new RequestUriBuilder(requestParameters);

			var actualUri = sut.GetRequestUri();

			Assert.Equal($"http://myanimelist.net/api/mangalist/add/{ID}.xml", actualUri);
		}

		[Fact]
		public void AddMangaRequestResponseContainsCreatedText()
		{
			var sut = _mangaListMethodsFixture.MangaListMethods;

			const string expectedSubstring = "Created";
			var actualResponseString = sut.AddManga(ID, _data);

			_output.WriteLine(actualResponseString);
			Assert.Contains(expectedSubstring, actualResponseString);
		}

		[Fact]
		public void AddMangaUsingMangaValuesObjectInstance()
		{
			var sut = _mangaListMethodsFixture.MangaListMethods;

			const string expectedSubstring = "Created";
			var actualResponseString = sut.AddManga(ID, _mangaValuesFixture.Values);

			Assert.Contains(expectedSubstring, actualResponseString);
		}

		[Fact]
		public void UpdateMangaRequestReturnsUpdatedText()
		{
			var sut = _mangaListMethodsFixture.MangaListMethods;

			var actualResponseString = sut.UpdateManga(ID, _data);

			_output.WriteLine("Actual: {0}", actualResponseString);
			Assert.Equal("Updated", actualResponseString);
		}

		[Fact]
		public void UpdateMangaUsingMangaValuesObjectInstance()
		{
			var sut = _mangaListMethodsFixture.MangaListMethods;

			var actualResponseString = sut.UpdateManga(ID, _mangaValuesFixture.Values);
			_output.WriteLine("Actual: {0}", actualResponseString);

			const string expected = "Updated";
			Assert.True(string.Compare(expected, actualResponseString, StringComparison.InvariantCultureIgnoreCase) == 0);
		}


		[Fact]
		public void DeleteMangaRequestReturnsDeletedText()
		{
			var sut = _mangaListMethodsFixture.MangaListMethods;

			var actualResponseString = sut.DeleteManga(ID);

			_output.WriteLine("Actual: {0}", actualResponseString);
			Assert.Equal("Deleted", actualResponseString);
		}
	}
}
