# README.md

# .NET Core Dependency Injection Lifetimes Demo (Minimal API)

This project provides a minimal, single-page ASP.NET Core web application (using the **Minimal API** template) to clearly demonstrate the differences between **Transient, Scoped, and Singleton service lifetimes** within the Dependency Injection (DI) system.

## Project Goal

The primary goal is to strip away the complexity of a full MVC application to focus solely on observing how the .NET runtime manages the creation and disposal of services based on their registered lifetime.

## 💡 How the Lifetimes Work

This application registers three services: `ITransientGuidService`, `IScopedGuidService`, and `ISingletonGuidService`. The single endpoint resolves each service **twice** within the same HTTP request to show their behavior.

| Lifetime | Registration | Behavior | How to Observe |
| :--- | :--- | :--- | :--- |
| **Transient** | `builder.Services.AddTransient<...>` | A **new instance** is created *every time* it is requested, even multiple times within the same HTTP request. | The two Transient GUIDs on the page are **different**. |
| **Scoped** | `builder.Services.AddScoped<...>` | A **single instance** is created *per scope* (i.e., per HTTP request). | The two Scoped GUIDs on the page are **the same**, but they **change** every time you refresh the browser (new request). |
| **Singleton** | `builder.Services.AddSingleton<...>` | A **single instance** is created for the *entire application lifetime* (since the server started). | The two Singleton GUIDs are **the same** and **never change** when you refresh the page. They only change if you stop and restart the application. |

## 🛠 Prerequisites

  * .NET SDK (version 6.0 or later, I used 9.0 here)
  * A code editor like VS Code

## 🏃 Getting Started

### 1\. Run the Application

Navigate to the project directory in your terminal and run the following command:

```bash
dotnet build
dotnet run
```

### 2\. View the Results

The console will output the URL where the application is running (e.g., `http://localhost:5000` or `https://localhost:7001`). Open that URL in your web browser.

**To observe the behavior:**

  * Note the GUIDs displayed for each service.
  * **Refresh the page** multiple times and observe which GUIDs change and which remain constant.

-----

## 📁 Key Files and Structure

The entire application logic is contained within `Program.cs` and the service definitions.

| File | Purpose |
| :--- | :--- |
| **`Program.cs`** | Registers all services (`AddSingleton`, `AddScoped`, `AddTransient`) and defines the single Minimal API endpoint that resolves and displays the GUIDs. |
| `*GuidService.cs` | The concrete implementation classes (e.g., `ScopedGuidService.cs`) that generate a `Guid` upon instantiation. |
| `I*GuidService.cs` | The interfaces (e.g., `IScopedGuidService.cs`) used for Dependency Injection. |
