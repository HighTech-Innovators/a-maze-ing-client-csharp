$swaggerFile = "https://maze.hightechict.nl/swagger/api/swagger.json"
$outputFolder = "src/HightechICT.Amazeing.Client.Rest"
$namespace = "HightechICT.Amazeing.Client.Rest"
$clientClassName = "AmazeingClient"
$dotnetVersion = "net6.0"

# Get script path and templates path
$scriptPath = Split-Path -Path $MyInvocation.MyCommand.Path -Parent
$templatesPath = Join-Path $scriptPath "NSwagTemplates"

# Install NSwag
dotnet tool restore

# Create output folder if it doesn't exist
New-Item -ItemType Directory -Force -Path $outputFolder

# Use NSwag CLI to generate C# API client
dotnet nswag openapi2csclient `
    /JsonLibrary:"SystemTextJson" `
    /input:$swaggerFile `
    /namespace:$namespace `
    /output:$outputFolder/$clientClassName.cs `
    /classname:$clientClassName `
    /generateClientInterfaces:true `
    /targetframework:$dotnetVersion `
    /OperationGenerationMode:"SingleClientFromOperationId" `
    /TemplateDirectory:$templatesPath