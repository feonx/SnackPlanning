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
    }
}
