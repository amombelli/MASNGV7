using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO
{
    public class ContabilizacionFacturaProveedor
    {

        private int AltaDocumentoT403Header(T0403_VENDOR_FACT_H d403)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (d403.IDINT > 0)
                {
                    var data = db.T0403_VENDOR_FACT_H.SingleOrDefault(c => c.IDINT == d403.IDINT);
                    if (data != null)
                    {
                        return 0; //El registro ya existe
                    }
                }
                else
                {
                    d403.IDINT = GetNextId403();
                    d403.LOGUSER = Environment.UserName;
                    d403.LOGDATE = DateTime.Now;
                }

                db.T0403_VENDOR_FACT_H.Add(d403);
                if (db.SaveChanges() > 0)
                    return d403.IDINT;
                return 0;
            }
        }
        private void ManageItems404(int numeroAsiento, int idFacturaT0403)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0063_ITEMS_OC_INGRESADOS.Where(c => c.NASIENTO == numeroAsiento).ToList();
                if (data.Count == 0)
                {
                    //no hay elementos para agregar
                    return;
                }

                var dataHeader = db.T0403_VENDOR_FACT_H.SingleOrDefault(c => c.IDINT == idFacturaT0403);
                if (dataHeader == null)
                {
                    //no se creo por algun error el header!
                    return;
                }

                foreach (var item in data)
                {
                    var it = new T0404_VENDOR_FACT_I();
                    it.IDINT = idFacturaT0403;
                    //it.IDIT = se genera al grabar
                    it.ITEM_DESC = item.IDMATERIAL;
                    it.TC = item.TC;
                    it.PUNIT_ARS = item.CONTA_U_ARS;
                    it.PUNIT_USD = item.CONTA_U_USD;
                    it.CANT = item.CONTA_CANT;
                    it.PTOTAL_ARS = it.PUNIT_ARS * it.CANT;
                    it.PTOTAL_USD = it.PUNIT_USD * it.CANT;
                    it.MONEDA = dataHeader.MON;
                    if (dataHeader.MON == "ARS")
                    {
                        it.PUNIT = item.CONTA_U_ARS;
                    }
                    else
                    {
                        it.PUNIT = item.CONTA_U_USD;
                    }
                    it.GL = item.GL;
                    //todo estos campos los voy a remover
                    //it.BRUTO = item.CONTA_U_ARS
                    //it.DTO =
                    //it.SUBTOTAL =
                    //it.IVA10 =
                    //it.IVA21 =
                    //it.RETIVA =
                    //it.RETIIBB =
                    //it.IMPINT =
                    //it.IMPOTR =
                    //it.NETO =
                    AltaItemFacturaProveedor(it);
                }

            }
        }
        private int AltaItemFacturaProveedor(T0404_VENDOR_FACT_I item)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (item.IDIT > 0)
                {
                    var x = db.T0404_VENDOR_FACT_I.SingleOrDefault(c => c.IDINT == item.IDINT && c.IDIT == item.IDIT);
                    if (x != null)
                    {
                        return 0; //El registro ya existe;
                    }
                }
                else
                {
                    int numItem = db.T0404_VENDOR_FACT_I.Count(c => c.IDINT == item.IDINT);
                    item.IDIT = numItem + 1;
                }

                db.T0404_VENDOR_FACT_I.Add(item);
                if (db.SaveChanges() > 0)
                    return item.IDIT;
                return 0;
            }
        }
        private int GetNextId403()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0403_VENDOR_FACT_H.Max(c => c.IDINT) + 1;
            }
        }

        public List<string> GetRemitosPendientesContabilizacionByVendor(int idProveedor)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data =
                    db.T0063_ITEMS_OC_INGRESADOS.Where(c => c.PROVEEDOR == idProveedor && c.CONTA.Value != true)
                        .Select(c => c.NREMITO)
                        .Distinct()
                        .ToList();

                return data;
            }
        }
        public List<T0063_ITEMS_OC_INGRESADOS> GetListItemsPendientesContabilizacionByNumeroRemito(string numeroRemito, int idProveedor)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data =
                    db.T0063_ITEMS_OC_INGRESADOS.Where(
                        c => c.PROVEEDOR == idProveedor && c.NREMITO == numeroRemito && c.CONTA.Value != true).ToList();

                return data;
            }
        }

    }
}


//    Option Compare Database

//'-------------------------------------------------------------------
//'Completa Facturas T0403 - T0404
//'-------------------------------------------------------------------
//Public Function FACTPROVEEDOR() As Double
//Dim db As DAO.Database
//Dim rs As DAO.Recordset
//Dim RH As DAO.Recordset
//Dim RI As DAO.Recordset
//Dim ZCANT As Double
//Dim XVAL As Double
//Dim ZFACTOR As Double
//Dim a2 As Integer
//'
//Set db = CurrentDb
//Set rs = db.OpenRecordset("Select * from T0063_ITEMS_OC_INGRESADOS where PROVEEDOR=" & CInt(Me.CPROVEEDOR) & " AND NFACTURA='" & Me.NFACTURA & "' AND ZINCLUIR= TRUE")
//Set RH = db.OpenRecordset("SELECT * FROM T0403_VENDOR_FACT_H WHERE IDINT=-1")
//Set RI = db.OpenRecordset("SELECT * FROM T0404_VENDOR_FACT_I WHERE IDINT=-1")
//'
//ZCANT = 0
//While Not rs.EOF
//    ZCANT = ZCANT + rs!CONTA_CANT
//    rs.MoveNext
//Wend

//IZ = DMax("IDINT", "T0403_VENDOR_FACT_H")
//If IsNull(IZ) Then
//    IZ = 1
//Else
//    IZ = IZ + 1
//End If

//RH.AddNew
//RH!IDINT = IZ
//RH!IDPROV = Me.CPROVEEDOR
//RH!PROVRS = Me.CPROVEEDOR.Column(1)
//RH!PRTAX1 = Me.TCUIT
//RH!Fecha = Me.TFECHA
//RH!MON = Me.CMON
//RH!TFACTURA = Me.CTIPO
//RH!NFACTURA = Me.NFACTURA
//RH!IMPORI = Me.TNETO
//RH!TC = Me.TTC
//RH!TIPO = Me.TTIPO
//RH!BRUTO = Me.TBRUTO
//RH!DTO = Me.TDTO
//RH!SUBTOTAL = Me.TSUBTOTAL
//RH!IVA10 = Me.TIVA10
//RH!IVA21 = Me.TIVA21
//RH!RETIVA = Me.TRETIVA
//RH!RETIIBB = Me.TRETIIBB
//RH!IMPINT = Me.TIMPINT
//RH!IMPOTR = Me.TIMPOTROS
//RH!NETO = Me.TNETO
//RH!LOGUSER = Environ("USERNAME")
//RH!LogDate = Date
//'RH!NASIENTO=
//RH!TCODE = "CONTA1"
//'RH!IDCTACTE=
//RH!GLAP = Me.TGL
//RH!CANTKG = ZCANT
//RH.Update
//Set RH = db.OpenRecordset("SELECT * FROM T0403_VENDOR_FACT_H WHERE IDINT=" & IZ)



//rs.MoveFirst
//XVAL = Me.TBRUTO - Me.TDTO

//a2 = 1
//While Not rs.EOF
//    If XVAL = 0 Then
//        ZFACTOR = 1
//    Else
//        ZFACTOR = rs!CONTA_TOTAL / XVAL
//    End If
//    RI.AddNew
//    'RI!ID=
//    RI!IDINT = IZ
//    RI!IDIT = a2
//    RI!ITEM_DESC = rs!IDMATERIAL
//    RI!TC = RH!TC
//    RI!BRUTO = Round(rs!CONTA_TOTAL, 2)
//    RI!DTO = Round(Me.TDTO * ZFACTOR, 2)
//    RI!SUBTOTAL = Round(Me.TSUBTOTAL * ZFACTOR, 2)
//    RI!IVA10 = Round(Me.TIVA10 * ZFACTOR, 2)
//    RI!IVA21 = Round(Me.TIVA21 * Round(ZFACTOR, 2), 2)
//    RI!RETIVA = Round(Me.TRETIVA * ZFACTOR, 2)
//    RI!RETIIBB = Round(Me.TRETIIBB * ZFACTOR, 2)
//    RI!IMPINT = Round(Me.TIMPINT * ZFACTOR, 2)
//    RI!IMPOTR = Round(Me.TIMPOTROS * ZFACTOR, 2)
//    RI!NETO = Round(Me.TNETO * ZFACTOR, 2)
//    RI!GL = rs!GL
//    RI!Cant = rs!CONTA_CANT
//    RI.Update
//    a2 = a2 + 1
//    rs.MoveNext
//Wend
//FACTPROVEEDOR = IZ
//End Function




//Private Sub CADDREMITO_Click()
//Dim a As Integer
//a = DCount("CANTIDAD", "T0063_ITEMS_OC_INGRESADOS", "PROVEEDOR=" & Me.CPROVEEDOR & " AND NFACTURA='" & Me.NFACTURA & "' AND CONTA=False")
//If a = 0 Then
//    MsgBox "No Se puede agregar otro Remito, porque no se ha agregado ningún Remito.", vbCritical
//    Exit Sub
//End If

//If a > 0 Then
//    If(MsgBox("Esta seguro que desea agregar otro Remito relacionado con la misma factura?", vbYesNo) = vbYes) Then
//       Me.CREMITO = Null
//       Me.TREMITO = Null

//       Me.TXREMITO = Null

//       Me.CREMITO.Locked = False

//       Me.TREMITO.Locked = False


//       MsgBox "Coloque el proximo Numero de Remito perteneciente a esta factura", vbInformation

//        'Indica que estoy en modo de MULTIPLES REMITOS

//       Me.CK_MULTIPLE_REMITO = True

//       Me.CK_NO_OC.Locked = False


//       If Me.CK_NO_OC = True Then
//           Me.TREMITO.VISIBLE = True

//           Me.TREMITO.SetFocus
//           Me.CREMITO.VISIBLE = False

//       Else
//           Me.CREMITO.VISIBLE = True

//           Me.CREMITO.SetFocus
//           Me.TREMITO.VISIBLE = False

//       End If

//   End If
//End If
//End Sub



//Private Sub CK_NO_OC_AfterUpdate()

//If Me.CK_MULTIPLE_REMITO = True Then
//    'Estoy modificando el CK de Sin Orden de Compra pero es al menos el segundo remito de la misma Factura
//    If Me.CK_NO_OC = True Then
//        Me.CREMITO.VISIBLE = False
//        Me.TREMITO.VISIBLE = True
//    Else
//        Me.CREMITO.VISIBLE = True
//        Me.TREMITO.VISIBLE = False
//    End If
//Else
//    'Es el primer remito de la factura
//    Me.SFITEMS.VISIBLE = False
//    Me.SFSINOC.VISIBLE = False
//    Me.CPROVEEDOR.Locked = False
//    Me.CREMITO.Locked = False
//    Me.TREMITO.Locked = False
//    Me.TXREMITO = ""
//    Me.TREMITO = ""
//    Me.CREMITO = ""
//    Me.NFACTURA = ""
//    Me.NFACTURA.Locked = False
//    Me.CADDITEMS.Enabled = False
//    If Me.CK_NO_OC = True Then
//        'La factura es sin orden de compra
//        Me.CPROVEEDOR = Null
//        Me.CPROVEEDOR.RowSource = "SELECT T0005_MPROVEEDORES.id_prov, T0005_MPROVEEDORES.prov_fantasia, T0005_MPROVEEDORES.prov_rsocial FROM T0005_MPROVEEDORES;"
//        Me.CREMITO.RowSource = ""
//        Me.CREMITO.VISIBLE = False
//        Me.TREMITO.VISIBLE = True
//        Me.TXREMITO = Me.TREMITO
//    Else
//        'La factura es con orden de compra
//        Me.CPROVEEDOR = Null
//        Me.CREMITO.VISIBLE = True
//        Me.TREMITO.VISIBLE = False
//        Me.CPROVEEDOR.RowSource = "SELECT DISTINCT T0005_MPROVEEDORES.id_prov, T0005_MPROVEEDORES.prov_fantasia, T0005_MPROVEEDORES.prov_rsocial, T0063_ITEMS_OC_INGRESADOS.CONTA, T0063_ITEMS_OC_INGRESADOS.ADDED FROM T0005_MPROVEEDORES INNER JOIN T0063_ITEMS_OC_INGRESADOS ON T0005_MPROVEEDORES.id_prov = T0063_ITEMS_OC_INGRESADOS.PROVEEDOR WHERE (((T0063_ITEMS_OC_INGRESADOS.CONTA)=False) AND ((T0063_ITEMS_OC_INGRESADOS.ADDED)=False));"
//        If IsNull(Me.CPROVEEDOR) Then
//            Me.CREMITO.RowSource = "SELECT DISTINCT T0063_ITEMS_OC_INGRESADOS.NREMITO, T0063_ITEMS_OC_INGRESADOS.PRAZONSOCIAL FROM T0063_ITEMS_OC_INGRESADOS WHERE (((T0063_ITEMS_OC_INGRESADOS.CONTA)=False));"
//        Else
//            Me.CREMITO.RowSource = "SELECT DISTINCT T0063_ITEMS_OC_INGRESADOS.NREMITO, T0063_ITEMS_OC_INGRESADOS.PRAZONSOCIAL FROM T0063_ITEMS_OC_INGRESADOS WHERE (((T0063_ITEMS_OC_INGRESADOS.CONTA)=False) AND ((T0063_ITEMS_OC_INGRESADOS.PROVEEDOR)='" & CPROVEEDOR & "'));"
//        End If
//        Me.TXREMITO = Me.CREMITO
//    End If
//End If
//End Sub

//'Funcion que automaticamente agrega una nota de pedido por el proceso de Fason
//Public Function ADD_NP1(cli As Double, MATERIAL As String, KG As Double, TipoLX As String, PRECIO1 As Double, Precio2 As Double, TXTNP1 As String) As Double

//End Function


//'Funcion que automaticamente agrega un PF automaticamente por el proceso de Fason
//Public Function ADD_PF1(cli As Double, MATERIAL As String, KG As Double, TXTOF As String) As Long


//End Function



//Private Sub CKFASON_AfterUpdate()
//If Me.CKFASON = True Then


//Else


//End If
//End Sub

//'Despues de actualizar el combo de proveedor
//Private Sub CPROVEEDOR_AfterUpdate()
//If IsNull(Me.CPROVEEDOR) = False Then
//    Me.TCUIT = DLookup("ntax1", "T0005_MPROVEEDORES", "id_prov=" & Me.CPROVEEDOR)
//    Me.CREMITO.RowSource = "SELECT DISTINCT T0063_ITEMS_OC_INGRESADOS.NREMITO, T0063_ITEMS_OC_INGRESADOS.ID FROM T0005_MPROVEEDORES INNER JOIN T0063_ITEMS_OC_INGRESADOS ON T0005_MPROVEEDORES.id_prov = T0063_ITEMS_OC_INGRESADOS.PROVEEDOR WHERE (((T0005_MPROVEEDORES.id_prov)=" & CPROVEEDOR & ") AND ((T0063_ITEMS_OC_INGRESADOS.CONTA)=False) AND ((T0063_ITEMS_OC_INGRESADOS.ADDED)=False));"
//    If IsNull(DLookup("GL", "T0005_MPROVEEDORES", "id_prov=" & Me.CPROVEEDOR)) = True Then
//        xTipo = DLookup("TIPO", "T0005_MPROVEEDORES", "id_prov=" & Me.CPROVEEDOR)
//        Me.TGL = DLookup("GL", "T0014_TIPO_PROVEEDOR", "TIPOPROV='" & xTipo & "'")
//    Else
//        Me.TGL = DLookup("GL", "T0005_MPROVEEDORES", "id_prov=" & Me.CPROVEEDOR)
//    End If
//End If
//Me.CREMITO = Null
//End Sub

//'---------------------------------------------------------------------------------------------
//'Boton de MainDocumentBase Factura
//'
//'
//'---------------------------------------------------------------------------------------------
//Private Sub CRECALCULAR_Click()
//Dim ZDOC As Double          ' #Numero de Asiento
//Dim db As DAO.Database      '
//Dim rs As DAO.Recordset     '
//Dim RB As DAO.Recordset     '
//Dim XCONTA As Currency      '

//Dim CC_Completo As Boolean  '


//If IsNull(DMax("IDDOCU", "T0601_DOCU_H")) = True Then
//    ZDOC = 1
//Else
//    ZDOC = DMax("IDDOCU", "T0601_DOCU_H") + 1
//End If

//If MsgBox("Desea MainDocumentBase Factura?", vbYesNo) = vbNo Then
//    Exit Sub
//End If

//If IsNull(Me.TNETO) = True Then
//    MsgBox "Error en el Monto Neto de la factura" & CHR(13) & _
//    "Se ha cancelado la imputacion", vbCritical
//    Exit Sub
//End If

//If Round(Me.TTOTAL_FACT, 2) <> Round(Me.TNETO, 2) Then
//    MsgBox "El total de la factura no corresponde con el monto ingresado en items"
//    Exit Sub
//End If

//Set db = CurrentDb
//Set rs = db.OpenRecordset("Select * from T0063_ITEMS_OC_INGRESADOS where PROVEEDOR=" & CInt(Me.CPROVEEDOR) & " AND NFACTURA='" & Me.NFACTURA & "' AND ZINCLUIR= TRUE")

//'#Valida que el total de los CostItems a contabilizar coincida con el total Bruto
//While Not rs.EOF
//    If Me.CMON = "ARS" Then
//        XCONTA = Round((rs!CONTA_CANT * rs!CONTA_U_ARS), 2) + XCONTA
//    Else
//        XCONTA = Round((rs!CONTA_CANT* rs!CONTA_U_USD), 2) + XCONTA
//   End If
//   rs.MoveNext
//Wend
//If Round(XCONTA, 2) <> Round(Me.TBRUTO, 2) Then
//   MsgBox "Existe una diferencia entre el valor a contabilizar y el total Bruto de la factura" & CHR(13) & CHR(13) & _
//    "Diferencia:= " & XCONTA - Me.TTOTAL_FACT
//    Exit Sub
//End If

//'-Chequea que todos los items tengan la cuenta GL correspondiente
//rs.MoveFirst
//CC_Completo = True
//While Not rs.EOF
//    If IsNull(rs!GL) = True Then CC_Completo = False
//    rs.MoveNext
//Wend

//If CC_Completo = False Then
//    MsgBox "Alguno de los ITEMS de esta factura no tienen una cuenta G/L Asociada para su contabilizacion", vbCritical
//    Exit Sub
//End If
//'
//'** Fin Validaciones antes de MainDocumentBase
//'
//rs.MoveFirst
//While Not rs.EOF
//    If IsNull(rs!id40) = False Then
//        Set RB = db.OpenRecordset("SELECT * FROM T0040_MAT_MOVIMIENTOS WHERE IDMOVIMIENTO=" & rs!id40)
//        If RB.RecordCount = 1 Then
//            RB.Edit
//            RB!TIPO = Me.TTIPO
//            RB.Update
//        End If
//    End If
//    rs.Edit
//    rs!CONTA = True
//    rs!TIPO = Me.TTIPO
//    rs!NASIENTO = ZDOC
//    rs.Update
//    rs.MoveNext

//Wend

//'Actualiza Tabla 203 Cta Cte
//Dim ra As DAO.Recordset
//Dim XXIDCTA As Double
//Set ra = db.OpenRecordset("T0203_CTACTE_PROV")
//ra.AddNew

//If IsNull(DMax("IDCTACTE", "T0203_CTACTE_PROV")) Then
//    ra!IDCTACTE = 1
//Else
//    ra!IDCTACTE = DMax("IDCTACTE", "T0203_CTACTE_PROV") + 1
//End If
//XXIDCTA = ra!IDCTACTE
//If Me.TTIPO = "L1" Then
//    ra!TDOC = "P1"
//Else
//    ra!TDOC = "P2"
//End If
//ra!NUMDOC = Me.NFACTURA
//ra!Fecha = Me.TFECHA
//ra!DOC_INTERNO = ZDOC
//If IsNull(DLookup("ZTERM", "T0005_MPROVEEDORES", "ID_PROV=" & CInt(Me.CPROVEEDOR))) = True Then
//    ra!ZTERM = 30
//Else
//    ra!ZTERM = DLookup("ZTERM", "T0005_MPROVEEDORES", "ID_PROV=" & CInt(Me.CPROVEEDOR))
//End If
//ra!IDPROV = Me.CPROVEEDOR
//ra!MONEDA = Me.CMON
//ra!TC = Me.TTC
//ra!IMPORTE_ORI = Round(Me.TNETO, 2)
//If Me.CMON = "ARS" Then
//    ra!IMPORTE_ARS = Round(Me.TNETO, 2)
//Else
//    ra!IMPORTE_ARS = Round(Me.TNETO, 2) * ra!TC
//End If
//ra!SALDOFACTURA = ra!IMPORTE_ORI
//ra!LogDate = Date
//ra!LogUsuario = Environ("USERNAME")
//ra!TIPO = Me.TTIPO
//ra!ZOP = False
//ra.Update

//'Actualiza Tabla 204 Cta Cte Saldo PRov

//Set ra = db.OpenRecordset("Select * from T0204_CTACTESALDOS_PROV WHERE IDPROV=" & CInt(Me.CPROVEEDOR) & " AND CUENTATIPO='" & Me.TTIPO & "'")
//If ra.RecordCount = 0 Then
//    ra.AddNew
//    ra!IDPROV = Me.CPROVEEDOR
//    ra!CUENTATIPO = Me.TTIPO
//    ra.Update
//End If
//'
//Set ra = db.OpenRecordset("Select * from T0204_CTACTESALDOS_PROV WHERE IDPROV=" & CInt(Me.CPROVEEDOR) & " AND CUENTATIPO='" & Me.TTIPO & "'")
//ra.Edit
//If Me.CMON = "ARS" Then
//    ra!DEUDA_ARS = ra!DEUDA_ARS + Round(Me.TNETO, 2)
//Else
//    ra!DEUDA_USD = ra!DEUDA_USD + Round(Me.TNETO, 2)
//End If
//ra!TC = Me.TTC
//ra!DEUDA_TOT_ARS = Round(ra!DEUDA_ARS + (ra!DEUDA_USD* ra!TC), 2)
//ra!LogDate = Date
//ra!LogUsuario = Environ("USERNAME")
//ra.Update
//'

//'-------------------------------------------------------------------------------------------
//'Actualiza Tabla T0601
//'-------------------------------------------------------------------------------------------
//Dim RH As DAO.Recordset
//Dim RE As DAO.Recordset

//Set RH = db.OpenRecordset("T0601_DOCU_H")
//RH.AddNew
//RH!IDDOCU = ZDOC
//RH!Fecha = Me.TFECHA
//RH!MONE_ORI = Me.CMON
//RH!TC = Me.TTC
//If (Len(Month(Me.TFECHA)) = 1) Then
//    RH!MES = "0" & Month(Me.TFECHA)
//Else
//    RH!MES = Month(Me.TFECHA)
//End If
//RH!YEAR = YEAR(Me.TFECHA)
//RH!HEADERTEXT = "Factura Proveedores"
//RH!DOCUTIPO = DLookup("DFACT", "T0015_TIPO_FACTURA", "IDFACT='" & Me.CTIPO.Column(0) & "'")
//RH!REFE = Me.NFACTURA
//'RH!ZTERM = DLookup("ZTERM", "T0005_MPROVEEDORES", "ID_PROV=" & Me.CPROVEEDOR)
//RH!TOT_ORI = Me.TNETO
//If Me.CMON = "ARS" Then
//    RH!TOT_ARS = Me.TNETO
//Else
//    RH!TOT_ARS = Me.TNETO* RH!TC
//End If
//RH!TIPO = Me.TTIPO
//RH!Log_User = Environ("USERNAME")
//RH!FECHA_HOY = Date
//RH.Update
//'-------------------------------------------------------------------------------------------
//'Actualiza Tabla T0602
//'-------------------------------------------------------------------------------------------
//Set RE = db.OpenRecordset("T0602_DOCU_S")
//Set ra = db.OpenRecordset("SELECT T0063_ITEMS_OC_INGRESADOS.PROVEEDOR, T0063_ITEMS_OC_INGRESADOS.NFACTURA, T0063_ITEMS_OC_INGRESADOS.CCOSTO,GL, Sum(T0063_ITEMS_OC_INGRESADOS.CONTA_TOTAL) AS ZTOTAL FROM T0063_ITEMS_OC_INGRESADOS WHERE (((T0063_ITEMS_OC_INGRESADOS.ZINCLUIR)=True) AND ((T0063_ITEMS_OC_INGRESADOS.CONTA)=True)) GROUP BY T0063_ITEMS_OC_INGRESADOS.PROVEEDOR, T0063_ITEMS_OC_INGRESADOS.NFACTURA, T0063_ITEMS_OC_INGRESADOS.CCOSTO,GL HAVING (((T0063_ITEMS_OC_INGRESADOS.PROVEEDOR)=" & Me.CPROVEEDOR & ") AND ((T0063_ITEMS_OC_INGRESADOS.NFACTURA)='" & Me.NFACTURA & "'));")
//Dim AZ As Integer
//AZ = 0
//While Not ra.EOF
//    'ASIENTO A CUENTA DE INVENTARIO
//    RE.AddNew
//        RE!IDDOCU = ZDOC    '*NASIENTO
//        RE!IDSEG = AZ + 1   '*NSEGMENTO
//        If (Len(Month(Me.TFECHA)) = 1) Then
//            RE!MES = "0" & Month(Me.TFECHA)
//        Else
//            RE!MES = Month(Me.TFECHA)
//        End If
//        RE!YEAR = YEAR(Me.TFECHA)
//        RE!CUENTA = ra!GL
//        Debug.Print DLookup("GLDESC", "T0135_GLX", "GL='" & ra!GL & "'")
//        RE!MONE_ORI = Me.CMON
//        RE!TC = Me.TTC
//        RE!IMPORTE_ORI = ra!ZTOTAL
//        If Me.CMON = "ARS" Then
//            RE!IMPORTE_ARS = ra!ZTOTAL
//        Else
//            RE!IMPORTE_ARS = ra!ZTOTAL* RE!TC
//       End If
//       RE!SEGTEXT = DLookup("GLDESC", "T0135_GLX", "GL='" & ra!GL & "'")
//        RE!DC = "D"
//        RE!DOCUTIPO = "FP"
//        RE!REFE = Me.NFACTURA
//        RE!PROV = Me.CPROVEEDOR
//        RE!Log_User = Environ("USERNAME")
//        RE!FECHA_HOY = Date
//        RE!DEBE = RE!IMPORTE_ARS
//        RE!HABER = 0
//        RE!GL = RE!CUENTA
//        RE!PERIODO = RE!YEAR & RE!MES
//        RE!TIPO = Me.TTIPO
//        RE!TCODE = "CONTA1"
//        RE.Update
//        AZ = AZ + 1
//ra.MoveNext
//Wend
//    'ASIENTO A DESCUENTOS
//If Me.TDTO<> 0 Then
//    RE.AddNew
//    RE!IDDOCU = ZDOC
//    RE!IDSEG = AZ + 1
//    If (Len(Month(Me.TFECHA)) = 1) Then
//        RE!MES = "0" & Month(Me.TFECHA)
//    Else
//        RE!MES = Month(Me.TFECHA)
//    End If
//    RE!YEAR = YEAR(Me.TFECHA)
//    RE!CUENTA = DLookup("CUENTA_MAP", "T0137_GL_MAPPING", "CUENTA_GEN='DESC_C'") '>>MAP CC
//    RE!MONE_ORI = Me.CMON
//    RE!TC = Me.TTC
//    RE!IMPORTE_ORI = Me.TDTO
//    If Me.CMON = "ARS" Then
//        RE!IMPORTE_ARS = Me.TDTO
//    Else
//        RE!IMPORTE_ARS = Me.TDTO* RE!TC
//   End If
//   RE!SEGTEXT = "Descuento en Compras"
//    RE!DC = "C"
//    RE!DOCUTIPO = "FP"
//    RE!REFE = Me.NFACTURA
//    RE!PROV = Me.CPROVEEDOR
//    RE!Log_User = Environ("USERNAME")
//    RE!FECHA_HOY = Date
//    RE!DEBE = 0
//    RE!HABER = RE!IMPORTE_ARS
//    RE!GL = RE!CUENTA
//    RE!PERIODO = RE!YEAR & RE!MES
//    RE!TIPO = Me.TTIPO
//    RE!TCODE = "CONTA1"
//    RE.Update
//    AZ = AZ + 1
//End If

//If Me.TIVA10<> 0 Then
//    RE.AddNew
//    RE!IDDOCU = ZDOC
//    RE!IDSEG = AZ + 1
//    If (Len(Month(Me.TFECHA)) = 1) Then
//        RE!MES = "0" & Month(Me.TFECHA)
//    Else
//        RE!MES = Month(Me.TFECHA)
//    End If
//    RE!YEAR = YEAR(Me.TFECHA)
//    RE!CUENTA = DLookup("CUENTA_MAP", "T0137_GL_MAPPING", "CUENTA_GEN='IVA10_C'") '>>MAP CC
//    RE!MONE_ORI = Me.CMON
//    RE!TC = Me.TTC
//    RE!IMPORTE_ORI = Me.TIVA10
//    If Me.CMON = "ARS" Then
//        RE!IMPORTE_ARS = Me.TIVA10
//    Else
//        RE!IMPORTE_ARS = Me.TIVA10* RE!TC
//   End If
//   RE!SEGTEXT = DLookup("CUENTA_DES", "T0137_GL_MAPPING", "CUENTA_GEN='IVA10_C'")
//    RE!DC = "C"
//    RE!DOCUTIPO = "FP"
//    RE!REFE = Me.NFACTURA
//    RE!PROV = Me.CPROVEEDOR
//    RE!Log_User = Environ("USERNAME")
//    RE!FECHA_HOY = Date
//    RE!DEBE = RE!IMPORTE_ARS
//    RE!HABER = 0
//    RE!GL = RE!CUENTA
//    RE!PERIODO = RE!YEAR & RE!MES
//    RE!TIPO = Me.TTIPO
//    RE!TCODE = "CONTA1"
//    RE.Update
//    AZ = AZ + 1
//End If

//If Me.TIVA21<> 0 Then
//       RE.AddNew
//    RE!IDDOCU = ZDOC
//    RE!IDSEG = AZ + 1
//    If (Len(Month(Me.TFECHA)) = 1) Then
//        RE!MES = "0" & Month(Me.TFECHA)
//    Else
//        RE!MES = Month(Me.TFECHA)
//    End If
//    RE!YEAR = YEAR(Me.TFECHA)
//    RE!CUENTA = DLookup("CUENTA_MAP", "T0137_GL_MAPPING", "CUENTA_GEN='IVA21_C'") '>>MAP CC
//    RE!MONE_ORI = Me.CMON
//    RE!TC = Me.TTC
//    RE!IMPORTE_ORI = Me.TIVA21
//    If Me.CMON = "ARS" Then
//        RE!IMPORTE_ARS = Me.TIVA21
//    Else
//        RE!IMPORTE_ARS = Me.TIVA21* RE!TC
//   End If
//   RE!SEGTEXT = DLookup("CUENTA_DES", "T0137_GL_MAPPING", "CUENTA_GEN='IVA21_C'")
//    RE!DC = "C"
//    RE!DOCUTIPO = "FP"
//    RE!REFE = Me.NFACTURA
//    RE!PROV = Me.CPROVEEDOR
//    RE!Log_User = Environ("USERNAME")
//    RE!FECHA_HOY = Date
//    RE!DEBE = RE!IMPORTE_ARS
//    RE!HABER = 0
//    RE!GL = RE!CUENTA
//    RE!PERIODO = RE!YEAR & RE!MES
//    RE!TIPO = Me.TTIPO
//    RE!TCODE = "CONTA1"
//    RE.Update
//    AZ = AZ + 1
//End If

//If Me.TRETIVA<> 0 Then
//     RE.AddNew
//    RE!IDDOCU = ZDOC
//    RE!IDSEG = AZ + 1
//    If (Len(Month(Me.TFECHA)) = 1) Then
//        RE!MES = "0" & Month(Me.TFECHA)
//    Else
//        RE!MES = Month(Me.TFECHA)
//    End If
//    RE!YEAR = YEAR(Me.TFECHA)
//    RE!CUENTA = DLookup("CUENTA_MAP", "T0137_GL_MAPPING", "CUENTA_GEN='IVA_RET'") '>>MAP CC
//    RE!MONE_ORI = Me.CMON
//    RE!TC = Me.TTC
//    RE!IMPORTE_ORI = Me.TRETIVA
//    If Me.CMON = "ARS" Then
//        RE!IMPORTE_ARS = Me.TRETIVA
//    Else
//        RE!IMPORTE_ARS = Me.TRETIVA* RE!TC
//   End If
//   RE!SEGTEXT = DLookup("CUENTA_DES", "T0137_GL_MAPPING", "CUENTA_GEN='IVA_RET'")
//    RE!DC = "C"
//    RE!DOCUTIPO = "FP"
//    RE!REFE = Me.NFACTURA
//    RE!PROV = Me.CPROVEEDOR
//    RE!Log_User = Environ("USERNAME")
//    RE!FECHA_HOY = Date
//    RE!DEBE = RE!IMPORTE_ARS
//    RE!HABER = 0
//    RE!GL = RE!CUENTA
//    RE!PERIODO = RE!YEAR & RE!MES
//    RE!TIPO = Me.TTIPO
//    RE!TCODE = "CONTA1"
//    RE.Update
//    AZ = AZ + 1
//End If

//If Me.TRETIIBB<> 0 Then
//    RE.AddNew
//    RE!IDDOCU = ZDOC
//    RE!IDSEG = AZ + 1
//    If (Len(Month(Me.TFECHA)) = 1) Then
//        RE!MES = "0" & Month(Me.TFECHA)
//    Else
//        RE!MES = Month(Me.TFECHA)
//    End If
//    RE!YEAR = YEAR(Me.TFECHA)
//    RE!CUENTA = DLookup("CUENTA_MAP", "T0137_GL_MAPPING", "CUENTA_GEN='IIBB_RET'") '>>MAP CC
//    RE!MONE_ORI = Me.CMON
//    RE!TC = Me.TTC
//    RE!IMPORTE_ORI = Me.TRETIIBB
//    If Me.CMON = "ARS" Then
//        RE!IMPORTE_ARS = Me.TRETIIBB
//    Else
//        RE!IMPORTE_ARS = Me.TRETIIBB* RE!TC
//   End If
//   RE!SEGTEXT = DLookup("CUENTA_DES", "T0137_GL_MAPPING", "CUENTA_GEN='IIBB_RET'")
//    RE!DC = "C"
//    RE!DOCUTIPO = "FP"
//    RE!REFE = Me.NFACTURA
//    RE!PROV = Me.CPROVEEDOR
//    RE!Log_User = Environ("USERNAME")
//    RE!FECHA_HOY = Date
//    RE!DEBE = RE!IMPORTE_ARS
//    RE!HABER = 0
//    RE!GL = RE!CUENTA
//    RE!PERIODO = RE!YEAR & RE!MES
//    RE!TIPO = Me.TTIPO
//    RE!TCODE = "CONTA1"
//    RE.Update
//    AZ = AZ + 1
//End If

//If Me.TIMPINT<> 0 Then
//    RE.AddNew
//    RE!IDDOCU = ZDOC
//    RE!IDSEG = AZ + 1
//    If (Len(Month(Me.TFECHA)) = 1) Then
//        RE!MES = "0" & Month(Me.TFECHA)
//    Else
//        RE!MES = Month(Me.TFECHA)
//    End If
//    RE!YEAR = YEAR(Me.TFECHA)
//    RE!CUENTA = DLookup("CUENTA_MAP", "T0137_GL_MAPPING", "CUENTA_GEN='IMP_INT'") '>>MAP CC
//    RE!MONE_ORI = Me.CMON
//    RE!TC = Me.TTC
//    RE!IMPORTE_ORI = Me.TIMPINT
//    If Me.CMON = "ARS" Then
//        RE!IMPORTE_ARS = Me.TIMPINT
//    Else
//        RE!IMPORTE_ARS = Me.TIMPINT* RE!TC
//   End If
//   RE!SEGTEXT = DLookup("CUENTA_DES", "T0137_GL_MAPPING", "CUENTA_GEN='IMP_INT'")
//    RE!DC = "C"
//    RE!DOCUTIPO = "FP"
//    RE!REFE = Me.NFACTURA
//    RE!PROV = Me.CPROVEEDOR
//    RE!Log_User = Environ("USERNAME")
//    RE!FECHA_HOY = Date
//    RE!DEBE = RE!IMPORTE_ARS
//    RE!HABER = 0
//    RE!GL = RE!CUENTA
//    RE!PERIODO = RE!YEAR & RE!MES
//    RE!TIPO = Me.TTIPO
//    RE!TCODE = "CONTA1"
//    RE.Update
//    AZ = AZ + 1
//End If

//If Me.TIMPOTROS<> 0 Then
//    RE.AddNew
//    RE!IDDOCU = ZDOC
//    RE!IDSEG = AZ + 1
//    If (Len(Month(Me.TFECHA)) = 1) Then
//        RE!MES = "0" & Month(Me.TFECHA)
//    Else
//        RE!MES = Month(Me.TFECHA)
//    End If
//    RE!YEAR = YEAR(Me.TFECHA)
//    RE!CUENTA = DLookup("CUENTA_MAP", "T0137_GL_MAPPING", "CUENTA_GEN='IMP_OTR'") '>>MAP CC
//    RE!MONE_ORI = Me.CMON
//    RE!TC = Me.TTC
//    RE!IMPORTE_ORI = Me.TIMPOTROS
//    If Me.CMON = "ARS" Then
//        RE!IMPORTE_ARS = Me.TIMPOTROS
//    Else
//        RE!IMPORTE_ARS = Me.TIMPOTROS* RE!TC
//   End If
//   RE!SEGTEXT = DLookup("CUENTA_DES", "T0137_GL_MAPPING", "CUENTA_GEN='IMP_OTR'")
//    RE!DC = "C"
//    RE!DOCUTIPO = "FP"
//    RE!REFE = Me.NFACTURA
//    RE!PROV = Me.CPROVEEDOR
//    RE!Log_User = Environ("USERNAME")
//    RE!FECHA_HOY = Date
//    RE!DEBE = RE!IMPORTE_ARS
//    RE!HABER = 0
//    RE!GL = RE!CUENTA
//    RE!PERIODO = RE!YEAR & RE!MES
//    RE!TIPO = Me.TTIPO
//    RE!TCODE = "CONTA1"
//    RE.Update
//    AZ = AZ + 1
//End If

//'ASIENTO A AP
//    RE.AddNew
//    RE!IDDOCU = ZDOC
//    RE!IDSEG = AZ + 1
//    If(Len(Month(Me.TFECHA)) = 1) Then
//       RE!MES = "0" & Month(Me.TFECHA)
//    Else
//        RE!MES = Month(Me.TFECHA)
//    End If
//    RE!YEAR = YEAR(Me.TFECHA)
//    RE!CUENTA = Me.TGL
//    RE!MONE_ORI = Me.CMON
//    RE!TC = Me.TTC
//    RE!IMPORTE_ORI = Me.TNETO
//    If Me.CMON = "ARS" Then
//        RE!IMPORTE_ARS = Me.TNETO
//    Else
//        RE!IMPORTE_ARS = Me.TNETO* RE!TC
//   End If
//   RE!SEGTEXT = "Cuentas por Pagar A/P"
//    RE!DC = "C"
//    RE!DOCUTIPO = "FP"
//    RE!REFE = Me.NFACTURA
//    RE!PROV = Me.CPROVEEDOR
//    RE!Log_User = Environ("USERNAME")
//    RE!FECHA_HOY = Date
//    RE!DEBE = 0
//    RE!HABER = RE!IMPORTE_ARS
//    RE!GL = RE!CUENTA
//    RE!PERIODO = RE!YEAR & RE!MES
//    RE!TIPO = Me.TTIPO
//    RE!TCODE = "CONTA1"
//    RE.Update

//'--------------------------------------------------------------
//'T0403
//Dim IDZ As Double
//IDZ = FACTPROVEEDOR
//Set RE = db.OpenRecordset("select * from T0403_VENDOR_FACT_H where idint=" & IDZ)
//RE.Edit
//RE!NASIENTO = ZDOC
//RE!IDCTACTE = XXIDCTA
//RE.Update


//'------------------------------------------------------------------------------------------------------------
//'                                   -- Actualizacion de Costo Unitario --
//'------------------------------------------------------------------------------------------------------------
//Set ra = db.OpenRecordset("SELECT T0063_ITEMS_OC_INGRESADOS.IDMATERIAL, T0063_ITEMS_OC_INGRESADOS.CANTIDAD, T0063_ITEMS_OC_INGRESADOS.CONTA_U_ARS,  T0063_ITEMS_OC_INGRESADOS.CONTA_U_USD, T0012_TIPO_MATERIAL.COSTO, T0063_ITEMS_OC_INGRESADOS.NASIENTO FROM T0012_TIPO_MATERIAL INNER JOIN (T0063_ITEMS_OC_INGRESADOS INNER JOIN T0010_MATERIALES ON T0063_ITEMS_OC_INGRESADOS.IDMATERIAL = T0010_MATERIALES.IDMATERIAL) ON T0012_TIPO_MATERIAL.TIPO_MATERIAL = T0010_MATERIALES.TIPO_MATERIAL WHERE (((T0012_TIPO_MATERIAL.COSTO)=True) AND ((T0063_ITEMS_OC_INGRESADOS.NASIENTO)=" & ZDOC & "));")
//Dim Xtype As String
//Xtype = DLookup("TIPO_MATERIAL", "T0010_MATERIALES", "IDMATERIAL='" & ra!IDMATERIAL & "'")
//While Not ra.EOF
//    Set RE = db.OpenRecordset("Select * from T0033_COSTO WHERE MATERIAL='" & ra!IDMATERIAL & "'")
//    If RE.RecordCount = 0 Then
//        RE.AddNew
//        RE!MATERIAL = ra!IDMATERIAL
//        RE!Stock = ra!CANTIDAD
//        If Me.CMON = "ARS" Then
//            RE!COSTO_UC_ARS = ra!CONTA_U_ARS
//            RE!COSTO_UC_USD = ra!CONTA_U_ARS / Me.TTC
//        Else
//            RE!COSTO_UC_ARS = ra!CONTA_U_USD* Me.TTC
//            RE!COSTO_UC_USD = ra!CONTA_U_USD
//        End If
//        RE!COSTO_1_ARS = 0
//        RE!COSTO_1_USD = 0
//        'Setea como esta primer compra el costo standard
//        RE!COSTO_ARS = RE!COSTO_UC_ARS
//        RE!COSTO_USD = RE!COSTO_UC_USD
//        '
//        RE!UM = Date
//        RE!FECHA_UC = Date
//        RE!MTYPE = Xtype
//        RE!CostDetermination = "AUTO"
//        RE!CostDeterminationBy = "COMPRA"
//        RE!PROVEEDOR = Me.CPROVEEDOR
//        RE!COSTO_PPP_ARS = RE!COSTO_UC_ARS
//        RE!COSTO_PPP_USD = RE!COSTO_UC_USD
//        RE.Update
//    Else
//        RE.Edit
//        RE!Stock = ra!CANTIDAD
//        're!COSTO_1_ARS = RA!CONTA_U_ARS
//        're!COSTO_1_USD = RA!CONTA_U_USD
//        If Me.CMON = "ARS" Then
//            RE!COSTO_UC_ARS = ra!CONTA_U_ARS
//            RE!COSTO_UC_USD = Round(ra!CONTA_U_ARS / Me.TTC, 2)
//        Else
//            RE!COSTO_UC_ARS = ra!CONTA_U_USD* Me.TTC
//            RE!COSTO_UC_USD = ra!CONTA_U_USD
//        End If
//        RE!UM = Date
//        RE!FECHA_UC = Date
//        RE!MTYPE = Xtype
//        RE!CostDetermination = "AUTO"
//        RE!CostDeterminationBy = "COMPRA"
//        RE!PROVEEDOR = Me.CPROVEEDOR
//        RE.Update
//        Set RE = db.OpenRecordset("Select * from T0033_COSTO WHERE MATERIAL='" & ra!IDMATERIAL & "'")
//        RE.Edit
//        RE!COSTO_PPP_ARS = Round(CalculaPPP(ra!IDMATERIAL, "ARS"), 2)
//        RE!COSTO_PPP_USD = Round(CalculaPPP(ra!IDMATERIAL, "USD"), 2)
//        RE.Update
//    End If
//ra.MoveNext
//Wend


//MsgBox "Se ha contabilizado correctamente ASIENTO: " & ZDOC, vbInformation
//DoCmd.Close acForm, "0230_CONTA_PROV", acSaveYes
//End Sub

//Public Function CalculaPPP(MATERIAL As String, MON As String) As Double
//Dim db As DAO.Database
//Dim rs As DAO.Recordset
//Dim KGTOT As Double
//Dim KGANT As Double
//Set db = CurrentDb
//Set rs = db.OpenRecordset("SELECT * FROM T0033_COSTO WHERE MATERIAL='" & MATERIAL & "'")
//KGTOT = GETSTOCK(MATERIAL, "ALL")
//KGANT = GETSTOCK(MATERIAL, "ALL") - rs!Stock

//If (IsNull(rs!COSTO_ARS) = True) Then
//    rs.Edit
//    rs!COSTO_ARS = 0
//    rs.Update
//End If

//If (IsNull(rs!COSTO_USD) = True) Then
//    rs.Edit
//    rs!COSTO_USD = 0
//    rs.Update
//End If

//If KGANT > 0 Then
//    If MON = "ARS" Then
//        CalculaPPP = ((KGANT * rs!COSTO_ARS) + (rs!Stock* rs!COSTO_UC_ARS)) / GETSTOCK(MATERIAL, "ALL")
//    Else
//        CalculaPPP = ((KGANT * rs!COSTO_USD) + (rs!Stock* rs!COSTO_UC_USD)) / GETSTOCK(MATERIAL, "ALL")
//    End If
//Else
//'El Stock existente ahora es MENOR al de la ultima compra por lo tanto PPP = UC
//    If MON = "ARS" Then
//        CalculaPPP = rs!COSTO_UC_ARS
//    Else
//        CalculaPPP = rs!COSTO_UC_USD
//    End If
//End If
//End Function

//'Despues de actualizar el combo del remito
//Private Sub CREMITO_AfterUpdate()
//    Me.TXREMITO = Me.CREMITO
//'Si el item es con orden de compra debe estar en la tabla T0063
//If Me.CK_NO_OC = False Then
//    If Me.CMON = "ARS" Then
//        If Me.CK_MULTIPLE_REMITO = False Then
//            Me.SFITEMS.Form.RecordSource = "SELECT ADDED,CONTA_TOTAL,NFACTURA,ZINCLUIR,CCOSTO,GL, ,T0063_ITEMS_OC_INGRESADOS.ID, T0063_ITEMS_OC_INGRESADOS.PROVEEDOR, T0063_ITEMS_OC_INGRESADOS.IDMATERIAL, T0063_ITEMS_OC_INGRESADOS.CANTIDAD, T0063_ITEMS_OC_INGRESADOS.TC, T0063_ITEMS_OC_INGRESADOS.PRECIO_U_ARS AS XPRECIO_U_OC, T0063_ITEMS_OC_INGRESADOS.NREMITO, T0063_ITEMS_OC_INGRESADOS.CONTA_CANT, T0063_ITEMS_OC_INGRESADOS.CONTA_U_ARS, T0063_ITEMS_OC_INGRESADOS.CONTA FROM T0063_ITEMS_OC_INGRESADOS WHERE (((T0063_ITEMS_OC_INGRESADOS.PROVEEDOR)=" & Me.CPROVEEDOR & ") AND ((T0063_ITEMS_OC_INGRESADOS.NREMITO)='" & TXREMITO & "') AND (ADDED=False));"
//        Else
//            Me.SFITEMS.Form.RecordSource = "SELECT T0063_ITEMS_OC_INGRESADOS.ADDED,GL, T0063_ITEMS_OC_INGRESADOS.CONTA_TOTAL, T0063_ITEMS_OC_INGRESADOS.ZINCLUIR, T0063_ITEMS_OC_INGRESADOS.CCOSTO, T0063_ITEMS_OC_INGRESADOS.ID, T0063_ITEMS_OC_INGRESADOS.PROVEEDOR, T0063_ITEMS_OC_INGRESADOS.IDMATERIAL, T0063_ITEMS_OC_INGRESADOS.CANTIDAD, T0063_ITEMS_OC_INGRESADOS.TC, T0063_ITEMS_OC_INGRESADOS.PRECIO_U_ARS AS XPRECIO_U_OC, T0063_ITEMS_OC_INGRESADOS.NFACTURA, T0063_ITEMS_OC_INGRESADOS.NREMITO, T0063_ITEMS_OC_INGRESADOS.CONTA_CANT, T0063_ITEMS_OC_INGRESADOS.CONTA_U_ARS, T0063_ITEMS_OC_INGRESADOS.CONTA FROM T0063_ITEMS_OC_INGRESADOS WHERE (((T0063_ITEMS_OC_INGRESADOS.ADDED)=False) AND ((T0063_ITEMS_OC_INGRESADOS.PROVEEDOR)=" & Me.CPROVEEDOR & ") AND ((T0063_ITEMS_OC_INGRESADOS.NREMITO)='" & TXREMITO & "')) OR (((T0063_ITEMS_OC_INGRESADOS.NFACTURA)='" & NFACTURA & "'));"
//        End If
//        Me.SFITEMS.Form.XPRECIO_U_FACT.ControlSource = "CONTA_U_ARS"
//    Else
//        If Me.CK_MULTIPLE_REMITO = False Then
//            Me.SFITEMS.Form.RecordSource = "SELECT T0063_ITEMS_OC_INGRESADOS.ADDED,GL, T0063_ITEMS_OC_INGRESADOS.CONTA_TOTAL, T0063_ITEMS_OC_INGRESADOS.ZINCLUIR, T0063_ITEMS_OC_INGRESADOS.CCOSTO, T0063_ITEMS_OC_INGRESADOS.ID, T0063_ITEMS_OC_INGRESADOS.PROVEEDOR, T0063_ITEMS_OC_INGRESADOS.IDMATERIAL, T0063_ITEMS_OC_INGRESADOS.CANTIDAD, T0063_ITEMS_OC_INGRESADOS.TC, T0063_ITEMS_OC_INGRESADOS.PRECIO_U_USD AS XPRECIO_U_OC, T0063_ITEMS_OC_INGRESADOS.NREMITO, T0063_ITEMS_OC_INGRESADOS.NFACTURA, T0063_ITEMS_OC_INGRESADOS.CONTA_CANT, T0063_ITEMS_OC_INGRESADOS.CONTA_U_ARS, T0063_ITEMS_OC_INGRESADOS.CONTA FROM T0063_ITEMS_OC_INGRESADOS WHERE (((T0063_ITEMS_OC_INGRESADOS.ADDED)=False) AND ((T0063_ITEMS_OC_INGRESADOS.PROVEEDOR)=" & Me.CPROVEEDOR & ") AND ((T0063_ITEMS_OC_INGRESADOS.NREMITO)='" & TXREMITO & "'));"
//        Else
//            Me.SFITEMS.Form.RecordSource = "SELECT T0063_ITEMS_OC_INGRESADOS.ADDED,GL, T0063_ITEMS_OC_INGRESADOS.CONTA_TOTAL, T0063_ITEMS_OC_INGRESADOS.ZINCLUIR, T0063_ITEMS_OC_INGRESADOS.CCOSTO, T0063_ITEMS_OC_INGRESADOS.ID, T0063_ITEMS_OC_INGRESADOS.PROVEEDOR, T0063_ITEMS_OC_INGRESADOS.IDMATERIAL, T0063_ITEMS_OC_INGRESADOS.CANTIDAD, T0063_ITEMS_OC_INGRESADOS.TC, T0063_ITEMS_OC_INGRESADOS.PRECIO_U_USD AS XPRECIO_U_OC, T0063_ITEMS_OC_INGRESADOS.NREMITO, T0063_ITEMS_OC_INGRESADOS.NFACTURA, T0063_ITEMS_OC_INGRESADOS.CONTA_CANT, T0063_ITEMS_OC_INGRESADOS.CONTA_U_ARS, T0063_ITEMS_OC_INGRESADOS.CONTA FROM T0063_ITEMS_OC_INGRESADOS WHERE (((T0063_ITEMS_OC_INGRESADOS.ADDED)=False) AND ((T0063_ITEMS_OC_INGRESADOS.PROVEEDOR)=" & Me.CPROVEEDOR & ") AND ((T0063_ITEMS_OC_INGRESADOS.NREMITO)='" & TXREMITO & "')) OR (((T0063_ITEMS_OC_INGRESADOS.NFACTURA)='" & NFACTURA & "'));"
//        End If
//        Me.SFITEMS.Form!XPRECIO_U_FACT.ControlSource = CONTA_U_USD
//    End If
//Else
//End If
//If Me.CK_MULTIPLE_REMITO = False Then
//    Me.SFITEMS.Form!TZTOTOC = DSum("CONTA_TOTAL", "T0063_ITEMS_OC_INGRESADOS", "PROVEEDOR=" & Me.CPROVEEDOR & " AND NFACTURA='" & Me.NFACTURA & "' and added = FALSE ")
//Else
//    Me.SFITEMS.VISIBLE = True
//End If
//Me.TID0063 = Me.CREMITO.Column(1)
//End Sub

//Private Sub CREMITO_Enter()
//If IsNull(Me.CPROVEEDOR) = True Then
//    MsgBox "Antes de completar el Numero de Remito, debe completar el proveedor", vbCritical
//    Me.CPROVEEDOR.Locked = False
//    Me.CPROVEEDOR.SetFocus
//End If
//End Sub

//Private Sub CTIPO_AfterUpdate()
//Me.TTIPO = Me.CTIPO.Column(2)
//Select Case Me.TTIPO
//Case Is = "L1"
//    Me.TIVA10.Locked = False
//    Me.TIVA21.Locked = False
//    Me.TRETIVA.Locked = False
//    Me.TRETIVA.Locked = False
//    Me.TIMPINT.Locked = False
//    Me.TIMPOTROS.Locked = False
//Case Is = "L2"
//    Me.TIVA10.Locked = True
//    Me.TIVA21.Locked = True
//    Me.TRETIVA.Locked = True
//    Me.TRETIVA.Locked = True
//    Me.TIMPINT.Locked = True
//    Me.TIMPOTROS.Locked = True
//    Me.NFACTURA = "0000-00000000"
//End Select
//End Sub



//Private Sub CTIPO_Enter()
//If IsNull(Me.CPROVEEDOR) = True Then
//    MsgBox "Antes de completar el tipo de Factura, debe completar el Proveedor"
//    Me.CPROVEEDOR.Locked = False
//    Me.CPROVEEDOR.SetFocus
//End If

//End Sub

//Private Sub Form_Load()

//    Me.TModo = Me.OpenArgs
//    Me.SFITEMS.Form.AllowAdditions = False
//    Me.SFITEMS.Form.RecordSource = ""
//    Me.SFSINOC.Form.RecordSource = ""
//    Me.SFITEMS.VISIBLE = False
//    Me.SFSINOC.VISIBLE = False
//    '
//    CK_NO_OC_AfterUpdate
//    Me.CPROVEEDOR.Locked = False
//    Me.NFACTURA.Locked = False
//    Me.CTIPO.Locked = False
//    Me.CMON.Locked = False
//    Me.TFECHA.Locked = False
//    Me.TTOTAL_FACT.Locked = False


//'    Me.Cremito.Locked = False
//'    Me.TREMITO.Locked = False


//    Me.SFITEMS.Form.AllowEdits = False
//    Me.SFSINOC.Form.AllowEdits = False
//    Me.SFITEMS.Form.AllowAdditions = False


//    Me.CEDIT.Enabled = True
//    Me.CRECALCULAR.Enabled = False
//    Me.CADDITEMS.Enabled = False
//    Me.CADDREMITO.Enabled = False


//    DoCmd.Maximize


//End Sub


//Private Sub CADDITEMS_Click()
//If IsNull(Me.CPROVEEDOR) Then
//    MsgBox "Complete el Proveedor"
//    Exit Sub
//End If

//If IsNull(Me.NFACTURA) Or Me.NFACTURA = "" Then
//    MsgBox "Complete el Numero de Factura"
//    Exit Sub
//End If

//If IsNull(Me.TFECHA) Then
//    MsgBox "Complete la Fecha de la factura"
//    Exit Sub
//End If

//If IsNull(Me.TTOTAL_FACT) Then
//    MsgBox "Complete el Total de la Factura"
//    Exit Sub
//End If

//Me.CPROVEEDOR.Locked = True
//Me.NFACTURA.Locked = True

//On Error GoTo Err_CADDITEMS_Click

//    Dim stdocname As String
//    Dim stLinkCriteria As String

//    stdocname = "0232_ADD_ITEMS_SINOC"
//    DoCmd.OpenForm stdocname, , , stLinkCriteria, , , Me.CPROVEEDOR & "@" & Me.CMON & "@" & Me.Form.Name

//Exit_CADDITEMS_Click:
//    Exit Sub

//Err_CADDITEMS_Click:
//    MsgBox ERR.Description
//    Resume Exit_CADDITEMS_Click

//End Sub


//'Despues de actualizar numero de factura habilita boton y formularios
//Private Sub NFACTURA_AfterUpdate()

//If Me.CK_NO_OC = True Then
//    Me.SFITEMS.VISIBLE = False
//Else
//    Me.SFITEMS.VISIBLE = True
//End If

//Me.SFSINOC.VISIBLE = True
//Me.CADDITEMS.Enabled = False
//Me.CADDREMITO.Enabled = False
//Me.CRECALCULAR.Enabled = False
//'
//Me.SFSINOC.Form.RecordSource = "SELECT CONTA_TOTAL,ZINCLUIR, T0063_ITEMS_OC_INGRESADOS.CCOSTO, T0063_ITEMS_OC_INGRESADOS.ID, T0063_ITEMS_OC_INGRESADOS.PROVEEDOR, T0063_ITEMS_OC_INGRESADOS.IDMATERIAL, T0063_ITEMS_OC_INGRESADOS.CANTIDAD, T0063_ITEMS_OC_INGRESADOS.TC, T0063_ITEMS_OC_INGRESADOS.PRECIO_U_ARS AS XPRECIO_U_OC, T0063_ITEMS_OC_INGRESADOS.NREMITO, T0063_ITEMS_OC_INGRESADOS.CONTA_CANT, T0063_ITEMS_OC_INGRESADOS.CONTA_U_ARS, T0063_ITEMS_OC_INGRESADOS.CONTA, T0063_ITEMS_OC_INGRESADOS.NFACTURA, T0063_ITEMS_OC_INGRESADOS.ADDED FROM T0063_ITEMS_OC_INGRESADOS WHERE (((T0063_ITEMS_OC_INGRESADOS.PROVEEDOR)=" & CDbl(Me.CPROVEEDOR) & ") AND ((T0063_ITEMS_OC_INGRESADOS.nfactura)='" & Me.NFACTURA & "') AND ((T0063_ITEMS_OC_INGRESADOS.ADDED)=True));"
//Me.SFSINOC.Form!TZTOTSINOC = DSum("CONTA_TOTAL", "T0063_ITEMS_OC_INGRESADOS", "PROVEEDOR=" & Me.CPROVEEDOR & " AND NFACTURA='" & Me.NFACTURA & "' and added = true ")
//Me.SFITEMS.Form!TZTOTOC = DSum("CONTA_TOTAL", "T0063_ITEMS_OC_INGRESADOS", "PROVEEDOR=" & Me.CPROVEEDOR & " AND NFACTURA='" & Me.NFACTURA & "' and added = FALSE ")
//ZCalcTotFact
//End Sub

//'Funcion que recalcula el TBRUTO y TNETO
//Public Function ZCalcTotFact()

//Select Case Me.TModo
//Case Is = 1
//    Me.TBRUTO = DSum("CONTA_TOTAL", "T0063_ITEMS_OC_INGRESADOS", "PROVEEDOR=" & CDbl(Me.CPROVEEDOR.Column(0)) & " AND NFACTURA='" & Me.NFACTURA & "' AND ZINCLUIR= True AND CONTA=False")
//    If IsNull(Me.TBRUTO) Then Me.TBRUTO = 0
//    Me.TSUBTOTAL = Me.TBRUTO - Me.TDTO
//    If IsNull(Me.TDTO) Then Me.TDTO = 0
//    If IsNull(Me.TIVA10) Then Me.TIVA10 = 0
//    If IsNull(Me.TIVA21) Then Me.TIVA21 = 0
//    If IsNull(Me.TRETIVA) Then Me.TRETIVA = 0
//    If IsNull(Me.TRETIIBB) Then Me.TRETIIBB = 0
//    If IsNull(Me.TIMPINT) Then Me.TIMPINT = 0
//    If IsNull(Me.TIMPOTROS) Then Me.TIMPOTROS = 0
//    Me.TNETO = Me.TSUBTOTAL + Me.TIVA10 + Me.TIVA21 + Me.TRETIVA + Me.TRETIIBB + Me.TIMPINT + Me.TIMPOTROS
//End Select
//Me.Recalc
//End Function

//Private Sub NFACTURA_Enter()
//If IsNull(Me.CTIPO) = True Then
//    MsgBox "Antes de Completar el numero de factura, debe completar el TIPO de Factura"
//    Me.CTIPO.Locked = False
//    Me.CTIPO.SetFocus
//End If
//End Sub

//Private Sub TDTO_AfterUpdate()
//ZCalcTotFact
//End Sub

//Private Sub TFECHA_AfterUpdate()
//If CONTA.CK_PeriodoFI(Me.TFECHA) = False Then
//    MsgBox "El Periodo que está intentando contabilizar no se encuentra abierto", vbCritical
//    Me.TFECHA = Null
//Else
//    Me.TTC = GetXRate2("FACTU", Me.TFECHA)
//End If
//End Sub

//Private Sub TIMPINT_AfterUpdate()
//ZCalcTotFact
//End Sub

//Private Sub TIMPOTROS_AfterUpdate()
//ZCalcTotFact
//End Sub

//Private Sub TIVA10_AfterUpdate()
//ZCalcTotFact
//End Sub

//Private Sub TIVA21_AfterUpdate()
//ZCalcTotFact
//End Sub

//Private Sub TIVA21_Click()
//If Me.TIVA21 = 0 Then
//    Me.TIVA21 = [TBRUTO] * 0.21
//End If
//ZCalcTotFact
//End Sub

//Private Sub TREMITO_AfterUpdate()
//If IsNull(Me.TREMITO) = True Then
//    Me.TXREMITO = "N/A"
//Else
//    Me.TXREMITO = Me.TREMITO
//    'MsgBox Me.TREMITO.COL
//End If
//End Sub

//Private Sub TRETIIBB_AfterUpdate()
//ZCalcTotFact
//End Sub

//Private Sub TRETIVA_AfterUpdate()
//ZCalcTotFact
//End Sub

//'Boton Habilita Edicion de CostItems Factura
//Private Sub CEDIT_Click()
//If IsNull(Me.CPROVEEDOR) Then
//    MsgBox "Complete el Proveedor"
//    Exit Sub
//End If

//If Me.CK_NO_OC = False Then
//    If IsNull(Me.CREMITO) Then
//        MsgBox "Complete el Remito"
//        Exit Sub
//    End If
//End If

//If Me.CKFASON = True Then
//    If IsNull(Me.TID0063) = True Or Me.TID0063 = "" Then
//        MsgBox "El Remito seleccionado no permite proceso de Fason", vbCritical
//        Exit Sub
//    End If
//    DoCmd.OpenForm "0231_CONTA_FASON", acNormal, , , , acDialog, Me.TID0063
//    DoCmd.Close acForm, "0230_CONTA_PROV", acSaveYes
//    Exit Sub
//End If

//If IsNull(Me.CTIPO) = True Then
//    MsgBox "Complete el tipo de Factura", vbCritical
//    Me.CTIPO.SetFocus
//    Exit Sub
//End If


//If IsNull(Me.NFACTURA) Or Me.NFACTURA = "" Then
//    MsgBox "Complete El Numero de Factura"
//    Exit Sub
//End If

//If IsNull(Me.TFECHA) Then
//    MsgBox "Complete la Fecha"
//    Me.TFECHA.SetFocus
//    Exit Sub
//End If

//If IsNull(Me.TTOTAL_FACT) Then
//    MsgBox "Complete el Total de la Factura"
//    Exit Sub
//End If

//Me.CPROVEEDOR.Locked = True
//Me.CREMITO.Locked = True
//Me.NFACTURA.Locked = True
//Me.TFECHA.Locked = True
//Me.TTOTAL_FACT.Locked = True
//Me.CTIPO.Locked = True
//Me.SFITEMS.Form.AllowEdits = True
//Me.SFSINOC.Form.AllowEdits = True

//Me.CADDITEMS.Enabled = True
//Me.CADDREMITO.Enabled = True
//Me.CRECALCULAR.Enabled = True




//Me.CADDITEMS.Enabled = True
//Me.CADDITEMS.SetFocus

//Me.CEDIT.Enabled = False






//End Sub

//Private Sub TTC_DblClick(Cancel As Integer)
//Me.TTC.Locked = False
//End Sub

//Private Sub TTOTAL_FACT_DblClick(Cancel As Integer)
//Me.TTOTAL_FACT.Locked = False
//End Sub
//Private Sub Comando76_Click()
//On Error GoTo Err_Comando76_Click

//    Dim stdocname As String

//    stdocname = "CARGACOMPRAS_TAS1"
//    DoCmd.RunMacro stdocname

//Exit_Comando76_Click:
//    Exit Sub

//Err_Comando76_Click:
//    MsgBox ERR.Description
//    Resume Exit_Comando76_Click


//End Sub
//Private Sub Comando77_Click()
//On Error GoTo Err_Comando77_Click

//    Dim stdocname As String

//    stdocname = "CARGACOMPRAS_TAS2"
//    DoCmd.RunMacro stdocname

//Exit_Comando77_Click:
//    Exit Sub

//Err_Comando77_Click:
//    MsgBox ERR.Description
//    Resume Exit_Comando77_Click


//End Sub



//}
