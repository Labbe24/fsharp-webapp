namespace FSharpWebApp.Data.Repositories

open System.Threading.Tasks
open FsharpWebApp.Data.Models
open FSharpWebApp.Database
open System

type IMovieRepository =
    interface
        abstract member GetMovie : int -> Movie Task
        abstract member GetMovies : unit -> Movie list Task
        abstract member CreateMovie : Movie -> Task<Movie>
    end

type MovieRepository(context : DataContext) =
    interface IMovieRepository with
        member this.GetMovie id =
            let query = context.Movies |> Seq.tryFind (fun q -> q.Id = id)

            let movie =
                match query with
                | Some i -> i
                | None -> null

            let asyncQuery = async {
                return movie
            }
            Async.StartAsTask(asyncQuery)

        member this.GetMovies () =
            let query = async {
                return context.Movies |> Seq.toList
            }
            Async.StartAsTask(query)

        member this.CreateMovie movie =
            movie.Id <- (new Random()).Next(99999)
            let query = async {
                context.Movies.Add(movie) |> ignore
                context.SaveChanges true |> ignore
                return movie
            }
            Async.StartAsTask(query)


