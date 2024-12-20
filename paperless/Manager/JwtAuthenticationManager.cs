﻿using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Npgsql;
using System.Data;
using System.Dynamic;
using Newtonsoft.Json.Linq;
using paperless.Libs;
using Newtonsoft.Json;
using paperless.Data.Models;
using paperless.Data.Controllers;
using System.Collections.Generic;

namespace paperless.Manager
{
    public class JwtAuthenticationManager
    {
        private BaseController bc = new BaseController();
        private lConvert lc = new lConvert();
        private lDbConn dbconn = new lDbConn();
 
        //key declaration
        private readonly IConfiguration _configuration;

        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        { {"nandar", "amrie"}, {"amrie", "nandar"}, {"ani", "amrie"} };
 
        public JArray getLoginUser (String iduser, String idpwd)
        {
            var jadata = new JArray();

            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getuser2";
            string p1 = "@iduser" + split + iduser + split + "s";
            string p2 = "@idpwd" + split + idpwd + split + "s";

            var retObject = new List<dynamic>();
            retObject = bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1, p2);
            jadata = lc.ConvertDynamicToJArray(retObject,"");

            return jadata;
        }
        public JArray getLoginUsermod(String iduser, String idpwd)
        {
            var jadata = new JArray();

            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getusermod2";
            string p1 = "@iduser" + split + iduser + split + "s";
            string p2 = "@idpwd" + split + idpwd + split + "s";

            var retObject = new List<dynamic>();
            retObject = bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1, p2);
            jadata = lc.ConvertDynamicToJArray(retObject, "");

            return jadata;
        }

        public void GetUser(String iduser, String idpwd)
        {
            var jData = new JArray();

            jData = this.getLoginUser (iduser, idpwd);
            if (jData.Count > 0)
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                List<Login> logins = JsonConvert.DeserializeObject<List<Login>>(jData.ToString());
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var userid = logins[0].UserId.ToString();
                var pwd = logins[0].UserPwd.ToString();
                users.Clear();
                users.Add(userid, pwd);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
        }
        public void GetUsermod(String iduser, String idpwd)
        {
            var jData = new JArray();

            jData = this.getLoginUsermod(iduser, idpwd);
            if (jData.Count > 0)
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                List<Login> logins = JsonConvert.DeserializeObject<List<Login>>(jData.ToString());
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var userid = logins[0].UserId.ToString();
                var pwd = logins[0].UserPwd.ToString();
                users.Clear();
                users.Add(userid, pwd);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
        }

        public JwtAuthenticationManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? Authenticate(string username, string passwd)
        {
            GetUser(username, passwd);

            //auth failed - creds incorrect
            if (!users.Any(u => u.Key == username && u.Value == passwd))
            {
                return null;
            }
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_configuration["Jwt:Token"]);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                // Duration of the Token
                // Now the the Duration to 1 Hour
                Expires = DateTime.UtcNow.AddHours(6),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature) //setting sha256 algorithm
            };
                     var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        
        
        public string? Authenticate1(string username, string passwd)
        {
            GetUsermod(username, passwd);

            //auth failed - creds incorrect
            if (!users.Any(u => u.Key == username && u.Value == passwd))
            {
                return null;
            }
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_configuration["Jwt:Token"]);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                // Duration of the Token
                // Now the the Duration to 1 Hour
                Expires = DateTime.UtcNow.AddHours(6),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature) //setting sha256 algorithm
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
