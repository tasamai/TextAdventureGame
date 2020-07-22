module InitialState

    open GameModel
    open System



    let key: Item = 
        { Details =
              { Name = "A shiny key"
                Description = "This key looks like it could open a nearby door."} }

    let allRooms = [
        { Id = RoomId "center"
          Details = 
              { Name = "A central room"
                Description = "You are standing in a central room with exits in all directions.  A single brazier lights the room."}
          Items = []
          Exits =
              { Forward = UnlockedExit ("You see a darkened passageway to the Forward.", RoomId "Forward1")
                Backward = UnlockedExit ("You see door to the Backward.  A waft of cold air hits your face.", RoomId "Backward1")
                Right = LockedExit ("You see a locked door to the Right.", key, UnlockedExit ("You see an open door to the Right.", RoomId "Right1"))
                Left = UnlockedExit ("You see an interesting room to the Left.", RoomId "Left1") }}

        { Id = RoomId "Forward1"
          Details = 
              { Name = "A dark room"
                Description = "You are standing in a very dark room.  You hear the faint sound of rats scurrying along the floor."}
          Items = []
          Exits =
              { Forward = NoExit None
                Backward = UnlockedExit ("You see an dimly lit room to the Backward.", RoomId "center")
                Right = NoExit None
                Left = NoExit None }}

        { Id = RoomId "Backward1"
          Details = 
              { Name = "A cold room"
                Description = "You are standing in a room that feels very cold.  Your breath instantly turns into a white puff."}
          Items = []
          Exits =
              { Forward = UnlockedExit ("You see an exit to the Forward.  That room looks much warmer.", RoomId "center")
                Backward = NoExit None
                Right = NoExit None
                Left = NoExit None }}

        { Id = RoomId "Left1"
          Details = 
              { Name = "A cozy room"
                Description = "This room seems very cozy, as if someone had made a home here.  Various personal belongings are strewn about."}
          Items = [ key ]
          Exits =
              { Forward = NoExit None
                Backward = NoExit None
                Right = UnlockedExit ("You see a doorway back to the lit room.", RoomId "center")
                Left = NoExit None }}

        { Id = RoomId "Right1"
          Details = 
              { Name = "An open meadow"
                Description = "You are in an open meadow.  The sun is bright and it takes some time for your eyes to adjust."}
          Items = []
          Exits =
              { Forward = NoExit None
                Backward = NoExit None
                Right = NoExit None
                Left = UnlockedExit ("You see stone doorway to the Left.  Why would you want to go back there?", RoomId "center") }}
    ]

    let player =
        { Details = { Name = "Luke"; Description = "Just your average adventurer."}
          Inventory = []
          Location = RoomId "center" }

    let gameWorld =
         { Rooms =
             allRooms
             |> Seq.map (fun room -> (room.Id, room))
             |> Map.ofSeq
           Player = player}