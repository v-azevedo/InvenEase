# Domain Models

## Order

```c#
class Order 
{
    Order Create();
    void Update();
    void Cancel();
    void Delete();
    void Approve();
}
```

```json
{
    "id": {"value": "000000000-0000-0000-0000-000000000000"},
    "description": "Order necessary for the functioning of the administration department.",
    "status": "pending", // pending, approved, ongoing, canceled, completed, closed
    "approved": false,
    "invoice": "something.pdf",
    "urgency": "low", // low, medium, high
    "objects": [
        {
            "objectId": {"value": "000000000-0000-0000-0000-000000000000"},
            "quantity": 1,
        },
        {
            "objectId": {"value": "000000000-0000-0000-0000-000000000000"},
            "quantity": 2,
        }
    ],
    "requestId": {"value": "000000000-0000-0000-0000-000000000000"},
    "stockistId": {"value": "000000000-0000-0000-0000-000000000000"},
    "managerId": {"value": "000000000-0000-0000-0000-000000000000"},
    "createdDateTime": "2021-01-01T00:00:00Z",
    "updatedDateTime": "2021-01-01T00:00:00Z",
}
```
