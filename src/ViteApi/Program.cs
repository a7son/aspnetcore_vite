var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSpaStaticFiles(config=>{
    config.RootPath = "dist";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();    
}

app.UseRouting();

app.UseEndpoints(endpoints => {
    endpoints.MapDefaultControllerRoute();
});

app.UseSpaStaticFiles();

app.UseSpa(builder => {
    if (app.Environment.IsDevelopment())
    {
        builder.UseProxyToSpaDevelopmentServer("http://localhost:3000/");
    }
});

app.Run();
