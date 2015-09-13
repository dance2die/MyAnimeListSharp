using System.Xml.Linq;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Facade;

namespace MyAnimeListSharp.ContentBuilders
{
	public interface IValuesContentBuilder<in T> where T : MyAnimeListValues
	{
		XElement BuildContent(T values);
	}
}