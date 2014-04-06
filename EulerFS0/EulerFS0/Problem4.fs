module Problem4
// solution from 23 Mar 2014, user luksan, with minor tweaks.
// this one just walks through all permutations of x & y, {100..999}.
let mutable loopCount = 0

let isPalindrome n =
    loopCount <- loopCount + 1
    let chars = n |> string |> Seq.toList
    chars |> List.rev = chars

// returns a seq from 999 to 100
let getSeqForDigits digits =
    let power = digits - 1
    let min = pown 10 power
    let max = pown 10 (power + 1) - 1
    { max .. -1 .. min }

let getSubSeqForDigits digits max =
    let power = digits - 1
    let min = pown 10 power
    { max .. -1 .. min}    

let largestPalindrome digits =
    let numbers = getSeqForDigits digits
    seq { for x in numbers do
          for y in getSubSeqForDigits digits x -> x * y }
//    |> Seq.length
    |> Seq.filter isPalindrome
    |> Seq.max 

let soln1 = largestPalindrome 3
printfn "loopCount: %d" loopCount   //810,000 -> 405,450
//printfn "%d" (largestPalindrome 3)

//pown 10 2 //100
//pown 10 3 - 1 //999
//for x in seq {120..-1..110} do printfn "%A" x
