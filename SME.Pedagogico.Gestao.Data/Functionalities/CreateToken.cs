using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.Functionalities
{
 public  class CreateToken
    {
        // Passar o método de gerar token pra ca
        private IConfiguration _config;
        public CreateToken(IConfiguration config)
        {

            _config = config;
        }


        /// <summary>
        /// Método para gerar o token de acesso.
        /// </summary>
        /// <param name="username">Nome do usuário</param>
        /// <returns>Token gerado à partir das informações do usuário.</returns>
        public string CreateTokenProvisorio()
        {
            string username = "Caique.amcom";
            // Adicionar Claims para restringir o acesso dos usuários a determinados conteudos
            Claim[] claims = new Claim[]
            {
                //new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim("username", username),
                //new Claim(JwtRegisteredClaimNames.Email, user.email),
                //new Claim(JwtRegisteredClaimNames.Birthdate, user.birthdate.ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
                _config["JwtSettings:Issuer"],
                _config["JwtSettings:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(10), // Define o tempo de validade de cada token
                signingCredentials: creds);

            return (new JwtSecurityTokenHandler().WriteToken(token));
        }

        /// <summary>
        /// Método para extrair atributos de uma página html (raw) pela propriedade 'name'. Só funciona se a propriedade 'name' estiver antes do 'value'.
        /// </summary>
        /// <param name="source">Fonte do html (raw)</param>
        /// <param name="name">Nome do atributo desejado</param>
        /// <returns>Valor (value) do atributo desejado</returns>
        private static string ExtractDataByName(string source, string name)
        {
            int startIndex = source.IndexOf(string.Format("name=\"{0}\"", name));
            string delimiter = "\"";

            if (startIndex < 0)
            {
                startIndex = source.IndexOf(string.Format("name='{0}'", name));
                delimiter = "'";

                if (startIndex < 0)
                    return (string.Empty);
            }

            int firstIndex = source.IndexOf("value=" + delimiter, startIndex) + 7;
            int lastIndex = source.IndexOf(">", startIndex);
            string data = source.Substring(firstIndex, lastIndex - firstIndex - 3);

            return (data);
        }
    }
}
