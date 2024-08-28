using Soul.IdentityModel;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddIdentityServer(builder =>
{
    builder.AddClientStore(new Client[] 
    {
        new Client("test")
    });
   
    builder.AddResourceStore(
        new ApiScope[]
        {
            new("baseapi")
        },
        new ApiResource[]
        {
            new("mallapi")
            {
                Scopes = { "baseapi"}
            },
            new("orderapi")
            {
                Scopes = { "baseapi"}
            },
        },
        new IdentityResource[]
        {
            new("openid")
        });

    builder.ConfigureOptions(configureOptions =>
    {

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseIdentityServer();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
