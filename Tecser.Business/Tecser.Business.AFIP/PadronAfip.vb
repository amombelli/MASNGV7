

Public Class PadronAfip
    'TIPO DOCUMENTO (80: "CUIT", 96: "DNI", etc)
    Public Cuit As String
    Public Razonsocial As String            'Denominacion
    Public TipoPersona As String
    Public Tdoc As Integer
    Public Ndoc As String
    Public Dni As String
    Public Estado As String
    Public Direccion As String
    Public Localidad As String
    Public Provincia As String
    Public Zip As String
    Public Iva As String
    Public Monotributo As String
    Public Empleador As String
    Public Actividades As New Collection        'Coleccion de Actividades
    Public Impuestos As New Collection          'Coleccion de Impuestos
    Public Version As String
    Public Directorio As String
    Public HayDatos As Boolean
    Public ActividadMonotributo As String
    Public PadronExcepcion As String
    Public PadronResponse As String
    '
    '
    Public Sub CargaDatos(CUIT As String)
        Dim padron As Object
        Dim ok As Object
        padron = CreateObject("PadronAFIP")      ' Crear la interfaz COM

        Me.Directorio = padron.Version
        Me.Version = padron.Version
        ok = padron.conectar()
        ok = padron.consultar(CStr(CUIT))
        Me.HayDatos = ok
        Me.Razonsocial = padron.denominacion
        Me.Cuit = CUIT
        Me.Direccion = padron.Direccion
        Me.Localidad = padron.LOCALIDAD
        Me.Provincia = padron.PROVINCIA
        Me.Zip = padron.cod_postal
        Me.Estado = padron.Estado
        Me.Monotributo = padron.MONOTRIBUTO
        Me.Empleador = padron.EMPLEADOR
        Me.ActividadMonotributo = padron.ACTIVIDAD_MONOTRIBUTO
        Me.TipoPersona = padron.TIPO_PERSONA
        Me.Tdoc = padron.TIPO_DOC
        If IsDBNull(padron.DNI) = False Then
            Me.Dni = padron.DNI
        Else
            Me.Dni = "\"
        End If

        Dim i As Integer
        Dim actividad As Object
        For Each actividad In padron.Actividades
            Me.Actividades.Add(actividad)
        Next
        '
        i = 0
        For Each actividad In padron.Impuestos
            Me.Impuestos.Add(actividad)
        Next
        '
        Select Case padron.IMP_IVA
            Case "NI", "N"
                Me.Iva = "No Inscripto"
            Case "AC", "S"
                Me.Iva = "Responsable Inscripto"
            Case "EX"
                Me.Iva = "Exento"
            Case "NA"
                Me.Iva = "No Alcanzado"
            Case "NX"
                Me.Iva = "Exento No Alcanzado"
            Case "AN"
                Me.Iva = "Activo No Alcanzado"
            Case "NC"
                Me.Iva = "No Corresponde"
            Case Else
                Me.Iva = "Error!"
        End Select
        '
        If padron.Excepcion = "" Then
            Me.PadronExcepcion = "\"
            'MsgBox Padron.denominacion & " " & Padron.ESTADO & vbCrLf & Padron.DIRECCION & vbCrLf & Padron.LOCALIDAD & vbCrLf & Padron.PROVINCIA & vbCrLf & Padron.cod_postal, vbInformation, "Resultado CUIT " & CUIT & " (online AFIP)"
        Else
            ' respuesta del servidor (para depuración)
            Debug.Print(padron.RESPONSE())
            Me.PadronResponse = padron.RESPONSE
            'MsgBox "Error AFIP: " & Padron.Excepcion, vbCritical, "Resultado CUIT " & CUIT & " (online)"
        End If
    End Sub
End Class