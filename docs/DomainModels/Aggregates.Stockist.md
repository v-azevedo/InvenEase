# Domain Models

## Stockist

```c#
class Stockist 
{
    Stockist Create();
    void Update();
    void Remove();
}
```

```json
{
    "id": {"value": "000000000-0000-0000-0000-000000000000"},
    "firstName": "John",
    "lastName": "Doe",
    "role": "stockist",
    "profileImage": "https://www.gravatar.com/avatar/",
    "userId": {"value": "000000000-0000-0000-0000-000000000000"},
    "orderIds": [
        {"value": "000000000-0000-0000-0000-000000000000"},
        {"value": "000000000-0000-0000-0000-000000000000"}
    ],
    "requestIds": [
        {"value": "000000000-0000-0000-0000-000000000000"},
        {"value": "000000000-0000-0000-0000-000000000000"}
    ],
    "createdDateTime": "2021-01-01T00:00:00Z",
    "updatedDateTime": "2021-01-01T00:00:00Z",
}
```
