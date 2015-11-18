namespace FsWithTests

open System.Collections.Generic

//---------------------------------------------------------------
// About .NET Collections
//
// Since F# is built for seamless interop with other CLR 
// languages, you can use all of the basic .NET collections types
// you're already familiar with if you're a C# or VB programmer.
//---------------------------------------------------------------




[<Test(Sort = 14)>]
module ``about dot net collections`` =




    [<Test>]
    let ``creating .net lists``() =
        let fruits = new List<string>()

        fruits.Add("apple")
        fruits.Add("pear")
 
        AssertEquality fruits.[0] "apple"
        >>= AssertEquality fruits.[1] "pear"







    [<Test>]
    let ``creating .net dictionaries``() =
        let addressBook = new Dictionary<string, string>()

        addressBook.["Chris"] <- "Ann Arbor"
        addressBook.["SkillsMatter"] <- "London"

        AssertEquality addressBook.["Chris"] "Ann Arbor"
        >>= AssertEquality addressBook.["SkillsMatter"] "London"









    [<Test>]
    let ``you use combinators with .net types``() =
        let addressBook = new Dictionary<string, string>()

        addressBook.["Chris"] <- "Ann Arbor"
        addressBook.["SkillsMatter"] <- "London"

        let verboseBook = 
            addressBook
            |> Seq.map (fun kvp -> sprintf "Name: %s - City: %s" kvp.Key kvp.Value)
            |> Seq.toArray

        //NOTE: The seq type in F# is an alias for .NET's IEnumerable interface
        //      Like the List and Array module, the Seq module contains functions 
        //      that you can combine to perform operations on types implementing 
        //      seq/IEnumerable.

        AssertEquality verboseBook.[0] "Name: Chris - City: Ann Arbor"
        >>= AssertEquality verboseBook.[1] "Name: SkillsMatter - City: London"






    [<Test>]
    let ``skipping elements``() =
        let original = [0..5]
        let result = Seq.skip 2 original
        
        AssertEquality result [2; 3; 4; 5]







    [<Test>]
    let ``finding the max``() =
        let values = new List<int>()

        values.Add(11)
        values.Add(20)
        values.Add(4)
        values.Add(2)
        values.Add(3)

        let result = Seq.max values
        
        AssertEquality result 20
    






    [<Test>]
    let ``finding the max using a condition``() =
        let getNameLength (name:string) =
            name.Length
        
        let names = [| "Harry"; "Lloyd"; "Nicholas"; "Mary"; "Joe"; |]
        let result = Seq.maxBy getNameLength names 
        
        AssertEquality result "Nicholas"
