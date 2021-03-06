﻿namespace FsWithTests

//---------------------------------------------------------------
// About Pipelining
//
// The forward pipe operator is one of the most commonly used
// symbols in F# programming. You can use it combine operations
// on lists and other data structures in a readable way.
//---------------------------------------------------------------




[<Test(Sort = 10)>]
module ``about pipelining`` =
    let square x = x * x
    let isEven x = x % 2 = 0






    [<Test>]
    let ``square even numbers with separate statements``() =
        (* One way to combine the operations is by using separate statements.
           However, this is can be clumsy since you have to name each result. *)

        let numbers = [0..5]

        let evens = List.filter isEven numbers
        let result = List.map square evens

        AssertEquality result [0; 4; 16]









    [<Test>]
    let ``square even numbers with parens``() =
        (* You can avoid this problem by using parens to pass the result of one
           function to another. This can be difficult to read since you have to 
           start from the innermost function and work your way out. *)

        let numbers = [0..5]

        let result = List.map square (List.filter isEven numbers)

        AssertEquality result [0; 4; 16]









    [<Test>]
    let ``square even numbers with pipeline operator``() =
        (* In F#, you can use the pipeline operator to get the benefit of the 
           parens style with the readablity of the statement style. *)

        let result = [0..5] |> List.filter isEven |> List.map square
        
        AssertEquality result [0; 4; 16]









    [<Test>]
    let ``how the pipe operator is defined``() =
        // overloaded
        let (|>) x y = y x

        let result =
            [0..5]
            |> List.filter isEven
            |> List.map square

        AssertEquality result [0; 4; 16]
