using Ef7BulkActions.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDb")));

var app = builder.Build();

CreateDb();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void CreateDb()
{
    using var scope = app.Services.CreateScope();
    using var db = scope.ServiceProvider.GetRequiredService<LibraryContext>();

    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    db.Books.AddRange(
        new Book { Title = "Sense and Sensibility", Author = "Jane Austen", Year = 1811 },
        new Book { Title = "Pride and Prejudice", Author = "Jane Austen", Year = 1813 },
        new Book { Title = "Mansfield Park", Author = "Jane Austen", Year = 1814 },
        new Book { Title = "Emma", Author = "Jane Austen", Year = 1815 },
        new Book { Title = "Northanger Abbey", Author = "Jane Austen", Year = 1818 },
        new Book { Title = "Persuasion", Author = "Jane Austen", Year = 1818 },
        new Book { Title = "Casino Royale", Author = "Ian Flemming", Year = 1953 },
        new Book { Title = "Live and Let Die", Author = "Ian Flemming", Year = 1954 },
        new Book { Title = "Moonraker", Author = "Ian Flemming", Year = 1955 },
        new Book { Title = "Diamonds are Forever", Author = "Ian Flemming", Year = 1956 },
        new Book { Title = "From Russia, with love", Author = "Ian Flemming", Year = 1957 },
        new Book { Title = "Dr No", Author = "Ian Flemming", Year = 1958 },
        new Book { Title = "Goldfinger", Author = "Ian Flemming", Year = 1959 },
        new Book { Title = "For Your Eyes Only", Author = "Ian Flemming", Year = 1960 },
        new Book { Title = "Thunderball", Author = "Ian Flemming", Year = 1961 },
        new Book { Title = "The Spy Who Loved Me", Author = "Ian Flemming", Year = 1962 },
        new Book { Title = "On Her Majesty's Secret Service", Author = "Ian Flemming", Year = 1963 },
        new Book { Title = "You Only Live Twice", Author = "Ian Flemming", Year = 1964 },
        new Book { Title = "The Man with the Golden Gun", Author = "Ian Flemming", Year = 1965 },
        new Book { Title = "Octopussy", Author = "Ian Flemming", Year = 1966 }
    );

    db.SaveChanges();
}