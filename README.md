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
Duomenų bazė: SQL server

UML deployment diagrama:
![image](https://user-images.githubusercontent.com/79587555/209173041-1d2b92c2-2f08-4945-9898-3910880ae67a.png)



JWT kodavimo algoritmas: HS256

JWT data:
```
"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name": "admin",
  "jti": "83fb3273-048d-4bad-bd30-951f606aea4a",
  "sub": "e716baf7-4ee0-4ae5-8f2d-fd36a0a70437",
  "http://schemas.microsoft.com/ws/2008/06/identity/claims/role": [
    "Manager",
    "Worker",
    "Admin"
  ],
  "exp": 1671722792,
  "iss": "Aurimas",
  "aud": "TrustedClient"
}
```
# Wireframe
Prisijungimas:
----------------------------------------------------------
![image](https://user-images.githubusercontent.com/79587555/209176690-0cd49710-1c93-421d-a45a-e537b2718e06.png)
----------------------------------------------------------
Puslapio prisijungimas:
----------------------------------------------------------
![image](https://user-images.githubusercontent.com/79587555/209177183-c77f578f-bc9a-404b-81ca-62dcb30e5ef5.png)
----------------------------------------------------------

Registracija:
----------------------------------------------------------
![image](https://user-images.githubusercontent.com/79587555/209177127-d34e7d4f-8755-470e-bc19-ef3e68bed89e.png)
----------------------------------------------------------
Puslapio registracija:
----------------------------------------------------------
![image](https://user-images.githubusercontent.com/79587555/209177227-42a16d49-5e5a-485e-b892-44aa373f5bd9.png)
----------------------------------------------------------
Sandėliai CRUD:
----------------------------------------------------------
![image](https://user-images.githubusercontent.com/79587555/209177793-15f8af37-1ff6-4e98-ab07-0bffe6d128c7.png)
----------------------------------------------------------
Manager registracija:
----------------------------------------------------------
![image](https://user-images.githubusercontent.com/79587555/209177903-edb420f5-c824-401f-a364-266ddc8b5fb4.png)
----------------------------------------------------------





# Registracija, prisijungimas

## Prisijungti
| API-Metodas | Login(Post) | 
| :---:         |     :---:      |
| Paskirtis  | Prisijungti prie sistemos     | 
| ENDPOINT   | api/login   | 
| Užklausos struktūra   | { "userName": string, "password": string }    | 
| Užklausos header   |   -   | 
| Kuri rolė atlieka   | -     | 
| Atsakymo kodas   | 200 - OK     | 
| Atsakymo struktūra   |   { "id": string, "userName": string, "roles": string[], "accessToken": string }  | 
| Kiti galimi atsakymai   | 400 - BadRequest   | 
----------------------------------------------------------------
## Registruotis
| API-Metodas | Register(Post) | 
| :---:         |     :---:      |
| Paskirtis  | Registruotis(worker) prie sistemos     | 
| ENDPOINT   | api/register   | 
| Užklausos struktūra   | { "userName": string, "email": string, "password": string }    | 
| Užklausos header   |   -   | 
| Kuri rolė atlieka   | -     | 
| Atsakymo kodas   | 201 - Created     | 
| Atsakymo struktūra   |   { "id": string, "userName": string, "email": string }  | 
| Kiti galimi atsakymai   | 400 - BadRequest   | 
----------------------------------------------------------------
## Registruoti vadovą
| API-Metodas | RegisterManager(Post) | 
| :---:         |     :---:      |
| Paskirtis  | Registruoti(manager) prie sistemos     | 
| ENDPOINT   | api/register   | 
| Užklausos struktūra   | { "userName": string, "email": string, "password": string }    | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin    | 
| Atsakymo kodas   | 201 - Created     | 
| Atsakymo struktūra   |   { "id": string, "userName": string, "email": string }  | 
| Kiti galimi atsakymai   | 400 - BadRequest   | 

# Sandėliai

## Kurti sandėlį
| API-Metodas | Create(Post) Warehouse | 
| :---:         |     :---:      |
| Paskirtis  | Sukurti sandėlį     | 
| ENDPOINT   | api/warehouses   | 
| Užklausos struktūra   | { "Name": string, "Description": string, "Address": string }    | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin    | 
| Atsakymo kodas   | 201 - Created     | 
| Atsakymo struktūra   |   { "id":  int , "name": string, "description":string, "address": string, "creationDate": DateTime.Now }  | 
| Kiti galimi atsakymai   | 400 - BadRequest, 401 - unauthorized, 403 - forbidden  | 
----------------------------------------------------------------
## Trinti sandėlį
| API-Metodas | Delete(Delete) Warehouse | 
| :---:         |     :---:      |
| Paskirtis  | Trinti 1 sandėlį     | 
| ENDPOINT   | api/warehouses/{warehouseId}   | 
| Užklausos struktūra   | - | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin   | 
| Atsakymo kodas   | 204 - No Content    | 
| Atsakymo struktūra   |  -  | 
| Kiti galimi atsakymai   |  401 - unauthorized, 403 - forbidden, 404 - Not Found  | 
----------------------------------------------------------------
## Gauti sandėlį
| API-Metodas | Get(Get) Warehouse | 
| :---:         |     :---:      |
| Paskirtis  | Gauti 1 sandėlį     | 
| ENDPOINT   | api/warehouses/{warehouseId}   | 
| Užklausos struktūra   | -    | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin/Manager/Worker    | 
| Atsakymo kodas   | 200 - OK     | 
| Atsakymo struktūra   |   { "id":  int , "name": string, "description":string, "address": string, "creationDate": DateTime.Now , "userId": null, "user": null }  | 
| Kiti galimi atsakymai   |  401 - unauthorized, 403 - forbidden, 404 - Not Found  | 
----------------------------------------------------------------
## Gauti sandėlius
| API-Metodas | Get(Get) Warehouses | 
| :---:         |     :---:      |
| Paskirtis  | Gauti visus sandėlius     | 
| ENDPOINT   | api/warehouses   | 
| Užklausos struktūra   | -    | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin/Manager/Worker    | 
| Atsakymo kodas   | 200 - OK     | 
| Atsakymo struktūra   |   ({ "id":  int , "name": string, "description":string, "address": string, "creationDate": DateTime.Now , "userId": null, "user": null })LIST| 
| Kiti galimi atsakymai   |  401 - unauthorized, 403 - forbidden, 404 - Not Found, 204 - No Content  | 
----------------------------------------------------------------
## Redaguoti sandėlį
| API-Metodas | Update(Put) Warehouse | 
| :---:         |     :---:      |
| Paskirtis  | Redaguoti 1 sandėlį     | 
| ENDPOINT   | api/warehouses/{warehouseId}   | 
| Užklausos struktūra   | { "name": string, "description": string }    | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin   | 
| Atsakymo kodas   | 200 - OK     | 
| Atsakymo struktūra   |   { "id":  int , "name": string, "description":string, "address": string, "creationDate": DateTime.Now , "userId": null, "user": null }| 
| Kiti galimi atsakymai   |  401 - unauthorized, 403 - forbidden, 404 - Not Found, 204 - No Content  | 

# Zonos

## Kurti zoną
| API-Metodas | Create(Post) Zone | 
| :---:         |     :---:      |
| Paskirtis  | Sukurti zoną sandėlyje     | 
| ENDPOINT   | api/warehouses/{warehouseId}/zones  | 
| Užklausos struktūra   | { "Name": string }    | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin   | 
| Atsakymo kodas   | 201 - Created     | 
| Atsakymo struktūra   |   { "id": int, "name": string }  | 
| Kiti galimi atsakymai   | 400 - BadRequest, 401 - unauthorized, 403 - forbidden  | 
----------------------------------------------------------------
## Trinti zoną
| API-Metodas | Delete(Delete) Zone | 
| :---:         |     :---:      |
| Paskirtis  | Trinti 1 sandėlį     | 
| ENDPOINT   | api/warehouses/{warehouseId}/zones/{zoneId}    | 
| Užklausos struktūra   | - | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin   | 
| Atsakymo kodas   | 204 - No Content    | 
| Atsakymo struktūra   |    -  | 
| Kiti galimi atsakymai   |  401 - unauthorized, 403 - forbidden, 404 - Not Found  | 
----------------------------------------------------------------
## Gauti zoną
| API-Metodas | Get(Get) Zone | 
| :---:         |     :---:      |
| Paskirtis  | Gauti 1 zoną     | 
| ENDPOINT   | api/warehouses/{warehouseId}/zones/{zoneId}    | 
| Užklausos struktūra   | -    | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin/Manager/Worker    | 
| Atsakymo kodas   | 200 - OK     | 
| Atsakymo struktūra   |   { "id": int, "name": string }  | 
| Kiti galimi atsakymai   |  401 - unauthorized, 403 - forbidden, 404 - Not Found  | 
----------------------------------------------------------------
## Gauti zonas
| API-Metodas | Get(Get) Zones | 
| :---:         |     :---:      |
| Paskirtis  | Gauti visas zonas     | 
| ENDPOINT   | api/warehouses/{warehouseId}/zones   | 
| Užklausos struktūra   | -    | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin/Manager/Worker    | 
| Atsakymo kodas   | 200 - OK     | 
| Atsakymo struktūra   |   ( { "id": int, "name": string })LIST | 
| Kiti galimi atsakymai   |  401 - unauthorized, 403 - forbidden, 404 - Not Found, 204 - No Content  | 
----------------------------------------------------------------
## Redaguoti zoną
| API-Metodas | Update(Put) Zone | 
| :---:         |     :---:      |
| Paskirtis  | Redaguoti 1 zoną     | 
| ENDPOINT   | api/warehouses/{warehouseId}/zones/{zoneId}   | 
| Užklausos struktūra   | { "name": string }    | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin/Manager   | 
| Atsakymo kodas   | 200 - OK     | 
| Atsakymo struktūra   |   { "id": int, "name": string } | 
| Kiti galimi atsakymai   |  401 - unauthorized, 403 - forbidden, 404 - Not Found, 204 - No Content  | 


# Daiktai

## Kurti daiktą
| API-Metodas | Create(Post) Item | 
| :---:         |     :---:      |
| Paskirtis  | Sukurti daiktą     | 
| ENDPOINT   | api/warehouses/{warehouseId}/zones/{zoneId}/items   | 
| Užklausos struktūra   | { "Name": string, "Description": string }    | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin/Manager    | 
| Atsakymo kodas   | 201 - Created     | 
| Atsakymo struktūra   |   { "id": int, "name": string, "description": string } | 
| Kiti galimi atsakymai   | 400 - BadRequest, 401 - unauthorized, 403 - forbidden  | 
----------------------------------------------------------------
## Trinti daiktą
| API-Metodas | Delete(Delete) Item | 
| :---:         |     :---:      |
| Paskirtis  | Redaguoti 1 daiktą     | 
| ENDPOINT   | api/warehouses/{warehouseId}/zones/{zoneId}/items/{itemId}   | 
| Užklausos struktūra   | - | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin/Manager/Worker   | 
| Atsakymo kodas   | 204 - No Content    | 
| Atsakymo struktūra   |   - | 
| Kiti galimi atsakymai   |  401 - unauthorized, 403 - forbidden, 404 - Not Found  | 
----------------------------------------------------------------
## Gauti daiktą
| API-Metodas | Get(Get) Item | 
| :---:         |     :---:      |
| Paskirtis  | Gauti 1 daiktą     | 
| ENDPOINT   | api/warehouses/{warehouseId}/zones/{zoneId}/items/{itemId}  | 
| Užklausos struktūra   | { "name": string, "description": string}   | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin/Manager/Worker    | 
| Atsakymo kodas   | 200 - OK     | 
| Atsakymo struktūra   |   { "id": int, "name": string, "description": string }  | 
| Kiti galimi atsakymai   |  401 - unauthorized, 403 - forbidden, 404 - Not Found  | 
----------------------------------------------------------------
## Gauti daiktus
| API-Metodas | Get(Get) Items | 
| :---:         |     :---:      |
| Paskirtis  | Gauti visus daiktus     | 
| ENDPOINT   | api/warehouses/{warehouseId}/zones/{zoneId}/items  | 
| Užklausos struktūra   | -    | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin/Manager/Worker    | 
| Atsakymo kodas   | 200 - OK     | 
| Atsakymo struktūra   |   ({ "id": int, "name": string, "description": string })LIST| 
| Kiti galimi atsakymai   |  401 - unauthorized, 403 - forbidden, 404 - Not Found, 204 - No Content  | 
----------------------------------------------------------------
## Redauoti daiktus
| API-Metodas | Update(Put) item | 
| :---:         |     :---:      |
| Paskirtis  | Redaguoti 1 daiktą     | 
| ENDPOINT   |api/warehouses/{warehouseId}/zones/{zoneId}/items/{itemId}   | 
| Užklausos struktūra   | { "name": string, "description": string, "newZoneId": int }   | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin/Manager/Worker   | 
| Atsakymo kodas   | 200 - OK     | 
| Atsakymo struktūra   |   { "id": int, "name": string, "description": string }| 
| Kiti galimi atsakymai   |  401 - unauthorized, 403 - forbidden, 404 - Not Found, 204 - No Content  | 
