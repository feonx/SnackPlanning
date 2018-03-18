using System;
using System.Threading.Tasks;
using SnackPlanning.Core.WebAPI.Shared;

namespace SnackPlanning.Core.WebAPI
{
    public class Login : API.WebAPIBase
    {
        private UserCredentials _userCredentials;

        public Login(string username, string password)
        {
            _userCredentials = new UserCredentials
            {
                Username = username,
                Password = password
            };
        }
        
        public async Task<bool> CheckCredentials()
        {
           var recordStatus = await WebAPI.Send<StatusResponse>("api/login", _userCredentials);
           return recordStatus.Status == StatusEnum.RecordExists;
        }

    }


}
