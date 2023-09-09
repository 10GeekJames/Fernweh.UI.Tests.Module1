# ReadMe

## Install Playwright

```text
git reset --hard origin/master
dotnet tool install --global Microsoft.Playwright.CLI --version 1.2.3
```

```text
playwright install
```

## To Run Tests

```text
dotnet test

dotnet test --filter "Category=SearchTests" -e env=uat
```


## To Run the Living Docs test reports
```text
livingdoc feature-folder ./ -t ./bin/Debug\net7.0\TestExecution*.json --output TestFeatureReport.html

livingdoc test-assembly ./bin/Debug\net7.0\Fernweh.BlazorClient.UITests.dll -t TestFeatureData.json --output TestAssemblyReport.html

```


## To Run the Living Docs Data Export
```text
livingdoc feature-folder ./ --output-type JSON -t bin/Debug/net7.0/TestExecution*.json --output TestFeatureData.json
```

