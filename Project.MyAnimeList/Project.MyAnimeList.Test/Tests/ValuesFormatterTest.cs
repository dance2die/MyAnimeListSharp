using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.MyAnimeList.Test.Fixture;
using Xunit;

namespace Project.MyAnimeList.Test.Tests
{
	public class ValuesFormatterTest : IClassFixture<ValuesFormatterTestFixture>
	{
		private readonly ValuesFormatterTestFixture _fixture;

		public ValuesFormatterTest(ValuesFormatterTestFixture fixture)
		{
			_fixture = fixture;
		}
	}
}
