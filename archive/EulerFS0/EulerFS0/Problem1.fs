module Problem1

//03 Apr 2014 02:41 pm - raptorix  
// Console.WriteLine(Enumerable.Range(1, 1000).ToArray().Where(num => (num%3) == 0 || (num%5) == 0).Sum());
// should return 233,168
    let soln1 =
        [1..999] |> List.filter (fun n -> n%3 = 0 || n%5 = 0) |> List.sum

//let mutable sum = 0
//for i in [1..999] do
//    if i % 3 = 0 || i % 5 = 0 then sum <- sum + i
//printfn "The sum is %A." sum
