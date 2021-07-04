Imports dllMsSQL

Public Class frmReparto
    Private Sub frmReparto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cmb_precio.Properties.DataSource = CatTipoPrecio.GetTipoPrecio()
        cmb_precio.Properties.ValueMember = "IdTP"
        cmb_precio.Properties.DisplayMember = "TipoPrecio"
        cmb_precio.Properties.PopulateViewColumns()
    End Sub
End Class