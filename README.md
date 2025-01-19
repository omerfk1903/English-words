# English-Words

**Not:** Uygulama henüz tamamlanmamıştır ve farklı özellikler eklenmeye devam edilecektir. Örneğin, veritabanındaki herhangi bir değişiklik olduğunda, kelimelerin karşılıkları sesli olarak kullanıcıya bildirilecektir.

---

## Uygulamanın Form Sayfası

Uygulama, tek bir form sayfasından oluşmaktadır. Bu sayfada, aşağıdaki özellikler bulunmaktadır:
- Veritabanına kelime ekleme
- Kelime silme
- Veritabanındaki kelimelerin Türkçe ya da İngilizce karşılıklarını görüntüleme

### Proje Görseli:
<img src="English words.png" alt="Proje Görseli" width="400" height="350"/>

---

### Formdaki Özellikler ve Butonlar:

- **ADD**: Yeni kelimeler eklemek için kullanılır.
- **Remove**: Kelime kaldırmak için kullanılır.
- **Delet**: Tüm lisboxları boşaltır.
- **Show**: Seçilen harf ile başlayan kelimeleri görüntüler.
- **Search**: Aranan kelimenin karşılığını gösterir.
- **Access**: Veritabanına bağlantı oluşturmak için kullanılır.

---

## Veritabanı İşlemleri

Veritabanına kelime eklemek veya silmek için:
1. Kullanıcılar ilgili metin alanına gerekli bilgileri girer.
2. İşlemi başlatan butona tıklanır.
3. Gerçekleştirilen işlemle ilgili özet bilgiler **ListBox** üzerinde görüntülenir.

Veritabanına bağlantı sağlamak için aşağıdaki kod kullanılabilir:

```csharp
OleDbConnection Connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:Data.accdb");
