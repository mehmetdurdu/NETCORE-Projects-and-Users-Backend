using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    //new leme yapamamak için static tanımlanır.
    public static class Messages
    {
        //Public olduğu için değişken isimleri Pascal Case yazıldı.

        public static string ProjectAdded = "Proje eklendi";
        public static string ProjectDeleted = "Proje silindi";
        public static string ProjectUpdated = "Proje güncellendi";
        public static string ProjectNameInvalid = "Proje ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProjectsListed = "Projeler listelendi";
        public static string ProjectCountOfCategoryError = "Bir kategoride en fazla 10 proje olabilir";
        public static string ProjectNameAlreadyExists = "Bu isimde zaten başka bir proje var";
        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni proje eklenemiyor";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz yok";
    }
}
