module Problem6
// brute force
let soln1 = 
    let nMax = 100
    let sumOfSquares = seq { for x in {1..nMax} -> x * x } |> Seq.sum
    let sums = {1..nMax} |> Seq.sum
    let squareOfSums = sums * sums
    squareOfSums - sumOfSquares
