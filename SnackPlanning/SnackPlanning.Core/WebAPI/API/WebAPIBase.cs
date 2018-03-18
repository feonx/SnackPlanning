using System;
namespace SnackPlanning.Core.WebAPI.API
{
    public class WebAPIBase
    {
        private WebAPI _webAPIInstance;

        public WebAPIBase()
        {
            if (_webAPIInstance != null)
                return;

            _webAPIInstance = new WebAPI();
        }

        public WebAPI WebAPI => _webAPIInstance;
    }
}
