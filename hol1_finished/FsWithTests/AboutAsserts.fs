namespace FsWithTests

[<Test(Sort = 1)>]
module ``about asserts`` =

    [<Test>]
    let ``assert expectation``() =
        let expected_value = 1 + 1
        let actual_value = 2
     
        AssertEquality expected_value actual_value
