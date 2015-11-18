namespace FsWithTests

open System.Collections.Generic

//---------------------------------------------------------------
// About Lists
//
// Lists are important building blocks that you'll use frequently
// in F# programming. They are used to group arbitrarily large 
// sequences of values. It's very common to store values in a 
// list and perform operations across each value in the 
// list.
//---------------------------------------------------------------






[<Test(Sort = 9)>]
module ``about lists`` =




    [<Test>]
    let ``creating lists``() =
        let list = ["apple"; "pear"; "grape"; "peach"]
        //Note: The list data type in F# is a singly linked list,  so indexing elements is O(n). 
        
        AssertEquality list.Head "apple"
        >>= AssertEquality list.Tail ["pear"; "grape"; "peach"]
        >>= AssertEquality list.Length 4
    
    
    
    
    
    
    
    [<Test>]
    let ``not the .NET list you're used to``() = 
        let list = ["apple"; "pear"; "grape"; "peach"]
        let dotNetList = new List<string>()
         (* .NET developers coming from other languages may be surprised
           that F#'s list type is not the same as the base class library's
           List<T>. In other words, the following assertion is true *)

        AssertInequality (list.GetType()) (dotNetList.GetType())










    [<Test>]
    let ``building new lists from old lists``() =
        let first = ["grape"; "peach"]
        let second = "pear" :: first
        let third = "apple" :: second

        //Note: "::" is known as "cons"
        
        AssertEquality third ["apple"; "pear"; "grape"; "peach"]
        >>= AssertEquality second ["pear"; "grape"; "peach"]
        >>= AssertEquality first ["grape"; "peach"]

        //What happens if you uncomment the following?

//        first.Head <- "apple"
//        first.Tail <- ["peach"; "pear"]

        //THINK ABOUT IT: Can you change the contents of a list once it has been
        //                created?










    [<Test>]
    let ConcatenatingLists() =
        let first = ["apple"; "pear"; "grape"]
        let second = first @ ["peach"]

        AssertEquality first ["apple"; "pear"; "grape"]
        >>= AssertEquality second ["apple"; "pear"; "grape"; "peach"]

    (* THINK ABOUT IT: In general, what performs better for building lists, 
       :: or @? Why?
       
       Hint: There is no way to modify "first" in the above example. It's
       immutable. With that in mind, what does the @ function have to do in
       order to append ["peach"] to "first" to create "second"? *)
        







    [<Test>]
    let CreatingListsWithARange() =
        let list = [0..4]
        
        AssertEquality list.Head 0
        >>= AssertEquality list.Tail [1; 2; 3; 4]
        









    [<Test>]
    let CreatingListsWithComprehensions() =
        let list = [for i in 0..4 do yield i]
                            
        AssertEquality list [0..4]
    











    [<Test>]
    let ComprehensionsWithConditions() =
        let list = [for i in 0..10 do 
                        if i % 2 = 0 then yield i ]
                            
        AssertEquality list [0..2..10]











    [<Test>]
    let TransformingListsWithMap() =
        let square x = x * x

        let original = [0..5]
        let result = List.map square original

        AssertEquality original [0; 1; 2; 3; 4; 5]
        >>= AssertEquality result [0; 1; 4; 9; 16; 25]











    [<Test>]
    let FilteringListsWithFilter() =
        let isEven x = x % 2 = 0

        let original = [0..5]
        let result = List.filter isEven original

        AssertEquality original [0; 1; 2; 3; 4; 5]
        >>= AssertEquality result [0; 2; 4]








