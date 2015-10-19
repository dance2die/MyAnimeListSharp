using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Formatters;
using MyAnimeListSharp.Util;
using Xunit;
using Xunit.Abstractions;

namespace Project.MyAnimeList.Test.Tests
{
	public class MangaSearchResponseFormatterTest : SearchResponseFormatterTestBase
	{
		private readonly ITestOutputHelper _output;

		private const string RESPONSE_TEXT = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<manga>
  <entry>
    <id>25</id>
    <title>Fullmetal Alchemist</title>
    <english>Fullmetal Alchemist</english>
    <synonyms>Full Metal Alchemist; Hagane no Renkinjutsushi; FMA; Fullmetal Alchemist Gaiden</synonyms>
    <chapters>116</chapters>
    <volumes>27</volumes>
    <score>9.12</score>
    <type>Manga</type>
    <status>Finished</status>
    <start_date>2001-07-12</start_date>
    <end_date>2010-06-11</end_date>
    <synopsis>The rules of alchemy state that to gain something, one must lose something of equal value.Alchemy is the process of taking apart and reconstructing an object into a different entity, with the rules of alchemy to govern this procedure.However, there exists an object that can bring any alchemist above these rules, the object known as the Philosopher's Stone. The young Edward Elric is a particularly talented alchemist who through an accident years back lost his younger brother Alphonse and one of his legs. Sacrificing one of his arms as well, he used alchemy to bind his brother's soul to a suit of armor.This lead to the beginning of their journey to restore their bodies, in search for the legendary Philosopher's Stone.&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;
[i][size=90]Note: The chapter count includes 8 bonus chapters.[/size][/i]</synopsis>
    <image>http://cdn.myanimelist.net/images/manga/1/27600.jpg</image>
  </entry>
  <entry>
    <id>789</id>
    <title>Full Metal Panic!</title>
    <english>Full Metal Panic</english>
    <synonyms>FMP; Furu Metaru Panikku!</synonyms>
    <chapters>58</chapters>
    <volumes>9</volumes>
    <score>7.92</score>
    <type>Manga</type>
    <status>Finished</status>
    <start_date>2003-08-09</start_date>
    <end_date>2006-03-27</end_date>
    <synopsis>A sergeant by the name of Sousuke Sagara is assigned an important task. That of guarding high school girl Chidori Kaname. Sousuke is a military genius, gaining high rank at an early age, but because of his strange upbringing, he lacks social skill. Now, he finds himself as a fish out of water as he attempts to protect a girl from an evil organization and turn in his school work on time. &lt;br /&gt;
&lt;br /&gt;
(Source: ANN) </synopsis>
    <image>http://cdn.myanimelist.net/images/manga/5/111469.jpg</image>
  </entry>
</manga>";

		public MangaSearchResponseFormatterTest(ITestOutputHelper output)
		{
			_output = output;
		}

		[Fact]
		public void FormatMangaSearchResponseToXmlString()
		{
			MangaSearchResponseFormatter formatter = new MangaSearchResponseFormatter(new MangaSearchResponseXmlFormatter());

			MangaSearchResponse response = new SearchResponseDeserializer<MangaSearchResponse>().Deserialize(RESPONSE_TEXT);
			string xmlText = formatter.Format(response);
			_output.WriteLine(xmlText);

			Assert.True(IsParsableXml(xmlText));
		}
	}

	public class MangaSearchResponseXmlFormatter : IFormatter<MangaSearchResponse>
	{
		public string Format(MangaSearchResponse value)
		{
			// http://stackoverflow.com/a/11448270/4035
			using (var stringwriter = new StringWriter())
			{
				var serializer = new XmlSerializer(value.GetType());
				serializer.Serialize(stringwriter, value);
				return stringwriter.ToString();
			}
		}
	}

	public class MangaSearchResponseFormatter
	{
		public IFormatter<MangaSearchResponse> Strategy { get; set; }

		public MangaSearchResponseFormatter(IFormatter<MangaSearchResponse> strategy)
		{
			Strategy = strategy;
		}

		public string Format(MangaSearchResponse value)
		{
			return Strategy.Format(value);
		}
	}
}
