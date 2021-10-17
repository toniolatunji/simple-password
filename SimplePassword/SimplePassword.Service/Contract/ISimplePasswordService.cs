using SimplePassword.Service.DataTransferObjects;

namespace SimplePassword.Service.Contract
{
    public interface ISimplePasswordService
    {
        SimplePasswordResponseDto SimplePassword(string password);
    }
}
