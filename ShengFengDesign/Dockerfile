# 使用 .NET 6.0 的官方 SDK 作為基礎映像
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# 設置工作目錄
WORKDIR /app

# 將項目文件複製到映像中
COPY . ./

# 執行 dotnet 命令來生成應用程序
RUN dotnet publish -c Release -o out

# 使用 ASP.NET Core 的官方運行時作為基礎映像
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# 設置工作目錄
WORKDIR /app

RUN sed -i 's/TLSv1.2/TLSv1/g' /etc/ssl/openssl.cnf \
&& sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf

# 從 build-env 映像中複製生成的應用程序到這個映像中
COPY --from=build-env /app/out .

# 暴露應用程序要聽的端口
EXPOSE 80

# 設置命令來運行應用程序
CMD ["dotnet", "ShengFengDesign.dll"]
