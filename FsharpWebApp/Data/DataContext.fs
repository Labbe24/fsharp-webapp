// https://github.com/morgankenyon/FSharpData

namespace FSharpWebApp.Database

open Microsoft.EntityFrameworkCore
open FsharpWebApp.Data.Models

type DataContext(options: DbContextOptions<DataContext>) =
    inherit DbContext(options)

    [<DefaultValue>]
    val mutable movies : DbSet<Movie>
    member x.Movies 
        with get() = x.movies 
        and set y = x.movies <- y

    override __.OnConfiguring(optionsBuilder : DbContextOptionsBuilder) =
        optionsBuilder.UseSqlServer("Server=localhost;Database=FSharpMvcDatabase;Trusted_Connection=True;")
        |> ignore


