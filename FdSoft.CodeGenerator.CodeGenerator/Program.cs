using FdSoft.CodeGenerator.CodeGenerator;
using FdSoft.CodeGenerator.CodeGenerator.Service;
using FdSoft.CodeGenerator.Service.System;
using FdSoft.Common;
using FdSoft.Common.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAppService();
builder.Services.AddSingleton(new AppSettings(builder.Configuration));
builder.Services.AddTransient<CodeGeneraterService>();
builder.Services.AddTransient<GenTableColumnService>();
builder.Services.AddTransient<GenTableService>();


//��ʼ��db
DbExtension.AddDb(builder.Configuration);


var app = builder.Build();
InternalApp.ServiceProvider = app.Services;

//���ɱ�
CodeGeneratorTool.GenTablesByDb("Labor_ProjectWorkerAuthorityLog,Labor_ProjectWorkerAuthority", "Labor");

