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

# Rgistracija, prisijungimas

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
| API-Metodas | Register Manager(Post) | 
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

| API-Metodas | Create(Post) Warehouse | 
| :---:         |     :---:      |
| Paskirtis  | Sukurti sandėlį     | 
| ENDPOINT   | api/warehouses   | 
| Užklausos struktūra   | { "Name": string, "Description": string, "Address": string }    | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin    | 
| Atsakymo kodas   | 201 - Created     | 
| Atsakymo struktūra   |   { "id": "string", "userName": "string", "email": "string" }  | 
| Kiti galimi atsakymai   | 400 - BadRequest, 401 - unauthorized, 403 - forbidden  | 
----------------------------------------------------------------
| API-Metodas | Delete(Delete) Warehouse | 
| :---:         |     :---:      |
| Paskirtis  | Redaguoti 1 sandėlį     | 
| ENDPOINT   | api/warehouses/{warehouseId}   | 
| Užklausos struktūra   | - | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin   | 
| Atsakymo kodas   | 204 - No Content    | 
| Atsakymo struktūra   |   No Content| 
| Kiti galimi atsakymai   |  401 - unauthorized, 403 - forbidden, 404 - Not Found  | 
----------------------------------------------------------------
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
| API-Metodas | Update(Put) Warehouse | 
| :---:         |     :---:      |
| Paskirtis  | Redaguoti 1 sandėlį     | 
| ENDPOINT   | api/warehouses/{warehouseId}   | 
| Užklausos struktūra   | { "name": string, "description": string }    | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin   | 
| Atsakymo kodas   | 200 - OK     | 
| Atsakymo struktūra   |   ({ "id":  int , "name": string, "description":string, "address": string, "creationDate": DateTime.Now , "userId": null, "user": null })LIST| 
| Kiti galimi atsakymai   |  401 - unauthorized, 403 - forbidden, 404 - Not Found, 204 - No Content  | 

# Zonos

| API-Metodas | Create(Post) Warehouse | 
| :---:         |     :---:      |
| Paskirtis  | Sukurti sandėlį     | 
| ENDPOINT   | api/warehouses   | 
| Užklausos struktūra   | { "Name": string, "Description": string, "Address": string }    | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin    | 
| Atsakymo kodas   | 201 - Created     | 
| Atsakymo struktūra   |   { "id": "string", "userName": "string", "email": "string" }  | 
| Kiti galimi atsakymai   | 400 - BadRequest, 401 - unauthorized, 403 - forbidden  | 
----------------------------------------------------------------
| API-Metodas | Delete(Delete) Warehouse | 
| :---:         |     :---:      |
| Paskirtis  | Redaguoti 1 sandėlį     | 
| ENDPOINT   | api/warehouses/{warehouseId}   | 
| Užklausos struktūra   | - | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin   | 
| Atsakymo kodas   | 204 - No Content    | 
| Atsakymo struktūra   |   No Content| 
| Kiti galimi atsakymai   |  401 - unauthorized, 403 - forbidden, 404 - Not Found  | 
----------------------------------------------------------------
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
| API-Metodas | Update(Put) Warehouse | 
| :---:         |     :---:      |
| Paskirtis  | Redaguoti 1 sandėlį     | 
| ENDPOINT   | api/warehouses/{warehouseId}   | 
| Užklausos struktūra   | { "name": string, "description": string }    | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin   | 
| Atsakymo kodas   | 200 - OK     | 
| Atsakymo struktūra   |   ({ "id":  int , "name": string, "description":string, "address": string, "creationDate": DateTime.Now , "userId": null, "user": null })LIST| 
| Kiti galimi atsakymai   |  401 - unauthorized, 403 - forbidden, 404 - Not Found, 204 - No Content  | 


# Daiktai

| API-Metodas | Create(Post) Warehouse | 
| :---:         |     :---:      |
| Paskirtis  | Sukurti sandėlį     | 
| ENDPOINT   | api/warehouses   | 
| Užklausos struktūra   | { "Name": string, "Description": string, "Address": string }    | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin    | 
| Atsakymo kodas   | 201 - Created     | 
| Atsakymo struktūra   |   { "id": "string", "userName": "string", "email": "string" }  | 
| Kiti galimi atsakymai   | 400 - BadRequest, 401 - unauthorized, 403 - forbidden  | 
----------------------------------------------------------------
| API-Metodas | Delete(Delete) Warehouse | 
| :---:         |     :---:      |
| Paskirtis  | Redaguoti 1 sandėlį     | 
| ENDPOINT   | api/warehouses/{warehouseId}   | 
| Užklausos struktūra   | - | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin   | 
| Atsakymo kodas   | 204 - No Content    | 
| Atsakymo struktūra   |   No Content| 
| Kiti galimi atsakymai   |  401 - unauthorized, 403 - forbidden, 404 - Not Found  | 
----------------------------------------------------------------
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
| API-Metodas | Update(Put) Warehouse | 
| :---:         |     :---:      |
| Paskirtis  | Redaguoti 1 sandėlį     | 
| ENDPOINT   | api/warehouses/{warehouseId}   | 
| Užklausos struktūra   | { "name": string, "description": string }    | 
| Užklausos header   |   Authorization: Bearer {token}   | 
| Kuri rolė atlieka   |  Admin   | 
| Atsakymo kodas   | 200 - OK     | 
| Atsakymo struktūra   |   ({ "id":  int , "name": string, "description":string, "address": string, "creationDate": DateTime.Now , "userId": null, "user": null })LIST| 
| Kiti galimi atsakymai   |  401 - unauthorized, 403 - forbidden, 404 - Not Found, 204 - No Content  | 
