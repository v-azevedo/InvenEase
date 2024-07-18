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
    "id": "000000000-0000-0000-0000-000000000000",
    "description": "Order necessary for the functioning of the administration department.",
    "status": "pending",
    "approved": false,
    "invoice": "something.pdf",
    "urgency": "low",
    "objects": [
        {
            "objectId": "000000000-0000-0000-0000-000000000000",
            "quantity": 1,
        },
        {
            "objectId": "000000000-0000-0000-0000-000000000000",
            "quantity": 2,
        }
    ],
    "createdDateTime": "2021-01-01T00:00:00Z",
    "updatedDateTime": "2021-01-01T00:00:00Z",
    "requestId": "000000000-0000-0000-0000-000000000000",
    "stockistId": "000000000-0000-0000-0000-000000000000",
    "managerId": "000000000-0000-0000-0000-000000000000",
}
```
