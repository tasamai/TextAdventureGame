//[<EntryPoint>]

module Main 

    open System
    open InitialState
    open GameModel


//open GameModel

    //type Input<'left, 'right, 'forward, 'backward> =
                    //|ULeft of Left: Exit
                    //|URight of Right: Exit
                    //|UForward of Forward: Exit
                    //|UBackward of Backward: Exit    

    let bind processFunc lastResult =
        match lastResult with
        | Success s -> processFunc s
        | Failure f -> Failure f

    let (>>=) x f =
        bind f x

    let switch processFunc input =
        Success (processFunc input)

    let getRoom world roomId =
        match world.Rooms.TryFind  roomId with
        | Some room -> Success room
        | None -> Failure "Room does not exist!"

    let describeDetails details =
        sprintf "\n\n%s\n\n%s\n\n" details.Name details.Description

    let extractDetailsFromRoom (room: Room) =
        room.Details

    let getCurrentRoom world =
        world.Player.Location
        |> getRoom world

    let setCurrentRoom world room =
        { world with
            Player = { world.Player with Location = room.Id} }

    let describeCurrentRoom world =
        world.Player.Location
        |> getRoom world
        |> (bind (switch extractDetailsFromRoom) >> bind (switch describeDetails))


    let forward ({ Forward = northExit }: Exits) = northExit
    let backward ({ Back = southExit }: Exits) = southExit
    let right ({ Right = eastExit }: Exits) = eastExit
    let left ({ Left = westExit }: Exits) = westExit
    let noInput ({NoInput = nExit}: Exits) = nExit

  

    let getExit direction Exits =
        match (direction Exits) with
        | UnlockedExit (_, roomId) -> Success roomId
        | LockedExit (_, _, _) -> Failure "There is a locked door in that direction."
        | NoExit (_) -> Failure "There is no room in that direction."

    let move direction world =
        world
        |> getCurrentRoom
        >>= switch (fun room -> room.Exits) 
        >>= getExit direction
        >>= getRoom world
        >>= switch (setCurrentRoom world)

    let displayResult result =
        match result with
        | Success s -> printf "%s" s
        | Failure f -> printf "%s" f
        
        //world.Player.Location
        //world
        //|> getRoom world
        //|> switch (setCurrentRoom world)



    //let displayResult result =
        //match result with
        //| Success s -> printf "%s" s
        //| Failure f -> printf "%s" f



    //let userInput raw=
        ////let raw = System.Console.ReadLine()
        //match raw with
        //|ULeft left -> user
        //|URight right
        //|UForward forward
        //|UBackward backward


    //let userInput = 
        //let raw = System.Console.ReadLine()
        //if raw.Contains "left" then
            //if String.Compare("left", raw, StringComparison.InvariantCultureIgnoreCase) = 0 then
            ////forward
            //printf "works"
            //else printf "does not work"//right 


    //let nextmove unit world=
        //unit
        //|>
        //switch (setCurrentRoom world)



    let usermove = 
        printf "Please enter a command: "
        let mutable raw = System.Console.ReadLine()
        //let input = raw
        //if raw.Contains 
        let (|InvariantEqual|_|) (str: string) raw = 
          if String.Compare(str, raw, StringComparison.OrdinalIgnoreCase) = 0
            then Some() else None

        match raw with
        | InvariantEqual "move left" -> left
        | InvariantEqual "move right" -> right
        | InvariantEqual "move forward" -> forward
        | InvariantEqual "move backward" -> backward
        | _ -> noInput

        //let raw = System.Console.ReadLine()
        //input = System.Console.ReadLine()
        //| _ -> printfn "Please enter a valid command"
        //raw = unit

    //example code from: https://forums.fsharp.org/t/basic-f-console-ui-program-loop/1216/3
    module CommandLineExample =
        let printPrompt state = 
            printfn "Current State: %s" state
            printf "command:>"

        let getCommandLineInput = Console.ReadLine

        let writeError value =
            printfn "ERROR - No Match\nYou typed: %s" value

        let writeMatch value =
            printfn "Matched: %s" value
         
        let processCommandLineInput state commandLineInput =
            match commandLineInput with
            | "a" -> writeMatch "a"; Some "Ivan"
            | "b" -> writeMatch "b"; Some "Bob"
            | "c" -> writeMatch "c"; Some state
            | "exit" | "quit" -> None
            | _ -> writeError commandLineInput; Some state

        let rec progLoop state =
            state |> printPrompt
            let updated = 
                getCommandLineInput()
                |> processCommandLineInput state
            match updated with
            | Some newState -> progLoop newState
            | None -> Environment.Exit 55

    
    //gameWorld
    //|> describeCurrentRoom
    //|> displayResult
    //gameWorld
    //|> move usermove
    //|> bind describeCurrentRoom
    //|> displayResult


    //|> nend (nextmove)
    //|> nextmove ()
    //|> move left
    //|> bind describeCurrentRoom
   //|> bind displayResult
    //|> move right
    //st
    //|> print
   // for i in allRooms do
   //    World
   //|    > describeCurrentRoom
   //|    > displayResult
   //g    ameWorld
   //|    > move usermove
   //|    > bind describeCurrentRoom
   //|    > displayResult