namespace FsWithTests

//---------------------------------------------------------------
// About Option Types
//
// Option Types are used to represent calculations that may or
// may not return a value. You may be used to using null for this
// in other languages. However, using option types instead of nulls
// has subtle but far reaching benefits.
//---------------------------------------------------------------




[<Test(Sort = 17)>]
module ``about option types`` =


    type Game = {
        Name: string
        Platform: string
        Score: int option
    }






    [<Test>]
    let ``option types might contain a value``() =
        let someValue = Some 10
        
        AssertEquality someValue.IsSome true
        >>= AssertEquality someValue.IsNone false
        >>= AssertEquality someValue.Value 10












    [<Test>]
    let ``or they might not``() =
        let noValue = None

        AssertEquality noValue.IsSome false
        >>= AssertEquality noValue.IsNone true












    [<Test>]
    let ``using option types with pattern matching``() =
        let chronoTrigger = { Name = "Chrono Trigger"; Platform = "SNES"; Score = Some 5 }
        let halo = { Name = "Halo"; Platform = "Xbox"; Score = None }

        let translate score =
            match score with
            | 5 -> "Great"
            | 4 -> "Good"
            | 3 -> "Decent"
            | 2 -> "Bad"
            | 1 -> "Awful"
            | _ -> "Unknown"

        let getScore game =
            match game.Score with
            | Some score -> translate score
            | None -> "Unknown"

        AssertEquality (getScore chronoTrigger) "Great"
        >>= AssertEquality (getScore halo) "Unknown"









    [<Test>]
    let ``projecting values from option types``() =
        let chronoTrigger = { Name = "Chrono Trigger"; Platform = "SNES"; Score = Some 5 }
        let halo = { Name = "Halo"; Platform = "Xbox"; Score = None }

        let decideOn game =
            game.Score
            |> Option.map (fun score -> if score > 3 then "play it" else "don't play")

        //HINT: look at the return type of the decide on function
        AssertEquality (decideOn chronoTrigger) (Some "play it")
        >>= AssertEquality (decideOn halo) null
