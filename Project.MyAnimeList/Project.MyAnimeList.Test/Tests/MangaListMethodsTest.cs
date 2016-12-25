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
            var sut = new AddMangaRequestParameters(CredentialContextFixture.CredentialContext, MangaValuesFixture.ID,
                MangaValuesFixture.Data);

            const string expected = "GET";
            Assert.Equal(expected, sut.HttpMethod);
        }

        [Fact]
        public void TestAddMangaRequestParametersBaseUri()
        {
            var requestParameters = new AddMangaRequestParameters(CredentialContextFixture.CredentialContext,
                MangaValuesFixture.ID, MangaValuesFixture.Data);
            var sut = new RequestUriBuilder(requestParameters);

            var actual = sut.GetRequestUri();

            string expected =
                $"https://myanimelist.net/api/mangalist/add/{MangaValuesFixture.ID}.xml?data=%3C%3Fxml%20version%20%3D%20%221.0%22%20encoding%3D%22UTF-8%22%20%3F%3E%0D%0A%09%09%09%3Centry%3E%0D%0A%09%09%09%09%3Cchapter%3E40%3C%2Fchapter%3E%0D%0A%09%09%09%09%3Cvolume%3E1%3C%2Fvolume%3E%0D%0A%09%09%09%09%3Cstatus%3E1%3C%2Fstatus%3E%0D%0A%09%09%09%09%3Cscore%3E9%3C%2Fscore%3E%0D%0A%09%09%09%09%3Ctimes_reread%3E%3C%2Ftimes_reread%3E%0D%0A%09%09%09%09%3Creread_value%3E%3C%2Freread_value%3E%0D%0A%09%09%09%09%3Cdate_start%3E%3C%2Fdate_start%3E%0D%0A%09%09%09%09%3Cdate_finish%3E%3C%2Fdate_finish%3E%0D%0A%09%09%09%09%3Cpriority%3E%3C%2Fpriority%3E%0D%0A%09%09%09%09%3Cenable_discussion%3E%3C%2Fenable_discussion%3E%0D%0A%09%09%09%09%3Cenable_rereading%3E%3C%2Fenable_rereading%3E%0D%0A%09%09%09%09%3Ccomments%3E%3C%2Fcomments%3E%0D%0A%09%09%09%09%3Cscan_group%3E%3C%2Fscan_group%3E%0D%0A%09%09%09%09%3Ctags%3E%3C%2Ftags%3E%0D%0A%09%09%09%09%3Cretail_volumes%3E%3C%2Fretail_volumes%3E%0D%0A%09%09%09%3C%2Fentry%3E";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddMangaRequestResponseReturnsUniqueRowId()
        {
            var sut = _mangaListMethodsFixture.MangaListMethods;

            var actualResponseString = sut.AddManga(MangaValuesFixture.ID, MangaValuesFixture.Data);

            _output.WriteLine(actualResponseString);

            // If no record was added, then a unique ID returned,
            int uniqueId;
            bool isNumber = int.TryParse(actualResponseString, out uniqueId);
            // Else "201 Created" response is returned.
            bool hasCreatedTextInIt = actualResponseString.Contains("Created");

            Assert.True(isNumber || hasCreatedTextInIt);
        }

        [Fact]
        public void AddMangaUsingMangaValuesObjectInstance()
        {
            var sut = _mangaListMethodsFixture.MangaListMethods;

            var actualResponseString = sut.AddManga(MangaValuesFixture.ID, _mangaValuesFixture.Values);

            // If no record was added, then a unique ID returned,
            int uniqueId;
            bool isNumber = int.TryParse(actualResponseString, out uniqueId);
            // Else "201 Created" response is returned.

            string alreadyExistsText = $"The manga (id: {MangaValuesFixture.ID}) is already in the list.";
            bool isMangaAlreadyAdded = actualResponseString == alreadyExistsText;

            Assert.True(isNumber || isMangaAlreadyAdded);
        }

        [Fact]
        public void UpdateMangaRequestReturnsUpdatedText()
        {
            var sut = _mangaListMethodsFixture.MangaListMethods;

            var actualResponseString = sut.UpdateManga(MangaValuesFixture.ID, MangaValuesFixture.Data);

            _output.WriteLine("Actual: {0}", actualResponseString);
            Assert.Equal("Updated", actualResponseString);
        }

        [Fact]
        public void UpdateMangaUsingMangaValuesObjectInstance()
        {
            var sut = _mangaListMethodsFixture.MangaListMethods;

            var actualResponseString = sut.UpdateManga(MangaValuesFixture.ID, _mangaValuesFixture.Values);
            _output.WriteLine("Actual: {0}", actualResponseString);

            const string expected = "Updated";
            Assert.True(string.Compare(expected, actualResponseString, StringComparison.InvariantCultureIgnoreCase) == 0);
        }


        [Fact]
        public void DeleteMangaRequestReturnsDeletedText()
        {
            var sut = _mangaListMethodsFixture.MangaListMethods;

            var actualResponseString = sut.DeleteManga(MangaValuesFixture.ID);

            _output.WriteLine("Actual: {0}", actualResponseString);
            Assert.Equal("Deleted", actualResponseString);
        }
    }
}