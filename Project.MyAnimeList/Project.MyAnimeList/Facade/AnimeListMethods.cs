using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Parameters;

namespace MyAnimeListSharp.Facade
{
    /// <summary>
    /// Represents a "Anime List Methods" section in MyAnimeList.net specification.
    /// <see cref="http://myanimelist.net/modules.php?go=api"/>
    /// </summary>
    public class AnimeListMethods : MyAnimeListMethods
    {
        public AnimeListMethods(ICredentialContext credentialContext)
            : base(credentialContext)
        {
        }

        /// <summary>
        /// Add anime info by ID
        /// </summary>
        /// <param name="id">Anime ID on MyAnimeList.net</param>
        /// <param name="data">XML string specified on MyAnimeList.net</param>
        /// <returns>
        /// Response from the server in raw string whether anime was added correctly or not
        /// </returns>
        public string AddAnime(int? id, string data)
        {
            return GetResponseText(new AddAnimeRequestParameters(CredentialContext, id, data));
        }

        /// <summary>
        /// Add Anime info by ID
        /// </summary>
        /// <param name="id">Anime ID on MyAnimeList.net</param>
        /// <param name="animeValues">object that represents XML specification</param>
        /// <returns>
        /// Response from the server in raw string whether anime was added correctly or not
        /// </returns>
        public string AddAnime(int? id, AnimeValues animeValues)
        {
            var data = GetDataStringFromMyAnimeListValues(animeValues);
            return AddAnime(id, data);
        }

        /// <summary>
        /// Update Anime info by ID
        /// </summary>
        /// <param name="id">Anime ID on MyAnimeList.net</param>
        /// <param name="data">XML string specified on MyAnimeList.net</param>
        /// <returns>Response from the server in raw string whether anime was added correctly or not</returns>
        public string UpdateAnime(int? id, string data)
        {
            return GetResponseText(new UpdateAnimeRequestParameters(CredentialContext, id, data));
        }

        /// <summary>
        /// Update Anime info by ID
        /// </summary>
        /// <param name="id">Anime ID on MyAnimeList.net</param>
        /// <param name="animeValues">object that represents XML specification</param>
        /// <returns>Response from the server in raw string whether anime was added correctly or not</returns>
        public string UpdateAnime(int? id, AnimeValues animeValues)
        {
            var data = GetDataStringFromMyAnimeListValues(animeValues);
            return UpdateAnime(id, data);
        }

        /// <summary>
        /// Delete anime info by ID
        /// </summary>
        /// <param name="id">Anime review to delete</param>
        /// <returns></returns>
        public string DeleteAnime(int? id)
        {
            return GetResponseText(new DeleteAnimeRequestParameters(CredentialContext, id));
        }
    }
}