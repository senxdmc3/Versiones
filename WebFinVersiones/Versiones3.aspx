<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Versiones3.aspx.vb" Inherits="WebFinVersiones.Versiones3" %>

<%@ Register TagPrefix="snt" Namespace="Sonda.Net.Control" Assembly="SondaNetWebUI" %>

<!DOCTYPE html>
<link href="Styles.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table id="Table4" cellspacing="0" cellpadding="0" width="1100" align="center" border="0">
            <tr>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                <td>
                    <table id="Table6" class="tablatit" cellspacing="0" cellpadding="0" width="95%">
                        <tr>
                            <td class="titppal"></td>
                            <td class="titppal2">
                                <snt:Label ID="lblTitulo" runat="server" Tipo="NombreCampo" CssClass="TituloV70"> Información de Bibliotecas</snt:Label></td>
                            <td class="titppal3"></td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td class="C_left"></td>
                <td class="C_center"></td>
                <td class="C_right"></td>
            </tr>
            <tr>
                <td class="C_left2"></td>
                <td>
                    <table cellspacing="0" cellpadding="0" width="50%">
                        <tr>
                            <td class="tit_left"></td>
                            <td class="tit_center">
                                <asp:Label ID="Label17" runat="server"> Criterio de Búsqueda</asp:Label></td>
                            <td class="tit_right"></td>
                        </tr>
                    </table>
                    <table id="Table7" class="TableContenido1" cellspacing="0" cellpadding="0" width="1100"
                        border="0">
                        <tr>
                            <td>
                                <snt:DataPanel ID="dpgenerica" runat="server">
                                    <table id="Table1" border="0" cellspacing="1" cellpadding="1" width="850">
                                        <tr>
                                            <td style="width: 321px" class="label">
                                                <snt:Label ID="Label3" Tipo="NombreCampo" runat="server">Bins</snt:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 321px" class="casilla">
                                                <snt:DropDownList ID="ddlBin" Tipo="NombreCampo" runat="server" AutoPostBack="True"
                                                    Width="200px" TextoDatoVacio=" " GuardarEnHistoria="True"
                                                    TipoCase="MAYUSCULAS">
                                                </snt:DropDownList></td>
                                        </tr>
                                    </table>

                                    <table id="Table23" border="0" cellspacing="1" cellpadding="1" width="850">
                                        <tr>
                                            <td style="width: 236px; height: 20px" class="label">
                                                <snt:Label ID="Label14" Tipo="NombreCampo" runat="server">Nombre</snt:Label></td>
                                            <td style="width: 236px; height: 20px" class="label">
                                                <snt:Label ID="Label1" Tipo="NombreCampo" runat="server">Versión</snt:Label></td>
                                            <td style="width: 294px; height: 20px" class="label">
                                                <snt:Label ID="Label18" Tipo="NombreCampo" runat="server">Comentario</snt:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 49px" class="casilla">
                                                <snt:TextBoxAdv ID="txtNombre" Tipo="NombreCampo" runat="server" GuardarEnHistoria="True" Width="200px"
                                                    MaxLength="40" TipoCase="TextoLibre"></snt:TextBoxAdv></td>
                                            <td style="width: 23px" class="casilla">
                                                <snt:TextBoxAdv ID="txtVersion" Tipo="NombreCampo" runat="server" GuardarEnHistoria="True" Width="200px"
                                                    MaxLength="40" TipoCase="TextoLibre"></snt:TextBoxAdv></td>
                                            <td style="width: 368px" class="casilla">
                                                <snt:TextBoxAdv ID="txtComentario" Tipo="NombreCampo" runat="server" GuardarEnHistoria="True" Width="368px"
                                                    MaxLength="40" TipoCase="TextoLibre"></snt:TextBoxAdv></td>
                                        </tr>
                                    </table>
                                    <table id="Table13" border="0" cellspacing="1" cellpadding="1" width="850">
                                        <tr>
                                            <td style="width: 141px; height: 20px" class="label">
                                                <snt:Label ID="Label7" Tipo="NombreCampo" runat="server" Width="120px">Filtro</snt:Label></td>
                                            <td style="width: 236px; height: 20px" class="label" colspan="4">
                                                
                                                <snt:Label ID="Label16" Tipo="NombreCampo" runat="server">Fecha Creación</snt:Label></td>
                                            <td style="width: 25px; height: 20px" class="label">
                                                <snt:Label ID="Label12" Tipo="NombreCampo" runat="server" Width="104px">Filtro</snt:Label></td>
                                            <td style="width: 294px; height: 20px" class="label" colspan="4">
                                                <snt:Label ID="Label27" Tipo="NombreCampo" runat="server">Fecha Modificación</snt:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 141px" class="casilla">
                                                <snt:DropDownList ID="Filtro_FechaCreacion" Tipo="NombreCampo" runat="server" GuardarEnHistoria="True" Width="110px"
                                                    AutoPostBack="True">
                                                    <asp:ListItem Value="0">=</asp:ListItem>
                                                    <asp:ListItem Value="1">&gt;=</asp:ListItem>
                                                    <asp:ListItem Value="2">&lt;=</asp:ListItem>
                                                    <asp:ListItem Value="3">Entre</asp:ListItem>
                                                    <asp:ListItem Value="4" Selected="True">Seleccionar</asp:ListItem>
                                                </snt:DropDownList></td>
                                            <td style="width: 49px" class="label">
                                                <snt:Label ID="Label6" Tipo="NombreCampo" runat="server" Width="38px" Height="6px">Desde</snt:Label></td>
                                            <td style="width: 16px" class="casilla">
                                                <snt:TextBoxAdv ID="FechaDesde" Tipo="NombreCampo" runat="server" GuardarEnHistoria="True" Enabled="False"></snt:TextBoxAdv></td>
                                            <td style="width: 7px" class="label">
                                                <snt:Label ID="Label8" Tipo="NombreCampo" runat="server">Hasta</snt:Label></td>
                                            <td style="width: 23px" class="casilla">
                                                <snt:TextBoxAdv ID="FechaHasta" Tipo="NombreCampo" runat="server" GuardarEnHistoria="True" Enabled="False"></snt:TextBoxAdv></td>
                                            <td style="width: 25px" class="casilla">
                                                <snt:DropDownList ID="Filtro_FechaModificacion" Tipo="NombreCampo" runat="server" GuardarEnHistoria="True"
                                                    Width="104px" AutoPostBack="True">
                                                    <asp:ListItem Value="0">=</asp:ListItem>
                                                    <asp:ListItem Value="1">&gt;=</asp:ListItem>
                                                    <asp:ListItem Value="2">&lt;=</asp:ListItem>
                                                    <asp:ListItem Value="3">Entre</asp:ListItem>
                                                    <asp:ListItem Value="4" Selected="True">Seleccionar</asp:ListItem>
                                                </snt:DropDownList></td>
                                            <td style="width: 49px" class="label">
                                                <snt:Label ID="Label10" Tipo="NombreCampo" runat="server" Width="34px">Desde</snt:Label></td>
                                            <td style="width: 74px" class="casilla">
                                                <snt:TextBoxAdv ID="FechaDesdeMod" Tipo="NombreCampo" runat="server" GuardarEnHistoria="True" Enabled="False"></snt:TextBoxAdv>

                                            </td>
                                            <td style="width: 11px" class="label">
                                                <snt:Label ID="Label21" Tipo="NombreCampo" runat="server">Hasta</snt:Label></td>
                                            <td style="width: 70px" class="casilla">
                                                <snt:TextBoxAdv ID="FechaHastaMod" Tipo="NombreCampo" runat="server" GuardarEnHistoria="True" Enabled="False"></snt:TextBoxAdv></td>
                                        </tr>
                                    </table>
                                </snt:DataPanel>
                                <table id="Table3" style="width: 1100px; height: 38px" cellspacing="1" cellpadding="1" width="850"
                                    border="0">
                                    <tr>
                                        <td align="right">
                                            <snt:Button ID="BtnBuscar" CssClass="btnBuscar" Tipo="Buscar" runat="server"></snt:Button></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table id="Table10" cellspacing="0" cellpadding="0" width="1100">
                        <tr>
                            <td class="tit_left" width="30"></td>
                            <td class="tit_center" style="width: 238px">
                                <snt:Label ID="Label22" CssClass="SubTituloV70" Tipo="NombreCampo" runat="server"> Resultados</snt:Label></td>
                            <td class="tit_right" width="30" align="right"></td>
                            <td style="width: 704px" align="right">
                                <snt:HyperLink ID="HypExportWord" runat="server" AutoPostBack="True" ImageUrl="..\Img\word.gif"
                                    Visible="False" CssClass="HyperLink"></snt:HyperLink><snt:HyperLink ID="HypExportExcel" runat="server" AutoPostBack="True" ImageUrl="..\Img\excel.gif"
                                        Visible="False" CssClass="HyperLink"></snt:HyperLink></td>
                        </tr>
                    </table>
                    <table id="Table9" class="TableContenido1" cellspacing="0" cellpadding="0" width="1100"
                        border="0">
                        <tr>
                            <td>
                                <table id="Table12" cellspacing="1" cellpadding="1" width="1100" border="0">
                                    <tr>
                                        <td>
                                            <snt:TablaPaginada ID="TablaPaginada1" runat="server" NroRegistros="0">
                                                <snt:TablaPaginadaColumna Ancho="" Titulo="Archivo" ColId="Col1" NombreCampo="Archivo" />
                                                <snt:TablaPaginadaColumna Ancho="" Titulo="Versión" ColId="Col2" NombreCampo="Version" Formato="Personalizado" FormatoPersonalizado="<p align=right>{0}</p>" />
                                                <snt:TablaPaginadaColumna Ancho="120px" Titulo="Fecha Creación" ColId="Col3" NombreCampo="Fecha" Formato="Personalizado" FormatoPersonalizado="<p align=right>{0}</p>" />
                                                <snt:TablaPaginadaColumna Ancho="120px" Titulo="Fecha Modificación" ColId="Col4" NombreCampo="FechaM" Formato="Personalizado" FormatoPersonalizado="<p align=right>{0}</p>" />
                                                <snt:TablaPaginadaColumna Ancho="" Titulo="Tamaño<br/>(Bytes)" ColId="Col6" NombreCampo="Tamano" Formato="Personalizado" FormatoPersonalizado="<p align=right>{0}</p>" />
                                                <snt:TablaPaginadaColumna Ancho="" Titulo="Comentario" ColId="Col7" NombreCampo="Comentario" />
                                            </snt:TablaPaginada>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>

                </td>
                <td class="C_right2" width="13"></td>
            </tr>
            <tr>
                <td class="C_left3"></td>
                <td class="C_bottom"></td>
                <td class="C_right3"></td>
            </tr>
        </table>
    </form>
</body>
</html>
