using Data.Repositories;
using Data.Repositories.Interfaces;
using Entity;
using MongoDB.Driver;
using NoteAPI.GraphQL;
using NoteAPI.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IMongoDatabase>(_ =>
{
    var client = new MongoClient(builder.Configuration["MongoDbSettings:ConnectionString"]);
    return client.GetDatabase(builder.Configuration["MongoDbSettings:DatabaseName"]);
});

builder.Services.AddScoped<INoteRepository, NoteRepository>();

builder.Services.AddGraphQLServer()
    .AddDocumentFromFile("note-schema.graphql")
    .BindRuntimeType<Query>("Query")
    .BindRuntimeType<Mutation>("Mutation")
    .BindRuntimeType<NormalNote>("NormalNote")
    .BindRuntimeType<CheckNote>("CheckNote");

builder.Services.AddAutoMapper(
    cfg => { },
    typeof(MapperProfile).Assembly
);


var app = builder.Build();


// Configure the HTTP request pipeline.
app.MapGraphQL();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.Run();