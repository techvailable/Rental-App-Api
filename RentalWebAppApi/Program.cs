using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using RentalWebInfrastructure.Infrastructure;
using RentalWebService.IServices;
using RentalWebService.Services;
using RentalWebAppApi.Extention;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RentalWebAppApi.Models;
using Microsoft.IdentityModel.Tokens;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

// Add Jwt Setings
var bindJwtSettings = new JwtSettings();
builder.Configuration.Bind("JsonWebTokenKeys", bindJwtSettings);
builder.Services.AddSingleton(bindJwtSettings);
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuerSigningKey = bindJwtSettings.ValidateIssuerSigningKey,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(bindJwtSettings.IssuerSigningKey)),
        ValidateIssuer = bindJwtSettings.ValidateIssuer,
        ValidIssuer = bindJwtSettings.ValidIssuer,
        ValidateAudience = bindJwtSettings.ValidateAudience,
        ValidAudience = bindJwtSettings.ValidAudience,
        RequireExpirationTime = bindJwtSettings.RequireExpirationTime,
        ValidateLifetime = bindJwtSettings.RequireExpirationTime,
        ClockSkew = TimeSpan.FromDays(1),
    };
});
// Add services to the container.
builder.Services.AddCors();
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddControllers();
builder.Services.AddDbContext<RentalWebContext>(options => options.UseSqlServer(connectionString));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
builder.Services.AddScoped<IAdminUserService, AdminUserService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ICartItemService, CartItemService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IIpAddressService, IpAddressService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPhysicalAddressService, PhysicalAddressService>();
builder.Services.AddScoped<IProductReviewService, ProductReviewService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IShippingService, ShippingService>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProcedureService, ProcedureService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
    //app.UseSwagger();
}
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = "/Images",
});
app.UseHttpsRedirection();
app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()); ;
app.UseAuthorization();
app.UseSwagger(x => x.SerializeAsV2 = true);
app.MapControllers();

app.Run();
