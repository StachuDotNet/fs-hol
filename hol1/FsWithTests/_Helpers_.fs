[<AutoOpenAttribute>]
module FsWithTests.Helpers

open System
open NUnit.Framework


// Philly.NET Devs: Ignore this file, thanks.
// (unless you want to peek into my hacky test framework, maybe?)








// Hacky ROP test framework
type Result = Success | Failure of string

let bind switchFunction twoTrackInput = 
    match twoTrackInput with
    | Success -> switchFunction
    | Failure f -> Failure f

let (>>=) twoTrackInput switchFunction = bind switchFunction twoTrackInput








// Assertions
let AssertEquality (x:'a) (y:'b) : Result = 
    let mutable msg : Result = Success
    try Assert.AreEqual (x, y) 
    with | :? NUnit.Framework.AssertionException as ex -> msg <- Failure ex.Message
    msg

let AssertInequality (x:'a) (y:'b) : Result = 
    let mutable msg : Result = Success
    try Assert.AreNotEqual (x, y) 
    with | :? NUnit.Framework.AssertionException as ex -> msg <- Failure ex.Message
    msg






// "Fill me in"s
let __ = "FILL ME IN"
type FILL_ME_IN = class end