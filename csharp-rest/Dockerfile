FROM microsoft/dotnet:2.1-sdk
COPY pub/ /root/
WORKDIR /root/
ENV ASPNETCORE_URLS="http://*80"
ENV DOTNET_RUNNING_IN_CONTAINER=true
EXPOSE 80/tcp
ENTRYPOINT ["dotnet, csharp-rest.dll"]