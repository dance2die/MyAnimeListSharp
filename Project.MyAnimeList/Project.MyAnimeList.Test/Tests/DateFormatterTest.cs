using System;
using MyAnimeListSharp.Util;
using Xunit;

namespace Project.MyAnimeList.Test.Tests
{
	public class DateFormatterTest
	{
		private readonly IDateTimeFormatter _dateTimeFormatter;

		public DateFormatterTest()
		{
			_dateTimeFormatter = new DefaultDateTimeFormatter();
		}

		[Fact]
		public void TestDefaultDateFormatterToReturnMMddyyyyString()
		{
			int month = 12;
			int day = 31;
			int year = 2015;
			string expected = $"{month}{day}{year}";

			string actual = _dateTimeFormatter.Format(new DateTime(year, month, day));

			Assert.Equal(expected, actual);
		}
	}
}
