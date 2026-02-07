module Problem3
// prime factors: 71, 839, 1471, 6857
// largest prime = 6857
    let soln1 =
        let mutable n = 600851475143L
        let mutable loopIterations = 0L
        let mutable i = 2L
        let mutable primeFactors = []
        //var sw = Stopwatch.StartNew();

        while n > 1L do
            loopIterations <- loopIterations + 1L
            if n % i = 0L then
                primeFactors <- i :: primeFactors
                n <- n / i;
                i <- 2L;
            else
                i <- i + 1L

        //sw.Stop();
        printfn "Loop iterations: %A" loopIterations  // 9234
        //Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
        printfn "prime factors: %A" primeFactors
        primeFactors |> List.max
