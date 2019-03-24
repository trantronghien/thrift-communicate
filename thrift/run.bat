REM create folder
mkdir out\java
mkdir out\csharp
REM generate code
thrift -r -out out/java/ --gen java account_auth_services.thrift
thrift -r -out out/csharp/ --gen  csharp account_auth_services.thrift
pause