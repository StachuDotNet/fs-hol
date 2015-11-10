namespace FsWithTests


//---------------------------------------------------------------
// About Classes
//
// As a full fledged Object Oriented language, F# allows you to
// create traditional classes to contain data and methods.
//---------------------------------------------------------------

[<Test(Sort = 21)>]
module ``about classes`` =





    type Zombie() =
        member this.FavoriteFood = "brains"

        member this.Eat food =
            match food with
            | "brains" -> "mmmmmmmmmmmmmmm"
            | _ -> "grrrrrrrr"

    [<Test>]
    let ``classes can have properties``() =
        let zombie = new Zombie()

        AssertEquality zombie.FavoriteFood __

    [<Test>]
    let ``classes can have methods``() =
        let zombie = new Zombie()
        let result = zombie.Eat "brains"
        
        AssertEquality result __
    









    type Person(name:string) =
        member this.Speak() = "Hi my name is " + name

    [<Test>]
    let ``classes can have constructors``() =
        let person = new Person("Shaun")
        let result = person.Speak()

        AssertEquality result __








    type Zombie2() =
        let favoriteFood = "brains"

        member this.Eat food =
            if food = favoriteFood then 
                "mmmmmmmmmmmmmmm" 
            else 
                "grrrrrrrr"

    [<Test>]
    let ``classes can have let bindings inside them``() =
        let zombie = new Zombie2()

        let result = zombie.Eat "chicken"
        AssertEquality result __

        (* TRY IT: Can you access the let bound value Zombie2.favoriteFood
                   outside of the class definition? *)






    type Person2(name:string) =
        let mutable internalName = name

        member this.Name
            with get() = internalName
            and set(value) = internalName <- value

        member this.Speak() = "Hi my name is " + this.Name

    [<Test>]
    let ``classes can have read write properties``() =
        let person = new Person2("Shaun")
        let firstPhrase = person.Speak()

        person.Name <- "Shaun of the Dead"
        let secondPhrase = person.Speak()

        AssertEquality firstPhrase __
        >>= AssertEquality secondPhrase __
