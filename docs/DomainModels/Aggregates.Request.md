# Domain Models

## Request

```c#
class Request 
{
    Request Create();
    Request Update();
    Request Cancel();
    
}
```

```json
{
    "id": "000000000-0000-0000-0000-000000000000",
    "description": "This request is for testing purposes, will be returned after the test.",
    "status": "pending",
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
    "orderIds": [
        "000000000-0000-0000-0000-000000000000",
        "000000000-0000-0000-0000-000000000000"
    ],
    "requesterId": "000000000-0000-0000-0000-000000000000",
    "stockistId": "000000000-0000-0000-0000-000000000000",  
}
```
