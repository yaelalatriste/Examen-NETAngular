using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace Examen.EventHandler.Autenticacion
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            Microsoft.AspNetCore.Authentication.ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return Task.FromResult(AuthenticateResult.Fail("Missing Authorization Header"));

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                if (authHeader.Scheme != "Basic")
                    return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Scheme"));

                var credentialBytes = Convert.FromBase64String(authHeader.Parameter ?? "");
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);
                if (credentials.Length != 2)
                    return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));

                var username = credentials[0];
                var password = credentials[1];

                // Validar credenciales
                if (username != "admin" || password != "admin")
                    return Task.FromResult(AuthenticateResult.Fail("Invalid Username or Password"));

                var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim(ClaimTypes.Name, username),
            };

                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return Task.FromResult(AuthenticateResult.Success(ticket));
            }
            catch
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
            }
        }
    }
}
