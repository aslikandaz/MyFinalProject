﻿using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages // static verdiğimizde newlememiz gerekmez
    {
        public static string ProductAdded = "Ürün eklendi"; // public fieldlar pascal case yazılır
        public static string ProductNameInValid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";
        public  static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün var";
        public  static string CategoryLimitExceded="Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public  static string AuthorizationDenied = "Yetkiniz yok.";

        public static string UserNotFound = "Kullanıcı bulunamadı";

        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu";
    }
}
