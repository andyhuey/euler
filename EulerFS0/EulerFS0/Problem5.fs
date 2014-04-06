module Problem5
// ajh 2014-04-06: from my C# solution, after a bunch of work...
let soln1 =
    let isTheAnswer ans = {19L .. -1L .. 1L} |> Seq.forall (fun i -> ans % i = 0L)
    //isTheAnswer 232792560L - yup.

    // from http://stackoverflow.com/a/7601951/301677:
    let multiples n = Seq.unfold (fun i -> Some(i, i + n)) n
    //multiples 2520L |> Seq.take 5 |> printfn "%A"

    multiples 2520L |> Seq.filter isTheAnswer |> Seq.head

//{19L .. -1L .. 1L} |> Seq.forall (fun i -> 2520L % i = 0L) -- false
//{19L .. -1L .. 1L} |> Seq.forall (fun i -> 232792560L % i = 0L) -- true
