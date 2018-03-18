using System;
namespace SnackPlanning.Core.WebAPI.Shared
{
    public enum StatusEnum
    {
        Error = 0,
        RecordExists = 1,
        RecordNotFound = 2,
        RecordCreated = 3
    }

    public class StatusResponse
    {
        public StatusEnum Status { get; set; }
    }
}