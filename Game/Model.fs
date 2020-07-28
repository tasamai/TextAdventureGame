namespace GameModel


    type Details =
                { Name: string
                  Description: string }

        type Item =
            { Details: Details }

        type RoomId =
            | RoomId of int

        type Exit =
            | UnlockedExit of string * destination: RoomId
            | LockedExit of string * key: Item * next: Exit 
            | NoExit of string option

        type Exits =
            { Forward: Exit
              Back: Exit
              Right: Exit
              Left: Exit
              NoInput: Exit }

        type Room =
            { Id: RoomId
              Details: Details
              Items: Item list
              Exits: Exits }

        //type Room =
            //{ Id: RoomId
              //Details: Details
              //Items: Item list
              //Exits: Exits }

        type Player =
            { Details: Details
              Location: RoomId
              Inventory: Item list }

        type World =
            { Rooms: Map<RoomId, Room> 
              Player: Player }


        type Result<'TSuccess, 'TFailure> =
                | Success of 'TSuccess
                | Failure of 'TFailure

        type Input<'left, 'right, 'forward, 'backward> =

                    |ULeft of Left: Exit
                    |URight of Right: Exit
                    |UForward of Forward: Exit
                    |UBackward of Backward: Exit
    

