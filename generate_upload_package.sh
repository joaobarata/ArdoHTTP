dotnet publish -c Release -r linux-x64 --self-contained false
zip -ur ArdoHTTP.zip ./bin/Release/net10.0/linux-x64/publish/*