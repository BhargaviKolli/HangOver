using HangOver1.Configuration;
using HangOver1.Controllers;
using HangOver1.Interface;
using HangOver1.Models;
using HangOver1.Repositories;
using HangOver1.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using Serilog;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));


builder.Services.AddDbContext<HangOver1Context>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("HangOver")));
builder.Services.AddScoped<IUsers,UserService>();
builder.Services.AddScoped<IPosts,PostService>();
builder.Services.AddScoped<ILikes, LikeService>();
builder.Services.AddScoped<IFollow, FollowService>();
builder.Services.AddScoped<IComments, CommentService>();


builder.Services.AddScoped<IAuthentication, AuthenticationService>();

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddScoped<IMailService,MailService>();

builder.Services.AddControllers();
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddAuthentication(option =>
{
	option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

})
	.AddJwtBearer(options =>
	{
		options.RequireHttpsMetadata = false;
		options.SaveToken = true;
		options.TokenValidationParameters = new TokenValidationParameters
		{
			//ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidateIssuer = false,
			ValidateAudience = false,
			/*ValidIssuer = Configuration["JwtConfiguration:Issuer"],
			ValidAudience = Configuration["JwtConfiguration:Audience"],*/
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JwtConfiguration:TokenSecret"]))
			
		};
	});
builder.Services.AddMvc();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
		  {
			  c.SwaggerDoc("v1",new OpenApiInfo {Title="HangOver",Version="v1",Description="HangOver RestAPI's With Authentication"});
			  c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
	             $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
			  c.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
					   new OpenApiSecurityScheme
						   {
						  Reference = new OpenApiReference
						  {
						   Type = ReferenceType.SecurityScheme,
						   Id = "Bearer"
						  }
						},
							new string[] {}
					}
		  });

			  c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
			  {
				  Name = "Authorization",
				  Type = SecuritySchemeType.ApiKey,
				  Scheme = "Bearer",
				  BearerFormat = "JWT",
				  In = ParameterLocation.Header,
				  Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
			  });
		  });
	
 void Configer(IApplicationBuilder app, IWebHostEnvironment env)
{
	if (env.IsDevelopment())
	{
		app.UseDeveloperExceptionPage();
		app.UseSwagger();
		app.UseSwaggerUI(c =>
		{
			c.SwaggerEndpoint("/swagger/v1/swagger.json", "HangOver v1");

		});
	}

	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "MY API");

	});


}

		  var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JWTAuthDemo v1"));

	app.UseSerilogRequestLogging();

	app.UseHttpsRedirection();

	app.UseAuthentication();

	app.UseAuthorization();

	app.MapControllers();
	app.UseStaticFiles();
	app.Run();
}