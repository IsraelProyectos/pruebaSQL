Imports System.Data.SqlClient

Public Class Form1
    Public mD As modificarDatos = New modificarDatos()
    Dim nombre As String
    Dim apellido As String
    Dim dni As String
    Dim dpto As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Prueba222222DataSet.DatosPersonales' Puede moverla o quitarla según sea necesario.
        Me.DatosPersonalesTableAdapter.Fill(Me.Prueba222222DataSet.DatosPersonales)
        'TODO: esta línea de código carga datos en la tabla 'Prueba222222DataSet.DatosPersonales' Puede moverla o quitarla según sea necesario.
        cargarGrid()
    End Sub



    Private Sub cargarGrid()
        Me.DatosPersonalesTableAdapter.Fill(Me.Prueba222222DataSet.DatosPersonales)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mD.insertarDatos()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        mD.borrarDatos()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        mD.datos(DataGridView1.CurrentRow.Cells(0).Value,
                 DataGridView1.CurrentRow.Cells(1).Value,
                 DataGridView1.CurrentRow.Cells(2).Value,
                 DataGridView1.CurrentRow.Cells(3).Value,
                 DataGridView1.CurrentRow.Cells(4).Value)
        mD.ShowDialog()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
        TextBox2.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
        TextBox3.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString
        TextBox4.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
    End Sub
End Class
