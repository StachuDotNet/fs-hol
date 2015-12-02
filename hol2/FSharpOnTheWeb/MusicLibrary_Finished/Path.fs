﻿module SuaveMusicStore.Path

type IntPath = PrintfFormat<(int->string),unit,string,string,int>

let home = "/"

let withParam (key, value) path = sprintf "%s?%s=%s" path key value

module Store = 
    let overview = "/store"
    let browse = "/store/browse"
    let browseKey = "genre"
    let details : IntPath = "/store/details/%d"