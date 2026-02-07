module Problem34
// ajh 2014-08-19: just messing with factorials in F#.

let rec factorial n =
    match n with
    | 0L -> 1L
    | _ -> n * factorial(n - 1L)

let soln1 = 
    factorial 4L

//123 |> string |> Seq.toList
//123 |> string |> List.ofSeq
