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

        AssertEquality message "hello"






    [<Test>]
    let ``string concat value``() =
        let message = "hello " + "world"

        AssertEquality message "hello world"






    [<Test>]
    let ``formatting string values``() =
        let message = sprintf "F# turns it to %d!" 11

        AssertEquality message "F# turns it to 11!"

        //NOTE: you can use printf to print to standard output








    [<Test>]
    let ``formatting other types``() =
        let message = sprintf "hello %s" "world"

        AssertEquality message "hello world"









    [<Test>]
    let ``formatting anything``() =
        let message = sprintf "Formatting other types is as easy as: %A" (1, 2, 3)

        AssertEquality message "Formatting other types is as easy as: (1, 2, 3)"

    (* NOTE: For all the %formatters that you can use with string formatting 
             see: http://msdn.microsoft.com/en-us/library/ee370560.aspx *)









    [<Test>]
    let ``combine multiple lines``() =
        let message = "super\
                        cali\
                        fragilistic\
                        expiali\
                        docious"

        AssertEquality message "supercalifragilisticexpialidocious"










    [<Test>]
    let ``multi-line strings``() =
        let message = "This
                        is
                        on
                        five
                        lines"

        AssertEquality
              message "This
                        is
                        on
                        five
                        lines"










    [<Test>]
    let ExtractValues() =
        let message = "hello world"

        let first = message.[0]
        let other = message.[4]

        AssertEquality first 'h'
        >>= AssertEquality other 'o'











    [<Test>]
    let ApplyWhatYouLearned() =

        let getFunFacts x =
            let doubled = x * 2
            let tripled = x * 3
            sprintf "%d doubled is %d, and %d tripled is %d!" x doubled x tripled

        let funFactsAboutThree = getFunFacts 3
        let funFactsAboutSix = getFunFacts 6

        AssertEquality funFactsAboutThree "3 doubled is 6, and 3 tripled is 9!"
        >>= AssertEquality funFactsAboutSix "6 doubled is 12, and 6 tripled is 18!"
