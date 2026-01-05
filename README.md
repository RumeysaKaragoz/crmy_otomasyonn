# CRMY (CRM Otomasyonu)

CRMY, C# ve Windows Forms kullanılarak geliştirilmiş bir CRM (Customer Relationship Management) uygulamasıdır.
Müşteri ve talep yönetimi gibi temel CRM işlemlerini basit bir arayüzle sunar.

## Özellikler
- Müşteri ekleme / güncelleme / silme / listeleme
- Talep işlemleri (ekleme / listeleme vb.)
- Firestore entegrasyonu (proje yapısına eklenmiştir)
- Demo Login (hocanın bilgisayarında hızlı çalıştırma için)

## Gereksinimler
- Windows
- Visual Studio 2022 (veya 2019)
- .NET Framework 4.7.2
- NuGet (Visual Studio ile birlikte gelir)

## Kurulum ve Çalıştırma
1. Projeyi indirin:
   - GitHub → Code → Download ZIP (veya clone)

2. ZIP'i çıkarın ve **crmy.sln** dosyasını açın.

3. NuGet paketlerini geri yükleyin:
   - Tools → NuGet Package Manager → Restore NuGet Packages  
   (veya Build aldığınızda otomatik restore eder)

4. Build alın:
   - Build → Rebuild Solution

5. Çalıştırın:
   - Start (F5)

## Demo Login
Projede hocanın bilgisayarında sorunsuz test için demo login yapılandırması vardır.

- DemoMode: true/false
- DemoUsername: ...
- DemoPasswordHash: ...

> Ayarlar `App.config` içindeki `appSettings` bölümündedir.

## Notlar
- `bin/` ve `obj/` klasörleri GitHub'a dahil edilmez; Build alınca otomatik oluşur.
- Eğer "crmy.exe missing" hatası alırsanız, Build başarısız olmuştur:
  - Build → Clean Solution
  - Build → Rebuild Solution
  - crmy.exe arka planda açıksa kapatın (Task Manager).
