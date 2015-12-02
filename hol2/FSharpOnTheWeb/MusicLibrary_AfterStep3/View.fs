module SuaveMusicStore.View

open Suave.Html

// Helper functions:
let h1 xml = tag "h1" [] xml
let aHref href = tag "a" ["href", href]
let divWithId id = divAttr ["id", id]

// html page
let index = 
    html [
        head [ title "Suave Music Store" ]
        
        body [
            divWithId "header" [
                h1 (aHref "/" (text "F# Suave Music Store App"))
            ]

            divWithId "footer" [
                text "built with "
                aHref "http://fsharp.org" (text "F#")
                text " and "
                aHref "http://suave.io" (text "Suave.IO")
            ]
        ]
    ] |> xmlToString