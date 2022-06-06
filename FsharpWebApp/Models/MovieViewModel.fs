namespace FsharpWebApp.Models

open System
open FsharpWebApp.Data.Models
open System.ComponentModel.DataAnnotations

type MovieViewModel =
    { 
        Title : string
        [<Display(Name = "Release Date")>]
        ReleaseDate : DateTime
        Genre : string
    }

