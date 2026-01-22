# CraftCase



## 框架架构

使用 DDD 模式和 CleanArchitecture 设计理念

使用 .net 8 进行开发

### Application

项目模板: 类库

安装使用的包

1. AutoMapper
2. FluentValidation.DependencyInjectionExtensions
3. MediatR
4. Microsoft.EntityFrameworkCore

依赖 Domain

#### 本层设计职责说明

Common.Exceptions

+ NotFoundException

  >  404 报错说明文件

+ ValidationException

  > 验证器抛出 message 文件

Common.Interfaces

+ IApplicationDbContext

  > 实体映射接口

Common.Mappings

+ IMapFrom

  > AutoMapper 映射公共接口

+ MappingExtensions

  > 分页查询公共方法

+ MappingProfile

  > 自动扫描并注册所有实现了 IMapFrom<> 或 IMapTo<> 接口的类型

Common.Models

+ PaginatedList

  > 分页搜索公共类

UserProfiles

> 示例增删改查接口

DependencyInjection

> Application 层的服务注册

GlobalUsings

> 公共 using 引用类



### Domain

项目模板: 类库

安装使用的包

1. MediatR.Contracts





### Infrastructure

项目模板: 类库

安装使用的包

1. Microsoft.EntityFrameworkCore
2. Microsoft.EntityFrameworkCore.SqlServer

依赖 Application 

### WebAPI

项目模板: ASP.NET Core Web API

安装使用的包

1. Microsoft.EntityFrameworkCore.Design
2. Microsoft.EntityFrameworkCore.Tools
3. Swashbuckle.AspNetCore

依赖 Application , Infrastructure



