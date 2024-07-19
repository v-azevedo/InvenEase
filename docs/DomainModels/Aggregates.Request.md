# Domain Models

## Request

```c#
class Request 
{
    Request Create();
    void Update();
    void Cancel();
    void Delete();
}
```

```json
{
    "id": {"value": "000000000-0000-0000-0000-000000000000"},
    "description": "This request is for testing purposes, will be returned after the test.",
    "status": "pending", // pending, ongoing, delivered, canceled, closed
    "requesterDelivered": false,
    "urgency": "low",
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
    "orderIds": [
        {"value": "000000000-0000-0000-0000-000000000000"},
        {"value": "000000000-0000-0000-0000-000000000000"}
    ],
    "requesterId": {"value": "000000000-0000-0000-0000-000000000000"},
    "stockistId": {"value": "000000000-0000-0000-0000-000000000000"},  
    "createdDateTime": "2021-01-01T00:00:00Z",
    "updatedDateTime": "2021-01-01T00:00:00Z",
}
```
