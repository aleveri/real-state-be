# 🏠 RealEstate API

A backend API for managing and retrieving real estate property data.  
Built with **.NET 9**, **C#**, and **MongoDB** following Clean Architecture principles.

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
- OpenAPI documentation
- Extensible for Owners, Property Images, and Property Trace

---
# 🏠 RealEstate API

A backend API for managing and retrieving real estate property data.  
Built with **.NET 9**, **C#**, and **MongoDB** following Clean Architecture principles.

---

## 🚀 Features
- Retrieve properties with filters:
  - **Name** (partial, case-insensitive)
  - **Address** (partial, case-insensitive)
  - **Price range**
- Pagination (page number & size)
- Sorting (by `Name`, `Price`, or `Year`, ASC/DESC)
- Returns property DTOs with:
  - IdOwner
  - Name
  - Address
  - Price
  - One enabled image
- Clean architecture (Domain, Application, Infrastructure, WebApi layers)
- MongoDB integration with official C# driver
- OpenAPI documentation
- Error handling middleware for consistent JSON error responses
- Unit testing with NUnit + Moq

---

## 🛠️ Tech Stack
- **.NET 9 / ASP.NET Core Web API**
- **C#**
- **MongoDB**
- **MongoDB.Driver**
- **Swagger / OpenAPI**
- **NUnit + Moq** for unit testing

---

## 📂 Project Structure
```
RealEstateAPI/
│── Application/             # Business logic (Services, DTOs, Interfaces)
│── Domain/                  # Entities (Property, Owner, Images, Traces)
│── Infrastructure/          # MongoDB repositories + settings
│── WebApi/                  # Controllers + Program.cs + Middleware
│── Tests/                   # NUnit tests (unit + integration)
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
   - OpenAPI JSON → `https://localhost:5001/openapi/v1.json`

---

## 🔎 API Endpoints

### Get all properties (with filters, pagination, sorting)
```http
GET /api/property/filter/{name}/{address}/{minPrice}/{maxPrice}/{pageNumber}/{pageSize}?sortBy=Price&sortDirection=asc
```

Example:
```http
GET /api/property/filter/House/Miami/100000/2000000/1/10?sortBy=Price&sortDirection=desc
```

Response:
```json
{
  "pageNumber": 1,
  "pageSize": 10,
  "results": [
    {
      "idOwner": "64af8b2e87a1f1a000000002",
      "name": "Beach House",
      "address": "200 Ocean Dr, Miami",
      "price": 1250000,
      "image": "beach_house_1.jpg"
    }
  ]
}
```

---

## 📬 Postman Collection

1. Open Postman → `Import` → paste this link or load `RealEstateAPI.postman_collection.json` (included in repo).  
2. Variables:
   - `baseUrl` → `https://localhost:5001`  

Example request in Postman:
```
GET {{baseUrl}}/api/property/filter/House/Miami/100000/2000000/1/5?sortBy=Year&sortDirection=asc
```

---

## 🧪 Testing

### Unit Tests
- Located in `Tests/Application/PropertyServiceTests.cs`  
- Run with:
  ```bash
  dotnet test
  ```

Covers:
- ✅ PropertyService returns mapped DTOs  
- ✅ Empty repo returns empty list  
- ✅ Property images correctly included  

### Integration Tests (optional)
- Use [Mongo2Go](https://github.com/Mongo2Go/Mongo2Go) or [Testcontainers](https://github.com/testcontainers/testcontainers-dotnet) for disposable MongoDB.  

---

## 👨‍💻 Author
**Andres Leveri**

## 🛠️ Tech Stack
- **.NET 9 / ASP.NET Core Web API**
- **C#**
- **MongoDB**
- **MongoDB.Driver**
- **OpenAPI**
- **NUnit** for unit testing

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

## 👨‍💻 Author
**Andres Leveri**
