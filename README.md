# IztekTestCase - .NET Core 9

## Kullanılan Teknolojiler 
+ .NET Core 9: En son sürüm .NET Core. Platformlar arası uyumluluk ve performans sağlayan projenin temeli.
+ MSSQL: İlişkisel veri tabanı yönetim sistemi.
+ Entity Framework: Veri tabanı etkileşimleri için Object-Relational Mapping (ORM) aracı.
+ AutoMapper: Farklı tipteki complex objeleri birbilerine otomatik dönüştüren kütüphane.
+ Swagger: API'lerin açıklayıcı bir şekilde belgelenmesini sağlayan açık kaynaklı araç.
+ Dependency Injection: Bağımlılıkları verimli bir şekilde yönetme ve çözme.

## Gereksinimler
+ Makinenizde yüklü bir [.NET Core 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0).
+ [Microsoft SQL Server 2022 Developer Edition](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) kurulmuş ve yapılandırılmış olmalıdır.

## Veri Tabanı Tasarımı
+ Proje dizini altındaki `TestCase.drawio` dosyası ile [draw.io](https://app.diagrams.net) sitesi üzerinde görüntülenebilir.
+ Microsoft SQL Server Managment Studio ile ilgili veri tabanı içinde `Database Diagrams` altında görüntülenebilir. 

## Kurulum 
1. Proje dizini altındaki `CreateTestCaseDb.sql` scripti ile yerel makineniz için gerekli düzenlemeleri yaptıktan sonra veri tabanı ve tabloları oluşturun.
2. Bu GitHub deposunu yerel makinenize klonlamak için aşağıdaki komutu kullanın:
```
git clone https://github.com/mirkankacan/IztekTestCase.git
```
3. Proje dizinine gidin:
```
cd IztekTestCase
```
4. Bağımlılıkları geri yüklemek için:
```
dotnet restore
```
5. Projeyi derlemek için:
```
dotnet build
```

## Konfigürasyon
Projenin başarılı bir şekilde çalıştırılabilmesi için aşağıdaki yapılandırmanın yapılması gerekmektedir:
+ Veri tabanı `connection string` düzenlemesi (proje dizini altında `appsettings.json` içinde).
