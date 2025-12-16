var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Dependency injection
builder.Services.AddSingleton<IEventRepository, EventRepository>();
builder.Services.AddSingleton<IBookingRepository, BookingRepository>();
builder.Services.AddSingleton<IBoatRepository, BoatRepository>();
builder.Services.AddSingleton<IMemberRepository, MemberRepository>();
builder.Services.AddSingleton<IBoatSpaceRepository, BoatSpaceRepository>();
builder.Services.AddSingleton<IBlogEntryRepository, BlogEntryRepository>();


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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
