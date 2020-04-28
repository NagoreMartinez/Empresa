Imports System
Imports System.IO

Module Program
    Async Function media(dias As Integer, salario As Double, contador As Integer) As Task(Of String)

        Dim md As Integer
        Dim ms As Double

        md = dias / contador
        ms = salario / contador

        Return $"El salario medio es {md} y los dias de vacaciones medios son {ms}"

    End Function

    Private Function LogIn(linea As empleado)

        Dim ruta As String = "C:\datos\documento.txt"

        If System.IO.File.Exists(ruta) = True Then
            Dim sw As StreamWriter = File.AppendText(ruta)

            sw.WriteLine(linea)
            sw.Close()

        Else
            Dim fs As FileStream = File.Create(ruta)
            Dim nsw As New System.IO.StreamWriter(ruta)

            nsw.Write(linea)
            nsw.Close()

        End If

    End Function

    Private Function calcularSalario(perfil As empleado) As String

        Dim sueldo As Double = 1500

        If perfil.edad < 18 Then
            Return "Edad insuficente para trabajar"

        Else
            If perfil.edad <= 50 Then
                Return (sueldo * 1.05).ToString
            Else
                If perfil.edad <= 60 Then
                    Return (sueldo * 1.1).ToString
                Else
                    Return (sueldo * 1.5).ToString
                End If
            End If
        End If

    End Function

    Private Function calcularVacaciones(perfil As empleado) As Integer

        If perfil.departamento = 1 Then
            If perfil.antiguedad >= 2 And perfil.antiguedad <= 6 Then
                Return 15
            Else
                If perfil.antiguedad >= 7 Then
                    Return 20
                End If
            End If
        ElseIf perfil.departamento = 2 Then
            If perfil.antiguedad >= 2 And perfil.antiguedad <= 6 Then
                Return 15
            Else
                If perfil.antiguedad >= 7 Then
                    Return 25
                End If
            End If

        ElseIf perfil.departamento = 3 Then
            If perfil.antiguedad >= 2 And perfil.antiguedad <= 6 Then
                Return 15
            Else
                If perfil.antiguedad >= 7 Then
                    Return 30
                End If
            End If
        End If

    End Function


    Private Structure empleado
        Public nombre As String
        Public id As Integer
        Public edad As Integer
        Public departamento As Integer
        Public antiguedad As Integer
        End Structure

    Private Structure usuario
        Public id As Integer
        Public contraseña As String
    End Structure

    Sub Main(args As String())

        Dim id As Integer
        Dim contraseña As String
        Dim emp As empleado
        Dim us As usuario
        Dim registrado As Boolean = False
        Dim x As Integer
        Dim listaEmpleados = New List(Of empleado)
        Dim listaUsuarios = New List(Of usuario)
        id = 1

        While id <> 0
            registrado = False
            x = 0
            Console.WriteLine("Inicio de sesion:")
                Console.WriteLine("Introduzca su id")
                id = Console.ReadLine
                Console.WriteLine("Introduzca su contraseña")
                contraseña = Console.ReadLine

            For i As Integer = 0 To listaUsuarios.Count - 1 Step 1
                us = listaUsuarios.ElementAt(i)
                If us.id = id And us.contraseña = contraseña Then
                    registrado = True
                    Exit For
                Else
                    registrado = False
                End If

            Next

            If registrado = False And id <> 0 Then
                Console.WriteLine("El usuario no existe o la contraseña es incorrecta. ¿Desea registrar el usuario?")
                If Console.ReadLine = "si" Then
                    Console.WriteLine("Iniciando registro")
                    Console.WriteLine("Introduzca el nombre:")
                    emp.nombre = Console.ReadLine
                    Console.WriteLine("Indique el ID:")
                    emp.id = Console.ReadLine
                    us.id = emp.id
                    Console.WriteLine("Indique la edad:")
                    emp.edad = Console.ReadLine
                    Console.WriteLine("Indique el número de departamento (1, 2 o 3):")
                    emp.departamento = Console.ReadLine
                    Console.WriteLine("Indique su tiempo de antigüedad:")
                    emp.antiguedad = Console.ReadLine
                    Console.WriteLine("Introduzca la contraseña:")
                    us.contraseña = Console.ReadLine
                    listaEmpleados.Add(emp)
                    listaUsuarios.Add(us)

                Else
                    Console.WriteLine("Error. Vuelva a intentarlo.")
                End If

                Else

                    For i As Integer = 0 To listaEmpleados.Count - 1 Step 1
                        If id = listaEmpleados.ElementAt(i).id Then
                        Dim a As String = $"{listaEmpleados.ElementAt(i).nombre}, {listaEmpleados.ElementAt(i).edad}, {listaEmpleados.ElementAt(i).antiguedad}, {calcularVacaciones(listaEmpleados.ElementAt(i))}, {calcularSalario(listaEmpleados.ElementAt(i))}"
                        Console.WriteLine(a)
                        LogIn(a)
                    End If
                    Next
                End If

            End While

        Dim totalVacaciones As Integer = 0
        Dim contador As Integer
        Dim totalSalario As Double = 0

        For i As Integer = 0 To listaEmpleados.Count - 1 Step 1
            totalVacaciones += calcularVacaciones(listaEmpleados.ElementAt(i))
            totalSalario += Double.Parse(calcularSalario(listaEmpleados.ElementAt(i)))
            contador = i
            Next
        End Sub
    End Module

