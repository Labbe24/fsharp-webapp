namespace FsharpWebApp

open System
open System.Collections.Generic
open System.IO
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Akka.FSharp
open Akka.Actor
open Actor

module Program =
    let exitCode = 0
    let actorSystemName = "ActorSystem"

    let CreateHostBuilder args =
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(fun webBuilder ->
                webBuilder.UseStartup<Startup>() |> ignore
            )

    let CreateActorSystem name = 
        System.create actorSystemName (Configuration.load())
        

    [<EntryPoint>]
    let main args =
        let host = CreateHostBuilder(args).Build()

        let actorSystem = CreateActorSystem actorSystemName
        let actor = spawn actorSystem "helloActor" (actorOf helloActor)
        host.Run()
        exitCode
