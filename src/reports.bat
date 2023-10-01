livingdoc feature-folder ./ -t ./bin/Debug/net7.0/TestExecution* --output ./Reports/TestFeatureReport.html

livingdoc feature-folder ./ --output-type JSON -t ./bin/Debug/net7.0/TestExecution*.json --output ./Reports/TestFeatureData.json

livingdoc test-assembly ./bin/Debug/net7.0/Fernweh.BlazorClient.UITests.dll -t ./Reports/TestFeatureData.json --output ./Reports/TestAssemblyReport.html

explorer .\Reports