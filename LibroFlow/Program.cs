var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<LibroFlow.Domain.Repositories.IBookRepository, LibroFlow.Infrastructure.Repositories.InMemoryBookRepository>();
builder.Services.AddSingleton<LibroFlow.Domain.Repositories.IMemberRepository, LibroFlow.Infrastructure.Repositories.InMemoryMemberRepository>();
builder.Services.AddSingleton<LibroFlow.Domain.Repositories.ILoanRepository, LibroFlow.Infrastructure.Repositories.InMemoryLoanRepository>();
builder.Services.AddSingleton<LibroFlow.Domain.Repositories.IReservationRepository, LibroFlow.Infrastructure.Repositories.InMemoryReservationRepository>();
builder.Services.AddSingleton<LibroFlow.Domain.Events.IDomainEventDispatcher, LibroFlow.Domain.Events.LoggingEventDispatcher>();
builder.Services.AddScoped<LibroFlow.Application.LibraryService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
