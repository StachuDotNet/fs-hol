namespace FsWithTests

//---------------------------------------------------------------
// About Strings
//
// Most languages have a set of utilities for manipulating 
// strings. F# is no different.
//---------------------------------------------------------------





[<Test(Sort = 7)>]
module ``about strings`` =





    [<Test>]
    let ``string value``() =
        let message = "hello"

        AssertEquality message __






    [<Test>]
    let ``string concat value``() =
        let message = "hello " + "world"

        AssertEquality message __






    [<Test>]
    let ``formatting string values``() =
        let message = sprintf "F# turns it to %d!" 11

        AssertEquality message __

        //NOTE: you can use printf to print to standard output

        (* TRY IT: 
            What happens if you change 11 to be something besides 
            a number? *)








    [<Test>]
    let ``formatting other types``() =
        let message = sprintf "hello %s" "world"

        AssertEquality message __









    [<Test>]
    let ``formatting anything``() =
        let message = sprintf "Formatting other types is as easy as: %A" (1, 2, 3)

        AssertEquality message __

    (* NOTE: For all the %formatters that you can use with string formatting 
             see: http://msdn.microsoft.com/en-us/library/ee370560.aspx *)









    [<Test>]
    let ``combine multiple lines``() =
        let message = "super\
                        cali\
                        fragilistic\
                        expiali\
                        docious"

        AssertEquality message __










    [<Test>]
    let ``multi-line strings``() =
        let message = "This
                        is
                        on
                        five
                        lines"

        AssertEquality
              message __










    [<Test>]
    let ExtractValues() =
        let message = "hello world"

        let first = message.[0]
        let other = message.[4] 

        AssertEquality first __
        >>= AssertEquality other __











    [<Test>]
    let ApplyWhatYouLearned() =
        (* It's time to apply what you've learned so far. 
            fill in the function below to make the asserts pass *)
        let getFunFacts x =
            let doubled = x * 2
            let tripled = x * 3
            sprintf "%d doubled is %d, and %d tripled is %d!" x doubled x tripled

        let funFactsAboutThree = getFunFacts 3
        let funFactsAboutSix = getFunFacts 6

        AssertEquality funFactsAboutThree __
        >>= AssertEquality funFactsAboutSix __
