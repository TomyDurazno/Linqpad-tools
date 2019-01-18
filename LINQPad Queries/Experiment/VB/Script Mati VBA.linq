<Query Kind="VBProgram" />

Sub Main
	
End Sub

'Option Explicit

Sub Guardartxt()
    Dim RutaArchivo As String
    Dim obj As FileSystemObject
    Dim Arch_txt As Scripting.TextStream
    Dim HJ As Worksheet
    Dim i, j, nFilas As Integer
    Dim Respuesta As Integer
    
    Set HJ = Worksheets("Importar Ventas")
    
    Respuesta = MsgBox("Se generarán los archivos Ventas.txt y AlicuotasVentas.txt en " & _
                ActiveWorkbook.Path & ". Si los mismos existen, serán reemplazados. ¿Desea continuar?", vbYesNo, "Exceldiario.com.ar")
    
    If Respuesta = 7 Then Exit Sub
    
    For j = 3 To 6 Step 3
        Select Case j
            Case 3
                If HJ.Range("B2") <> 0 Then
                    nFilas = HJ.Range("B2").Value
                    RutaArchivo = ActiveWorkbook.Path & "\Ventas.txt"
                    Set obj = New FileSystemObject
                    Set Arch_txt = obj.CreateTextFile(RutaArchivo)
                    For i = 3 To nFilas + 2
                        Arch_txt.Write HJ.Cells(i, j)
                        Arch_txt.WriteLine
                    Next i
                    Arch_txt.Close
                End If
            Case 6
                If HJ.Range("E2") <> 0 Then
                    nFilas = HJ.Range("E2").Value
                    RutaArchivo = ActiveWorkbook.Path & "\AlicuotasVentas.txt"
                    Set obj = New FileSystemObject
                    Set Arch_txt = obj.CreateTextFile(RutaArchivo)
                    For i = 3 To nFilas + 2
                        Arch_txt.Write HJ.Cells(i, j)
                        Arch_txt.WriteLine
                    Next i
                    Arch_txt.Close
                End If
        End Select
    Next j
    
    Set obj = Nothing
    
    MsgBox "Archivos generados con éxito en " & ActiveWorkbook.Path, , "Exceldiario.blogspot.com.ar"
    

End Sub
