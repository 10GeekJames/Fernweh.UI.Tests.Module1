livingdoc feature-folder ./ -t ./bin/Debug/net7.0/TestExecution* --output ./Reports/TestFeatureReport.html --binding-assemblies ./../src/bin/Debug/net7.0/Fernweh.UITests.dll

livingdoc feature-folder ./ --output-type JSON -t ./bin/Debug/net7.0/TestExecution*.json --output ./Reports/TestFeatureData.json --binding-assemblies ./../src/bin/Debug/net7.0/Fernweh.UITests.dll

explorer .\Reports