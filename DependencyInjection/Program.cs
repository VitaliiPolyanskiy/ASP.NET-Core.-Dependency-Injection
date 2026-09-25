using DependencyInjection.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Реєстрація сервісів. Оскільки IMessageSender реєструється двічі різними класами,
// ін'єкція IEnumerable<IMessageSender> поверне колекцію з обох реалізацій.
// Якщо ж ін'єктується просто IMessageSender, буде використана остання зареєстрована (SmsMessageSender).
builder.Services.AddScoped<IMessageSender, EmailMessageSender>();
builder.Services.AddScoped<IMessageSender, SmsMessageSender>();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();