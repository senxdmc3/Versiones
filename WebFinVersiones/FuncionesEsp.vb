Imports Sonda.Net
Imports Sonda.Gestion.Adm.WEB

Module FuncionesEsp
    '--Este codigo es para extraer los errores correspondientes a venta 
    'de la db de Desarrollo y generar los insert
    '
    'Declare @Codi char(250)
    ',        @Codi2 char(250)
    'set @Codi="INSERT INTO SYS_SONDAEXCEPTION ( CODIGO, DESCRIPCION, TIPO, SEVERIDAD, PROCESONEGOCIO, ESTADO_REG,FEC_ESTADO_REG, FEC_ING_REG, ID_USUARIO_ING_REG, FEC_ULT_MODIF_REG, ID_USUARIO_ULT_MODIF_REG,ID_FUNCION_ULT_MODIF_REG )  VALUES ("
    'set @Codi2=",1,1,'VTA','V','02/03/2003','02/03/2003', 'MARTINEZ','02/03/2003','MARTINEZ', 'SECCIONES')"
    'select rtrim(@Codi) 
    '     , rtrim(str(Codigo,5)) + ",'" + rtrim(DESCRIPCION) + "'" +RTrim(@Codi2) 
    'from SYS_SONDAEXCEPTION where CODIGO>=60000 and  CODIGO<=60999
    Public dsComunas As DataSet
    Public Defv_String As String = " "
    Public Msg_ErrorOnwer As Integer = 60000 'Fue Imposible Lee Owner"
    Public Msg_ErrorPeriodo As Integer = 60001 'No Existe periodo para la Empresa Selecionada"
    Public Msg_ErrorConfPer As Integer = 60002 'No Existe Configuracion Para este Periodo"
    Public Msg_ErrorNvExiste As Integer = 60003 'Numero Nota Venta Existe"
    Public Msg_ErrorClVigente As Integer = 60004 'Cliente no esta Vigente"
    Public Msg_ErrorClBloqueado As Integer = 60005 'Cliente se encuentra Bloqueado"
    Public Msg_ErrorCliNoExisEmp As Integer = 60006 'Error, Cliente no Existe para la Empresa."
    Public Msg_ErrorExisteNotaV As Integer = 60007 'Numero de Nota Venta ya Existe"
    Public Msg_ErrorNoExistePro As Integer = 60008 'Producto No Existe"
    Public Msg_ErrorProducNoVigente As Integer = 60009 'Producto No  Vigente"
    Public Msg_ErrorLagoPemitido As Integer = 60010 'Largo exedido en campo :"
    Public Msg_ErrorNumDoctoRango As Integer = 60011 'Numero hasta debe ser mayor a Numero desde"
    Public Msg_ErrorFecDoctoRango As Integer = 60012 'Fecha hasta debe ser mayor a Fecha desde"
    Public Msg_ErrorInfCfgIva As Integer = 60013 'Nota de Venta Afecta,No se a Informado % de Iva en Configuración!!!"
    Public Msg_ErrorNoGeneroCierre As Integer = 60014 'No se pudo Generar Cierre!!!"
    Public Msg_ErrorSeleccionarItem As Integer = 60015 'Debe Selecionar Nota Venta"
    Public Msg_ErrorDebeIngresarOc As Integer = 60016 'Debe Ingresar Orden de Compra"
    Public Msg_ErrorDebeIngresarRut As Integer = 60017 'Debe Ingresar Rut Cliente"
    Public Msg_ErrorDebeIngresarSuc As Integer = 60018 'Debe Seleccionar Sucursal"
    Public Msg_ErrorDebeIngresarCodArt As Integer = 60019 'Debe Ingresar Codigo Articulo"
    Public Msg_ErrorDebeIngresarEmpresa As Integer = 60020 'Debe Ingresar Empresa"
    Public Msg_ErrorDebeIngresaDivision As Integer = 60021 'Debe Ingresar Division"
    Public Msg_ErrorDebeIngresaUnidad As Integer = 60022 'Debe Ingresar Unidad"
    Public Msg_ErrorDebeIngresarMonedaCab As Integer = 60023 'Debe Ingresar Moneda Oc"
    Public Msg_ErrorDebeIngresarTipoVenta As Integer = 60024 'Debe Selecionar Tipo Venta"
    Public Msg_ErrorDebeIngresarNv As Integer = 60025 'Debe Ingresar Nro. Venta"
    Public Msg_ErrorDebeIngresarTipoDocto As Integer = 60026 'Debe Ingresar Tipo Documento"
    Public Msg_ErrorDebeIngresarCantDocto As Integer = 60027 'Debe Ingresar Cantidad Solicitada"
    Public Msg_ErrorDebeIngresarPrecioUnitario As Integer = 60028 'Debe Ingresar Precio Unitario"
    Public Msg_ErrorDebeIngresarFecEntrega As Integer = 60029 'Debe Ingresar Fecha Entrega"
    Public Msg_ErrorDebeIngresarCondPago As Integer = 60030 'Debe Ingresar Condicion Pago"
    Public Msg_ErrorDebeIngresarObsOc As Integer = 60031 'Debe Ingresar Observacion Oc"
    Public Msg_ErrorDebeIngresarMonOc As Integer = 60032 'Debe Ingresar Moneda Oc"
    Public Msg_ErrorDebeIngresarUniMed As Integer = 60033 'Debe Seleccionar Unidad Medida"
    Public Msg_ErrorDebeIngresarFechaNV As Integer = 60034 'Debe Ingresar Fecha Nota Pedido"
    Public Msg_ErrorTipoParidad As Integer = 60035 'Debe Ingresar Tipo Paridad"
    Public Msg_ErrorDebeCondicionDePago As Integer = 60036 'Debe Ingresar Condicion de Pago"
    Public Msg_ErrorDebeIngresarVenta As Integer = 60037 'Debe Ingresar Venta"
    Public Msg_ErrorTipoNotaPedido As Integer = 60038 'Debe Ingresar Tipo Nota Pedido"
    Public Msg_ErrorDebeIngresarVendedor As Integer = 60039 'Debe Ingresar Vendedor"
    Public Msg_ErrorNoExistenEmpAsociUso As Integer = 60040 'No Existen Empresas Asociadas al Usuario"
    Public Msg_ErrorIngresarFechaSolicitada As Integer = 60085 'Debe Ingresar Fecha Solicitada"
    Public Msg_ErrorIngresarFechaEntrega As Integer = 60048 'Debe Ingresar Fecha de Entrega"
    Public Msg_ErrorNoExisteConfiguracionContable As Integer = 60086 'No Existe Configuracion Contable
    Public Msg_ErrorLeerPeriodoVenta As Integer = 60087 'No se Pudo Leer Periodo de Configuracion segun fecha
    Public Msg_ErrorFecInvalidaPerCerrado As Integer = 60088 'Fecha Invalida Perido de venta esta Cerrado
    Public Msg_ErrorDebeIngresarCodUbicacion As Integer = 60089 'Debe Ingresar Codigo Ubicacion
    Public Msg_ErrorDebeIngresarCodBodega As Integer = 60090 ''Debe Ingresar Codigo Bodega
    Public Msg_ErrorDebeIngresarOperacion As Integer = 60091 ' Debe Ingresar Operacion
    Public Msg_ErrorPUnitarioDebeSerMayorIgualCero As Integer = 60092
    Public Msg_ErrorCantidadDebeSerMayorIgualCero As Integer = 60093
    Public Msg_ErrorNoExiteCCMov209 As Integer = 60094
    Public Msg_ErrorLeeNiveldeCliente As Integer = 60095
    Public Msg_ErrorCCRel As Integer = 60096
    Public Msg_ErrorExisteCCVendedor As Integer = 60097
    Public Msg_ErrorCCMarca As Integer = 60098
    Public Msg_ErrorValoresLineaProducto As Integer = 60099
    Public Msg_ErrorDebeIngresarTipoProyecto As Integer = 60100
    Public Msg_ErrorDebeIngresarNumeroProyecto As Integer = 60101
    Public Msg_ErrorDebeIngresarCentroImputacion As Integer = 60102
    Public Msg_ErrorDebeIngresarCentroCosto As Integer = 60103
    Public Msg_ErrorCCNoExisteEnCuentaAsociada As Integer = 60104
    Public Msg_ErrorFolioIngresadoYaExiste As Integer = 60105
    Public Msg_ErrorDebeIngresarFolio As Integer = 60106
    Public Defv_FechaNula As Date = "#01/01/1900#"
    Public Defv_DecimalNulo As Decimal = 0
    Public Defv_IntegerNulo As Integer = 0
    Public Defv_StringNulo As String = " "
    Public Defv_RutNulo As String = "0000000000-0"
    Public Enum Defv_ValorDefecto
        Defv_DecimalNulo = 0
        Defv_IntegerNulo = 1
        Defv_StringNulo = 2
        Defv_RutNulo = 3
        Defv_FechaNula = 4
    End Enum
    Public Enum Valida
        Numericos = 0
        Fechas = 1
    End Enum

    Public Const glosaindbeneficiario = "INDBENEFICIARIO"
    Public Const glosamoneda = "MONEDA"
    Public Const glosaindaplica = "INDAPLICA"
    Public Const glosasexo = "SEXO"
    Public Const glosaestadosol = "ESTADOSOL"
    Public Const glosaformapago = "FORMAPAGO"
    Public Const glosamespago = "MESPAGO"
    Public Const glosapagoautomatico = "PAGOAUTOMATICO"
    Public Const glosaperiodicidad = "PERIODICIDAD"
    Public Const glosatipo = "TIPO"
    Public Const glosatipoagrupacion = "TIPOAGRUPACION"
    Public Const glosatipoapertura = "TIPOAPERTURA"
    Public Const glosatipocarencia = "TIPOCARENCIA"

    Public Sub GuardaHistoria(ByVal Panta As Object, ByVal Estado As Boolean)
        Dim X As Integer

        For X = 0 To Panta.Count - 1
            If Panta.item(X).GetType.FullName = "Sonda.Net.Control.TextBox" _
               Xor Panta.item(X).GetType.FullName = "Sonda.Net.Control.CheckBox" _
               Xor Panta.item(X).GetType.FullName = "Sonda.Net.Control.DropDownList" _
               Xor Panta.item(X).GetType.FullName = "Sonda.Net.Control.Fecha" _
               Then
                Panta.Item(X).GuardarEnHistoria = Estado
            End If
        Next
    End Sub
    Public Sub EnabledTodo(ByVal Panta As Object, ByVal Estado As Boolean)
        Dim X As Integer

        For X = 0 To Panta.Count - 1
            If Panta.item(X).GetType.FullName = "Sonda.Net.Control.TextBox" _
               Xor Panta.item(X).GetType.FullName = "Sonda.Net.Control.CheckBox" _
               Xor Panta.item(X).GetType.FullName = "Sonda.Net.Control.DropDownList" _
               Xor Panta.item(X).GetType.FullName = "Sonda.Net.Control.Fecha" _
               Then
                Panta.Item(X).Enabled = Estado
            End If
        Next
    End Sub
    Public Function CmrBuscarEnCombo(ByVal ObjNetDesde As Object, ByVal ObjNetHasta As Object)
        Try
            If ObjNetHasta.GetType.FullName = "Sonda.Net.Control.DropDownList" Then
                If Not IsNothing(ObjNetHasta.Items.FindByValue(ObjNetDesde.Text)) Then
                    ObjNetHasta.SelectedValue = ObjNetHasta.Items.FindByValue(ObjNetDesde.Text).Value
                Else
                    ObjNetHasta.Selectedindex = ObjNetHasta.Items.Count - 1
                    ObjNetDesde.Text = ""
                End If
            End If
            If ObjNetHasta.GetType.FullName = "Sonda.Net.Control.TextBox" Then
                ObjNetHasta.text = ObjNetDesde.SelectedValue
            End If

        Catch ex As SondaException
            If ObjNetHasta.GetType.FullName = "Sonda.Net.Control.DropDownList" Then
                ObjNetHasta.SelectedValue = ""
            End If
        Catch ex As Exception
            If ObjNetHasta.GetType.FullName = "Sonda.Net.Control.DropDownList" Then
                ObjNetHasta.SelectedValue = ""
            End If
        End Try

    End Function
    Public Sub ControlCheck(ByVal Caja As Object, ByVal Controles As Object)

    End Sub
    'Public Function FormatoRut(ByVal Rut As String) As String

    '    FormatoRut = Val(Left(Rut.Trim, Len(Rut.Trim) - 1)).ToString + "-" + Right(Rut.Trim, 1)
    'End Function

    Public Function ExisteRegistro(ByVal DataSet As DataSet) As Boolean
        ExisteRegistro = False
        If IsNothing(DataSet) Then
            Exit Function
        End If
        If DataSet.Tables.Count = 0 Then
            Exit Function
        End If
        If DataSet.Tables(0).Rows.Count <= 0 Then
            Exit Function
        End If

        ExisteRegistro = True
    End Function
    Public Function FormarRutdb(ByVal Rut As String)
        If Rut.Trim <> "" Then
            FormarRutdb = Right("000000000" + Rut.Trim, 12)
        Else
            Rut = "0000000000-0"
        End If
    End Function

    Function LeeParametro(ByVal Ds As DataSet, ByVal Parametro As String) As Object
        If Not IsDBNull(Ds.Tables("OUTPUTPARAMS").Rows(0).Item(Parametro)) Then
            LeeParametro = Ds.Tables("OUTPUTPARAMS").Rows(0).Item(Parametro)
        End If
    End Function
    Function Vbg_Parametros(ByVal Obj As Object, ByVal ValorDefecto As FuncionesEsp.Defv_ValorDefecto) As Object
        Select Case Obj.GetType.FullName
            Case "Sonda.Net.Control.TextBox", "Sonda.Net.Control.Rut"
                Vbg_Parametros = IIf(Obj.Text.Trim <> "", Obj.Text, ValorDefecto)
            Case "Sonda.Net.Control.CheckBox"
                Vbg_Parametros = IIf(Obj.Checked = True, 1, 0)
            Case "Sonda.Net.Control.DropDownList"
                Vbg_Parametros = IIf(Obj.SelectedValue <> "", Obj.SelectedValue, Defv_StringNulo)
            Case "Sonda.Net.Control.Fecha"
                Vbg_Parametros = IIf(Obj.Text.Trim <> "", Obj.Text, ValorDefecto)
        End Select


    End Function
    Function Vbg_ValCampos(ByVal Caja As Object, ByVal Validacion As Valida) As Boolean
        '        Numericos = 0
        '       Fechas = 1

        Vbg_ValCampos = False
        If Validacion = 0 Then
            If Not IsNumeric(Caja.text) Then
                Caja.text = ""
                Exit Function
            End If
        End If
        If Validacion = 1 Then
            If Caja.GetType.FullName = "Sonda.Net.Control.Fecha" Then
                If Not IsDate(Caja.VALUE) Then
                    Caja.Value = ""
                    Exit Function
                End If
                If Len(Caja.VALUE) < 10 Then
                    Caja.Value = ""
                    Exit Function
                End If
            End If
            If Caja.GetType.FullName = "Sonda.Net.Control.TextBox" Then
                If Not IsDate(Trim(Caja.Text)) Then
                    Caja.Text = ""
                    Exit Function
                End If
                If Len(Trim(Caja.Text)) < 10 Then
                    Caja.Text = ""
                    Exit Function
                End If

            End If

        End If

        Vbg_ValCampos = True
    End Function
    Public Function Vbg_FormatFechas(ByVal Fecha As Object) As String
        Dim pFecha As Date
        pFecha = Fecha
        If pFecha <= Defv_FechaNula Then
            Fecha = Nothing
        End If
        Vbg_FormatFechas = Fecha

    End Function

    Public Function Vbg_Mensaje(ByVal Codigo As Integer) As String
        Dim msg As New SondaException(Codigo)
        Vbg_Mensaje = msg.Message
    End Function
    Public Function FormateaFechaenBlanco(ByRef fecFecha As Object) As Object
        Dim auxFecha As String
        auxFecha = Replace(Replace(Left(fecFecha, 10), "-", ""), "/", "")

        If auxFecha <> "01011900" Then
            FormateaFechaenBlanco = fecFecha
        Else
            FormateaFechaenBlanco = Nothing
        End If
    End Function
    Public Function FormatoRut(ByVal Rut As String, ByVal Formato As String) As String
        'Funcion da Formato a string de Rut para webmethod(W) y Formato de Texto(T)
        If InStr(Rut, "-") = 0 Or Rut = " " Or Len(Rut) = 0 Then FormatoRut = " " : Exit Function
        Select Case Formato
            Case "T"
                FormatoRut = Val(Mid(Rut, 1, InStr(Rut, "-"))) & (Mid(Rut, InStr(Rut, "-"), 2))
            Case "W"
                FormatoRut = Mid("0000000000", 1, (12 - Len(Rut.Trim))) + Rut.Trim
        End Select
    End Function
    Public Function Exportaciones(ByVal Page As System.Web.UI.Page, ByVal ds As DataSet, ByVal TipoExportar As Integer)
        If ds.Tables(0).Rows.Count = 0 Then Exit Function
        If TipoExportar = 0 Then
            Exportar.Exportar(Page, Exportar.TipoExportacion.Word, ds)
        Else
            Exportar.Exportar(Page, Exportar.TipoExportacion.Excel, ds)
        End If
    End Function
End Module
