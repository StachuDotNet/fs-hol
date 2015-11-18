namespace FsWithTests

//---------------------------------------------------------------
// About Tuples
//
// Tuples are used to easily group together values in F#. 
// They're another fundamental construct of the language.
//---------------------------------------------------------------




[<Test(Sort = 6)>]
module ``about tuples`` =
    





    [<Test>]
    let ``creating tuples``() =
        let items = ("apple", "dog")
        
        AssertEquality items ("apple", "dog")
    
    
    
    
    
    
    
        
    [<Test>]
    let ``accessing tuple elements``() =
        let items = ("apple", "dog")
        
        let fruit = fst items
        let animal = snd items
        
        AssertEquality fruit "apple"
        >>= AssertEquality animal "dog"







    [<Test>]
    let ``accessing tuple elements with pattern matching``() =

        let items = ("apple", "dog", "Mustang")
        
        let fruit, animal, car = items
        
        AssertEquality fruit "apple"
        >>= AssertEquality animal "dog"
        >>= AssertEquality car "Mustang"
        






    [<Test>]
    let ``ignoring values with pattern matching``() =
        let items = ("apple", "dog", "Mustang")
        
        let _, animal, _ = items
        
        AssertEquality animal "dog"
    

        






    [<Test>]
    let ``returning multiple values from a function(?)``() =
        let squareAndCube x = (x ** 2.0, x ** 3.0)
        
        let squared, cubed = squareAndCube 3.0
        
        AssertEquality squared 9.0
        >>= AssertEquality cubed 27.0
    
    (* THINK ABOUT IT: 
        Is there really more than one return value?
        What type does the squareAndCube function
        return? *)
    






    [<Test>]
    let ``the truth behind multiple return values``() =
        let squareAndCube x = (x ** 2.0, x ** 3.0)
            
        let result = squareAndCube 3.0
       
        AssertEquality result (9.0, 27.0)
