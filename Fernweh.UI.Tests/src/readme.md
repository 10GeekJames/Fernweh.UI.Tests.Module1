# Fernweh e2e UI tests mission

## Prerequisites

### Install Playwright

```text
dotnet tool install --global Microsoft.Playwright.CLI
```

Install Playwright in the project
```text
playwright install
```

```text
dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI
```

## Start by running all the tests against qa

```text
.\Fernweh.UI.Tests\src\test.bat
.\Fernweh.UI.Tests\src\reports.bat
```

## Running a specific test

```text
dotnet test --filter "Category=SearchTests" -e env=qa
```

## To run tests using the various batch files

```text
test uat SearchTests
test qa
test dev
```

## To run the test reports
```text
reports.bat
```

test.bat will run the tests and generate the reports in the ./Reports folder


