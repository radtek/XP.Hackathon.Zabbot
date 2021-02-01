# Zabbot - Integração de alertas

API responsible for managing and consulting escalations, enabling the assimilation of existing records and documents used by the NOC. In addition to the integration and communication between the two ends (Teams and Zabbix) with notification of alerts directed to those responsible and status update of Zabbix events (ACK) through chat interaction between the bot and the user.

## Contents

* [General](#general)
* [Frameworks, Libraries and Tools](#frameworks-libraries-and-tools)
  * [API](#api)
  * [Application Frameworks](#application-frameworks)
  * [Authentication and Authorization](#authentication-and-authorization)
  * [Testing](#testing)

## General

* [ASP.NET Core Documentation](https://docs.asp.net/en/latest/) - The official ASP.NET Core documentation site.
* [.NET Core Documentation](https://docs.microsoft.com/en-us/dotnet/articles/welcome) - Home of the technical documentation for .NET Core, C#, F# and Visual Basic, including basic concepts, getting started instructions, tutorials and samples.
* [.NET Core SDK](https://www.microsoft.com/net/core) - .NET Core SDK is a general purpose development platform maintained by Microsoft and the .NET community on [GitHub](https://github.com/dotnet/core).
* [.NET Platform Standard](https://github.com/dotnet/corefx/blob/1719a3fe2a5c81b67a4909787da4a02fb0d0d419/Documentation/architecture/net-platform-standard.md) - The differrent between the old version and the new version of .NET.
* [Introducing .NET Standard 2.0](https://blogs.msdn.microsoft.com/dotnet/2016/09/26/introducing-net-standard) - The description of what will be going on for .NET Standard 2.0 and the roadmap for some missing parts of the current .NET Standard.
* [Clean Code .NET/.NET Core](https://github.com/thangchung/clean-code-dotnet) - Clean Code concepts adapted for .NET / .NET Core.

## Frameworks, Libraries and Tools

### API

* [autorest](https://github.com/Azure/autorest) - Swagger (OpenAPI) Specification code generator featuring C# and Razor templates. Supports C#, Java, Node.js, TypeScript, Python and Ruby. `4.5.x or above`
* [aspnet-api-versioning](https://github.com/Microsoft/aspnet-api-versioning) - set of libraries which add service API versioning to ASP.NET Web API, OData with ASP.NET Web API, and ASP.NET Core.
* [AspNetCoreRateLimit](https://github.com/stefanprodan/AspNetCoreRateLimit) - ASP.NET Core rate limiting middleware.
* [CondenserDotNet](https://github.com/Drawaes/CondenserDotNet) - API Condenser / Reverse Proxy using Kestrel and Consul, Including light weight consul library.
* [Flurl](https://github.com/tmenier/Flurl) - Fluent URL builder and testable HTTP for .NET [https://flurl.dev](https://flurl.dev).
* GraphQL
  * [Dapper.GraphQL](https://github.com/landmarkhw/Dapper.GraphQL) - A library designed to integrate the Dapper and graphql-dotnet projects with ease-of-use in mind and performance as the primary concern.
  * [graphql-aspnetcore](https://github.com/JuergenGutsch/graphql-aspnetcore) - ASP.NET Core MiddleWare to create a GraphQL end-point.
  * [graphql-convention](https://github.com/graphql-dotnet/conventions) - This library is a complementary layer on top that allows you to automatically wrap your .NET classes into GraphQL schema definitions using existing property getters and methods as field resolvers
  * [graphiql-dotnet](https://github.com/JosephWoodward/graphiql-dotnet) - GraphiQL middleware for ASP.NET Core.
  * [graphql-dotnetcore](https://github.com/mkmarek/graphql-dotnetcore) - GraphQL for .NET Core based on [https://github.com/graphql/graphql-js](https://github.com/graphql/graphql-js).
  * [graphql-dotnet](https://github.com/graphql-dotnet/graphql-dotnet) - GraphQL for .NET.
  * [graphql-dotnet-server](https://github.com/graphql-dotnet/server) - GraphQL for .NET - Subscription Transport WebSockets.
  * [Hot Chocolate](https://github.com/ChilliCream/hotchocolate) - GraphQL server for .Net Core and .NET Framework.
  * [FSharp.Data.GraphQL](https://github.com/fsprojects/FSharp.Data.GraphQL) - FSharp implementation of Facebook GraphQL query language [https://fsprojects.github.io/FSharp.Data.GraphQL](https://fsprojects.github.io/FSharp.Data.GraphQL).
  * [parser](https://github.com/graphql-dotnet/parser) - A lexer and parser for GraphQL in .NET.
  * [tanka-graphql](https://github.com/pekkah/tanka-graphql) - GraphQL execution and server libraries supporting SignalR, Apollo, schema manipulation and other features familiar from Apollo and graphql-js
* [halcyon](https://github.com/visualeyes/halcyon) - HAL implementation for ASP.NET.
* [JSON API .NET Core](https://github.com/Research-Institute/json-api-dotnet-core) - Framework for building json:api compliant APIs with the goal of eliminating RESTful boilerplate.
* [LightNode](https://github.com/neuecc/LightNode) - Micro RPC/REST Framework built on OWIN [http://neuecc.github.io/LightNode](http://neuecc.github.io/LightNode).
* [NetCoreStack.Proxy](https://github.com/NetCoreStack/Proxy) - The type-safe, distributed REST library for .NET Standard 2.0 (NetCoreStack Flying Proxy)
* [NSwag](https://github.com/RSuter/NSwag) - The Swagger/OpenAPI toolchain for .NET, Web API and TypeScript. [http://NSwag.org](http://NSwag.org).
* [OData](https://github.com/OData/WebApi/tree/feature/netcore) - The Open Data Protocol (OData) enables the creation of HTTP-based data services, which allow resources identified using Uniform Resource Identifiers (URIs) and defined in an abstract data model, to be published and edited by Web clients using simple HTTP messages.
* [OpenAPI Generator](https://github.com/OpenAPITools/openapi-generator) - OpenAPI Generator allows generation of API client libraries (e.g. C#, TypeScript, etc), server stubs (ASP.NET Core, NancyFx, etc), documentation and configuration automatically given an OpenAPI Spec (v2, v3).
* [refit](https://github.com/paulcbetts/refit) - The automatic type-safe REST library for Xamarin and .NET.
* [RestClient.Net](https://github.com/MelbourneDeveloper/RestClient.Net) - Cross Platform REST Client for all C# platforms
* [RestEase](https://github.com/canton7/RestEase) - Easy-to-use typesafe REST API client library, which is simple and customisable.
* [RestLess](https://github.com/letsar/RestLess) - The automatic type-safe-reflectionless REST API client library for .Net Standard.
* [Restier](https://github.com/OData/RESTier) - RESTier is a RESTful API development framework for building standardized, OData V4 based RESTful services on .NET platform.
* [Restsharp](https://github.com/restsharp/RestSharp) - Simple REST and HTTP API Client for .NET
* [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) - Seamlessly adds a swagger to WebApi projects.
  * [MicroElements.Swashbuckle.FluentValidation](https://github.com/micro-elements/MicroElements.Swashbuckle.FluentValidation) - Adds FluentValidation rules to swagger.
  * [Swashbuckle.AspNetCore.Filters](https://github.com/mattfrear/Swashbuckle.AspNetCore.Filters) - A bunch of useful filters for Swashbuckle.AspNetCore.
* [WebAnchor](https://github.com/mattiasnordqvist/Web-Anchor) - Web Anchor provides type-safe, testable and flexible, runtime-generated access to web resources.
* [WebAPIContrib for ASP.NET CORE](https://github.com/WebApiContrib/WebAPIContrib.Core) - Community Contributions for ASP.NET Core.
### Authentication and Authorization
* [AspNet.Security.OpenIdConnect.Server](https://github.com/aspnet-contrib/AspNet.Security.OpenIdConnect.Server) - OpenID Connect/OAuth2 server framework for OWIN/Katana and ASP.NET Core.
* [Auth0](https://github.com/auth0/auth0.net) - Hosted, enterprise-grade platform for modern identity.
* [Casbin.NET](https://github.com/casbin-net/Casbin.NET) - Authorization library that supports access control models like ACL, RBAC, ABAC in C#
* [Identity](https://github.com/aspnet/Identity) - ASP.NET Core Identity is the membership system for building ASP.NET Core web applications, including membership, login, and user data.
* [IdentityServer](https://github.com/IdentityServer/IdentityServer4) - IdentityServer for ASP.NET Core 1.0 & 2.0
  * [IdentityServer4.EntityFramework](https://github.com/IdentityServer/IdentityServer4.EntityFramework) - EntityFramework persistence layer
  * [IdentityServer4.MongoDB](https://github.com/diogodamiani/IdentityServer4.MongoDB) - MongoDB persistence layer
  * [IdentityServer4.EntityFrameworkCore](https://github.com/2020IP/TwentyTwenty.IdentityServer4.EntityFrameworkCore) - Entity Framework Core persistence layer
  * [IdentityServer4.Templates](https://github.com/IdentityServer/IdentityServer4.Templates) - dotnet cli templates for IdentityServer4.
* [openiddict](https://github.com/openiddict/openiddict-core) - Easy-to-use OpenID Connect server for ASP.NET Core.
  * [oidc-debugger](https://github.com/nbarbettini/oidc-debugger) - OAuth 2.0 and OpenID Connect debugging tool.
* [stormpath-sdk](https://github.com/stormpath/stormpath-sdk-dotnet) - Build [simple, secure web applications](https://github.com/stormpath/stormpath-aspnetcore) with Stormpath and ASP.NET Core. 
* [stormpath-sdk](https://github.com/stormpath/stormpath-sdk-dotnet) - Build [simple, secure web applications](https://github.com/stormpath/stormpath-aspnetcore) with Stormpath and ASP.NET Core.(Deprecated: It will longer get updated as of March 2017 after joining OKTA) 
* [stuntman](https://github.com/ritterim/stuntman) - Library for impersonating users during development leveraging ASP.NET Identity.

### Code Analysis and Metrics
* [awesome-static-analysis](https://github.com/mre/awesome-static-analysis) - Curated list of static analysis tools, linters and code quality checkers for various programming languages.
* Code Analysis
  * [CodeFormatter](https://github.com/dotnet/codeformatter) - Tool that uses Roslyn to automatically rewrite the source to follow netfx coding styles. [Nuget Package](https://www.nuget.org/packages/Dotnet.CodeFormatter.BuildTask.Fork) 
  * [DevSkim](https://github.com/Microsoft/DevSkim) - A set of IDE plugins and rules that provide security "linting" capabilities.
  * [RefactoringEssentials](https://github.com/icsharpcode/RefactoringEssentials) - Refactoring Essentials for Visual Studio.
  * [roslyn-analyzers](https://github.com/dotnet/roslyn-analyzers) - .NET Compiler Platform ("Roslyn") Analyzers.
  * [StyleCopAnalyzers](https://github.com/DotNetAnalyzers/StyleCopAnalyzers) - StyleCop rules using the .NET Compiler Platform.
* Metrics
  * [AppMetrics](https://github.com/alhardy/AppMetrics) - App Metrics is an open-source and cross-platform .NET library used to record and report metrics within an application and reports it's health.
  * [Audit.NET](https://github.com/thepirat000/Audit.NET) - Small framework to audit .NET object changes.
  * [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet) - Powerful .NET library for benchmarking.
  * [coverlet](https://github.com/tonerdo/coverlet) - Cross platform code coverage library for .NET Core.
  * [Foundatio](https://github.com/exceptionless/Foundatio#metrics) - A common interface with in memory, redis, StatsD, and Metrics.NET implementations.
  * [MiniCover](https://github.com/lucaslorentz/minicover) - Minimalist Code Coverage Tool for .NET Core.
  * [NBench](https://github.com/petabridge/NBench) - Performance benchmarking and testing framework for .NET applications.
  * [Nexogen.Libraries.Metrics](https://github.com/nexogen-international/Nexogen.Libraries.Metrics) - Library for collecting application metrics in .NET and exporting them to Prometheus.
  * [OpenCover](https://github.com/OpenCover/opencover) - Code coverage tool for .NET 2 and above (WINDOWS OS only), support for 32 and 64 processes with both branch and sequence points.
  * [PerformanceMonitor](https://github.com/dotnet-architecture/PerformanceMonitor) - .NET Core Application Performance Monitor.
  * [prometheus-net](https://github.com/prometheus-net/prometheus-net) - .NET Client for [https://prometheus.io](https://prometheus.io).
  * [Prometheus.Client](https://github.com/PrometheusClientNet/Prometheus.Client) - .NET Client for [Prometheus](https://prometheus.io).
  	* [Prometheus.Client.MetricPusher](https://github.com/PrometheusClientNet/Prometheus.Client.MetricPusher) -  Push metrics to a PushGateaway for the Prometheus.Client.
  	* [Prometheus.Client.AspNetCore](https://github.com/PrometheusClientNet/Prometheus.Client.AspNetCore) -  Middleware for the Prometheus.Client.
  	* [Prometheus.Client.MetricServer](https://github.com/PrometheusClientNet/Prometheus.Client.MetricServer) -  MetricServer for the Prometheus.Client.
  	* [Prometheus.Client.HttpRequestDurations](https://github.com/PrometheusClientNet/Prometheus.Client.HttpRequestDurations) -  Metrics logging of request durations for the Prometheus.Client.

### Testing
* [Atata](https://github.com/atata-framework/atata) - Web UI test automation full-featured framework based on Selenium WebDriver. [https://atata.io](https://atata.io)
* [Bogus](https://github.com/bchavez/Bogus) - Simple and sane fake data generator for C#. Based on and ported from the famed faker.js.
* [CoreBDD](https://github.com/stevenknox/CoreBDD) - BDD framework for xUnit.net
* [FakeItEasy](https://github.com/FakeItEasy/FakeItEasy) - The easy mocking library for .NET.
* [FluentAssertions](https://github.com/fluentassertions/fluentassertions) - Set of .NET extension methods that allow you to more naturally specify the expected outcome of a TDD or BDD-style test.
* [GenFu](https://github.com/MisterJames/GenFu) - Library you can use to generate realistic test data.
* [LightBDD](https://github.com/LightBDD/LightBDD) - BDD framework allowing to create easy to read and maintain tests.
* [mockhttp](https://github.com/richardszalay/mockhttp) - Testing layer for Microsoft's HttpClient library.
* [moq.netcore](https://github.com/Moq/moq4) - Most popular and friendly mocking framework for .NET.
* [MSpec](https://github.com/machine/machine.specifications) - Popular testing framework for writing BDD-style tests.
* [MyTested.AspNetCore.Mvc](https://github.com/ivaylokenov/MyTested.AspNetCore.Mvc) - Fluent testing
  framework for ASP.NET Core MVC.
* [Netling](https://github.com/hallatore/Netling) - Load tester client for easy web testing.
* [NSpec](https://github.com/nspec/NSpec) - Battle hardened testing framework for C# that's heavily inspired by Mocha and RSpec.
* [NSubstitute](https://github.com/nsubstitute/NSubstitute) - A friendly substitute for .NET mocking frameworks.
* [nunit](https://github.com/nunit/dotnet-test-nunit) - NUnit test runner for .NET Core.
* [shouldly](https://github.com/shouldly/shouldly) - Should testing for .NET - the way Asserting *Should* be! [http://shouldly.readthedocs.org/en/latest](http://shouldly.readthedocs.org/en/latest)
* [SpecFlow](https://github.com/techtalk/SpecFlow) - Pragmatic BDD solution for .NET. It uses the Gherkin specification language and integrates to Visual Studio.
* [Storyteller](https://github.com/storyteller/Storyteller) - Executable Specifications for .NET [http://storyteller.github.io](http://storyteller.github.io).
* [Stubbery](https://markvincze.github.io/Stubbery/) - A simple library for creating and running Api stubs in .NET.
* [Testavior](https://github.com/geeklearningio/Testavior) - Testavior is a lightweight solution to help you develop Behavior Tests for ASP.NET Core.
* [TestStack.BDDfy](https://github.com/TestStack/TestStack.BDDfy) - The simplest BDD framework EVER!
* [xBehave.net](https://github.com/xbehave/xbehave.net) - An xUnit.net extension for describing your tests using natural language. [http://xbehave.github.io](http://xbehave.github.io)
* [xUnit.net](https://github.com/xunit/xunit) - A free, open source, community-focused unit testing tool for the .NET Framework.

## License

[![CC0](http://mirrors.creativecommons.org/presskit/buttons/88x31/svg/cc-zero.svg)](https://creativecommons.org/publicdomain/zero/1.0/)

To the extent possible under law, [thangchung](http://weblogs.asp.net/thangchung) has waived all copyright and related or neighboring rights to this work.

