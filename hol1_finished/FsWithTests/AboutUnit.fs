namespace FsWithTests

open Microsoft.FSharp.Reflection

//---------------------------------------------------------------
// About Unit
//
// The unit type is a special type that represents the lack of a value. 
// It's similar to void in other languages, but unit is actually considered to be a type in F#.
//---------------------------------------------------------------






[<Test(Sort = 5)>]
module ``about unit`` =





    [<Test>]
    let ``unit is used when there is no return value for a function``() =
        let sendData data =
            // do some stuff
            ()

        let x = sendData "data"
        AssertEquality x ()








    [<Test>]
    let ``parameterless functions take unit as their argument``() =
        let sayHello() =
            "hello"

        let result = sayHello()

        AssertEquality result "hello"
