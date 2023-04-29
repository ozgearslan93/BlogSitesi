using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using YoutubeBlog.Data.Context;
using YoutubeBlog.Data.Extensions;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Describers;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Services.Concrete;
using YoutubeBlog.Web.Filters.ArticleVisitors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.LoadDataLayerExtension(builder.Configuration);
builder.Services.LoadServiceLayerExtension();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews( opt =>
{
    opt.Filters.Add<ArticleVisitorFilter>();
})
    .AddNToastNotifyToastr(new ToastrOptions()  // tostr kullanmak i�in oncel�kli burada ekledik
    {
        PositionClass = ToastPositions.TopRight,
        TimeOut = 3000,
    }) 
    .AddRazorRuntimeCompilation();


builder.Services.AddIdentity<AppUser, AppRole>(opt =>        //identity yap�s� uzer�nde kurallar olusturacag�z.
{
    opt.Password.RequireNonAlphanumeric = false; // noktalama i�areti, sembol vb. olma zorunlulugunu ortadan kald�rd�k
    opt.Password.RequireLowercase = false;  // kucuk harf zorunlulugunu ortadan kald�r�yoruz
    opt.Password.RequireUppercase = false;  //buyuk harf zorunlugunu ortadan kald�r�yoruz

})
    .AddRoleManager<RoleManager<AppRole>>()
    .AddErrorDescriber<CustomIdentityErrorDescriber>() //identity mesajlar�m�z� t�rkcelestirmek istedigimiz i�in bu sat�r� ekled�k. t�rkce mesajlarda servis i�indeki describers klas�r�ndeki class ta yer al�yor
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(config =>    //uygulamaya cookie ekliyoruz
{
    config.LoginPath = new PathString("/Admin/Auth/Login");//adm�n aream�z olacak auth ded�g�m�z user �slemler� �c�n auth �slemler� yapacag�m�z controller olcak log�n de act�on olcak
    config.LogoutPath = new PathString("/Admin/Auth/LogOut");
    config.Cookie = new CookieBuilder()
    {
        Name = "YoutubeBlog",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest//SecurePolicy hem http hemde https istek alabilmemizi sa�l�yor.SecurePolicy yerine Always yazarsak sadece https olan� destekler.
    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromDays(7); //siteye log in olmadan 7 g�n gezebilmemi saglad�k
    config.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied"); //yetkisiz bir giri� oldugunda bu sayfay� c�kar�caz.sizin bu sayfaya er�s�m�n�z yok log in olun tarz� birsey c�kacak
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseNToastNotify(); //
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession(); //
app.UseRouting();


app.UseAuthentication(); //

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Home}/{action=Index}/{id?}"

        );
    endpoints.MapDefaultControllerRoute();
});
app.Run();


// ismini admin verdigimiz bir alan� cag�r�cam.ama admin vermez isem default olarak yine bu alan� cag�rmas�n� gerekti�ini s�yl�yoruz
//app.MapControllerRoute(
//    name: "default"
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapDefaultControllerRoute(); // bir �sttekiyle ayn�

