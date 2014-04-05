// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv = 
    //printfn "%A" argv
    printfn "The answer is %A" Problem3.soln1

    printfn "Press enter..."
    System.Console.ReadLine() |> ignore
    0 // return an integer exit code
