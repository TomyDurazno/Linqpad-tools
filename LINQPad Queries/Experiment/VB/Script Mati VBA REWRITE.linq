<Query Kind="VBProgram" />

Sub Main

End Sub


Sub Guardartxt()
    Dim Arch_txt As Scripting.TextStream
	Dim obj As FileSystemObject
    Dim HJ As Worksheet
    Dim i, j, nFilas As Integer
    Dim Respuesta As Integer
    
    HJ = Worksheets("Importar Ventas")
    
    Respuesta = MsgBox("Se generarán los archivos Ventas.txt y AlicuotasVentas.txt en " & _
                ActiveWorkbook.Path & ". Si los mismos existen, serán reemplazados. ¿Desea continuar?", vbYesNo, "Exceldiario.com.ar")
    
    If Respuesta = 7 Then Exit Sub
    
    For j = 3 To 6 Step 3
			Dim celda = If(j = 3,"B2", "E2")
			Dim path = If(j= 3,"\Ventas.txt", "\AlicuotasVentas.txt")
                If HJ.Range(celda) <> 0 Then
                    nFilas = HJ.Range(celda).Value
                    Arch_txt = New FileSystemObject().CreateTextFile(ActiveWorkbook.Path & path)
                    For i = 3 To nFilas + 2
                        Arch_txt.Write(HJ.Cells(i, j)) 
                        Arch_txt.WriteLine()
                    Next i
                    Arch_txt.Close()
                End If
    Next j
    
    obj = Nothing
    
    MsgBox("Archivos generados con éxito en " & ActiveWorkbook.Path, , "Exceldiario.blogspot.com.ar")
    

End Sub

' Define other methods and classes here