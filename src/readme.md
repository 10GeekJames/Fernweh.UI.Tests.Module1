# Fernweh e2e UI tests mission

## Prerequisites

### Install Playwright

```text
dotnet tool install --global Microsoft.Playwright.CLI
```

```text
playwright install
```

## Running a specific test

```text
dotnet test --filter "Category=SearchTests" -e env=uat
```

## To run tests using the various batch files

```text
test uat "Category=SearchTests"
test qa "Category="
test dev ""
```

## To run the test reports
```text
reports.bat
```

test.bat will run the tests and generate the reports in the ./Reports folder

