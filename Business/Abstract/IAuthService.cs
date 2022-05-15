using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        //sisteme giriş yapmamızı ya da üye olmamızı gerçekleştiriyoruz
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email); // kullanıcı var mı kontrolü
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}