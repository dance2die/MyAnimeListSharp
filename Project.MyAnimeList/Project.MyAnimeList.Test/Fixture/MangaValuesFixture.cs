using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAnimeListSharp.Facade;

namespace Project.MyAnimeList.Test.Fixture
{
	public class MangaValuesFixture
	{
		public MangaValues Values { get; set; }

		public MangaValuesFixture()
		{
			Values = GetTestMangaValues();
		}

		private MangaValues GetTestMangaValues()
		{
			return new MangaValues
			{
			};
		}
	}
}
