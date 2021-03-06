﻿using MyAnimeListSharp.Auth;

namespace Project.MyAnimeList.Test.Fixture
{
    /// <remarks>
    /// http://xunit.github.io/docs/shared-context.html
    /// </remarks>
    public class CredentialContextFixture
    {
        public ICredentialContext CredentialContext { get; private set; }

        public CredentialContextFixture()
        {
            CredentialContext = new CredentialContext();
        }
    }
}