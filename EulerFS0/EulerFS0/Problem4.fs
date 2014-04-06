module Problem4
// solution from 23 Mar 2014, user luksan, with minor tweaks.
// this one just walks through all permutations of x & y, {100..999}.
let isPalindrome n =
    let chars = n |> string |> Seq.toList
    chars |> List.rev = chars

// returns a seq from 100 to 999
let getSeqForDigits digits =
    let power = digits - 1
    let min = pown 10 power
    let max = pown 10 (power + 1) - 1
    { min .. max }

let largestPalindrome digits =
    let numbers = getSeqForDigits digits
    seq { for x in numbers do
          for y in numbers -> x * y }
//    |> Seq.length   //810,000
    |> Seq.filter isPalindrome
    |> Seq.max 

let soln1 = largestPalindrome 3
//printfn "%d" (largestPalindrome 3)

//pown 10 2 //100
//pown 10 3 - 1 //999
