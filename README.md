# 🏠 RealEstate API

A backend API for managing and retrieving real estate property data.  
Built with **.NET 8**, **C#**, and **MongoDB** following Clean Architecture principles.

---

## 🚀 Features
- Retrieve properties with filters:
  - **Name**
  - **Address**
  - **Price range**
- Returns property DTOs with:
  - IdOwner
  - Name
  - Address
  - Price
  - One enabled image
- Clean architecture (Domain, Application, Infrastructure, WebApi layers)
- MongoDB integration with official C# driver
- Swagger / OpenAPI documentation
- Extensible for Owners, Property Images, and Property Trace

---

## 🛠️ Tech Stack
- **.NET 8 / ASP.NET Core Web API**
- **C#**
- **MongoDB**
- **MongoDB.Driver**
- **Swagger / OpenAPI**
- (Optional) **NUnit** for unit testing

---

## 📂 Project Structure
```
RealEstateAPI/
│── Application/             # Business logic (Services, DTOs, Interfaces)
│── Domain/                  # Entities (Property, Owner, Images, Traces)
│── Infrastructure/          # MongoDB context + repositories
│── WebApi/                  # Controllers + Program.cs
│── Tests/                   # Unit tests (NUnit, Moq)
```

---

## ⚙️ Configuration

Set your MongoDB connection string and database name in **`appsettings.json`**:

```json
{
  "ConnectionStrings": {
    "MongoDb": "mongodb+srv://<user>:<password>@<cluster-url>"
  },
  "MongoDbSettings": {
    "DatabaseName": "millon_assessment"
  }
}
```

---

## ▶️ Running the API

1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo/realestate-api.git
   cd realestate-api
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Run the project:
   ```bash
   dotnet run --project WebApi
   ```

4. Open in browser:
   - Swagger UI → `https://localhost:5001/swagger`
   - OpenAPI JSON → `https://localhost:5001/openapi/v1.json`

---

## 🔎 API Endpoints

### Get all properties (with filters)
```http
GET /api/property/filter/{name}/{address}/{minPrice}/{maxPrice}
```

Example:
```http
GET /api/property/filter/House/Miami/100000/2000000
```

Response:
```json
[
  {
    "idOwner": "64af8b2e87a1f1a000000002",
    "name": "Beach House",
    "address": "200 Ocean Dr, Miami",
    "price": 1250000,
    "image": "beach_house_1.jpg"
  }
]
```

---

### Get property by ID
```http
GET /api/property/{id}
```

---

## 🧪 Testing

### Unit tests (NUnit + Moq)
Run tests with:
```bash
dotnet test
```

Tests include:
- PropertyService (filtering + DTO mapping)
- Repository mocking with Moq

---

## 📌 Next Steps
- Add pagination & sorting
- Add authentication (JWT / Identity)
- Extend endpoints for:
  - Property Images
  - Property Trace (sales history)
  - Owners
- CI/CD setup

---

## 👨‍💻 Author
**Andres Leveri**
