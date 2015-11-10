namespace FsWithTests

open System

// Philly.NET Devs: Ignore this file, thanks.
// (unless you want to see how to both *use* and *create* new attributes in F#, maybe?

[<AttributeUsage(AttributeTargets.Class ||| AttributeTargets.Method, AllowMultiple = false)>]
type TestAttribute () =
    inherit Attribute()
    let mutable sortOrder = 0
    member x.Sort
        with get() = sortOrder
        and set(v) = sortOrder <- v