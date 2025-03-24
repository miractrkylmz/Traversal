# 🌍 Traversal Seyahat Acentesi MVC Projesi

Bu proje, backend geliştirme sürecinde büyük bir adım attığım ve birçok yeni teknolojiyle haşır neşir olduğum bir çalışma oldu. Traversal Seyahat Acentesi, seyahat planlama ve yönetimini kolaylaştıran bir platform olarak tasarlandı. Proje sürecinde N Katmanlı Mimari, Kimlik Doğrulama, Gerçek Zamanlı Bildirimler ve daha birçok konuyu detaylıca öğrenme fırsatım oldu.

## 🛠️ Kullanılan Teknolojiler

- **ASP.NET Core MVC** – Proje altyapısını oluşturmak için kullanıldı.
- **Entity Framework Core (Code First)** – Veritabanı yönetimi ve modelleme için kullanıldı.
- **MSSQL & PostgreSQL** – Çoklu veritabanı desteği sağlandı.
- **LINQ** – Veritabanı sorguları ve veri manipülasyonu için kullanıldı.
- **AJAX** – Sayfa yenilenmeden asenkron işlemler gerçekleştirmek için kullanıldı.
- **Bootstrap & CSS** – Responsive ve modern bir tasarım sağlamak için kullanıldı.
- **Fluent Validation** – Kullanıcı girişleri için doğrulama mekanizması oluşturuldu.
- **Identity Framework** – Kullanıcı yönetimi ve kimlik doğrulama işlemleri gerçekleştirildi.
- **MailKit** – Kullanıcılara e-posta gönderimi sağlandı.
- **AutoMapper (DTO Kullanımı)** – Veri transfer işlemlerini optimize etmek için kullanıldı.
- **SignalR** – Gerçek zamanlı bildirim ve mesajlaşma işlemleri gerçekleştirildi.

## ⚙️ Teknik Özellikler

- **N Katmanlı Mimari Yapısı** – Kodun daha düzenli ve sürdürülebilir olması sağlandı.
- **Repository Design Pattern** – Veritabanı işlemleri için daha temiz bir yapı oluşturuldu.
- **DTO (Data Transfer Object) Kullanımı** – Model ve entity arasındaki veri taşıma işlemleri optimize edildi.
- **PagedList ile Sayfalama** – Büyük verilerin daha iyi yönetilmesi için sayfalama işlemi gerçekleştirildi.
- **Fluent Validation ile Doğrulama** – Kullanıcı girişleri ve form doğrulamaları güvenli hale getirildi.
- **Identity ile Kullanıcı ve Rol İşlemleri** – Yetkilendirme ve kullanıcı yönetimi sağlandı.

## 🚀 Sitenin Öne Çıkan Özellikleri

- **Üye Paneli ve Admin Paneli** – Kullanıcılar ve yöneticiler için ayrı paneller tasarlandı.
- **Identity Framework ile Giriş Yapma** – Kullanıcıların güvenli bir şekilde giriş yapması sağlandı.
- **Rolleme ve Yetkilendirme** – Admin ve kullanıcı rolleri belirlendi.
- **AJAX ile CRUD İşlemleri** – Sayfa yenilenmeden veri ekleme, silme, güncelleme işlemleri yapıldı.
- **MailKit ile Mesajlaşma Sistemi** – Kullanıcıların birbirine e-posta göndermesi sağlandı.
- **PagedList ile Sayfalama** – Veri listeleri sayfalara bölünerek daha düzenli hale getirildi.
- **Ana Sayfadaki Turları Görüntüleme & Rezervasyon Yapma** – Kullanıcılar aktif turları görüntüleyip rezervasyon oluşturabildi.
- **Panellerde Profil Ayarları Sayfaları** – Kullanıcıların bilgilerini güncelleyebileceği sayfalar oluşturuldu.
- **Şifremi Unuttum Özelliği** – Kullanıcıların şifrelerini sıfırlaması sağlandı.
- **Kullanıcılara Roller Atama, Silme ve Güncelleme** – Yetkilendirme işlemleri yapıldı.
- **Üye Panelinde Çoklu Dil Desteği** – Kullanıcılar siteyi farklı dillerde kullanabildi.
- **Arama İşlemleri** – Veriler üzerinde dinamik arama işlemleri gerçekleştirildi.

## 🛠️ Admin Paneli Özellikleri

- **İstatistikleri Görme** – Site içi veriler analiz edildi.
- **Profil Düzenleme İşlemleri** – Admin bilgilerini güncelleyebildi.
- **Tüm Turlar Üzerinde CRUD İşlemleri** – Tur ekleme, silme ve güncelleme işlemleri yapıldı.
- **Rezervasyonları Görüntüleme ve Takip Etme** – Kullanıcıların rezervasyon süreçleri takip edildi.
- **Site Üzerindeki Tüm Yorumları Görüntüleme** – Kullanıcı yorumları incelenip yönetildi.
- **Kullanıcıları Görüntüleme** – Kayıtlı kullanıcılar listelendi.
- **Rehberler Üzerinde CRUD İşlemleri ve Aktif/Pasif Yapma** – Rehber ekleme, düzenleme işlemleri yapıldı.
- **Mesajlaşma Sistemi** – Kullanıcılar ve admin arasında mesajlaşma sağlandı.
- **Raporlamalar** – Veriler analiz edilerek raporlandı.
- **Mail Gönderme** – Admin tarafından kullanıcılara e-posta gönderimi sağlandı.
- **AJAX ile Tur Üzerinde CRUD İşlemler** – Turlar dinamik olarak güncellendi.
- **API Kullanımı** – Harici API'ler ile veri alımı gerçekleştirildi.
- **Site Üzerindeki Verilerde CRUD İşlemleri** – İçerik yönetimi sağlandı.
- **Rolleme Yapma** – Kullanıcılara yetkilendirme işlemleri yapıldı.

## 👤 Üye Paneli Özellikleri

- **İstatistikleri Görme** – Kullanıcılar kendi verilerini analiz edebildi.
- **Profil Düzenleme İşlemleri** – Kullanıcılar bilgilerini güncelleyebildi.
- **Aktif Rota & Gezileri Görme ve Rezervasyon Oluşturma** – Kullanıcılar seyahat planları yapabildi.
- **Onay Bekleyen Rezervasyonları Görüntüleme** – Rezervasyon süreci takip edildi.
- **Geçmiş Rezervasyonları Görüntüleme** – Kullanıcıların önceki rezervasyonları listelendi.
- **Menülerde Çoklu Dil Desteği** – Kullanıcılar dili değiştirebildi.

## 📸 Proje Resimleri

(Proje Görüntüleri Geleck)

Bu proje, backend geliştirme sürecinde benim için büyük bir dönüm noktası oldu. N Katmanlı Mimari, Repository Pattern, SOLID Prensipleri ve daha birçok konu hakkında derinlemesine bilgi sahibi oldum.
