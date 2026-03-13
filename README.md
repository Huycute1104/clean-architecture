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
        dotnet add package FluentValidation
        dotnet add package FluentValidation.DependencyInjectionExtensions
        
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

    - Utils
        + Localization
            dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.0
            dotnet add package CoreApiResponse --version 1.0.1
            dotnet add package Microsoft.Extensions.Hosting.Abstractions --version 8.0.0
    - Test
        Tạo 
        dotnet new xunit -n be-authenticationDomain.Tests
        dotnet new xunit -n be-authenticationApplication.Tests
        dotnet new xunit -n be-authenticationIntegrationTests
        
        dotnet sln add .\be-authenticationDomain.Tests\be-authenticationDomain.Tests.csproj
        dotnet sln add .\be-authenticationApplication.Tests\be-authenticationApplication.Tests.csproj
        dotnet sln add .\be-authenticationIntegrationTests\be-authenticationIntegrationTests.csproj

        Add Refe
        dotnet add .\be-authenticationDomain.Tests\be-authenticationDomain.Tests.csproj reference .\be-authenticationDomain\be-authenticationDomain.csproj

        dotnet add .\be-authenticationApplication.Tests\be-authenticationApplication.Tests.csproj reference .\be-authenticationApplication\be-authenticationApplication.csproj
        dotnet add .\be-authenticationApplication.Tests\be-authenticationApplication.Tests.csproj reference .\be-authenticationDomain\be-authenticationDomain.csproj
        
        dotnet add .\be-authenticationIntegrationTests\be-authenticationIntegrationTests.csproj reference .\be-authenticationAPI\be-authenticationAPI.csproj

        Add package
        dotnet add .\be-authenticationDomain.Tests\be-authenticationDomain.Tests.csproj package FluentAssertions

        dotnet add .\be-authenticationApplication.Tests\be-authenticationApplication.Tests.csproj package Moq
        dotnet add .\be-authenticationApplication.Tests\be-authenticationApplication.Tests.csproj package FluentAssertions
        
        dotnet add .\be-authenticationIntegrationTests\be-authenticationIntegrationTests.csproj package Microsoft.AspNetCore.Mvc.Testing
        dotnet add .\be-authenticationIntegrationTests\be-authenticationIntegrationTests.csproj package FluentAssertions
        
## B3 Base Config
