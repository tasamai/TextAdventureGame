//// Learn more about F# at http://fsharp.org

////open GameModel

////open System
////[<EntryPoint>]
module program

//    open System
//    open InitialState
//    open GameModel

    
    
//    //
//    // --------- Model ---------
//    //
//    type Details =
//                { Name: string
//                  Description: string }

//        type Item =
//            { Details: Details }

//        type RoomId =
//            | RoomId of string

//        type Exit =
//            | UnlockedExit of string * destination: RoomId
//            | LockedExit of string * key: Item * next: Exit 
//            | NoExit of string option

//        type Exits =
//            { North: Exit
//              South: Exit
//              East: Exit
//              West: Exit }

//        type Room =
//            { Id: RoomId
//              Details: Details
//              Items: Item list
//              Exits: Exits }

//        type Player =
//            { Details: Details
//              Location: RoomId
//              Inventory: Item list }

//        type World =
//            { Rooms: Map<RoomId, Room> 
//              Player: Player }



//    // --------- Initial World ---------

//    (*let key: Item = 
//        { Details =
//              { Name = "A shiny key"
//                Description = "This key looks like it could open a nearby door."} }

//    let allRooms = [
//        { Id = RoomId "center"
//          Details = 
//              { Name = "A central room"
//                Description = "You are standing in a central room with exits in all directions.  A single brazier lights the room."}
//          Items = []
//          Exits =
//              { North = UnlockedExit ("You see a darkened passageway to the north.", RoomId "north1")
//                South = UnlockedExit ("You see door to the south.  A waft of cold air hits your face.", RoomId "south1")
//                East = LockedExit ("You see a locked door to the east.", key, UnlockedExit ("You see an open door to the east.", RoomId "east1"))
//                West = UnlockedExit ("You see an interesting room to the west.", RoomId "west1") }}

//        { Id = RoomId "north1"
//          Details = 
//              { Name = "A dark room"
//                Description = "You are standing in a very dark room.  You hear the faint sound of rats scurrying along the floor."}
//          Items = []
//          Exits =
//              { North = NoExit None
//                South = UnlockedExit ("You see an dimly lit room to the south.", RoomId "center")
//                East = NoExit None
//                West = NoExit None }}

//        { Id = RoomId "south1"
//          Details = 
//              { Name = "A cold room"
//                Description = "You are standing in a room that feels very cold.  Your breath instantly turns into a white puff."}
//          Items = []
//          Exits =
//              { North = UnlockedExit ("You see an exit to the north.  That room looks much warmer.", RoomId "center")
//                South = NoExit None
//                East = NoExit None
//                West = NoExit None }}

//        { Id = RoomId "west1"
//          Details = 
//              { Name = "A cozy room"
//                Description = "This room seems very cozy, as if someone had made a home here.  Various personal belongings are strewn about."}
//          Items = [ key ]
//          Exits =
//              { North = NoExit None
//                South = NoExit None
//                East = UnlockedExit ("You see a doorway back to the lit room.", RoomId "center")
//                West = NoExit None }}

//        { Id = RoomId "east1"
//          Details = 
//              { Name = "An open meadow"
//                Description = "You are in an open meadow.  The sun is bright and it takes some time for your eyes to adjust."}
//          Items = []
//          Exits =
//              { North = NoExit None
//                South = NoExit None
//                East = NoExit None
//                West = UnlockedExit ("You see stone doorway to the west.  Why would you want to go back there?", RoomId "center") }}
//    ]

//    let player =
//        { Details = { Name = "Luke"; Description = "Just your average adventurer."}
//          Inventory = []
//          Location = RoomId "center" }

//   let gameWorld =
//        { Rooms =
//            allRooms
//            |> Seq.map (fun room -> (room.Id, room))
//            |> Map.ofSeq
//          Player = player} *)

////
//// --------- Logic --------- 
////

   //     type Input<'left, 'right, 'forward, 'backward> =
   //                 |ULeft of Left: Exit
   //                 |URight of Right: Exit
   //                 |UForward of Forward: Exit
   //                 |UBackward of Backward: Exit

   //     type Result<'TSuccess, 'TFailure> =
   //         | Success of 'TSuccess
   //         | Failure of 'TFailure

   //     let bind processFunc lastResult =
   //         match lastResult with
   //         | Success s -> processFunc s
   //         | Failure f -> Failure f

   //     let (>>=) x f =
   //         bind f x

   //     let switch processFunc input =
   //         Success (processFunc input)

   //     let getRoom world roomId =
   //         match world.Rooms.TryFind roomId with
   //         | Some room -> Success room
   //         | None -> Failure "Room does not exist!"

   //     let describeDetails details =
   //         sprintf "\n\n%s\n\n%s\n\n" details.Name details.Description


   //     let extractDetailsFromRoom (room: Room) =
   //         room.Details

   //     let getCurrentRoom world =
   //         world.Player.Location
   //         |> getRoom world

   //     let setCurrentRoom world room =
   //         { world with
   //             Player = { world.Player with Location = room.Id} }

   //     let describeCurrentRoom world =
   //         world.Player.Location
   //         |> getRoom world
   //         |> (bind (switch extractDetailsFromRoom)
   //         >> bind (switch describeDetails))

   //     let forward ({ Forward = northExit }: Exits) = northExit
   //     let backward ({ Backward = southExit }: Exits) = southExit
   //     let right ({ Right = eastExit }: Exits) = eastExit
   //     let left ({ Left = westExit }: Exits) = westExit
       

      

   //     let getExit direction exits =
   //         match (direction exits) with
   //         | UnlockedExit (_, roomId) -> Success roomId
   //         | LockedExit (_, _, _) -> Failure "There is a locked door in that direction."
   //         | NoExit (_) -> Failure "There is no room in that direction."

   //     let move direction world =
   //         world
   //         |> getCurrentRoom
   //         >>= switch (fun room -> room.Exits) 
   //         >>= getExit direction
   //         >>= getRoom world
   //         >>= switch (setCurrentRoom world)

   //     let displayResult result world=
   //         match result with
   //         | Success s -> printf "%s" s
   //         | Failure f -> printf "%s" f
   //         world
   //         |> getCurrentRoom
   //         >>= switch (setCurrentRoom world)


   //     let userInput =
   //         let raw = Console.ReadLine()
   //         if String.Compare("left", raw, StringComparison.InvariantCultureIgnoreCase) = 0 then
   //             forward
   //             else right




   // //gameWorld
   // //|> getCurrentRoom
   // //|> describeCurrentRoom
   // //|> displayResult
   // //|> ignore
   // //|>  move forward
   // //|>  describeCurrentRoom
   ////|>  displayResult
   // //|>  getCurrentRoom

   // //|>  bind (switch move userInput) 

   // //|> 

   ////|> bind (switch move north)
   // //|> describeCurrentRoom
   // //|> displayResult
   // //|> bind getCurrentRoom
   // //|>bind move userInput
   // //|> 
   // //|> bind (move userInput)
   // //|> bind (move north)
   // //|> userInput
   // //|> getCurrentRoom
   // //|> displayResult
   // //|> bind (move userInput)
   ////|> bind describeCurrentRoom
    ////|> displayResult
    ////|> (move userInput)
    ////|> bind describeCurrentRoom
    ////|> displayResult