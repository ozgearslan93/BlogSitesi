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
    .AddNToastNotifyToastr(new ToastrOptions()  // tostr kullanmak için oncelýkli burada ekledik
    {
        PositionClass = ToastPositions.TopRight,
        TimeOut = 3000,
    }) 
    .AddRazorRuntimeCompilation();


builder.Services.AddIdentity<AppUser, AppRole>(opt =>        //identity yapýsý uzerýnde kurallar olusturacagýz.
{
    opt.Password.RequireNonAlphanumeric = false; // noktalama iþareti, sembol vb. olma zorunlulugunu ortadan kaldýrdýk
    opt.Password.RequireLowercase = false;  // kucuk harf zorunlulugunu ortadan kaldýrýyoruz
    opt.Password.RequireUppercase = false;  //buyuk harf zorunlugunu ortadan kaldýrýyoruz

})
    .AddRoleManager<RoleManager<AppRole>>()
    .AddErrorDescriber<CustomIdentityErrorDescriber>() //identity mesajlarýmýzý türkcelestirmek istedigimiz için bu satýrý ekledýk. türkce mesajlarda servis içindeki describers klasöründeki class ta yer alýyor
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(config =>    //uygulamaya cookie ekliyoruz
{
    config.LoginPath = new PathString("/Admin/Auth/Login");//admýn areamýz olacak auth dedýgýmýz user ýslemlerý ýcýn auth ýslemlerý yapacagýmýz controller olcak logýn de actýon olcak
    config.LogoutPath = new PathString("/Admin/Auth/LogOut");
    config.Cookie = new CookieBuilder()
    {
        Name = "YoutubeBlog",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest//SecurePolicy hem http hemde https istek alabilmemizi saðlýyor.SecurePolicy yerine Always yazarsak sadece https olaný destekler.
    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromDays(7); //siteye log in olmadan 7 gün gezebilmemi sagladýk
    config.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied"); //yetkisiz bir giriþ oldugunda bu sayfayý cýkarýcaz.sizin bu sayfaya erýsýmýnýz yok log in olun tarzý birsey cýkacak
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


// ismini admin verdigimiz bir alaný cagýrýcam.ama admin vermez isem default olarak yine bu alaný cagýrmasýný gerektiðini söylüyoruz
//app.MapControllerRoute(
//    name: "default"
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapDefaultControllerRoute(); // bir üsttekiyle ayný

