namespace FsharpWebApp.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open System.Diagnostics

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging

type LectureController (logger : ILogger<LectureController>) =
    inherit Controller()

    member this.LectureOne () =
        this.View()

    member this.LectureTwo () =
        this.View()

    member this.LectureThree () =
        this.View()

    member this.LectureFour () =
        this.View()

    member this.LectureFive () =
        this.View()

    member this.LectureSix () =
        this.View()

    member this.LectureSeven () =
        this.View()

    member this.LectureEight () =
        this.View()

    member this.LectureNine () =
        this.View()

    member this.LectureTen () =
        this.View()

    member this.LectureEleven () =
        this.View()


