Imports System.Globalization
Imports System.IO
Imports System.Xml
Imports Sonda.Net
Imports Sonda.Net.Control
Imports Sonda.Net.Nxt

Public Class Versiones3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                Call CargaBin()
                Call CargaArchivosBin("Bin")
            End If
        Catch ex As Exception
            Dim myScript As String = "window.alert('" & ex.Message & "');"
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", myScript, True)
        End Try
    End Sub

    Private Sub CargaBin()
        Dim probing = ""
        Dim xmlDoc As XmlDocument = New XmlDocument()
        xmlDoc.Load(Server.MapPath("~/web.config"))
        Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(xmlDoc.NameTable)

        Try
            probing = xmlDoc.SelectSingleNode("//runtime", nsmgr).Item("assemblyBinding").Item("probing").Attributes(0).Value
        Catch ex As Exception
            probing = "bin"
        End Try

        Dim splits As String() = probing.Split(";")

        ddlBin.DataSource = splits
        ddlBin.DataBind()


    End Sub

    Private Sub CargaArchivosBin(ByVal BindeCarga As String,
                                 Optional ByVal Archivo As String = "",
                                 Optional ByVal Version As String = "",
                                 Optional ByVal Comentario As String = "",
                                 Optional ByVal FechaDesde As String = "",
                                 Optional ByVal FechaHasta As String = "",
                                 Optional ByVal FechaDesdeMod As String = "",
                                 Optional ByVal FechaHastaMOd As String = "")
        Try
            Dim s As String
            Dim sDirectorio, sArchivo, sComentario, sVersion As String
            Dim sFecha, sFechaMod, sFechaDesde, sFechaDesdeMod, sFechaHasta, sFechaHastaMod As DateTime
            Dim splitCreacion As String()
            Select Case Filtro_FechaCreacion.SelectedValue
                Case 0, 1, 2
                    splitCreacion = FechaDesde.Split("-")
                    sFechaDesde = splitCreacion(2) & "-" & splitCreacion(1) & splitCreacion(0)
                    sFechaHasta = DateTime.MaxValue
                Case 3
                    splitCreacion = FechaDesde.Split("-")
                    sFechaDesde = splitCreacion(2) & "-" & splitCreacion(1) & splitCreacion(0)
                    splitCreacion = FechaHasta.Split("-")
                    sFechaHasta = splitCreacion(2) & "-" & splitCreacion(1) & splitCreacion(0)
                Case 4
                    sFechaDesde = DateTime.MinValue
                    sFechaHasta = DateTime.MaxValue
            End Select

            Dim ds As New DataSet("DataSet")
            Dim dt As New DataTable("DataTable")
            ds.Tables.Add(dt)
            For Each s In New String() {"Archivo", "Version", "Fecha", "FechaM", "FechaA", "Tamano", "Comentario"}
                dt.Columns.Add(New DataColumn(s, GetType(String)))
            Next

            Dim theFiles() As String
            Dim dr As DataRow

            sDirectorio = Server.MapPath("") & "\" & BindeCarga
            theFiles = Directory.GetFiles(sDirectorio, "*.dll")

            Dim currentFiles As String
            For Each currentFiles In theFiles
                sArchivo = currentFiles.Substring(currentFiles.LastIndexOf("\") + 1)

                Dim Fdat As FileInfo = New FileInfo(sDirectorio & "\" & sArchivo)
                sComentario = FileVersionInfo.GetVersionInfo(sDirectorio & "\" & sArchivo).Comments.ToString()

                dr = ds.Tables(0).NewRow
                dr("Archivo") = sArchivo
                sVersion = FileVersionInfo.GetVersionInfo(sDirectorio & "\" & sArchivo).ProductVersion.ToString
                dr("Version") = sVersion
                sFecha = Fdat.CreationTime
                dr("Fecha") = Format(Fdat.CreationTime, "yyyy-MM-dd HH:mm")
                sFechaMod = Fdat.LastWriteTime
                dr("FechaM") = Format(Fdat.LastWriteTime, "yyyy-MM-dd HH:mm")
                dr("FechaA") = Format(Fdat.LastAccessTime, "yyyy-MM-dd HH:mm")
                dr("Tamano") = Format(Fdat.Length, "#,###,###,###")
                dr("Comentario") = IIf(True, sComentario.Replace(vbCrLf, "<br/>"), sComentario)

                If sArchivo.ToUpper().Contains(Archivo.ToUpper()) _
                    And sComentario.ToUpper().Contains(Comentario.ToUpper()) _
                    And sVersion.Contains(Version) _
                    And sFecha >= sFechaDesde _
                    And sFecha <= sFechaHasta Then
                    ds.Tables(0).Rows.Add(dr)
                End If

            Next
            ds.AcceptChanges()
            TablaPaginada1.DataSource = ds
            TablaPaginada1.DataBind()
            If ds.Tables(0).Rows().Count Then
                HypExportExcel.Visible = True
                HypExportWord.Visible = True
            Else
                HypExportExcel.Visible = False
                HypExportWord.Visible = False
            End If
        Catch ex As Exception
            Dim myScript As String = "window.alert('" & ex.Message & "');"
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", myScript, True)
        End Try

    End Sub

    Protected Sub ddlBin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBin.SelectedIndexChanged
        Try
            Call CargaArchivosBin(ddlBin.SelectedValue,
                                  txtNombre.Text.Trim(),
                                  txtVersion.Text.Trim(),
                                  txtComentario.Text.Trim())
        Catch ex As Exception
            Dim myScript As String = "window.alert('" & ex.Message & "');"
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", myScript, True)
        End Try
    End Sub

    Protected Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Try
            Call CargaArchivosBin(ddlBin.SelectedValue,
                                  txtNombre.Text.Trim(),
                                  txtVersion.Text.Trim(),
                                  txtComentario.Text.Trim())
        Catch ex As Exception
            Dim myScript As String = "window.alert('" & ex.Message & "');"
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", myScript, True)
        End Try
    End Sub

    Protected Sub HypExportWord_BeforeClick(sender As Object, e As ComponentModel.CancelEventArgs) Handles HypExportWord.BeforeClick
        Try

        Catch ex As Exception
            Dim myScript As String = "window.alert('" & ex.Message & "');"
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", myScript, True)
        End Try
    End Sub

    Protected Sub HypExportExcel_BeforeClick(sender As Object, e As ComponentModel.CancelEventArgs) Handles HypExportExcel.BeforeClick
        Try

        Catch ex As Exception
            Dim myScript As String = "window.alert('" & ex.Message & "');"
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", myScript, True)
        End Try
    End Sub

    Private Sub TablaPaginada1_Ordenar(sender As Object, e As TablaPaginadaOrdenarEventArgs) Handles TablaPaginada1.Ordenar
        Try

        Catch ex As Exception
            Dim myScript As String = "window.alert('" & ex.Message & "');"
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", myScript, True)
        End Try
    End Sub

    Protected Sub Filtro_FechaCreacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Filtro_FechaCreacion.SelectedIndexChanged
        Try
            Select Case Filtro_FechaCreacion.SelectedValue

                Case 0, 1, 2
                    FechaDesde.Enabled = True
                    FechaHasta.Enabled = False
                Case 3
                    FechaDesde.Enabled = True
                    FechaHasta.Enabled = True
                Case 4
                    FechaDesde.Enabled = False
                    FechaHasta.Enabled = False
            End Select

        Catch ex As Exception
            Dim myScript As String = "window.alert('" & ex.Message & "');"
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", myScript, True)
        End Try
    End Sub

    Protected Sub Filtro_FechaModificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Filtro_FechaModificacion.SelectedIndexChanged
        Try
            Select Case Filtro_FechaModificacion.SelectedValue

                Case 0, 1, 2
                    FechaDesdeMod.Enabled = True
                    FechaHastaMod.Enabled = False
                Case 3
                    FechaDesdeMod.Enabled = True
                    FechaHastaMod.Enabled = True
                Case 4
                    FechaDesdeMod.Enabled = False
                    FechaHastaMod.Enabled = False
            End Select

        Catch ex As Exception
            Dim myScript As String = "window.alert('" & ex.Message & "');"
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", myScript, True)
        End Try
    End Sub

    Protected Sub FechaHasta_TextChanged(sender As Object, e As EventArgs) Handles FechaHasta.TextChanged
        Try

        Catch ex As Exception

        End Try
    End Sub
End Class