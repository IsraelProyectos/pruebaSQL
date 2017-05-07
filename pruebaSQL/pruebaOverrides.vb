Public Class pruebaOverrides
    Inherits modificarDatos
    Protected Overrides Sub cargarGrid()
        Form1.DatosPersonalesTableAdapter.Fill(Form1.Prueba222222DataSet.DatosPersonales)
    End Sub
End Class
