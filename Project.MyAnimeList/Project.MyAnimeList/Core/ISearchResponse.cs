using System.Collections.Generic;

namespace MyAnimeListSharp.Core
{
    public interface ISearchResponse<T> where T : EntryBase
    {
        List<T> Entries { get; set; }
    }
}