using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspects.Autofac
{
    //JWT
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(','); // split bizim istediğiiz gibi elemanları ayırıp arraye atıyo
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>(); 

            // HttpContext her jwt isteği için context(threat) oluşturur
            // service tool injection altyapısını okuyabilmemize yarayan araç

        }

        protected override void OnBefore(IInvocation invocation) //metodun önünde çalıştır
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles) // yetkisi var mı diye bakıyo
            {
                if (roleClaims.Contains(role))
                {
                    return; // hata verme metoda devam et
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
