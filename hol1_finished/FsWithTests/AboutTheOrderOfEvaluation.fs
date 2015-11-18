namespace FsWithTests

//---------------------------------------------------------------
// About the Order of Evaluation
//
// Sometimes you'll need to be explicit about the order in which
// functions are evaluated. F# offers a couple mechanisms for
// doing this.
//---------------------------------------------------------------





[<Test(Sort = 4)>]
module ``about the order of evaluation`` =



    [<Test>]
    let ``sometimes you need parenthesis to group things``() =
        let add x y = x + y

        let result = add (add 5 8) (add 1 1)

        AssertEquality result 15

        (* TRY IT: What happens if you remove the parenthesis?*)








    [<Test>]
    let ``the backward pipe operator can also help with grouping``() =
        let add x y = x + y
        let double x = x * 2

        let result = double <| add 5 8

        AssertEquality result 26
