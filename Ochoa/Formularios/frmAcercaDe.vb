Public Class frmAcercaDe
    Dim DX, DY As Integer

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmAcercaDe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblAutorizado.Text = "Productos de Maíz Ochoa, S.A. de C.V."
        lblUsuario.Text = "Pablo Ochoa Briseño"
        lblOpenSSL.Text = "Para hacer un CFD se utiliza el programa de OpenSSL"
        lblVersion.Text = String.Format("Versión {0}", Application.ProductVersion.ToString())
        lblTimbrado.Text = "SefacturaTestV2"
    End Sub

    Private Sub HyperlinkLabelControl1_HyperlinkClick(sender As Object, e As DevExpress.Utils.HyperlinkClickEventArgs) Handles hllCorreoSoporte.HyperlinkClick
        hllCorreoSoporte.LinkVisited = False
        System.Diagnostics.Process.Start(e.Link)
    End Sub

    Private Sub hllWebSite_HyperlinkClick(sender As Object, e As DevExpress.Utils.HyperlinkClickEventArgs) Handles hllWebSite.HyperlinkClick
        hllCorreoSoporte.LinkVisited = False
        System.Diagnostics.Process.Start(e.Link)
    End Sub

    Private Sub frmAcercaDe_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        ' Cuando se pulsa con el ratón
        DX = e.X
        DY = e.Y
    End Sub

    Private Sub frmAcercaDe_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        ' Cuando se mueve el ratón y se pulsa el botón izquierdo... mover el control
        If e.Button = MouseButtons.Left Then
            CType(sender, Control).Left = e.X + CType(sender, Control).Left - DX
            CType(sender, Control).Top = e.Y + CType(sender, Control).Top - DY
        End If
    End Sub
End Class