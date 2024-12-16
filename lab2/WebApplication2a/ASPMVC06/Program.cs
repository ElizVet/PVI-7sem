var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// M01
app.MapControllerRoute(
        name: "TMResearchM01",
        pattern: "V2/{controller}/M01",
        defaults: new { controller = "TMResearch", action = "M01" });

app.MapControllerRoute(
        name: "TMResearchM011",
        pattern: "{controller}/{action}/{id?}",
        defaults: new { controller = "TMResearch", action = "M01"});

app.MapControllerRoute(
        name: "TMResearchM012",
        pattern: "V3/{controller}/{id}/M01",
        defaults: new { controller = "TMResearch", action = "M01" });

// M02
app.MapControllerRoute(
        name: "TMResearchM02",
        pattern: "V2/{controller}/{action}",
        defaults: new { controller = "TMResearch", action = "M02" });

app.MapControllerRoute(
        name: "TMResearchM021",
        pattern: "{controller}/M02/{id?}",
        defaults: new { controller = "TMResearch", action = "M02" });

app.MapControllerRoute(
        name: "TMResearchM022",
        pattern: "V3/{controller}/{id}/M02",
        defaults: new { controller = "TMResearch", action = "M02" });

// M03
app.MapControllerRoute(
        name: "TMResearchM03",
        pattern: "V3/{controller}/{id?}/{action}",
        defaults: new { controller = "TMResearch", action = "M03" });

// MXX
app.MapControllerRoute(
        name: "TMResearchMXX",
        pattern: "MXX",
        defaults: new { controller = "TMResearch", action = "MXX" });



app.Run();
