cd ./CMDKhakatonProject
rmdir Migrations /s /q
dotnet-ef migrations add "Initial"
dotnet-ef database drop
dotnet-ef database update
pause