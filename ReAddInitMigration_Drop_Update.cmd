cd ./CMDKhakatonProject
rmdir Migrations /s /q
dotnet-ef migrations add "Initial"
echo Y|dotnet-ef database drop
dotnet-ef database update
pause