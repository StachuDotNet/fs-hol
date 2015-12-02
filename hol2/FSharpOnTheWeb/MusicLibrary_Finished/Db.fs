module SuaveMusicStore.Db

open FSharp.Data.Sql

// Infrastructure

let firstOrNone s = s |> Seq.tryFind (fun _ -> true)

// Connection

type Sql = 
    SqlDataProvider<
        "Server=SQL5011.Smarterasp.net;Database=DB_9AB22B_pdnfshol;User Id=ReadOnlyHolUser;Password=SuperSecret",
        DatabaseVendor=Common.DatabaseProviderTypes.MSSQLSERVER>

type DbContext = Sql.dataContext

type Album = DbContext.``[dbo].[Albums]Entity``
type Genre = DbContext.``[dbo].[Genres]Entity``
type AlbumDetails = DbContext.``[dbo].[AlbumDetails]Entity``

let getContext() = Sql.GetDataContext()

// Queries

let getGenres (ctx : DbContext) : Genre list =
    ctx.``[dbo].[Genres]`` |> Seq.toList

let getAlbumsForGenre genreName (ctx : DbContext) : Album list = 
    query {
        for album in ctx.``[dbo].[Albums]`` do
            join genre in ctx.``[dbo].[Genres]`` on (album.GenreId = genre.GenreId)
            where (genre.Name = genreName)
            select album
    } |> Seq.toList

let getAlbumDetails id (ctx : DbContext) : AlbumDetails option = 
    query {
        for album in ctx.``[dbo].[AlbumDetails]`` do
            where (album.AlbumId = id)
            select album
    } |> firstOrNone
