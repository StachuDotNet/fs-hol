open FsWithTests

open System
open System.Collections.Generic
open System.Reflection
open System.IO


// Philly.NET Devs: Ignore this file, thanks.
// (unless you want to peek into my hacky test framework, maybe?)

let allModules =
    Assembly.GetCallingAssembly().GetTypes()
    |> Array.map (fun t -> t, t.GetCustomAttributes(typeof<TestAttribute>, true))
    |> Array.filter (not << Seq.isEmpty << snd)
    |> Array.sortBy (fun (t, attrs) -> (attrs.[0] :?> TestAttribute).Sort)
    |> Array.map fst

let hasTestAttribute (info:MethodInfo) = 
    info.GetCustomAttributes(typeof<TestAttribute>, true) 
    |> Seq.isEmpty 
    |> not

let findTestMethods (container: Type) = 
    container.GetMethods(BindingFlags.Public ||| BindingFlags.Static) 
    |> Seq.filter hasTestAttribute
    |> Seq.toList
    
let runTests container =
    let getTestResult (m:MethodInfo) =
        let result = m.Invoke(null, [||]) :?> Result

        match result with 
        | Success -> printfn "\t\"%s\" passed" m.Name
        | Failure msg -> printfn "\t\"%s\" failed." m.Name

        result
    
    let koanMethods = container |> findTestMethods

    let mutable lastTestMethod = Success

    for mtd in koanMethods do
        match lastTestMethod with
        | Success -> lastTestMethod <- getTestResult mtd
        | Failure msg -> ()
    
    lastTestMethod
        
let mutable lastTestModule = Success
for m in allModules do
    match lastTestModule with
    | Success -> 
        printfn "\n%s:" m.Name
        lastTestModule <- runTests m
    | Failure msg -> ()
    ()

match lastTestModule with
    | Success -> printfn "\nGood job, we're done! Go home or something!"
    | Failure msg -> printfn "\nFailure message: \n%A" msg

System.Console.ReadLine() |> ignore