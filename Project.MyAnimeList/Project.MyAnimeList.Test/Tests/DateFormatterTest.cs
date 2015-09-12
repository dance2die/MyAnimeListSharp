using System;
using MyAnimeListSharp.Util;
using Xunit;

namespace Project.MyAnimeList.Test.Tests
{
	public class DateFormatterTest
	{
		private readonly IDateFormatter _dateFormatter;

		public DateFormatterTest()
		{
			_dateFormatter = new DefaultDateFormatter();
		}

		[Fact]
		public void TestDefaultDateFormatterToReturnMMddyyyyString()
		{
			int month = 12;
			int day = 31;
			int year = 2015;
			string expected = $"{month}{day}{year}";

			string actual = _dateFormatter.Format(new DateTime(year, month, day));

			Assert.Equal(expected, actual);
		}
	}
}
