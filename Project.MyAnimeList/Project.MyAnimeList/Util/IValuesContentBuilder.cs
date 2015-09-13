using System.Xml.Linq;
using MyAnimeListSharp.Facade;

namespace MyAnimeListSharp.Util
{
	public interface IValuesContentBuilder<in T> where T : MyAnimeListValues
	{
		XElement BuildContent(T values);
	}
}