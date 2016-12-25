using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace Project.MyAnimeList.Test.Tests
{
    public class InvalidResponseStringDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] {"<root></root>"};
            yield return new object[] {"This is not an XML string"};
        }
    }
}