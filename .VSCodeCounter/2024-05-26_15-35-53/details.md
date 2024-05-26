# Details

Date : 2024-05-26 15:35:53

Directory /Users/dasontiovino/Documents/University/PemogramanBerorientasiObjek/UAS/hotel-backend

Total : 43 files,  5297 codes, 54 comments, 329 blanks, all 5680 lines

[Summary](results.md) / Details / [Diff Summary](diff.md) / [Diff Details](diff-details.md)

## Files
| filename | language | code | comment | blank | total |
| :--- | :--- | ---: | ---: | ---: | ---: |
| [Controllers/AuthController.cs](/Controllers/AuthController.cs) | C# | 40 | 0 | 9 | 49 |
| [Controllers/RoomController.cs](/Controllers/RoomController.cs) | C# | 111 | 4 | 25 | 140 |
| [Controllers/RoomTypeController.cs](/Controllers/RoomTypeController.cs) | C# | 105 | 5 | 21 | 131 |
| [Controllers/UserController.cs](/Controllers/UserController.cs) | C# | 105 | 0 | 21 | 126 |
| [Data/ApplicationDbContext.cs](/Data/ApplicationDbContext.cs) | C# | 15 | 0 | 2 | 17 |
| [Migrations/20240526044847_InitialCreate.Designer.cs](/Migrations/20240526044847_InitialCreate.Designer.cs) | C# | 83 | 2 | 26 | 111 |
| [Migrations/20240526044847_InitialCreate.cs](/Migrations/20240526044847_InitialCreate.cs) | C# | 69 | 3 | 8 | 80 |
| [Migrations/20240526053308_AddFilePathToRoomTypes.Designer.cs](/Migrations/20240526053308_AddFilePathToRoomTypes.Designer.cs) | C# | 85 | 2 | 27 | 114 |
| [Migrations/20240526053308_AddFilePathToRoomTypes.cs](/Migrations/20240526053308_AddFilePathToRoomTypes.cs) | C# | 53 | 3 | 7 | 63 |
| [Migrations/20240526060557_UserModel.Designer.cs](/Migrations/20240526060557_UserModel.Designer.cs) | C# | 116 | 2 | 37 | 155 |
| [Migrations/20240526060557_UserModel.cs](/Migrations/20240526060557_UserModel.cs) | C# | 40 | 3 | 4 | 47 |
| [Migrations/20240526080831_ModifyRoomTypeId.Designer.cs](/Migrations/20240526080831_ModifyRoomTypeId.Designer.cs) | C# | 84 | 2 | 26 | 112 |
| [Migrations/20240526080831_ModifyRoomTypeId.cs](/Migrations/20240526080831_ModifyRoomTypeId.cs) | C# | 63 | 3 | 14 | 80 |
| [Migrations/ApplicationDbContextModelSnapshot.cs](/Migrations/ApplicationDbContextModelSnapshot.cs) | C# | 113 | 1 | 36 | 150 |
| [Models/RoomModel.cs](/Models/RoomModel.cs) | C# | 29 | 0 | 12 | 41 |
| [Models/RoomTypeModel.cs](/Models/RoomTypeModel.cs) | C# | 15 | 0 | 7 | 22 |
| [Models/UserModel.cs](/Models/UserModel.cs) | C# | 29 | 0 | 9 | 38 |
| [Program.cs](/Program.cs) | C# | 20 | 4 | 9 | 33 |
| [Properties/launchSettings.json](/Properties/launchSettings.json) | JSON | 41 | 0 | 1 | 42 |
| [README.md](/README.md) | Markdown | 1 | 0 | 1 | 2 |
| [Utilities/UploadUtils.cs](/Utilities/UploadUtils.cs) | C# | 18 | 0 | 5 | 23 |
| [appsettings.Development.json](/appsettings.Development.json) | JSON | 8 | 0 | 1 | 9 |
| [appsettings.json](/appsettings.json) | JSON | 9 | 0 | 1 | 10 |
| [bin/Debug/net8.0/appsettings.Development.json](/bin/Debug/net8.0/appsettings.Development.json) | JSON | 8 | 0 | 1 | 9 |
| [bin/Debug/net8.0/appsettings.json](/bin/Debug/net8.0/appsettings.json) | JSON | 9 | 0 | 1 | 10 |
| [bin/Debug/net8.0/hotel-backend.deps.json](/bin/Debug/net8.0/hotel-backend.deps.json) | JSON | 899 | 0 | 0 | 899 |
| [bin/Debug/net8.0/hotel-backend.runtimeconfig.json](/bin/Debug/net8.0/hotel-backend.runtimeconfig.json) | JSON | 20 | 0 | 0 | 20 |
| [hotel-backend.csproj](/hotel-backend.csproj) | XML | 22 | 0 | 4 | 26 |
| [obj/Debug/net8.0/.NETCoreApp,Version=v8.0.AssemblyAttributes.cs](/obj/Debug/net8.0/.NETCoreApp,Version=v8.0.AssemblyAttributes.cs) | C# | 3 | 1 | 1 | 5 |
| [obj/Debug/net8.0/hotel-backend.AssemblyInfo.cs](/obj/Debug/net8.0/hotel-backend.AssemblyInfo.cs) | C# | 9 | 9 | 5 | 23 |
| [obj/Debug/net8.0/hotel-backend.GeneratedMSBuildEditorConfig.editorconfig](/obj/Debug/net8.0/hotel-backend.GeneratedMSBuildEditorConfig.editorconfig) | Properties | 19 | 0 | 1 | 20 |
| [obj/Debug/net8.0/hotel-backend.GlobalUsings.g.cs](/obj/Debug/net8.0/hotel-backend.GlobalUsings.g.cs) | C# | 16 | 1 | 1 | 18 |
| [obj/Debug/net8.0/hotel-backend.MvcApplicationPartsAssemblyInfo.cs](/obj/Debug/net8.0/hotel-backend.MvcApplicationPartsAssemblyInfo.cs) | C# | 4 | 9 | 5 | 18 |
| [obj/Debug/net8.0/hotel-backend.sourcelink.json](/obj/Debug/net8.0/hotel-backend.sourcelink.json) | JSON | 1 | 0 | 0 | 1 |
| [obj/Debug/net8.0/staticwebassets.build.json](/obj/Debug/net8.0/staticwebassets.build.json) | JSON | 11 | 0 | 0 | 11 |
| [obj/Debug/net8.0/staticwebassets/msbuild.build.hotel-backend.props](/obj/Debug/net8.0/staticwebassets/msbuild.build.hotel-backend.props) | XML | 3 | 0 | 0 | 3 |
| [obj/Debug/net8.0/staticwebassets/msbuild.buildMultiTargeting.hotel-backend.props](/obj/Debug/net8.0/staticwebassets/msbuild.buildMultiTargeting.hotel-backend.props) | XML | 3 | 0 | 0 | 3 |
| [obj/Debug/net8.0/staticwebassets/msbuild.buildTransitive.hotel-backend.props](/obj/Debug/net8.0/staticwebassets/msbuild.buildTransitive.hotel-backend.props) | XML | 3 | 0 | 0 | 3 |
| [obj/hotel-backend.csproj.EntityFrameworkCore.targets](/obj/hotel-backend.csproj.EntityFrameworkCore.targets) | XML | 28 | 0 | 1 | 29 |
| [obj/hotel-backend.csproj.nuget.dgspec.json](/obj/hotel-backend.csproj.nuget.dgspec.json) | JSON | 100 | 0 | 0 | 100 |
| [obj/hotel-backend.csproj.nuget.g.props](/obj/hotel-backend.csproj.nuget.g.props) | XML | 26 | 0 | 0 | 26 |
| [obj/hotel-backend.csproj.nuget.g.targets](/obj/hotel-backend.csproj.nuget.g.targets) | XML | 9 | 0 | 0 | 9 |
| [obj/project.assets.json](/obj/project.assets.json) | JSON | 2,852 | 0 | 0 | 2,852 |

[Summary](results.md) / Details / [Diff Summary](diff.md) / [Diff Details](diff-details.md)