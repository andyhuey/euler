module Problem2
// from my own soln4()
//  E(n)=4*E(n-1)+E(n-2).
// Answer: 4,613,732
    let soln1 =
        let max = 4000000
        let mutable efib1=2
        let mutable efib2=8
        //let mutable efib3=0
        let mutable sum = efib1 + efib2
        //var sw = Stopwatch.StartNew();
        let mutable efib3 = 4 * efib2 + efib1
        while efib3 < max do
            sum <- sum + efib3
            efib1 <- efib2
            efib2 <- efib3
            efib3 <- 4 * efib2 + efib1
            //printfn "%A" efib3
        //sw.Stop();
        //Console.WriteLine("elapsed = {0} secs", sw.Elapsed.TotalSeconds);
        sum
        