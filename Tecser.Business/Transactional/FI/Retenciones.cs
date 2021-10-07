using System;
using Tecser.Business.TOOLS;
using Tecser.Business.WebServices;

namespace Tecser.Business.Transactional.FI
{
    public class Retenciones
    {
        public Retenciones()
        {

        }


        public decimal GetAlicuotaRetencionIIBB(string numeroCuit, string periodo)
        {
            var iibb = new PadronArba();
            iibb.Conectar(numeroCuit, new PeriodoConversion().GetPrimerDiaPeriodoYyyymmdd(periodo),
                new PeriodoConversion().GetUltimoDiaPeriodoYyyymmdd(periodo));
            return Convert.ToDecimal(iibb.AlRete);
        }


        private decimal GetTotalPagadoMes(int idProveedor, string periodoPago)
        {
            return 0;
        }

        /// <summary>
        /// Calculo de Rentecion de Ganancias
        /// </summary>
        /// <returns></returns>
        public decimal CalculoRetencionGanancias()
        {
            return 0;
        }

        /// <summary>
        /// Calculo de Retencion de IIBB 
        /// </summary>
        /// <returns></returns>
        public decimal CalculoRetencionIIBB(decimal alicuotaIIBB, decimal coeficiente, decimal baseImponible)
        {
            coeficiente = 1;
            return alicuotaIIBB * baseImponible * coeficiente;
        }




        public void CalculaAlicuotasRetencionIIBB()
        {

        }


        public void CalculaRetencionOrdenPago(int numeroOP)
        {

        }
    }
}


//'---------------------------------------------------------------------------------------
//' Author    : Andres Mombelli
//' Fecha     : 16/08/2015
//' Proposito : Calcular el Importe de Retenciones cuando una factura es agregada. Si la
//'            factura ya se encuentra en la T405 no hace nada, pero si no esta la agrega
//'            En T0405 y ademas le hace la asignacion en T0123_OP_H
//' Parametros:
//' Retorna   :
//'---------------------------------------------------------------------------------------
//Public Function CalculaRetenciones(IDOP As Double)
//Dim db As DAO.Database
//Dim rs As DAO.Recordset
//Set db = CurrentDb
//Set rs = db.OpenRecordset("SELECT * FROM T0213_OP_FACT WHERE IDOP=" & IDOP)
//If IsNull(Me.txtCoeficienteCM05) = True Then
//      'No hay informacion de alicuotas
//      Me.txtCoeficienteCM05 = 1
//      Me.txtBaseImponibleGanancias = 12000
//      Me.txtAlicuotaGanancias = 0.02
//      Me.txtAlicuotaRetIIBB = 0.001
//      Call MsgBox("No se ha encontrado informacion de ARBA para el calculo de retenciones." _
//                  & vbCrLf & "Se ha inicializado con valores default. Revise manualmente la configuracion de retenciones" _
//                  , vbExclamation, "Calculo de Retenciones")
//End If

//While Not rs.EOF
//      If MTax.CRUD_A_RETENCIONEST405(CLng(IDOP), CLng(rs!FACT_ID), CDbl(Me.txtBaseImponibleGanancias), CSng(Me.txtAlicuotaGanancias), CSng(Me.txtCoeficienteCM05 * Me.txtAlicuotaRetIIBB), CStr(Me.cboConcepto)) = True Then
//            AsignaRetencionesFacturas rs!IDITEM, rs!FACT_ID
//      End If
//rs.MoveNext
//Wend
//ActualizaCalculosFacturas
//db.Close
//Set db = Nothing
//Set rs = Nothing
//End Function

//'---------------------------------------------------------------------------------------
//' Author    : Andres Mombelli
//' Fecha     : 16/08/2015
//' Proposito : RECALCULA el monto de la retencion cuando el importe es cambiado
//' Parametros:
//' Retorna   :
//'---------------------------------------------------------------------------------------
//Public Function RECalculaRetenciones(IDOP As Double)
//Dim db As DAO.Database
//Dim rs As DAO.Recordset
//Dim BaseImponibleDocumento As Double
//Set db = CurrentDb
//Set rs = db.OpenRecordset("SELECT * FROM T0213_OP_FACT WHERE IDOP=" & IDOP)
//While Not rs.EOF
//    BaseImponibleDocumento = DLookup("baseimponible", "T0403_VENDOR_FACT_H", "idint=" & rs!FACT_ID)
//    If MTax.CRUD_U_RETENCIONEST405(CLng(IDOP), CLng(rs!FACT_ID), CDbl(Me.txtBaseImponibleGanancias), CSng(Me.txtAlicuotaGanancias), CSng(Me.txtCoeficienteCM05 * Me.txtAlicuotaRetIIBB), CStr(Me.cboConcepto), CSng(BaseImponibleDocumento)) = True Then
//        AsignaRetencionesFacturas rs!IDITEM, rs!FACT_ID
//    End If
//rs.MoveNext
//Wend
//ActualizaCalculosFacturas
//db.Close
//Set db = Nothing
//Set rs = Nothing
//End Function

//Private Sub cmdExportarCheques_Click()
//MCheques.ExportaTablaChequesDisponibles
//End Sub

//Private Sub cmdImprimirOrdenPago_Click()
//    If Me.txtNumeroOP = "" Or IsNull(Me.txtNumeroOP) = True Then
//        MsgBox "La Orden de Pago no se encuentra Inicializada", vbCritical
//        Exit Sub
//    End If
//    DoCmd.OpenReport "OrdenPago_Header", acViewPreview, , , , Me.txtNumeroOP & "@1"
//End Sub

//Private Sub cmdModificarRetencion_Click()
//If IsNull(Me.txtNumeroOP) = True Then
//    MsgBox "La Orden de Pago no ha sido Inicializada", vbCritical
//    Exit Sub
//End If
//DoCmd.OpenForm "0215_DETALLE_RETENCIONES", acNormal, , , , acDialog, Me.txtNumeroOP
//ActualizaCalculosFacturas
//End Sub

//Private Sub cmdTAX_Click()
//DoCmd.OpenForm "TTAX", acNormal, , , , acDialog, "P@" & Me.txtIDProveedor & "@" & Me.txtCUIT
//'
//Me.txtAlicuotaRetIIBB = MTax.GETalicuotaRETIIBB(Me.txtIDProveedor, "RET_IB_BS", Me.txtFechaOP)
//Me.txtCoeficienteCM05 = MTax.GetAlicuotaCM05(Me.txtIDProveedor, Me.txtFechaOP)
//If IsNull(Me.txtNumeroOP) = False Then RECalculaRetenciones (Me.txtNumeroOP)
//Me.SF2_FACTURAS.Requery
//'
//End Sub

//Private Sub CREP1_Click()
//    MsgBox "No Listo"
//End Sub

//Private Sub CSALIR_Click()
//DoCmd.Close acForm, "0210_ORDENPAGOE", acSaveYes
//End Sub


//'---------------------------------------------------------------------------------------
//' Fecha Creacion : 03/02/2016
//' Proposito : Chequea si hay ordenes de pago existentes en estado INCIAL
//' Parametros:
//' Retorna   :
//'---------------------------------------------------------------------------------------
//Public Function ChequeaOPIniciadas(IDProveedor As Long) As Boolean
//If DCount("OP_STATUS", "T0210_OP_H", "OP_STATUS='INICIAL' AND PROV_ID=" & IDProveedor) > 0 Then
//    Select Case MsgBox("ATENCION -- " _
//        & vbCrLf & "" _
//        & vbCrLf & "Existen ordenes de pago para este proveedor en estado INICIAL" _
//        & vbCrLf & "Se recomienda salir y continuar con la OP anterior o bien cancelarla" _
//        & vbCrLf & "ya que pueden existir RETENCIONES tomadas para una factura que" _
//        & vbCrLf & "no será pagada." _
//        & vbCrLf & "" _
//        & vbCrLf & "DESEA CONTINUAR CON ESTA OP?" _
//        , vbYesNo Or vbQuestion Or vbDefaultButton2, "Ordenes de Pago Existentes")
//    Case vbYes
//        ChequeaOPIniciadas = True
//    Case vbNo
//        ChequeaOPIniciadas = False
//    End Select
//Else
//    ChequeaOPIniciadas = True
//End If
//End Function

//'---------------------------------------------------------------------------------------
//' Author    : Andres Mombelli
//' Fecha     : 10/09/2015
//' Proposito :
//' Parametros: @0 IDPROVEEDOR
//'                        @1 TIPO "L1", "L2" o "TipoLX"
//'                        @2 ConexionWsaa arba
//'                        @3 Numero OP
//' Ret