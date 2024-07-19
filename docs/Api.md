# InvenEase - Storage Manager API

- [InvenEase - Storage Manager API](#invenease---storage-manager-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)
  - [Object](#object)
    - [Create](#create)
      - [Create Request](#create-request)
      - [Create Response](#create-response)

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

## Object

### Create

```javascript
POST /object
```

#### Create Request

```json
{
  "name": "Object",
  "description": "Object description",
  "code": "000000",
  "image": "https://utfs.io/f/e1c218ab-7827-4ff6-8a68-5c07e701ac24-y7xt7g.png",
  "dimensions": {
    "length": 10,
    "width": 10,
    "height": 2,
    "weight": 5
  },
  "quantity": 8,
  "minimumQuantity": 5,
}
```

#### Create Response

```javascript
201 OK
```

```json
{
  "id": "000000000-0000-0000-0000-000000000000",
  "name": "Object",
  "description": "Object description",
  "code": "000000",
  "image": "https://utfs.io/f/e1c218ab-7827-4ff6-8a68-5c07e701ac24-y7xt7g.png",
  "dimensions": {
      "length": 10,
      "width": 10,
      "height": 2,
      "weight": 5
  },
  "quantity": 8,
  "minimumQuantity": 5,
  "requestIds": [],
  "orderIds": [],
  "createdDateTime": "2021-01-01T00:00:00Z",
  "updatedDateTime": "2021-01-01T00:00:00Z",
}
```
