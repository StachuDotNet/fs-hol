namespace FsWithTests

//---------------------------------------------------------------
// Answering Problems
// 
// This is where the fun begins! Each Test method contains
// an example designed to teach you a lesson about the F# language. 
// If you execute the program defined in this project, you will get
// a message that the AssertEquality test below has failed. Your
// job is to fill in the blank (the __ symbol) to make it pass. Once
// you make the change, re-run the program to make sure the koan
// passes, and continue on to the next failing koan.  With each 
// passing koan, you'll learn more about F#, and add another
// weapon to your F# programming arsenal.
//---------------------------------------------------------------
[<Test(Sort = 1)>]
module ``about asserts`` =

    [<Test>]
    let ``assert expectation``() =
        let expected_value = 1 + 1
        let actual_value = __
     
        AssertEquality expected_value actual_value
