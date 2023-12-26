using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CMDKhakatonProject.Authorization
{
    public class AuthOptions
    {
        public const string ISSUER = "CSEON";
        public const string AUDIENCE = "VolgaItClients";
        const string KEY = "mysupersecret_secretkey!123";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new(Encoding.UTF8.GetBytes(KEY));
    }
}
