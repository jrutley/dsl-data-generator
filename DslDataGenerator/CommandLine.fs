module CommandLine
    open System

    module CommandLine =

        type CommandLineOptions = {
            startDate: DateTimeOffset;
            endDate: DateTimeOffset;
        }

        // create the "helper" recursive function
        let rec parseCommandLineRec args optionsSoFar = 
            match args with 
            // empty list means we're done.
            | [] -> 
                optionsSoFar
            | "-start"::xs::xss ->
                let newOptionsSoFar = {optionsSoFar with startDate = DateTimeOffset.Parse(xs.Trim())}
                parseCommandLineRec xss newOptionsSoFar

            | "-stop"::xs::xss ->
                let newOptionsSoFar = {optionsSoFar with endDate = DateTimeOffset.Parse(xs.Trim())}
                parseCommandLineRec xss newOptionsSoFar

            // handle unrecognized option and keep looping
            | x::xs -> 
                printfn "Option '%s' is unrecognized" x
                parseCommandLineRec xs optionsSoFar 

        // create the "public" parse function
        let parseCommandLine args = 
            // create the defaults
            let defaultOptions = {
                startDate = DateTimeOffset.MinValue
                endDate = DateTimeOffset.MaxValue
                }

            // call the recursive one with the initial options
            parseCommandLineRec args defaultOptions 
