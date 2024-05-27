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
            Console.WriteLine("signature : {0}", signature)
            Console.WriteLine()
            Console.WriteLine("============== TRY GET HEADER INFO ===============")
            Console.WriteLine()
            Dim unknow1 As Int32 = br.ReadInt32
            Console.WriteLine("unknow1 : {0}",unknow1)
            Dim unknow2 as Int32 = br.ReadInt32
            Console.WriteLine("unknow2 : {0}",unknow2)
            Dim unknow3 as Int32 = br.ReadInt32
            Console.WriteLine("unknow3 : {0}",unknow3)
            Dim unknow4 as Int32 = br.ReadInt32
            Console.WriteLine("unknow4 : {0}",unknow4)
            Dim unknow5 as Int32 = br.ReadInt32
            Console.WriteLine("unknow5 : {0}", unknow5)
            Dim unknow6 as Int32 = br.ReadInt32
            Console.WriteLine("unknow6 : {0}",unknow6)
            Dim unknow7 as Int32 = br.ReadInt32
            Console.WriteLine("unknow7 : {0}",unknow7)
            Dim unknow8 As Int32 = br.ReadInt32
            Console.WriteLine("unknow8 : {0}",unknow8)
            Dim unknow9 As Int32 = br.ReadInt32
            Console.WriteLine("unknow9 : {0}",unknow9)
            Dim unknow10 As Int32 = br.ReadInt32
            Console.WriteLine("unknow10 : {0}",unknow10)
            Console.WriteLine()
            Console.WriteLine("============ View Data as Hex Format ==========")
            Console.WriteLine()
            Dim h1 As String = IntToHex(unknow1)
            Console.WriteLine("hex-unknow1 : {0}",h1)
            Dim h2 As String = IntToHex(unknow2)
            Console.WriteLine("hex-unknow2 : {0}",h2)
            Dim h3 As String = IntToHex(unknow3)
            Console.WriteLine("hex-unknow3 : {0}",h3)
            Dim h4 As String = IntToHex(unknow4)
            Console.WriteLine("hex-unknow4 : {0}",h4)
            Dim h5 As String = IntToHex(unknow5)
            Console.WriteLine("hex-unknow5 : {0}",h5)
            Dim h6 As String = IntToHex(unknow6)
            Console.WriteLine("hex-unknow6 : {0}",h6)
            Dim h7 As String = IntToHex(unknow7)
            Console.WriteLine("hex-unknow7 : {0}",h7)
            Dim h8 as String = 	IntToHex(unknow8)
            Console.WriteLine("hex-unknow8 : {0}", h8)
            Dim h9 as String = 	IntToHex(unknow9)																			
            Console.WriteLine("hex-unknow9 : {0}",h9)
            Dim h10 As String = IntToHex(unknow10)
            Console.WriteLine("hex-unknow10 : {0}", h10)
            Console.WriteLine()
            Console.WriteLine("============= View Data As String ==========")
            Console.WriteLine()																						
            Dim s1 as String = HexToString(h1)
            Console.WriteLine("text-unknow1 : {0}", s1)
            Dim s2 as String = HexToString(h2)
            Console.WriteLine("text-unknow2 : {0}", s2)
            Dim s3 as String = HexToString(h3)
            Console.WriteLine("text-unknow3 : {0}", s3)
            Dim s4 as String = HexToString(h4)
            Console.WriteLine("text-unknow4 : {0}", s4)
            Dim s5 as String = HexToString(h5)
            Console.WriteLine("text-unknow5 : {0}", s5)
            Dim s6 as String = HexToString(h6)
            Console.WriteLine("text-unknow6 : {0}", s6)
            Dim s7 as String = HexToString(h7)
            Console.WriteLine("text-unknow7 : {0}", s7)
            Dim s8 as String = HexToString(h8)
            Console.WriteLine("text-unknow8 : {0}", s8)
            Dim s9 as String = HexToString(h9)
            Console.WriteLine("text-unknow9 : {0}", s9)
            Dim s10 as String = HexToString(h10)
            Console.WriteLine("text-unknow10 : {0}", s10)

            Console.WriteLine()
            Console.WriteLine("============== Anyzing ..... ============")
            Console.WriteLine()

            Dim subfiles As New List(Of FileData)
            For i As Int32 = 0 To unknow1 - 1
                subfiles.Add(New FileData)
            Next


            p = Path.GetDirectoryName(input) & "\" & Path.GetFileNameWithoutExtension(input)
            Directory.CreateDirectory(p)
            For Each f As FileData In subfiles

                Console.WriteLine("data0 : {0} - data1 : {1} - data2 : {2} - data3 : {3} - data4 : {4} - data5 : {5}", f.data0, f.data1, f.data2, f.data3, f.data4, f.data5)



                ' br.BaseStream.Position = 
                Using bw As New BinaryWriter(File.Create(p & "//" & f.data0))
                    bw.Write(br.ReadBytes(f.data3))
                End Using

            Next

            Console.WriteLine()
            Console.WriteLine("============== DONE !!!!!!!! ============")
            Console.WriteLine()
			
	    End If
        Console.ReadLine()
    End Sub

    Class FileData
        Public data0 As Int32 = br.ReadInt32
        Public data1 As Int32 = br.ReadInt32
        Public data2 As Int32 = br.ReadInt32
        Public data3 As Int32 = br.ReadInt32
        Public data4 As Int32 = br.ReadInt32
        Public data5 As Int32 = br.ReadInt32
        Public data6 As Int32 = br.ReadInt32
        Public data7 As Int32 = br.ReadInt32
        Public data8 As Int32 = br.ReadInt32
        Public data9 As Int32 = br.ReadInt32
        Public Sub New()
            data0 = br.ReadUInt32
            data1 = br.ReadUInt32
            data2 = br.ReadUInt32
            data3 = br.ReadUInt32
            data4 = br.ReadUInt32
            data5 = br.ReadUInt32
            data6 = br.ReadUInt32
            data7 = br.ReadUInt32
            data8 = br.ReadUInt32
            data9 = br.ReadUInt32
        End Sub

    End Class
#Region "Tools"
    Function GetTypes() As String
        Dim magicBytes = br.ReadBytes(4)
        br.BaseStream.Position -= 4
        Dim magic = System.Text.Encoding.UTF8.GetString(magicBytes)
        Select Case magic
            Case ""
                Return ""
            Case ""
                Return ""
            Case Else
                Return magic
        End Select
    End Function


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

    Public Function GB2312ToUtf8(ByVal gb2312String As String) As String
        Dim fromEncoding As Encoding = Encoding.GetEncoding("gb2312")
        Dim toEncoding As Encoding = Encoding.UTF8
        Return EncodingConvert(gb2312String, fromEncoding, toEncoding)
    End Function

    Public Function Utf8ToGB2312(ByVal utf8String As String) As String
        Dim fromEncoding As Encoding = Encoding.UTF8
        Dim toEncoding As Encoding = Encoding.GetEncoding("gb2312")
        Return EncodingConvert(utf8String, fromEncoding, toEncoding)
    End Function

    Public Function EncodingConvert(ByVal fromString As String, ByVal fromEncoding As Encoding, ByVal toEncoding As Encoding) As String
        Dim fromBytes As Byte() = fromEncoding.GetBytes(fromString)
        Dim toBytes As Byte() = Encoding.Convert(fromEncoding, toEncoding, fromBytes)
        Dim toString As String = toEncoding.GetString(toBytes)
        Return toString
    End Function


#End Region


End Module
