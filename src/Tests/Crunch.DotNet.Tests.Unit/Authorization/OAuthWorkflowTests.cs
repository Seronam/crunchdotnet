using System.IO;
using System.Net;
using System.Text;
using Crunch.DotNet.Authorization;
using Crunch.DotNet.Utilities;
using Moq;
using NUnit.Framework;

namespace Crunch.DotNet.Tests.Unit.Authorization
{
    [TestFixture]
    public class OAuthWorkflowTests
    {
        [Test]
        public void InitiateAccessRequest()
        {
            // Setup
            var expectedTempToken = "TEMPORARY_ACCESS_TOKEN";
            var expectedTokenSecret = "TOKEN_SECRET";
            var responseStream = GetResponseStream($"oauth_token={expectedTempToken}&oauth_token_secret={expectedTokenSecret}");

            var response = new Mock<HttpWebResponse>();
            response.Setup(c => c.GetResponseStream()).Returns(responseStream);
            var request = new Mock<HttpWebRequest>();
            request.Setup(c => c.GetResponse()).Returns(response.Object);

            var factory = new Mock<IHttpWebRequestFactory>();
            factory.Setup(c => c.Create(It.IsAny<string>(), WebRequestMethods.Http.Get, It.IsAny<string>(), ContentType.Json))
                .Returns(request.Object);

            var workflow = new OAuthWorkflow("CONSUMER_KEY", "CONSUMER_SECRET", new CrunchRestUrlProvider(), factory.Object);

            // Execute
            var result = workflow.InitiateAccessRequest();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.TemporaryToken, Is.EqualTo(expectedTempToken));
            Assert.That(result.TokenSecret, Is.EqualTo(expectedTokenSecret));
            Assert.That(result.VerificationUrl, Is.EqualTo("https://demo.crunch.co.uk/crunch-core/login/oauth-login.seam?oauth_token=TEMPORARY_ACCESS_TOKEN"));
        }

        [Test]
        public void RequestAccess()
        {
            // Setup
            var tempToken = "TEMPORARY_ACCESS_TOKEN";
            var tokenSecret = "TOKEN_SECRET";
            var consumerKey = "CONSUMER_KEY";
            var consumerSecret = "CONSUMER_SECRET";
            var token = "ACCESS_TOKEN";
            var verificationToken = "VERIFICATION_TOKEN";
            var responseStream = GetResponseStream($"oauth_token={token}&oauth_token_secret={tokenSecret}");
            var tempTokens = new OAuthTempTokens(tempToken, tokenSecret, "https://demo.crunch.co.uk/crunch-core/login/oauth-login.seam?oauth_token=TEMPORARY_ACCESS_TOKEN");

            var urls = new CrunchRestUrlProvider();
            var response = new Mock<HttpWebResponse>();
            response.Setup(c => c.GetResponseStream()).Returns(responseStream);
            var request = new Mock<HttpWebRequest>();
            request.Setup(c => c.GetResponse()).Returns(response.Object);

            var factory = new Mock<IHttpWebRequestFactory>();
            factory.Setup(c => c.Create(It.IsAny<string>(), WebRequestMethods.Http.Get, It.IsAny<string>(), ContentType.Json))
                .Returns(request.Object);

            var workflow = new OAuthWorkflow(consumerKey, consumerSecret, urls, factory.Object);

            // Execute
            var result = workflow.RequestAccess(verificationToken, tempTokens);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Token, Is.EqualTo(token));
            Assert.That(result.TokenSecret, Is.EqualTo(tokenSecret));
            Assert.That(result.ConsumerKey, Is.EqualTo(consumerKey));
            Assert.That(result.ConsumerSecret, Is.EqualTo(consumerSecret));
        }

        [Test]
        public void ProtectedResourceAccess()
        {
            // Setup
            var tokens = new OAuthTokens
            {
                ConsumerKey = "CONSUMER_KEY",
                ConsumerSecret = "CONSUMER_SECRET",
                TokenSecret = "TOKEN_SECRET",
                Token = "TOKEN"
            };

            // Execute
            var authHeader = tokens.GetAuthorisationHeader("https://sandbox.api.crunch.co.uk/rest/v2/clients", WebRequestMethods.Http.Get);

            // Assert
            Assert.That(authHeader, Is.Not.Null);
        }

        private Stream GetResponseStream(string expectedResponse)
        {
            var expectedBytes = Encoding.UTF8.GetBytes(expectedResponse);
            var responseStream = new MemoryStream();
            responseStream.Write(expectedBytes, 0, expectedBytes.Length);
            responseStream.Seek(0, SeekOrigin.Begin);
            return responseStream;
        }
    }

    [TestFixture]
    public class CrunchRestUrlProviderTests
    {
        [Test]
        public void Demo()
        {
            // Setup + Execute
            var provider = new CrunchRestUrlProvider();
            var output = new StringBuilder();
            output.AppendFormat("Request temporary token url: {0}", provider.RequestToken);
            output.AppendFormat("Verification login url: {0}", provider.GetAuthLogin("TEMP_ACCESS_TOKEN"));
            output.AppendFormat("Request access token url: {0}", provider.AccessToken);
            output.AppendFormat("Rest url: {0}", provider.Rest);

            var text = output.ToString();

            // Assert
            Assert.That(text, Is.Not.Null);


        }
    }
}
