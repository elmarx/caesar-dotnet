namespace Caesar.F

type ModuloArithmetic(modulo: int) = 
    static member Egcd(a: int, b: int) : int * int * int =
        if b = 0 then (a, 1, 0)
        else 
            let (d', s', t') = ModuloArithmetic.Egcd(b, a % b)
            (d', t', s' - (a / b) * t')
        
    member this.Congruent(v: int) =
        if v < 0 then this.Congruent(v + modulo);
        else v % modulo

    member this.Inverse(x: int) = 
        if x < 0 then this.Inverse(this.Congruent(x))
        else
            let (ggt, t, s) = ModuloArithmetic.Egcd(modulo, x)
            if ggt <> 1 then raise (System.ArgumentException("ggt != 1"))
            else s