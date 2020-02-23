using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using PemUtils;

namespace MHanafy.GithubClient
{
    public class JwtTokenFactory : IJwtTokenFactory
    {
        private JwtEncoder _encoder;
        private string _issuer;
        private bool _initialized;

        public JwtTokenFactory()
        {
        }

        public JwtTokenFactory(Stream keyStream, string issuer)
        {   
            Initialize(keyStream, issuer);
        }

        public void Initialize(Stream keyStream, string issuer)
        {
            using var reader = new PemReader(keyStream);
            var key = reader.ReadRsaKey();

            var algorithm = new RS256Algorithm(RSA.Create(key), RSA.Create(key));
            var serializer = new JsonNetSerializer();
            var urlEncoder = new JwtBase64UrlEncoder();
            _encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            _issuer = issuer;
            _initialized = true;
        }

        public JwtToken GetJwtToken(int minutes = 10)
        {
            if(!_initialized) throw new InvalidOperationException("Initialize must be called before usage if the parameter-less constructor was used");
            //add some buffer to account for time difference between local machine and Github
            var now = DateTime.UtcNow;
            var expiry = now.AddMinutes(minutes).AddSeconds(-1 * DateHelper.SafetyMargin);
            var payload = new Dictionary<string, object>
            {
                { "iat", now.ToUnixTime() },
                { "exp", expiry.ToUnixTime() },
                {"iss", _issuer}
            };
            var value = _encoder.Encode(payload, string.Empty);
            return new JwtToken(expiry, value);
        }
    }

    public class JwtToken
    {
        /// <summary>
        /// allows a safety margin to avoid issuing a request with and expired token
        /// </summary>
        public readonly string Value;
        readonly DateTime _expiry;

        public bool IsValid => (_expiry - DateTime.UtcNow).TotalSeconds >= DateHelper.SafetyMargin;
        //todo: consider extending expiry time upon every call, as it seems to be renewed automatically by GitHub
        public JwtToken(DateTime expiry, string value)
        {
            Value = value;
            _expiry = expiry;
        }
    }

    public interface IJwtTokenFactory
    {
        JwtToken GetJwtToken(int minutes = 10);
    }
}
