Public Class PadronArba
   

    Public Version As String
    Public InstallDir As String
    Public Modo As String
    Public NumComprobante As String
    Public CodigoHash As String
    Public Cuit As String
    Public AlPerc As Single
    Public AlRete As Single
    Public GrupoPerc As String
    Public GrupoRete As String


    'Retorna el valor de la percepcion/retencion en formato decimal (porcentaje dividido 100)
    Public Sub Conectar(CUIT As String, fechaDesdeYyyymm As String, fechaHastaYyyymm As String)
        Dim iibb As Object
        Dim ok As Object
        Dim url As String  'Path Produccion o Test
        Try
            iibb = CreateObject("IIBB")
            Me.Version = iibb.Version
            Me.InstallDir = iibb.InstallDir
            Me.Modo = "PROD" 'sino usar TEST

            'Establecer Datos de acceso (ARBA)
            iibb.USUARIO = "30709669091"        'USUARIO
            iibb.Password = "200812"            'CIT

            If Me.Modo = "PROD" Then
                url = "https://dfe.arba.gov.ar/DomicilioElectronico/SeguridadCliente/dfeServicioConsulta.do"
            Else
                url = "https://dfe.test.arba.gov.ar/DomicilioElectronico/SeguridadCliente/dfeServicioConsulta.do"
            End If

            ' Conectar al servidor
            ok = iibb.Conectar(url)

            ' Enviar el archivo y procesar la respuesta:
            ok = iibb.ConsultarContribuyentes(fechaDesdeYyyymm, fechaHastaYyyymm, CUIT)

            ' Hubo error interno?
            If iibb.Excepcion <> "" Then
                Debug.Print(iibb.Excepcion)
                Debug.Print(iibb.Traceback)
                MsgBox(iibb.Traceback, vbCritical, "Excepcion:" & iibb.Excepcion)
            Else
                'Debug.Print IIBB.XmlResponse
                'Debug.Print "Error General:", IIBB.TipoError, "|", IIBB.CODIGOERROR, "|", IIBB.mensajeError

                ' Hubo error general de ARBA?
                If iibb.CODIGOERROR <> "" Then
                    MsgBox(iibb.mensajeError, vbExclamation, "Error " & iibb.TipoError & ":" & iibb.CODIGOERROR)
                End If
                ' Datos generales de la respuesta:
                Me.NumComprobante = iibb.numeroComprobante
                Me.CodigoHash = CodigoHash
                ' Datos del contribuyente consultado:
                If iibb.CODIGOERROR = "11" Then
                    'La CUIT no esta en ninguna base
                    Me.AlPerc = 0.08       '8%
                    Me.AlRete = 0.04       '4%
                Else
                    If IsNothing(iibb.ALICUOTAPERCEPCION) = True Then
                        Me.AlPerc = 0.08
                    Else
                        Me.AlPerc = GetStringFormatoNumerico(iibb.AlicuotaPercepcion) / 100
                    End If
                    If IsNothing(iibb.AlicuotaRetencion) = True Then
                        Me.AlRete = 0.04
                    Else
                        Me.AlRete = GetStringFormatoNumerico(iibb.AlicuotaRetencion) / 100
                    End If
                    Me.GrupoPerc = iibb.grupoPercepcion
                    Me.GrupoRete = iibb.grupoRetencion
                End If
                Me.Cuit = iibb.CuitContribuyente
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub



    '---------------------------------------------------------------------------------------
    ' Fecha Creacion : 29/08/2015
    ' Proposito : Funcion usada mayoritariamente para las funciones string de AFIP
    ' Parametros:
    ' Retorna   :
    '---------------------------------------------------------------------------------------
    Public Function GetStringFormatoNumerico(numeroString As String) As Single
        Dim simv As String
        Dim simvA As String
        Simv = Mid(1 / 2, 2, 1)
        If InStr(1, NumeroString, ",", vbTextCompare) <= 1 Then
            SimvA = "."
        Else
            SimvA = ","
        End If
        If IsNothing(NumeroString) Or (NumeroString = "") Then
            GetStringFormatoNumerico = 0
        Else
            If InStr(1, NumeroString, Simv, vbTextCompare) > 1 Then
                GetStringFormatoNumerico = CSng(NumeroString)
            Else
                GetStringFormatoNumerico = CSng(Replace(NumeroString, SimvA, Simv))
            End If
        End If
    End Function



    'Public Function TEST_IIBB(CUIT As String)
    '    Dim x As New CPadronIIBB
    '    x.CargaDatos(CUIT, "20150701", "20150731")
    '    Debug.Print "PERCEPCION = " & x.AL_PERC
    '    Debug.Print "RETENCION = " & x.AL_RETE
    'End Function
End Class
