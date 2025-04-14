"# CleanArchitectureDemo"

# Các bước build source code

## B1: Tạo solution

    - Tạo project ASP.NET Core Web API (Ex : cleanAPI)
    - Tạo clas libary [NameProject]Application (Ex : cleanApplication)
    - Tạo clas libary [NameProject]Domain (Ex : cleanDomain)
    - Tạo clas libary [NameProject]Infrastructure (Ex : cleanInfrastructure)

    - Add project reference
        + cleanAPI reference  cleanApplication,cleanInfrastructure
        + cleanApplication reference  cleanDomain
        + cleanDomain no reference
        + cleanInfrastructure reference  cleanApplication, cleanDomain

## B2 Cài thư viện nuget

    - cleanAPI
        dotnet add package Microsoft.EntityFrameworkCore --version 8.0.14
        dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.14
        dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.14
        dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.14

        dotnet add package Swashbuckle.AspNetCore.Annotations --version 8.0.0
        dotnet add package Swashbuckle.AspNetCore.Swagger --version 8.0.0
        dotnet add package CoreApiResponse --version 1.0.1

        Lệnh cài trong cleanAPI xml config swagger api docs
        <GenerateDocumentationFile>true</GenerateDocumentationFile>
        <NoWarn>1591</NoWarn>
        <UserSecretsId>1e8194e5-5b3a-462e-a25c-c771d41ca2ed</UserSecretsId>
        <DockerDefaultTargetOS>Linux</DockerDefaultTargetOS><!-- Tắt cảnh báo nếu không có XML comment -->

    - cleanApplication
        dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.0
        dotnet add package Microsoft.AspNetCore.Http.Abstractions --version 2.3.0

    - cleanDomain
        dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.0
        dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 8.0.14
        dotnet add package Microsoft.EntityFrameworkCore --version 8.0.14
        dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.14
        dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.14
        dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.14


    - cleanInfrastructure
        dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.0
        dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.14

        + option

        realtime
        dotnet add package Microsoft.AspNetCore.SignalR.Client --version 8.0.14
        dotnet add package Microsoft.AspNetCore.SignalR.Common --version 8.0.14

        cron job
        dotnet add package Quartz --version 3.14.0
        dotnet add package Quartz.Extensions.Hosting --version 3.14.0

## B3 Base Config
