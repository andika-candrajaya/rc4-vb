Module Module1



    Sub Main()
        Console.WriteLine("Input your plaintext: ")
        Dim plaintext = Console.ReadLine()

        Console.WriteLine("Input your key: ")
        Dim keytext = Console.ReadLine()

        'input key and plaintext
        Dim plain As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(plaintext)
        Dim key As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(keytext)

        'permutasi
        Dim sbox As Integer() = New Integer(255) {}
        Dim kunci As Integer() = New Integer(255) {}

        'aux var
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim keylen As Integer = keytext.Length



        'bikin kunci dan sub box
        Dim a As Integer = 0
        While a <= 255
            Dim ctmp As Char = keytext.Substring((a Mod keylen), 1).ToCharArray()(0)
            kunci(a) = Asc(ctmp)
            sbox(a) = a
            a = a + 1

        End While
        Console.WriteLine(String.Join(", ", kunci))

        'acak sbox
        Dim x As Integer = 0
        Dim b As Integer = 0
        While b <= 255
            x = (x + sbox(b) + kunci(b)) Mod 256
            Dim tempswap As Integer = sbox(b)
            sbox(b) = sbox(x)
            sbox(x) = tempswap
            b = b + 1
        End While
        Console.WriteLine(String.Join(", ", sbox))

        'mulai enkripsi
        a = 0 'pulangin dulu harga a ke nol
        Dim cipher As Integer() = New Integer(plaintext.Length) {}
        While a < plaintext.Length
            i = (i + 1) Mod 256
            j = (j + sbox(i)) Mod 256
            Dim itmp As Integer = sbox(i)
            sbox(i) = sbox(j)
            sbox(j) = itmp

            Dim k As Integer = sbox((sbox(i) + sbox(j)) Mod 256)
            Dim ctmp As Char = plaintext.Substring(a, 1).ToCharArray()(0)
            itmp = Asc(ctmp)

            cipher(a) = itmp Xor k

            a = a + 1
        End While
        Console.WriteLine(String.Join(", ", cipher))

        Console.ReadKey()
        'Console.ReadKey()

    End Sub

End Module
