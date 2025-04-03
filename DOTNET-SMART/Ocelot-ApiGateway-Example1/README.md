# API Gateway with Ocelot Implementation

## 📦 Needed Packages
- `Ocelot`
- `Ocelot.Cache.CacheManager` (optional, for caching needs)

## ⚙️ Configuration

In this example, we use three web APIs running on different ports, simulating a microservices architecture:

- **API Gateway (Ocelot):** `http://localhost:5139`
- **Article API:** `http://localhost:5172`
- **Writer API:** `http://localhost:5174`

### 🚀 Setup Steps

1. **Install Ocelot package:**
   ```sh
   dotnet add package Ocelot
   ```

2. **Create the Ocelot configuration file:**
   - Add a new JSON file named `ocelot.json` at the root of your project.

3. **Configure the JSON file in your application:**
   - Add the following line in `Program.cs` to load the configuration:
     ```csharp
     builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
     ```

4. **Use Ocelot middleware:**
   - Ensure Ocelot is registered in the middleware pipeline:
     ```csharp
     app.UseOcelot().Wait();
     ```

### 🛠 Ocelot Configuration Highlights
- All routing and gateway logic happen inside `ocelot.json`.
- You can define routes individually or group similar endpoints together.
- Example: Grouping `GET` and `DELETE` requests for articles by ID.

## 📌 Additional Features
- API Gateway
- Rate Limiting
- Load Balancer
- Custom Authorization Policies
- Performance Testing for APIs

### 🎥 Video Resource
For an in-depth explanation, check out this tutorial:
[API Gateway with Ocelot - Milan Jovanović](https://www.youtube.com/watch?v=2_hjz-325Fg&ab_channel=MilanJovanovi%C4%87)

---
🔹 **Happy coding!** 🚀
