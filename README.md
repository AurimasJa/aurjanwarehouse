# Easy Warehouse system

# Sistemos paskirtis
Projekto tikslas – Sistema kuri padėtų lengviau skirstyti prekes sandėliuose.

Veikimo principas – galimybė sandėliuoti prekes, rasti jų būvimo vietą sandėlyje. Sandėlis turi zonas, kuriose prekės yra laikomos.

Administratorius galės registruoti sandėlius bei vadovų paskyras. Vadovas galės pridėti sandėlyje zonas, kuriose bus laikomos prekės, prekes į pagrindinę zoną. Darbuotojai gali peržiūrėti zonoje esančių prekių sąrašą, perkelti prekes į kitą zoną esančia sandėlyje.

# Funkciniai reikalavimai

Neprisijungęs naudotojas:

•	Prisijungti

•	Peržiūrėti pagrindinį puslapį


Darbuotojas:

•	Skirstyti prekes sandėlio zonose

•	Peržiūrėti sandėlius, zonas, prekes

•	Atsijungti


Vadovas

•	Pridėti sandėlio zonas

•	Peržiūrėti sandėlius, zonas, prekes

•	Pridėti prekes į pagrindinę zoną

•	Atsijungti


Administratorius:

•	Peržiūrėti sandėlius, zonas, prekes

•	Gali pridėti/redaguoti/šalinti sandėlį/zonas/prekes

•	Peržiūrėti sandėlio informaciją

•	Registruoti sandėlio vadovą


# Sistemos sudedamosios dalys:

Front–End : React.js
Back-End : .NET
Duomenų bazė: MySQL

UML deployment diagrama: Vėliau…


| API-Metodas | Login(Post) | 
| :---:         |     :---:      |
| Paskirtis  | Prisijungti prie sistemos     | 
| ENDPOINT   | api/login   | 
| Užklausos struktūra   | { "userName": "admin", "password": "VerySafePassword1!" }    | 
| Užklausos header   |   -   | 
| Kuri rolė atlieka   | -     | 
| Atsakymo kodas   | 200 - OK     | 
| Atsakymo struktūra   | { "id": "e716baf7-4ee0-4ae5-8f2d-fd36a0a70437", "userName": "admin", "roles": [ "Manager", "Worker", "Admin" ], "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRtaW4iLCJqdGkiOiJkNTZhYmQxYi0zNDQzLTQ2NzMtYmE5ZC0wZDAzNzc4NTRlZjEiLCJzdWIiOiJlNzE2YmFmNy00ZWUwLTRhZTUtOGYyZC1mZDM2YTBhNzA0MzciLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOlsiTWFuYWdlciIsIldvcmtlciIsIkFkbWluIl0sImV4cCI6MTY3MTcwOTM2MiwiaXNzIjoiQXVyaW1hcyIsImF1ZCI6IlRydXN0ZWRDbGllbnQifQ.ZRVS38BGByIHag7BxddkE47Zfbtvph3gdAOTH7lG6xM" }     | 
| Kiti galimi atsakymai   | 400 - BadRequest   | 
