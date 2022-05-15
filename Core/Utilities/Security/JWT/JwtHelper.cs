using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; } // IConfiguration webapı dki appsetting deki değerleri okumamıza yarıyo
        private TokenOptions _tokenOptions; // IConfigurationla okuduğum verileri bir nesneye yazıcam bu o nesne
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration; // configuration appsetting yani
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); //appsetting deki verileri al tokenoptions takilere ata

        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey); // securitykey ve algoritmayı belirlediğimiz nesne
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler(); // bu nesneyi kullanarak elimdeki token bilgisini yazdırıcam
            var token = jwtSecurityTokenHandler.WriteToken(jwt); // token nesnesini write ile stringe çevirdik

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, // token oluşturuyoruz
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");//iki stringi bu şekilde de arka arkaya yazabiliriz
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray()); //operation claims ICollection türünde olduğu için onu array e çevirdim

            return claims;
        }
    }
}
