module Problem29
// the answer is 9283
let soln1 = 
    //let nMax = 100
    seq { for a in [2.0..100.0] do
          for b in [2..100] -> pown a b }
    |> Seq.distinct 
    |> Seq.length
