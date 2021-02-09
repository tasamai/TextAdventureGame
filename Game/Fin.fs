open System
open InitialState
open GameModel
open Main

[<EntryPoint>]
let main argv =

    
    gameWorld
    |> move usermove
    |> bind describeCurrentRoom
    |> displayResult
    gameWorld
    |> move usermove
    |> bind describeCurrentRoom
    |> displayResult

    0
