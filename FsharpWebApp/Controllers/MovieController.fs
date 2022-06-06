namespace FsharpWebApp.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open System.Diagnostics

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging

open FsharpWebApp.Models
open FsharpWebApp.Data.Models
open FSharpWebApp.Data.Repositories

type MovieController (movieRepository : IMovieRepository) =
    inherit Controller()

    member this.Index () =
        let movies = movieRepository.GetMovies()
        movies.Wait()
        this.View({ Movies = movies.Result })


    [<HttpGet>]
    member this.Create () =
        this.View()

    [<HttpPost>]
    member this.Create (movie : Movie) : ActionResult =
        let asActionResult result = result :> ActionResult

        match base.ModelState.IsValid with
        | false -> movie |> this.View |> asActionResult
        | true -> movieRepository.CreateMovie(movie).Wait() |> ignore
                  base.RedirectToAction("Index") |> asActionResult
        

    [<ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)>]
    member this.Error () =
        let reqId = 
            if isNull Activity.Current then
                this.HttpContext.TraceIdentifier
            else
                Activity.Current.Id

        this.View({ RequestId = reqId })


