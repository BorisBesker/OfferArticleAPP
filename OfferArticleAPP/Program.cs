using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.RepositoryImplementation;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services;
using ServiceLayer.ServicesImplementation;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<ArticleOfferContext>(options => options.UseSqlServer(builder.Configuration["Data:DefaultConnection:ConnectionString"]));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IOfferService, OfferService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowLocalhost");
app.MapControllers();

ApplyMigration();

app.Run();


void ApplyMigration()
{
    using (var scope = app.Services.CreateScope())
    {
        var _Db = scope.ServiceProvider.GetRequiredService<ArticleOfferContext>();

        if (_Db != null)
        {
            if (_Db.Database.GetPendingMigrations().Any())
            {
                _Db.Database.Migrate();
            }
        }
    }
}