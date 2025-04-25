# assigning dotnet.sdk as the base image

#base image meaning it's then foundation layer/entry point of the docker layers
FROM mcr.microsoft.com/dotnet/sdk AS build-env

#working Directory meaning it sets the working directory for "RUN","CMD","COPY" like instructions
WORKDIR /App

#this makes application inside container listen to port 8080 to connect
EXPOSE 8080

#This docker pattern helps Docker cache the restore layer, so it doesn’t re-download NuGet packages unless your .csproj file changes.
#COPY *.csproj ./

#COPY [Source] [Destination]
#The first/Source is relative to the HOST build context
#The Second/Destinaion is relative the CONTAINER's WORKING DIR
#Copy everything from the current folder on my host computer into "/App" inside the container 
COPY . ./


# run "Download all the nuget packages need by the project" same as npm install 
RUN dotnet restore

#dotnet publish gives deployable output that can copy to another machiene inthis case outputs to docker image to run
# -o / --output sets the output directory for the published app
RUN dotnet publish --output out


#build runtime image

#This is the base image you're using for the runtime environment:
# mcr.microsoft - is the official continer registry and it grabs ASP.Net Core RunTime image 
#runtime image doesn't include build tools and only includes deployable artifacts 
#above image and below image version should match eachother
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /App

COPY --from=build-env /App/out ./
ENTRYPOINT ["dotnet","weatherWebRecords.dll"]

#build 