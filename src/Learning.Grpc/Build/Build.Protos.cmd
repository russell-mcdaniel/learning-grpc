@ECHO OFF

REM *** Set gRPC tools location.
SET GRPC_TOOLS=%UserProfile%\.nuget\packages\grpc.tools\1.16.0\tools\windows_x64

REM *** Generate code.
%GRPC_TOOLS%\protoc.exe -I..\Protos --csharp_out ..\ --grpc_out ..\ ..\Protos\Learning.proto --plugin=protoc-gen-grpc=%GRPC_TOOLS%\grpc_csharp_plugin.exe
