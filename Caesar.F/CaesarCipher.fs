namespace Caesar.F

type CaesarCipher(a: int, b: int) =
    member this.A = a
    member this.B = b
    new(cipherText: string) = CaesarCipher(1, 2)

    static member CharToRingElement(x: char): int = 0
    static member RingElementToChar(x: int): char = 'a'
    
    member this.Decrypt(c: string) = c
    member this.Decrypt(c: char) = c

    member this.Encrypt(m: char) = m
    member this.Encrypt(m: string) = m