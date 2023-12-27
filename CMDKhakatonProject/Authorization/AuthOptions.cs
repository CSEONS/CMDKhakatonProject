using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CMDKhakatonProject.Authorization
{
    public class AuthOptions
    {
        public const string ISSUER = "CSEON";
        public const string AUDIENCE = "VolgaItClients";
        const string KEY = "_-sqddkqwdasd;alsdkqpwkeleji32ue89h2e9dfh2837rry29eho3ue023hdeoiwqde0293he2ouefhd9283yhro2iehfd9028eufr2oibfoi2whef923bf";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new(Encoding.UTF8.GetBytes(KEY));
    }
}
