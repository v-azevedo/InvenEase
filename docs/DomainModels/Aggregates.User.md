# Domain Models

## User

```c#
class User 
{
    User Create();
    void Update();
    void Delete();
}
```

```json
{
    "id": {"value": "000000000-0000-0000-0000-000000000000"},
    "firstName": "John",
    "lastName": "Doe",
    "email": "jonh.doe@email.com",
    "password": "john@doe!123",
    "createdDateTime": "2021-01-01T00:00:00Z",
    "updatedDateTime": "2021-01-01T00:00:00Z",
}
```
