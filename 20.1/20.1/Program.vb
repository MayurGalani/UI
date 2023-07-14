Imports System

Module Exp_20_1
    Public Class Sample2
        Private x1 As Double
        Private y1 As Double
        Public Property X() As Double
            Get
                Return x1
            End Get
            Set(ByVal value As Double)
                x1 = value
            End Set
        End Property
        Public Property Y() As Double
            Get
                Return y1
            End Get
            Set(ByVal value As Double)
                y1 = value
            End Set
        End Property
        Public Sub SetValues(ByVal a As Double, ByVal b As Double)
            x1 = a
            y1 = b
        End Sub
        Public Sub SetValues(ByVal a As Double)
            x1 = a
            y1 = a
        End Sub
        Public Function GetProduct() As Double
            Return x1 * y1
        End Function
    End Class
    Class Test
        Public Shared Sub Main()
            Dim obj As New Sample2
            obj.X = 5
            obj.Y = 30
            Console.WriteLine("Product=" & obj.GetProduct())

            Dim obj2 As New Sample2
            obj2.SetValues(10, 20)
            Console.WriteLine("Product=" & obj2.GetProduct())
            Dim obj3 As New Sample2
            obj3.SetValues(10)
            Console.WriteLine("Product=" & obj3.GetProduct())
            Console.WriteLine("DESIGNED BY HARSH PURSWANI")
        End Sub
    End Class
End Module
