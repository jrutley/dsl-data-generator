open CommandLine

type Dsl = {
    oid : int
    framedIpAddress : string
}

[<EntryPoint>]
let main argv =
    let options = CommandLine.parseCommandLine ( Array.toList(argv) )
    printfn "%A" argv
    0 // return an integer exit code