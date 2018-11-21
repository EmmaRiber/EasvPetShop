using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

// Helper class . Token controlleren behøver en security key, 
//for at lave en token, og den laves derinde. 
//Enten kommer der en string, og ellers kan man sætte den til en new value.
//Den bliver også brugt i Starup classen.

namespace PetShop.Menu.Infrastructure.Data
{
    public static class JwtSecurityKey
    {
        private static byte[] secretBytes = Encoding.UTF8.GetBytes("A secret for HmacSha256");

        public static SymmetricSecurityKey Key
        {
            get { return new SymmetricSecurityKey(secretBytes); }
        }

        public static void SetSecret(string secret)
        {
            secretBytes = Encoding.UTF8.GetBytes(secret);
        }
    }
}
