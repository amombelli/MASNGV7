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

        IIBB = CreateObject("IIBB")
        Me.Version = IIBB.Version
        Me.InstallDir = IIBB.InstallDir
        Me.MODO = "PROD" 'sino usar TEST

        'Establecer Datos de acceso (ARBA)
        IIBB.USUARIO = "30709669091"        'USUARIO
        IIBB.Password = "200812"            'CIT

        If Me.MODO = "PROD" Then
            url = "https://dfe.arba.gov.ar/DomicilioElectronico/SeguridadCliente/dfeServicioConsulta.do"
        Else
            url = "https://dfe.test.arba.gov.ar/DomicilioElectronico/SeguridadCliente/dfeServicioConsulta.do"
        End If

        ' Conectar al servidor
        OK = IIBB.Conectar(url)

        ' Enviar el archivo y procesar la respuesta:
        OK = IIBB.ConsultarContribuyentes(FechaDesdeYYYYMM, FechaHastaYYYYMM, CUIT)

        ' Hubo error interno?
        If IIBB.Excepcion <> "" Then
            Debug.Print(IIBB.Excepcion)
            Debug.Print(IIBB.Traceback)
            MsgBox(IIBB.Traceback, vbCritical, "Excepcion:" & IIBB.Excepcion)
        Else
            'Debug.Print IIBB.XmlResponse
            'Debug.Print "Error General:", IIBB.TipoError, "|", IIBB.CODIGOERROR, "|", IIBB.mensajeError

            ' Hubo error general de ARBA?
            If IIBB.CODIGOERROR <> "" Then
                MsgBox(IIBB.mensajeError, vbExclamation, "Error " & IIBB.TipoError & ":" & IIBB.CODIGOERROR)
            End If
            ' Datos generales de la respuesta:
            Me.NumComprobante = IIBB.numeroComprobante
            Me.CodigoHash = CodigoHash
            ' Datos del contribuyente consultado:
            If IIBB.CODIGOERROR = "11" Then
                'La CUIT no esta en ninguna base
                Me.AlPerc = 0.08       '8%
                Me.AlRete = 0.04       '4%
            Else
                If IsNothing(IIBB.ALICUOTAPERCEPCION) = True Then
                    Me.AlPerc = 0.08
                Else
                    Me.AlPerc = GetStringFormatoNumerico(IIBB.AlicuotaPercepcion) / 100
                End If
                If IsNothing(IIBB.AlicuotaRetencion) = True Then
                    Me.AlRete = 0.04
                Else
                    Me.AlRete = GetStringFormatoNumerico(IIBB.AlicuotaRetencion) / 100
                End If
                Me.GrupoPerc = IIBB.grupoPercepcion
                Me.GrupoRete = IIBB.grupoRetencion
            End If
            Me.CUIT = IIBB.CuitContribuyente
        End If
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
