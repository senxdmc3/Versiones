<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Versiones4.aspx.vb" Inherits="WebFinVersiones.Versiones4" %>

<%@ Register TagPrefix="snt" Namespace="Sonda.Net.Control" Assembly="SondaNetWebUI" %>

<!DOCTYPE html>
<%--<link href="Styles.css" rel="stylesheet" />--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Scripts/jquery-1.9.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/moment.js"></script>
    <script src="Scripts/bootstrap-datetimepicker.js"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <script type="text/javascript">
        $(function () {
            $('#FechaDesde').datetimepicker();
            $('#FechaHasta').datetimepicker();
            $('#FechaDesdeMod').datetimepicker();
            $('#FechaHastaMod').datetimepicker();

        });
        </script>
    <style>
        .table td, .table th {
            padding: .25rem;
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-12">
                <div class="card small">
                    <div class="card-header bg-warning ">
                        Información de Bibliotecas
                    </div>
                    <div class="card-body">
                        <div class="card">
                            <div class="card-header bg-warning ">
                                Criterio de Búsqueda
                            </div>
                            <div class="card-body form-row">
                                    <div class="form-group col-md-2">
                                        <label for="txtNombre">Bins</label>
                                        <asp:DropDownList ID="ddlBin" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="txtNombre">Nombre Archivo</label>
                                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre Archivo"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-3">
                                        <label for="txtVersion">Versión</label>
                                        <asp:TextBox ID="txtVersion" runat="server" CssClass="form-control" placeholder="Versión"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-3">
                                        <label for="txtNombre">Comentario</label>
                                        <asp:TextBox ID="txtComentario" runat="server" CssClass="form-control" placeholder="Comentario"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="txtNombre">Fecha Creación</label>
                                        <asp:DropDownList ID="Filtro_FechaCreacion" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="0">=</asp:ListItem>
                                            <asp:ListItem Value="1">&gt;=</asp:ListItem>
                                            <asp:ListItem Value="2">&lt;=</asp:ListItem>
                                            <asp:ListItem Value="3">Entre</asp:ListItem>
                                            <asp:ListItem Value="4" Selected="True">Seleccionar</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class='form-group date col-md-2'>
                                        <label for="FechaDesde">Desde</label>
                                        <asp:TextBox ID="FechaDesde" runat="server" CssClass="form-control" placeholder="Desde"></asp:TextBox>
                                    </div>
                                    <div class='form-group date col-md-2'>
                                        <label for="FechaHasta">Hasta</label>
                                        <asp:TextBox ID="FechaHasta" runat="server" CssClass="form-control" placeholder="Hasta"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="txtNombre">Fecha Modificación</label>
                                        <asp:DropDownList ID="Filtro_FechaModificacion" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="0">=</asp:ListItem>
                                            <asp:ListItem Value="1">&gt;=</asp:ListItem>
                                            <asp:ListItem Value="2">&lt;=</asp:ListItem>
                                            <asp:ListItem Value="3">Entre</asp:ListItem>
                                            <asp:ListItem Value="4" Selected="True">Seleccionar</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class='form-group date col-md-2'>
                                        <label for="FechaDesdeMod">Desde</label>
                                        <asp:TextBox ID="FechaDesdeMod" runat="server" CssClass="form-control" placeholder="Desde"></asp:TextBox>
                                    </div>
                                    <div class='form-group date col-md-2'>
                                        <label for="FechaHastaMod">Hasta</label>
                                        <asp:TextBox ID="FechaHastaMod" runat="server" CssClass="form-control" placeholder="Hasta"></asp:TextBox>
                                    </div>
                                    <div class="offset-md-10 col-md-2">
                                        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" CssClass="btn btn-outline-secondary  d-inline float-right"/>
                                   </div>
                            </div>
                            <div class="card">
                                <div class="card-header bg-success ">
                                <h6 class="d-md-inline s">Resultados
                                    <span class="d-inline float-right"
                                        <snt:HyperLink ID="HypExportWord" runat="server" AutoPostBack="True" ImageUrl="..\Img\word.gif"
                                    Visible="False" CssClass="HyperLink"></snt:HyperLink>
                                        <snt:HyperLink ID="HypExportExcel" runat="server" AutoPostBack="True" ImageUrl="..\Img\excel.gif"
                                        Visible="False" CssClass="HyperLink"></snt:HyperLink>
                                    </span>
                                </h6>
                                </div>
                                <div class="card-body">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" CssClass="table table-striped table-hover" Style="">
                                    <Columns>
                                        <asp:BoundField HeaderText="Archivo" DataField="Archivo" />
                                        <asp:BoundField HeaderText="Versión" DataField="Version" />
                                        <asp:BoundField HeaderText="Fecha Creación" DataField="Fecha" >
                                        <ItemStyle Width="130px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Fecha modificación" DataField="FechaM" >
                                        <ItemStyle Width="130px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Tamaño(Bytes)" DataField="Tamano" >
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Comentario" DataField="Comentario" />
                                    </Columns>

                                </asp:GridView>
                                    </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </form>
</body>
</html>
