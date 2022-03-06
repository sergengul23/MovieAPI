using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Store.BUSINESS.Extensions;
using Store.BUSINESS.Mappings.AutoMapper;
using Store.BUSINESS.Validators;
using Store.CORE.Repositories;
using Store.CORE.Repositories.EntityFramework;
using Store.DATA.Concrete.EntityFramework.Contexts;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(opt =>
    {
        opt.SuppressModelStateInvalidFilter = true;
    }).AddFluentValidation();

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.RegisterHandlers();
builder.Services.RegisterValidators();
builder.Services.LoadMyService();

builder.Services.AddMvc(options =>
{
    options.Filters.Add(new ResponseValidator());
});

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
