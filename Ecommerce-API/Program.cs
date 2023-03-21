using Ecommerce_API.Models;
using Ecommerce_API.Repo;
using Ecommerce_API.Service;
using LayeringEg.Service;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Logging.AddLog4Net();

builder.Services.AddControllers();
builder.Services.AddTransient<IProdRepo<Product>, ProdRepo>();
builder.Services.AddTransient<IProdService<Product>, ProdService>();

builder.Services.AddTransient<IOrderRepo<Order>, OrderRepo>();
builder.Services.AddTransient<IOrderService<Order>, OrderService>();

builder.Services.AddTransient<IOrderDetailRepo<OrderDetail>, OrderDetailRepo>();
builder.Services.AddTransient<IOrderDetailService<OrderDetail>, OrderDetailService>();

builder.Services.AddTransient<ILoginRepo<LoginDetail>, LoginRepo>();
builder.Services.AddTransient<ILoginService<LoginDetail>, LoginService>();

builder.Services.AddTransient<IAdminRepo<Admin>, AdminRepo>();
builder.Services.AddTransient<IAdminService<Admin>, AdminService>();

builder.Services.AddTransient<IBrandRepo<Brand>, BrandRepo>();
builder.Services.AddTransient<IBrandService<Brand>, BrandService>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDbContext<EcommerceContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.UseSession();
app.Run();
