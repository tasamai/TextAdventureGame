////[<EntryPoint>]

////module Script 

//    open System
//    open InitialState
//    open GameModel


////open GameModel

        

    //let bind processFunc lastResult =
    //    match lastResult with
    //    | Success s -> processFunc s
    //    | Failure f -> Failure f

    //let (>>=) x f =
    //    bind f x

    //let switch processFunc input =
    //    Success (processFunc input)

    //let getRoom world roomId =
    //    match world.Rooms.TryFind roomId with
    //    | Some room -> Success room
    //    | None -> Failure "Room does not exist!"

    //let describeDetails details =
    //    sprintf "\n\n%s\n\n%s\n\n" details.Name details.Description

    //let extractDetailsFromRoom (room: Room) =
    //    room.Details

    //let getCurrentRoom world =
    //    world.Player.Location
    //    |> getRoom world

    //let setCurrentRoom world room =
    //    { world with
    //        Player = { world.Player with Location = room.Id} }

    //let describeCurrentRoom world =
    //    world.Player.Location
    //    |> getRoom world
    //    |> (bind (switch extractDetailsFromRoom) >> bind (switch describeDetails))


    //let forward ({ Forward = northExit }: Exits) = northExit
    //let backward ({ Backward = southExit }: Exits) = southExit
    //let right ({ Right = eastExit }: Exits) = eastExit
    //let left ({ Left = westExit }: Exits) = westExit

  

    //let getExit direction exits =
    //    match (direction exits) with
    //    | UnlockedExit (_, roomId) -> Success roomId
    //    | LockedExit (_, _, _) -> Failure "There is a locked door in that direction."
    //    | NoExit (_) -> Failure "There is no room in that direction."

    //let move direction world =
    //    world
    //    |> getCurrentRoom
    //    >>= switch (fun room -> room.Exits) 
    //    >>= getExit direction
    //    >>= getRoom world
    //    >>= switch (setCurrentRoom world)

    //let displayResult result =
    //    match result with
    //    | Success s -> printf "%s" s
    //    | Failure f -> printf "%s" f



    //let userInput =
    //    let raw = Console.ReadLine()
    //    if String.Compare("left", raw, StringComparison.InvariantCultureIgnoreCase) = 0 then
    //        forward
    //        else right


    //gameWorld
    //|> describeCurrentRoom
    //|> displayResult
    //|> ignore