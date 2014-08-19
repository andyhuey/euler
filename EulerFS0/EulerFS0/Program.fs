// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv = 
    //printfn "%A" argv
    //printfn "The answer is %A" Problem31.soln1
    System.Console.WriteLine("The answer is {0:n0}.", Problem34.soln1)
    //System.Console.WriteLine("The other answer is {0:n0}.", Problem31.soln2)

    printfn "Press enter..."
    System.Console.ReadLine() |> ignore
    0 // return an integer exit code
