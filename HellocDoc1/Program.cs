using HellocDoc1.DataContext;
using HellocDoc1.Services;
using HelloDoc1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<IHashing, Hashing>();
builder.Services.AddTransient<ILoginHandler, LoginHandler>();
builder.Services.AddTransient<IPatientRequest, PatientRequest>();
builder.Services.AddTransient<IFamilyRequest, FamilyRequest>();
builder.Services.AddTransient<IConcirgeRequest, ConcirgeRequest>();
builder.Services.AddTransient<IBusinessRequest, BusinessRequest>();
builder.Services.AddTransient<IPatientServices, PatientServices>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Patient}/{action=Login}/{id?}");

app.Run();
