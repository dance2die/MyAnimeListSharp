using System.Xml.Linq;
using MyAnimeListSharp.Core;

namespace MyAnimeListSharp.ContentBuilders
{
	public interface IValuesContentBuilder<in T> where T : MyAnimeListValues
	{
		XElement BuildContent(T values);
	}
}