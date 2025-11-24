using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IMongoDatabase>(_ =>
{
    var client = new MongoClient(builder.Configuration["MongoDbSettings:ConnectionString"]);
    return client.GetDatabase(builder.Configuration["MongoDbSettings:DatabaseName"]);
});

builder.Services.AddGraphQLServer()
    .AddDocumentFromFile("note-schema.graphql");

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGraphQL();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.Run();