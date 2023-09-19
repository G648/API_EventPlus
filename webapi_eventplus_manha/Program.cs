using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

    .AddJwtBearer("JwtBearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //valida quem est� solicitando
            ValidateIssuer = true,

            //valida quem est� recebendo
            ValidateAudience = true,

            //define se o tempo de expira��o ser� validado
            ValidateLifetime = true,

            //forma de criptografia e valida a chave de autentica��o
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("eventplus-chave-autenticacao-webapi-codeFirst")),

            //valida o tempo de expira��o do token
            ClockSkew = TimeSpan.FromMinutes(5),

            //nome do issuer (de onde est� vindo)
            ValidIssuer = "webapi_eventplus_manha",

            //nome do audience (para onde est� indo)
            ValidAudience = "webapi_eventplus_manha"
        };
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

app.MapControllers();

app.Run();
