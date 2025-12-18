# Code Coverage – Simple Guide

This project uses **MSTest**, **Coverlet**, and **ReportGenerator**.

---

## 1. Run tests

```bash
dotnet test
```

---

## 2. Generate coverage XML

```bash
dotnet test --collect:"XPlat Code Coverage"
```

This creates:

```
MyApp.Tests/TestResults/.../coverage.cobertura.xml
```

---

## 3. Create HTML report

```bash
reportgenerator -reports:MyApp.Tests/TestResults/**/coverage.cobertura.xml -targetdir:coveragereport -reporttypes:Html
```

---

## 4. Open report

```bash
start coveragereport/index.html
```

---

## What the report shows

* Coverage percentage
* Green lines = covered
* Red lines = not covered

---

## 5. Run mutation testing (Stryker)

### Install Stryker (once)

```bash
dotnet tool install -g dotnet-stryker
```

### Run Stryker

From solution folder:

```bash
dotnet stryker
```

This will:

* Run all tests
* Use coverage data
* Generate an HTML mutation report

---

## Stryker report

* Mutation score percentage
* Survived mutations = missing tests
* Killed mutations = good tests

---

Done.
