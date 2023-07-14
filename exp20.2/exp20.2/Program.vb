Module Exp_20_2
    Class Person
        Public Name As String
        Public City As String
        Sub New()
            Name = "Tanisha Harjani"
            City = "Thane"
        End Sub
        Overridable Sub Print()
            Console.WriteLine(Name)
            Console.WriteLine(City)
        End Sub
    End Class
    Class Employee
        Inherits Person
        Public Salary As Integer
        Sub New()
            Salary = 80000
        End Sub
        Overrides Sub Print()
            MyBase.Print()
            Console.WriteLine("Salary=" & Salary)
        End Sub
    End Class
    Sub Main()
        Dim e As New Employee
        e.Print()
        Console.Read()
    End Sub

End Module
