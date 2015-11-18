namespace FsWithTests

//---------------------------------------------------------------
// About Functions
//
// Now that you've seen how to bind a name to a value with let,
// you'll learn to use the let keyword to create functions.
//---------------------------------------------------------------





[<Test(Sort = 3)>]
module ``about functions`` =

    (* By default, F# is whitespace sensitive.
       For functions, this means that the last
       line of a function is its return value,
       and the body of a function is denoted
       by indentation. *)

    let add x y =
        x + y







    [<Test>]
    let ``creating functions with let``() =
        let result1 = add 2 2
        let result2 = add 5 2
        
        AssertEquality result1 4
        >>= AssertEquality result2 7








    [<Test>]
    let ``nesting functions``() =
        let quadruple x =    
            let double x = x * 2
            double(double(x))

        let result = quadruple 4

        AssertEquality result 16








    [<Test>]
    let ``adding type annotations``() =

        (* Sometimes you need to help F#'s type inference system out with an
           explicit type annotation *)
    
        let sayItLikeAnAuctioneer (text:string) = text.Replace(" ", "")

        let auctioneered = 
            sayItLikeAnAuctioneer "going once going twice sold to the lady in red"
        AssertEquality auctioneered "goingoncegoingtwicesoldtotheladyinred"

        //TRY IT: What happens if you remove the type annotation on text?






    [<Test>]
    let ```variables in the parent scope can be accessed``() =
        let suffix = "!!!"

        let caffinate (text:string) = (text.Trim() + suffix).ToUpper()

        let caffinatedReply = caffinate "    hello there  "

        AssertEquality caffinatedReply "HELLO THERE!!!"

        (* TRY IT: What happens if you make suffix into a mutable variable? *)
