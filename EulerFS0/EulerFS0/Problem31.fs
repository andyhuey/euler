module Problem31
// converted to F# from the code at http://www.geeksforgeeks.org/dynamic-programming-set-7-coin-change/

let rec count (S:_[]) m n =
    // If n is 0 then there is 1 solution (do not include any coin)
    if n = 0 then 1
    // If n is less than 0 then no solution exists
    elif n < 0 then 0
    // If there are no coins and n is greater than 0, then no solution exists
    elif m <= 0 && n >= 1 then 0
    // count is sum of solutions (i) including S[m-1] (ii) excluding S[m-1]
    else count S (m-1) n + count S m (n - S.[m-1])

let soln1 = 
    let S = [| 1; 2; 5; 10; 20; 50; 100; 200 |]
    let m = S.Length
    let n = 200
    count S m n
