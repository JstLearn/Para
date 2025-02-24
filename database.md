# Para Veritabanı Şeması

## Veritabanı Adı: Para

## Tablolar

### Para Tablosu
Bu tablo oyun verilerini ve işlemlerini takip etmek için kullanılmaktadır.

| Sütun Adı | Veri Tipi | Açıklama |
|-----------|-----------|-----------|
| ID | int | Otomatik artan birincil anahtar |
| turno | nvarchar(50) | Tur numarası |
| x | decimal(18,2) | X değeri |
| KasaKar | decimal(18,2) | Kasa kârı |
| KasaHerkesSatarsa | decimal(18,2) | Herkes satarsa oluşacak kasa kârı |
| KasaEnBuyukSatarsa | decimal(18,2) | En büyük satış yapılırsa oluşacak kasa kârı |
| BahisAdet | int | Toplam bahis adedi |
| BahisMiktar | decimal(18,2) | Toplam bahis miktarı |
| KarliSatisAdet | int | Kârlı satış adedi |
| KarliSatisMiktar | decimal(18,2) | Kârlı satış miktarı |
| SatilmamisAdet | int | Satılmamış bahis adedi |
| SatilmamisMiktar | decimal(18,2) | Satılmamış bahis miktarı |
| SatilmamisEnBuyukMiktar | decimal(18,2) | En büyük satılmamış bahis miktarı |
| Tarih | datetime | İşlem tarihi (DEFAULT GETDATE()) |

### Log Tablosu
Bu tablo sistem loglarını tutmak için kullanılmaktadır.

| Sütun Adı | Veri Tipi | Açıklama |
|-----------|-----------|-----------|
| ID | int | Otomatik artan birincil anahtar |
| Tarih | datetime | Log tarihi (DEFAULT GETDATE()) |
| Mesaj | nvarchar(MAX) | Log mesajı |
| Fonksiyon | nvarchar(100) | Hata oluşan fonksiyon adı |
| HataMesaji | nvarchar(MAX) | Hata detayı |

### CanliVeri Tablosu
Bu tablo canlı oyun verilerini takip etmek için kullanılmaktadır.

| Sütun Adı | Veri Tipi | Açıklama |
|-----------|-----------|-----------|
| ID | int | Otomatik artan birincil anahtar |
| CanliX | decimal(18,2) | Canlı X değeri |
| OyunDurumu | nvarchar(50) | Oyun durumu (Yellow/Green/Red) |
| RiskYuzde | decimal(18,2) | Risk yüzdesi |
| GenelRiskYuzde | decimal(18,2) | Genel risk yüzdesi |
| WriteTime | datetime | Yazma zamanı (DEFAULT GETDATE()) |

## İlişkiler
- Tablolar arasında direkt bir ilişki bulunmamaktadır.
- Her tablo bağımsız olarak kendi verilerini tutar.

## Notlar
- Veritabanı MSSQL Server üzerinde çalışmaktadır
- Tüm datetime alanları için varsayılan değer olarak GETDATE() kullanılmaktadır
- Para tablosundaki decimal alanlar için hassasiyet 2 decimal karakter olarak belirlenmiştir
- CanliVeri tablosu oyun durumunu takip etmek için kullanılır (Yellow: Başlıyor, Green: Devam Ediyor, Red: Bitti)
- Log tablosu hata takibi ve sistem logları için kullanılır 
