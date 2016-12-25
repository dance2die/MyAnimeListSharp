using MyAnimeListSharp.Auth;

namespace MyAnimeListSharp.Parameters
{
    public abstract class CrudRequestParameters : RequestParameters
    {
        private const string DATA_BODY_NAME = "data";

        protected CrudRequestParameters(ICredentialContext credential, int? id, string data)
            : base(credential, id)
        {
            Data = data;
        }

        public string Data
        {
            get { return QueryProperties[DATA_BODY_NAME]; }
            set { QueryProperties[DATA_BODY_NAME] = value; }
        }

        public override string HttpMethod { get; set; } = "GET";
    }
}