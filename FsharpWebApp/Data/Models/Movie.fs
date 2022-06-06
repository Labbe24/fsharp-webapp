namespace FsharpWebApp.Data.Models

open System
open System.ComponentModel.DataAnnotations

//[<CLIMutable>]
//type Movie = {
//    Id : int
//    Title : string
//    ReleaseDate : string
//    Genre : string
//}


[<AllowNullLiteral>]
type Movie() =
    [<DefaultValue>]
    val mutable private id : int
    member this.Id with get() = this.id and set(value) = this.id <- value

    [<DefaultValue>]
    val mutable private title : string
    member this.Title with get() = this.title and set(value) = this.title <- value

    [<DefaultValue>]
    val mutable private releaseDate : string
    member this.ReleaseDate with get() = this.releaseDate and set(value) = this.releaseDate <- value
    
    [<DefaultValue>]
    val mutable private genre : string
    member this.Genre with get() = this.genre and set(value) = this.genre <- value
