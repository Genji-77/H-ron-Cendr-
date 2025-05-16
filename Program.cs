using Microsoft.EntityFrameworkCore;
using PrgFinalSujet3.Data.Services;
using PrgFinalSujet3.Models;
using PrgFinalSujet3.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Ajout des services MVC
        builder.Services.AddControllersWithViews();

        // Ajout des interfaces avec des alias
        builder.Services.AddScoped<IActivityService, ActivityService>();
        builder.Services.AddScoped<IContactService, ContactService>();
        builder.Services.AddScoped<IEventService, EventService>();
        builder.Services.AddScoped<IHotelService, HotelService>();
        builder.Services.AddScoped<IRestaurantService, RestaurantService>();
        builder.Services.AddScoped<IHomeService, HomeService>();

        // Utilisation de l'alias pour WellnessService
        builder.Services.AddScoped<IWellnessService, WellnessServiceManager>();

        // Configuration du contexte de la base de données
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            if (!dbContext.Menus.Any())
            {
                dbContext.Menus.AddRange(
                    new Menu { Name = "Entrée du jour", Description = "Salade fraîche", Price = 12.50m, Category = "Entrée" },
                    new Menu { Name = "Plat signature", Description = "Poisson grillé", Price = 25.00m, Category = "Plat" },
                    new Menu { Name = "Dessert gourmand", Description = "Tarte aux pommes", Price = 8.00m, Category = "Dessert" }
                );
                dbContext.SaveChanges();
            }
            // Ajout du seed pour les chambres d'hôtel
            if (!dbContext.Rooms.Any())
            {
                dbContext.Rooms.AddRange(
                    new Room { Name = "Chambre Standard", Description = "Chambre confortable de 25m² avec lit double, salle de bain privative et TV écran plat.", Price = 120, IsAvailable = true, Capacity = 2 },
                    new Room { Name = "Chambre Supérieure", Description = "Chambre spacieuse de 35m² avec lit king size, salle de bain avec baignoire, coin salon et vue panoramique.", Price = 180, IsAvailable = true, Capacity = 3 },
                    new Room { Name = "Chambre Deluxe", Description = "Chambre luxueuse de 45m² avec lit king size, salle de bain avec baignoire et douche à l'italienne, coin salon et terrasse privée.", Price = 250, IsAvailable = true, Capacity = 3 },
                    new Room { Name = "Suite", Description = "Suite de 60m² avec chambre séparée, salon, salle de bain avec jacuzzi, dressing et terrasse privée.", Price = 350, IsAvailable = true, Capacity = 4 },
                    new Room { Name = "Suite Présidentielle", Description = "Suite prestigieuse de 100m² avec chambre principale, salon, salle à manger, salle de bain avec spa, dressing et grande terrasse avec vue panoramique.", Price = 500, IsAvailable = true, Capacity = 4 }
                );
                dbContext.SaveChanges();
            }
            // Ajout du seed pour les services de spa
            if (!dbContext.SpaServices.Any())
            {
                dbContext.SpaServices.AddRange(
                    new SpaService { Name = "Massage relaxant", Description = "Massage complet du corps", Price = 80, Duration = 60 },
                    new SpaService { Name = "Soin du visage", Description = "Soin hydratant et relaxant", Price = 60, Duration = 45 }
                );
                dbContext.SaveChanges();
            }
            // Ajout du seed pour les événements
            if (!dbContext.Events.Any())
            {
                dbContext.Events.AddRange(
                    new Event { Name = "Soirée Jazz", Description = "Concert live de jazz avec artistes locaux.", EventDate = DateTime.Now.AddDays(7), Price = 25 },
                    new Event { Name = "Atelier Œnologie", Description = "Dégustation de vins et initiation à l'œnologie.", EventDate = DateTime.Now.AddDays(14), Price = 40 },
                    new Event { Name = "Brunch du dimanche", Description = "Brunch gourmand avec animation musicale.", EventDate = DateTime.Now.AddDays(3), Price = 30 },
                    new Event { Name = "Soirée à thème : Années 80", Description = "Soirée dansante sur les tubes des années 80.", EventDate = DateTime.Now.AddDays(21), Price = 20 }
                );
                dbContext.SaveChanges();
            }
        }

        // Configuration du pipeline HTTP
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
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
    }
}
