namespace FsWithTests

//---------------------------------------------------------------
// About Branching
//
// Branching is used to tell a program to conditionally perform
// an operation. It's another fundamental part of F#.
//---------------------------------------------------------------





[<Test(Sort = 8)>]
module ``about branching`` =
    



    [<Test>]
    let ``basic branching``() =
        let isEven x =
            if x % 2 = 0 then
                "it's even!"
            else
                "it's odd!"
                
        let result = isEven 2                
        AssertEquality result "it's even!"














    [<Test>]
    let ``branching with pattern matching``() =
        let isApple x =
            match x with
            | "apple"
            | "golden delicious"
            | "macintosh"   -> true
            | _ -> false
        
        let result1 = isApple "apple"
        let result2 = isApple ""
        
        AssertEquality result1 true
        >>= AssertEquality result2 false
    








    [<Test>]
    let ``using tuples with if statements quickly becomes clumsy``() =
        
        let getDinner x = 
            let name, foodChoice = x
            
            if foodChoice = "veggies" || foodChoice = "fish" || foodChoice = "chicken" then
                sprintf "%s doesn't want red meat" name
            else
                sprintf "%s wants 'em some %s" name foodChoice
         
        let person1 = ("Chris", "steak")
        let person2 = ("Dave", "veggies")
        
        AssertEquality (getDinner person1) "Chris wants 'em some steak"
        >>= AssertEquality (getDinner person2) "Dave doesn't want red meat"
        









    [<Test>]
    let ``pattern matching is nicer``() =
    
        let getDinner x =
            match x with
            | (name, "veggies")
            | (name, "fish")
            | (name, "chicken") -> sprintf "%s doesn't want red meat" name

            | (name, foodChoice) -> sprintf "%s wants 'em some %s" name foodChoice 
            
        let person1 = ("Bob", "fish")
        let person2 = ("Sally", "Burger")
        
        AssertEquality (getDinner person1) "Bob doesn't want red meat"
        >>= AssertEquality (getDinner person2) "Sally wants 'em some Burger"
