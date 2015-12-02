module SuaveMusicStore.View

open Suave.Html

// Helper functions:
let h1 xml = tag "h1" [] xml
let h2 s = tag "h2" [] (text s)
let aHref href = tag "a" ["href", href]
let divWithId id = divAttr ["id", id]

let ul xml = tag "ul" [] (flatten xml)
let li = tag "li" []

let cssLink href = linkAttr ["href", href; " rel", "stylesheet"; " type", "text/css"]


// html page
let index container = 
    html [
        head [ 
            title "Suave Music Store" 
            cssLink "/Site.css"
        ]
        
        body [
            divWithId "header" [
                h1 (aHref Path.home (text "F# Suave Music Store App"))
            ]

            divWithId "footer" [
                text "built with "
                aHref "http://fsharp.org" (text "F#")
                text " and "
                aHref "http://suave.io" (text "Suave.IO")
            ]
        ]
    ] |> xmlToString



let home = [ h2 "Home" ]

let store genres = [
    h2 "Browse Genres"
    p [ text (sprintf "Select from %d genres:" (List.length genres)) ]

    ul [
        for g in genres ->
            li (aHref (Path.Store.browse |> Path.withParam (Path.Store.browseKey, g)) (text g))
    ]
]

let browse genre = [ h2 (sprintf "Genre: %s" genre) ]
let details id = [ h2 (sprintf "Details: %d" id) ]
