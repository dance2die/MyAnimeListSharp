using Xunit;
using Xunit.Abstractions;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Formatters;
using MyAnimeListSharp.Util;

namespace Project.MyAnimeList.Test.Tests
{
	public class AnimeSearchResponseFormatterTest : SearchResponseFormatterTestBase
	{
		private readonly ITestOutputHelper _output;

		private const string RESPONSE_TEXT = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<anime>
  <entry>
    <id>71</id>
    <title>Full Metal Panic!</title>
    <english>Full Metal Panic!</english>
    <synonyms>FMP; Fullmetal Panic!</synonyms>
    <episodes>24</episodes>
    <score>7.86</score>
    <type>TV</type>
    <status>Finished Airing</status>
    <start_date>2002-01-08</start_date>
    <end_date>2002-06-18</end_date>
    <synopsis>Sousuke Sagara, a seventeen-year-old military specialist working for the secret organization MITHRIL, has been assigned to protect the latest &amp;quot;Whispered&amp;quot; candidate Kaname Chidori. To complete this task Sousuke will have to deal with enemies from his past as well as the occasional panty thief. Unfortunately for Sousuke, the toughest part of his mission isn't only protecting Miss Chidori but also getting used to living an average high school student's life, which is no easy task for someone raised on the battlefield.&lt;br /&gt;
&lt;br /&gt;
(Source: ANN, edited)</synopsis>
    <image>http://cdn.myanimelist.net/images/anime/2/75259.jpg</image>
  </entry>
  <entry>
    <id>72</id>
    <title>Full Metal Panic? Fumoffu</title>
    <english>Full Metal Panic? Fumoffu</english>
    <synonyms>Full Metal Panic Fumoffu; Fullmetal Panic? Fumoffu</synonyms>
    <episodes>12</episodes>
    <score>8.26</score>
    <type>TV</type>
    <status>Finished Airing</status>
    <start_date>2003-08-26</start_date>
    <end_date>2003-10-18</end_date>
    <synopsis>It's back-to-school mayhem with Kaname Chidori and her war-freak classmate Sousuke Sagara as they encounter more misadventures in and out of Jindai High School. But when Kaname gets into some serious trouble, Sousuke takes the guise of Bonta-kun&amp;mdash;the gun-wielding, butt-kicking mascot. And while he struggles to continue living as a normal teenager, Sousuke also has to deal with protecting his superior officer Teletha Testarossa, who has decided to take a vacation from Mithril and spend a couple of weeks as his and Kaname's classmate.&lt;br /&gt;
&lt;br /&gt;
(Source: ANN)</synopsis>
    <image>http://cdn.myanimelist.net/images/anime/4/75260.jpg</image>
  </entry>
</anime>";

		public AnimeSearchResponseFormatterTest(ITestOutputHelper output)
		{
			_output = output;
		}

		[Fact]
		public void FormatAnimeSearchResponseToXmlString()
		{
			var formatter = new XmlFormatter<AnimeSearchResponse>();

			AnimeSearchResponse animeSearchResponse = new SearchResponseDeserializer<AnimeSearchResponse>().Deserialize(RESPONSE_TEXT);
			string xmlText = formatter.Format(animeSearchResponse);
			_output.WriteLine(xmlText);

			Assert.True(IsParsableXml(xmlText));
		}

		[Fact]
		public void FormatAnimeSearchResponseToJsonString()
		{
			var formatter = new JsonFormatter<AnimeSearchResponse>();

			AnimeSearchResponse animeSearchResponse = new SearchResponseDeserializer<AnimeSearchResponse>().Deserialize(RESPONSE_TEXT);
			string jsonText = formatter.Format(animeSearchResponse);
			_output.WriteLine(jsonText);

			Assert.True(IsParsableJson(jsonText));
		}
	}
}