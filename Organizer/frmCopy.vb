Public Class frmCopy

    Private Sub frmCopy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtTopic.Text = frmMain.tv.SelectedNode.Text
        If frmMain.tv.SelectedNode.Nodes.Count = 0 Then
            chkChildren.Checked = False
            chkChildren.Enabled = False
        Else
            chkChildren.Checked = True
            chkChildren.Enabled = True
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Dim sTree As String = ""
        If chkFormatting.Checked Then
            sTree = ExtractBranchRTF(frmMain.tv.SelectedNode, chkChildren.Checked)
            Clipboard.SetData(DataFormats.Rtf, sTree)
        Else
            sTree = ExtractBranchText(frmMain.tv.SelectedNode, chkChildren.Checked)
            Clipboard.SetData(DataFormats.Text, sTree)
        End If
        Me.Close()

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class