using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string MaintenanceTime = "Sistem bakımda...";
        public static string CarAdded = "Araba eklendi.";
        public static string Cardeleted = "Araba silindi.";
        public static string CarUpdated = "Araba bilgileri güncellendi.";
        public static string CarNameInvalid = "Araba ismi geçersiz.";
        public static string CarNameAndDailyPrice = "Girmiş olduğunuz araç adını ve günlük fiyatını kontrol ediniz.";       
        public static string CarListed = "Arabalar listelendi.";

        public static string ColorAdded = "Renk eklendi.";
        public static string Colordeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk bilgileri güncellendi.";
        public static string ColorNameInvalid = "Renk ismi geçersiz.";
        public static string ColorListed = "Renkler listelendi.";

        public static string BrandAdded = "Marka eklendi.";
        public static string Branddeleted = "Marka silindi.";
        public static string BrandUpdated = "Marka bilgileri güncellendi.";
        public static string BrandNameInvalid = "Marka ismi geçersiz.";
        public static string BrandListed = "Marka listelendi.";

        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UserNameInvalid = "Kullanıcı ismi geçersiz.";
        public static string UserListed = "Kullanıcı listelendi";

        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string CustomerNameInvalid = "Müşteri ismi gerçersiz.";
        public static string CustomerListed = "Müşteri listelendi.";
        public static string CustomerDetailDtoListed = "Kiralamalar detaylı listelendi.";


        public static string RentalAdded = "Kiralama gerçekleşti.";
        public static string RentalDeleted = "Kiralama bilgileri silindi.";
        public static string RentalUpdated = "Kiralama bilgileri güncellendi.";
        public static string RentalReturnDate = "Araba teslim edilmemiştir.";
        public static string RentalListed = "Kiralamalar listelendi.";
        public static string RentalDetailDtoListed = "Kiralamalar detaylı listelendi.";

        public static string CarImageAdded = "Resim yüklendi.";
        public static string CarImageLimitError= "Bir araçta en fazla 5 resim olabilir.";
        public static string CarImageListed = "Araç resimleri listelendi.";
        public static string DefaultImageAdded = "Varsayılan resim eklendi.";
        public static string CarImageUpdated = "Araç resimi güncellendi.";
        public static string CarImageDeleted = "Araç resmi silindi.";
        public static string ImageIdNotFound = "Doğru sayi giriniz.";
        public static string EmailNotFound = "Email bulunamadı.";
        public static string EmailAlreadyExists = "Email mevcuttur.";
        public static string ClaimNotFound = "Claim bulunamadı.";
        public static string ClaimsListed = "Claimler listelendi.";
        public static string PasswordError = "Parola hatası.";
        public static string SuccessfulLogin = "Giriş başarılı.";
        public static string UserRegistered = "Kullanıcı kayıt oldu.";
        public static string AccessTokenCreated = "Erişim tokenı oluşturuldu.";
        public static string AuthorizationDenied = "Yetkiniz yok.";
    }
}
