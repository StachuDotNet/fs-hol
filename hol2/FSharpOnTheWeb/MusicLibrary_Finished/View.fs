module SuaveMusicStore.View

open Suave.Html
open System

// Helper functions:
let h1 xml = tag "h1" [] xml
let h2 s = tag "h2" [] (text s)
let aHref href = tag "a" ["href", href]
let divWithId id = divAttr ["id", id]

let ul xml = tag "ul" [] (flatten xml)
let li = tag "li" []

let cssLink href = linkAttr ["href", href; " rel", "stylesheet"; " type", "text/css"]


let imgSrc src = imgAttr [ "src", src ]
let em s = tag "em" [] (text s)
let formatDec (d : Decimal) = d.ToString(Globalization.CultureInfo.InvariantCulture)

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

            divWithId "main" container

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

let browse genre (albums : Db.Album list) = [
    h2 (sprintf "Genre: %s" genre)
    ul [
        for a in albums ->
            li (aHref (sprintf Path.Store.details a.AlbumId) (text a.Title))
    ]
]

let details (album : Db.AlbumDetails) = [
    h2 album.Title
    
    p [ imgSrc album.AlbumArtUrl ]

    divWithId "album-details" [
        p [ em "Genre:"; text album.Genre ]

        p [ em "Artist:"; text album.Artist ]

        p [ em "Price:"; text <| formatDec album.Price ]
    ]
]


let notFound = [
    h2 "Page not found"
    
    p [text "Could not find the requested page"]
    
    p [
        text "Back to "
        aHref Path.home (text "Home")
    ]
]