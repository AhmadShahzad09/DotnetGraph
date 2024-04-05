using Microsoft.EntityFrameworkCore;
using posts_graphql.api.Query;
using Posts_graphql.Application.Services;
using Posts_graphql.Infrastructure.Context;
using Posts_graphql.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);
var cs = builder.Configuration.GetConnectionString("Default");
builder.Services.AddPooledDbContextFactory<PostGrapghQlDbContext>(options =>
{
    options.UseSqlServer(cs);
});

// builder.Services.AddGraphQLServer()
//     .AddQueryType<UserQuery>()
//     .AddQueryType<PostQuery>()
//     .AddQueryType<NotificationQuery>()
//     .AddMutationType<RegisterUserMutationType>()
//     .AddMutationType<AddEditPostMutationType>()
//     .AddMutationType<AddEditNotificationMutationType>();
   builder.Services.AddGraphQL(x => SchemaBuilder.New()
                                        .AddServices(x)
                                        .AddType<PostType>()
                                        .AddQueryType<Query>() 
                                        .AddMutationType<Mutation>() 
                                        .Create()
                                        );


builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<PostService>();
builder.Services.AddScoped<PostRepository>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<NotificationRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

// app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL("/graphql");
});

app.Run();
