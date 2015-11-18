namespace FsWithTests
open System.Collections.Generic

//---------------------------------------------------------------
// About Arrays
//
// Like lists, arrays are another basic container type in F#.
//---------------------------------------------------------------

[<Test(Sort = 11)>]
module ``about arrays`` =




    [<Test>]
    let ``creating arrays``() =
        let fruits = [| "apple"; "pear"; "peach"|]

        AssertEquality fruits.[0] "apple"
        >>= AssertEquality fruits.[1] "pear"
        >>= AssertEquality fruits.[2] "peach"








    [<Test>]
    let ``arrays are .net ararys``() =
        let fruits = [| "apple"; "pear" |]

        let arrayType = fruits.GetType()
        let systemArray = System.Array.CreateInstance(typeof<string>, 0).GetType()

        (* Unlike List, Arrays in F# are the standard .NET arrays that
           you're used to if you're coming from another .NET language *)
        AssertEquality arrayType systemArray








    [<Test>]
    let ``arrays are mutable``() =
        let fruits = [| "apple"; "pear" |]
        fruits.[1] <- "peach"

        AssertEquality fruits [|"apple"; "peach"|]








    [<Test>]
    let ``you can create arrays with comprehensions``() =
        let numbers = 
            [| for i in 0..10 do 
                   if i % 2 = 0 then yield i |]

        AssertEquality numbers [|0; 2; 4; 6; 8; 10|]








    [<Test>]
    let ``there are also some operations you can perform on arrays``() =
        let cube x = x * x * x

        let original = [| 0..5 |]
        let result = Array.map cube original

        AssertEquality original [| 0; 1; 2; 3; 4; 5 |]
        >>= AssertEquality result [| 0; 1; 8; 27; 64; 125 |]
