namespace Caesar.F
open System

module ExtensionMethods =
    type System.Char with
        member x.ToRingElement: int = Convert.ToInt32(Char.ToLower(x)) - 97
    type System.Int32 with
        member x.ToCharInRing: char = Convert.ToChar(x + 97)

open ExtensionMethods

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

        let c1 = (frequency |> Seq.nth(0)).ToRingElement
        let c2 = (frequency |> Seq.nth(1)).ToRingElement

        let m1 = 'e'.ToRingElement
        let m2 = 'n'.ToRingElement

        let a = CaesarCipher.ring.Congruent(c1 - c2) * CaesarCipher.ring.Inverse(m1 - m2)
        let b = c1 - m1 * a

        CaesarCipher(CaesarCipher.ring.Congruent(a), CaesarCipher.ring.Congruent(b))  

    static member ring: ModuloArithmetic = new ModuloArithmetic(26)
    
    member this.Decrypt(c: string) = transformString(c, this.Decrypt)
    member this.Decrypt(c: char): char = this.Decrypt(c.ToRingElement).ToCharInRing
    member private this.Decrypt(c: int): int = CaesarCipher.ring.Congruent((c - this.B) * CaesarCipher.ring.Inverse(this.A))

    member this.Encrypt(m: char) = this.Encrypt(m.ToRingElement).ToCharInRing
    member this.Encrypt(m: string) = transformString(m, this.Encrypt)
    member private this.Encrypt(m: int): int = CaesarCipher.ring.Congruent(this.A * m + this.B)
