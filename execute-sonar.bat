dotnet tool install --global dotnet-sonarscanner
dotnet sonarscanner begin /k:"bookstore" /d:sonar.login="f60d6fd7a7bb9bac3d317b166dc9619aada7755b"

dotnet clean src
dotnet restore src
dotnet build src --no-restore
dotnet test src --no-build
dotnet sonarscanner end /d:sonar.login="f60d6fd7a7bb9bac3d317b166dc9619aada7755b"