using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;


namespace Common.Utility
{
    public static class JwtWorker
    {
        public static string GenerateTokenJwt(string username)
        {
            // appsetting for Token JWT
            var secretKey = "jklnhfadsuijnu32893hr879hbd37u89hn78u32h78h7u89qwdj90189";
            var audienceToken = "http://gamequiz.app";
            var issuerToken = "http://api.gamequiz.app";
            var expireTime = 30;

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // create a claimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) });

            // create token to the user
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }
    }
}
