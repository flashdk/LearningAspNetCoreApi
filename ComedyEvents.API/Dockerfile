#Get sdk image from mMicrosoft
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

#COPY the CSPROJ file and restore any dependecies
COPY *.csproj ./
Run dotnet restore

#Copy the prjet files and build our release
Copy . ./
Run dotnet publish -c Release -o out

#Generate runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ComedyEvents.API.dll]