using System;
using System.Threading.Tasks;
using SnackPlanning.Core.WebAPI.Shared;

namespace SnackPlanning.Core.WebAPI
{
    public class User : API.WebAPIBase
    {
        private string _username;

        public User(string username)
        {
            _username = username;
        }

        public bool Exists()
        {
            var credentialStatus =
                WebAPI.Send<StatusResponse>("api/register/userexists", new UserCredentials
                {
                    Username = _username
                }).Result;

            return credentialStatus.Status == StatusEnum.RecordExists;
        }

        public async Task<bool> Create(string password)
        {
            var credentials = new UserCredentials
            {
                Username = _username,
                Password = password
            };

            var recordStatus = await WebAPI.Send<StatusResponse>("api/register", credentials);
            return recordStatus.Status == StatusEnum.RecordCreated;
        }
    }
}
