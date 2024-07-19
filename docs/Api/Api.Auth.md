# InvenEase - Storage Manager API

- [InvenEase - Storage Manager API](#invenease---storage-manager-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

## Auth

### Register

```javascript
POST {{host}}/auth/register
```

#### Register Request

```json
{
  "firstName": "Victor",
  "lastName": "Azevedo",
  "email": "victor.azevedo@email.com",
  "password": "v.azevedo123",
}
```

#### Register Response

```javascript
200 OK
```

```json
{
  "id": "fb28a416-bb8b-4ca6-b15d-c03383756ada",
  "firstName": "Victor",
  "lastName": "Azevedo",
  "email": "victor.azevedo@email.com",
  "role": "requester",
  "token":"eyJhbGci...adQss5c"
}
```

### Login

```javascript
POST {{host}}/auth/login
```

#### Login Request

```json
{
  "email": "victor.azevedo@email.com",
  "password": "v.azevedo123"
}
```

#### Login Response

```javascript
200 OK
```

```json
{
  "id": "fb28a416-bb8b-4ca6-b15d-c03383756ada",
  "firstName": "Victor",
  "lastName": "Azevedo",
  "email": "victor.azevedo@email.com",
  "role": "requester",
  "token":"eyJhbGci...adQss5c"
}
```
