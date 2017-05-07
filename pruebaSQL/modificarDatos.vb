Imports System.Data.SqlClient


Public Class modificarDatos
    Public idModificar As Integer
    Private Sub modificarDatos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
    End Sub

    Public Sub borrarDatos()
        Using cn As New SqlConnection("Data Source=Israel-8;Initial Catalog=Prueba222222;Integrated Security=True"),
             command As New SqlCommand("pruebaBorrar", cn)

            command.CommandType = CommandType.StoredProcedure
            Dim id As Integer = Form1.DataGridView1.CurrentRow.Cells(0).Value
            command.Parameters.AddWithValue("@id", id)


            Try
                cn.Open()
                command.ExecuteNonQuery()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                cargarGrid()
                cn.Dispose()
                command.Dispose()

                MsgBox("Usuario borrado correctamente", vbInformation, "Sistema")


            End Try

        End Using
    End Sub

    //hola

    Public Sub insertarDatos()
        Using cn As New SqlConnection("Data Source=Israel-8;Initial Catalog=Prueba222222;Integrated Security=True"),
          command As New SqlCommand("pruebaInsertar", cn)
            With command
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@nombre", Form1.TextBox1.Text)
                .Parameters.AddWithValue("@apellido", Form1.TextBox2.Text)
                .Parameters.AddWithValue("@dni", Form1.TextBox3.Text)
                .Parameters.AddWithValue("@dpto", Form1.TextBox4.Text)
            End With
            Try
                cn.Open()
                command.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally

                cn.Dispose()
                command.Dispose()
                cargarGrid()
                MsgBox("Usuario Registrado Correctamente", vbInformation, "Sistema")
                Form1.TextBox1.Text = ""
                Form1.TextBox2.Text = ""
                Form1.TextBox3.Text = ""
                Form1.TextBox4.Text = ""

            End Try
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using cn As New SqlConnection("Data Source=Israel-8;Initial Catalog=Prueba222222;Integrated Security=True"),
           command As New SqlCommand("pruebaModificar", cn)
            With command
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@id", idModificar)
                .Parameters.AddWithValue("@nombre", nombre1.Text)
                .Parameters.AddWithValue("@apellido", TextBox2.Text)
                .Parameters.AddWithValue("@dni", TextBox3.Text)
                .Parameters.AddWithValue("@dpto", TextBox1.Text)
            End With
            Try
                cn.Open()
                command.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally

                cn.Dispose()
                cargarGrid()
                command.Dispose()
                MsgBox("Usuario modificado correctamente", vbInformation, "Sistema")
                nombre1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                Me.Close()

            End Try
        End Using
    End Sub

    Public Sub datos(id As Integer, nombre As String, apellido As String, dni As String, dpto As Integer)
        idModificar = id
        nombre1.Text = nombre
        TextBox2.Text = apellido
        TextBox3.Text = dni
        TextBox1.Text = dpto
    End Sub


    Protected Overridable Sub cargarGrid()
        Form1.DatosPersonalesTableAdapter.Fill(Form1.Prueba222222DataSet.DatosPersonales)
    End Sub

End Class