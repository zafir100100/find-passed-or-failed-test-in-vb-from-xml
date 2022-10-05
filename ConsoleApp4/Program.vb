Imports System.Xml


Module Program
    Sub Main(args As String())
        Dim doc As New XmlDocument()
        doc.Load("SampleTrxXMLTestLogFile.trx")

        Console.WriteLine("1. Passed")
        Console.WriteLine("2. Failed")
        Console.WriteLine()
        Console.WriteLine("Enter 1 or 2")

        Dim user_input As String = ""
        Dim Search As String = 0
        While (True)
            user_input = Console.ReadLine()
            If user_input = "1" Then
                Search = "Passed"
                Exit While
            ElseIf user_input = "2" Then
                Search = "NotExecuted"
                Exit While
            ElseIf user_input <> "1" AndAlso user_input <> "2" Then
                Console.WriteLine("Invalid Input!")
                Continue While
            End If
        End While

        Dim nodeList As XmlNodeList = doc.DocumentElement.ChildNodes
        For Each node As XmlNode In nodeList
            If node.Name = "Results" Then
                Dim intValue1 As Integer = 0
                For Each node2 As XmlNode In node.ChildNodes
                    If node2.Name = "UnitTestResult" AndAlso node2.Attributes("outcome").Value = Search Then
                        Console.WriteLine("ID : " + node2.Attributes("testId").Value + " ---- " + "Title : " + node2.Attributes("testName").Value)
                        Console.WriteLine()
                        Console.WriteLine()
                        intValue1 += 1
                    End If
                Next
                Console.WriteLine(Search + " : " + intValue1.ToString)
            End If
        Next
    End Sub
End Module