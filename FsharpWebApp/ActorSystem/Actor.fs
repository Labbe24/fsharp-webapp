module Actor

open Akka.FSharp
open Akka.Actor

    let helloActor msg =
        match msg with
        | "Hello" -> printfn "Hello back at you"
        |_ -> printfn "Say that again"



