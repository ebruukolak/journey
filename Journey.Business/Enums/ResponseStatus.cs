using System;
namespace Journey.Business.Enums
{
    public enum ResponseStatus
    {
        Success,
        InvalidDepartureDate,
        InvalidRoute,
        InvalidLocation,
        Timeout,
        DeviceSessionError
    }
}
