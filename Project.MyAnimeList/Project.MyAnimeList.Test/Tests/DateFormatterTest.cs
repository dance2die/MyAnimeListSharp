using System;
using MyAnimeListSharp.Formatters;
using Xunit;
using Xunit.Abstractions;

namespace Project.MyAnimeList.Test.Tests
{
	public class DateFormatterTest
	{
		private readonly ITestOutputHelper _output;
		private readonly IDateTimeFormatter _dateTimeFormatter;

		public DateFormatterTest(ITestOutputHelper output)
		{
			_output = output;
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

		[Fact]
		public void IfDateTimeIsNotSpecifiedReturnEmptyString()
		{
			string actual = _dateTimeFormatter.Format(null);

			var expected = "";
			_output.WriteLine("Actual: {0}", _output);
            Assert.Equal(expected, actual);
		}
	}
}
