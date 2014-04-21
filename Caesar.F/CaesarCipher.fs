namespace Caesar.F
open System

type CaesarCipher(a: int, b: int) =
    let transformString (s: string, f: char -> char) 
        = String(
            s.ToCharArray()
            |> Seq.map(f)
            |> Seq.toArray
            )

    member this.A = a
    member this.B = b

    new(cipherText: string) = 
        let frequency =
            cipherText.ToCharArray()
            |> Seq.groupBy(fun c -> c)
            |> Seq.sortBy(fun (key, s) -> -Seq.length(s) - 1)
            |> Seq.map(fun (key, s) -> key)

        let c1 = CaesarCipher.CharToRingElement(frequency |> Seq.nth(0))
        let c2 = CaesarCipher.CharToRingElement(frequency |> Seq.nth(1))

        let m1 = CaesarCipher.CharToRingElement('e')
        let m2 = CaesarCipher.CharToRingElement('n')

        let a = CaesarCipher.ring.Congruent(c1 - c2) * CaesarCipher.ring.Inverse(m1 - m2)
        let b = c1 - m1 * a

        CaesarCipher(CaesarCipher.ring.Congruent(a), CaesarCipher.ring.Congruent(b))  

    static member ring: ModuloArithmetic = new ModuloArithmetic(26)

    static member CharToRingElement(x: char): int = Convert.ToInt32(Char.ToLower(x)) - 97
    static member RingElementToChar(x: int): char = Convert.ToChar(x + 97)
    
    member this.Decrypt(c: string) = transformString(c, this.Decrypt)
    member this.Decrypt(c: char) = CaesarCipher.RingElementToChar(this.Decrypt(CaesarCipher.CharToRingElement(c)))
    member private this.Decrypt(c: int) = CaesarCipher.ring.Congruent((c - this.B) * CaesarCipher.ring.Inverse(this.A))

    member this.Encrypt(m: char) = CaesarCipher.RingElementToChar(this.Encrypt(CaesarCipher.CharToRingElement(m)))
    member this.Encrypt(m: string) = transformString(m, this.Encrypt)
    member private this.Encrypt(m: int) = CaesarCipher.ring.Congruent(this.A * m + this.B)
