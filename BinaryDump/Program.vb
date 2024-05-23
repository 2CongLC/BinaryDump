Imports System
Imports System.Collections
Imports System.IO
Imports System.IO.Compression
Imports System.Runtime
Imports System.Runtime.Intrinsics
Imports System.Text
Imports System.Text.RegularExpressions


Module Program
    Public br As BinaryReader
    Public input As String
    Sub Main(args As String())
        If args.Count = 0 Then
            Console.WriteLine("Tool UnPack - 2CongLC.vn :: 2024")
        Else
            input = args(0)
        End If
        Dim p As String = Nothing
        If IO.File.Exists(input) Then
            br = New BinaryReader(File.OpenRead(input))
            Dim signature as String = Encoding.GetEncoding("us-ascii").GetString(br.ReadBytes(4))
            Console.WriteLine("signature {0},signature)
            Console.WriteLine()
	    Console.WriteLine("============== TRY GET HEADER INFO ===============")
	    Console.WriteLine()
	    Dim unknow1 as Int32 = br.ReadInt32
            Console.WriteLine("unknow1 : {0},unknow1)
            Dim unknow2 as Int32 = br.ReadInt32
            Console.WriteLine("unknow2 : {0},unknow2)
            Dim unknow3 as Int32 = br.ReadInt32
            Console.WriteLine("unknow3 : {0},unknow3)
            Dim unknow4 as Int32 = br.ReadInt32
            Console.WriteLine("unknow4 : {0},unknow4)
            Dim unknow5 as Int32 = br.ReadInt32
	    Console.WriteLine("unknow5 : {0},unknow5)
            Dim unknow6 as Int32 = br.ReadInt32
            Console.WriteLine("unknow6 : {0},unknow6)
            Dim unknow7 as Int32 = br.Readint32
            Console.WriteLine("unknow7 : {0},unknow7)
	    Dim unknow8 as Int32 = br.ReadInt32
            Console.WriteLine("unknow8 : {0},unknow8)
	    Dim unknow9 as Int32 = br.ReadInt32
            Console.WriteLine("unknow9 : {0},unknow9)
	    Dim unknow10 as Int32 = br.ReadInt32
            Console.WriteLine("unknow10 : {0},unknow10)
            Console.WriteLine()
	    Console.WriteLine("============ View Data as Hex Format ==========")
	    Console.WriteLine()
	    Console.WriteLine("hex-unknow1 : {0},IntToHex(unknow1))
	    Console.WriteLine("hex-unknow2 : {0},IntToHex(unknow2))
	    Console.WriteLine("hex-unknow3 : {0},IntToHex(unknow3))													
            Console.WriteLine("hex-unknow4 : {0},IntToHex(unknow4))
	    Console.WriteLine("hex-unknow5 : {0},IntToHex(unknow5))														
	    Console.WriteLine("hex-unknow6 : {0},IntToHex(unknow6))													
            Console.WriteLine("hex-unknow7 : {0},IntToHex(unknow7))
            Console.WriteLine("hex-unknow8 : {0},IntToHex(unknow8))
            Console.WriteLine("hex-unknow9 : {0},IntToHex(unknow9))
	    Console.WriteLine("hex-unknow10 : {0},IntToHex(unknow10))																		
            
        End If
        Console.ReadLine()
    End Sub




    Public Function IntToHex(ByVal val As Integer) As String
        Dim hexValue As String = val.ToString("X")
        If hexValue.Length > 2 Then
            If hexValue.Length.ToString().EndsWith("1") OrElse hexValue.Length.ToString().EndsWith("3") OrElse hexValue.Length.ToString().EndsWith("5") OrElse hexValue.Length.ToString().EndsWith("7") OrElse hexValue.Length.ToString().EndsWith("9") Then
                hexValue = "0" & hexValue
            End If
            Dim NHEX As String = ""
            For index As Integer = hexValue.Length To 1 Step -2
                NHEX &= hexValue.Substring(index - 2, 2) & " "
            Next
            NHEX = NHEX.Substring(0, NHEX.Length - 1)
            Select Case NHEX.Replace(" ", "").Length
                Case 2
                    Return NHEX & " 00 00 00"
                Case 4
                    Return NHEX & " 00 00"
                Case 6
                    Return NHEX & " 00"
                Case 8
                    Return NHEX
            End Select
            Return "null"
        Else
            If hexValue.Length = 1 Then
                Return "0" & hexValue & " 00 00 00"
            End If
            Return hexValue & " 00 00 00"
        End If
    End Function
																					
    Public Function HexToInt(ByVal hex As String) As Integer
        Dim num As Integer = Integer.Parse(hex, System.Globalization.NumberStyles.HexNumber)
        Return num
    End Function

    Public Function HexToString(ByVal hex As String) As String
        Dim hexValuesSplit() As String = hex.Split(" "c)
        Dim returnvar As String = ""
        For Each hexs As String In hexValuesSplit
            Dim value As Integer = Convert.ToInt32(hexs, 16)
            Dim charValue As Char = ChrW(value)
            returnvar &= charValue
        Next
        Return returnvar
    End Function
																				
    Public Function StringToHex(ByVal _in As String) As String
        Dim input As String = _in
        Dim values As Char() = input.ToCharArray()
        Dim r As String = ""
        For Each letter As Char In values
            Dim value As Integer = Convert.ToInt32(letter)
            Dim hexOutput As String = String.Format("{0:X}", value)
            If value > 255 Then
                Return UnicodeStringToHex(input)
            End If
            r += value & " "
        Next
        Dim bytes As String() = r.Split(" "c)
        Dim b As Byte() = New Byte(bytes.Length - 2) {}
        Dim index As Integer = 0
        For Each val As String In bytes
            If index = bytes.Length - 1 Then
                Exit For
            End If
            If Integer.Parse(val) > Byte.MaxValue Then
                b(index) = Byte.Parse("0")
            Else
                b(index) = Byte.Parse(val)
            End If
            index += 1
        Next
        r = ByteArrayToString(b)
        Return r.Replace("-", " ")
    End Function

    Public Function UnicodeStringToHex(ByVal _in As String) As String
        Dim input As String = _in
        Dim values As Char() = Encoding.Unicode.GetChars(Encoding.Unicode.GetBytes(input.ToCharArray()))
        Dim r As String = ""
        For Each letter As Char In values
            Dim value As Integer = Convert.ToInt32(letter)
            Dim hexOutput As String = String.Format("{0:X}", value)
            r += value & " "
        Next
        Dim unicode As New UnicodeEncoding()
        Dim b As Byte() = unicode.GetBytes(input)
        r = ByteArrayToString(b)
        Return r.Replace("-", " ")
    End Function

    Public Function StringToByteArray(ByVal hex As String) As Byte()
        Try
            Dim NumberChars As Integer = hex.Length
            Dim bytes As Byte() = New Byte(NumberChars \ 2 - 1) {}
            For i As Integer = 0 To NumberChars - 1 Step 2
                bytes(i \ 2) = Convert.ToByte(hex.Substring(i, 2), 16)
            Next
            Return bytes
        Catch
            Console.Write("Invalid format file!")
            Return New Byte(0) {}
        End Try
    End Function

    Public Function StringToByteArray(ByVal hex As String()) As Byte()
        Try
            Dim NumberChars As Integer = hex.Length
            Dim bytes As Byte() = New Byte(NumberChars - 1) {}
            For i As Integer = 0 To NumberChars - 1
                bytes(i) = Convert.ToByte(hex(i), 16)
            Next
            Return bytes
        Catch
            Console.Write("Invalid format file!")
            Return New Byte(0) {}
        End Try
    End Function

    Public Function ByteArrayToString(ByVal ba As Byte()) As String
        Dim hex As String = BitConverter.ToString(ba)
        Return hex
    End Function

    

    Public Function UnicodeHexToUnicodeString(ByVal hex As String) As String
        Dim hexString As String = hex.Replace(" ", "")
        Dim length As Integer = hexString.Length
        Dim bytes() As Byte = New Byte(length \ 2 - 1) {}

        For i As Integer = 0 To length - 1 Step 2
            bytes(i \ 2) = Convert.ToByte(hexString.Substring(i, 2), 16)
        Next

        Return Encoding.Unicode.GetString(bytes)
    End Function

End Module
