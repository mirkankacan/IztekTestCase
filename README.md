# IztekTestCase - .NET Core 9

## Kullanılan Teknolojiler [Link Text](#kullanilan-teknolojiler)
+ .NET Core 9: En son sürüm .NET Core. Platformlar arası uyumluluk ve performans sağlayan projenin temeli.
+ MSSQL: İlişkisel veri tabanı yönetim sistemi.
+ Entity Framework: Veri tabanı etkileşimleri için Object-Relational Mapping (ORM) aracı.
+ AutoMapper: Farklı tipteki complex objeleri birbilerine otomatik dönüştüren kütüphane.
+ Swagger: API'lerin açıklayıcı bir şekilde belgelenmesini sağlayan açık kaynaklı araç.
+ Dependency Injection: Bağımlılıkları verimli bir şekilde yönetme ve çözme.

## Gereksinimler [Link Text](#gereksinimler)
+ Makinenizde yüklü bir [.NET Core 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0).
+ [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) kurulmuş ve yapılandırılmış olmalıdır.

## Kurulum [Link Text](#kurulum)
1. Bu GitHub deposunu yerel makinenize klonlamak için aşağıdaki komutu kullanın:
```
git clone https://github.com/mirkankacan/IztekTestCase.git
```
2. Proje dizinine gidin:
```
cd IztekTestCase
```
3. Bağımlılıkları geri yüklemek için:
```
dotnet restore
```
4. Projeyi derlemek için:
```
dotnet build
```

## Konfigürasyon [Link Text](#konfigurasyon)
Projenin başarılı bir şekilde çalıştırılabilmesi için aşağıdaki yapılandırmanın yapılması gerekmektedir:
+ Veri tabanı `connection string` düzenlemesi (`appsettings.json` içinde).
