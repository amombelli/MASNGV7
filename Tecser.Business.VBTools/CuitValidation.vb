Public Class CuitValidation
    Public Function ValidarCuit(ByVal numeroCuit As String) As Boolean
        Dim mkSuma As Integer
        Dim mkValido As String
        numeroCuit = numeroCuit.Replace("-", "")
        If IsNumeric(numeroCuit) Then
            If numeroCuit.Length <> 11 Then
                mkValido = False
                Return (mkValido)
            Else
                mkSuma = 0
                mkSuma += CInt(numeroCuit.Substring(0, 1)) * 5
                mkSuma += CInt(numeroCuit.Substring(1, 1)) * 4
                mkSuma += CInt(numeroCuit.Substring(2, 1)) * 3
                mkSuma += CInt(numeroCuit.Substring(3, 1)) * 2
                mkSuma += CInt(numeroCuit.Substring(4, 1)) * 7
                mkSuma += CInt(numeroCuit.Substring(5, 1)) * 6
                mkSuma += CInt(numeroCuit.Substring(6, 1)) * 5
                mkSuma += CInt(numeroCuit.Substring(7, 1)) * 4
                mkSuma += CInt(numeroCuit.Substring(8, 1)) * 3
                mkSuma += CInt(numeroCuit.Substring(9, 1)) * 2
                mkSuma += CInt(numeroCuit.Substring(10, 1)) * 1
            End If

            If Math.Round(mkSuma / 11, 0) = (mkSuma / 11) Then
                mkValido = True
            Else
                mkValido = False
            End If
        Else
            mkValido = False
        End If
        Return (mkValido)

    End Function
End Class