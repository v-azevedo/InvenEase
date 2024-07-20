# InvenEase - Storage Manager API

- [InvenEase - Storage Manager API](#invenease---storage-manager-api)
  - [Item](#item)
    - [Create](#create)
      - [Create Request](#create-request)
      - [Create Response](#create-response)

## Item

### Create

```javascript
POST /items
```

#### Create Request

```json
{
  "name": "Item",
  "description": "Item description",
  "code": "000000",
  "imageUrl": "https://utfs.io/f/e1c218ab-7827-4ff6-8a68-5c07e701ac24-y7xt7g.png",
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
  "name": "Item",
  "description": "Item description",
  "code": "000000",
  "imageUrl": "https://utfs.io/f/e1c218ab-7827-4ff6-8a68-5c07e701ac24-y7xt7g.png",
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
