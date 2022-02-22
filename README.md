
# restapi
Projeye en basit haliyle swagger eklenmiş ve launchsettings.json da gerekli yönlendirme yapılmıştır.

Proje komple .net core ile yazılmıştır. DB olarak MongoDB, cache olarak Redis kullanılmıştır.

Projenin çalışması için "appsettings.json" bunulan MongoDB ayarlarının girilmesi gerekmektedir.

RedisCache leme çalışabilmesi için "appsettings.json" bunulan Redis ayarlarının girilmesi gerekmektedir.


Katmanlar;<br>
SelamYemek.Api;<br>
	Api controller ları bu projede yer almaktadır.

SelamYemek.Common;<br>
	Projede kullanılan modeller, exeptionhandler, result file ları bu projede yer akmaktadır. Mapleme için automapper tarzı kullanılabilirdi ama ben projede kullanmadım.

SelamYemek.Service;<br>
	Apideki logic bu projede yer almaktadır.

SelamYemek.Data;<br>
	DbContext ve dbentityleri bu projede yer almaktadır.

SelamYemek.Repository;<br>
	Tüm repositoryler bu projede yer almaktadır.

SelamYemek.Caching;<br>
	Cache için kullanılan redis code ları bu projede yer almaktadır.
