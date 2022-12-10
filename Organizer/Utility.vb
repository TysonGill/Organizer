Module Utility

    Friend dtTree As DataTable

    Friend Function ExtractBranchTable(ByVal TopNode As TreeNode, Optional ByVal Recursive As Boolean = True) As DataTable
        Try
            Cursor.Current = Cursors.WaitCursor

            ' Copy top node
            Dim dtBranch As DataTable = dtTree.Clone
            dtBranch.ImportRow(TopNode.Tag)
            If Not Recursive Then Return dtBranch

            ' Copy child nodes recursively
            For Each n As TreeNode In TopNode.Nodes
                dtBranch.ImportRow(n.Tag)
                ExtractBranchTableRecursive(dtBranch, n)
            Next

            Return dtBranch

        Catch ex As System.Exception
            MessageBox.Show(ex.Message, "Organizer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return dtTree.Clone
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Sub ExtractBranchTableRecursive(ByRef dt As DataTable, ByVal NodeIn As TreeNode)
        For Each n As TreeNode In NodeIn.Nodes
            dt.ImportRow(n.Tag)
            ExtractBranchTableRecursive(dt, n)
        Next
    End Sub

    Friend Function ExtractBranchRTF(ByVal TopNode As TreeNode, Optional ByVal Recursive As Boolean = True) As String
        Try
            Cursor.Current = Cursors.WaitCursor

            ' Copy top node
            Dim rtfBranch As String = ""
            rtfBranch = AppendRTF(rtfBranch, TopNode.Tag("Description"))
            rtfBranch = AppendRTF(rtfBranch, TopNode.Tag("Tag"))
            If Not Recursive Then Return rtfBranch

            ' Copy child nodes recursively
            For Each n As TreeNode In TopNode.Nodes
                rtfBranch = AppendRTF(rtfBranch, n.Tag("Description"))
                rtfBranch = AppendRTF(rtfBranch, n.Tag("Tag"))
                ExtractBranchRTFRecursive(rtfBranch, n)
            Next

            Return rtfBranch

        Catch ex As System.Exception
            MessageBox.Show(ex.Message, "Organizer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Sub ExtractBranchRTFRecursive(ByRef rtfBranch As String, ByVal NodeIn As TreeNode)
        For Each n As TreeNode In NodeIn.Nodes
            rtfBranch = AppendRTF(rtfBranch, n.Tag("Description"))
            rtfBranch = AppendRTF(rtfBranch, n.Tag("Tag"))
            ExtractBranchRTFRecursive(rtfBranch, n)
        Next
    End Sub

    Friend Function AppendRTF(ByVal rtf1 As String, ByVal rtf2 As String) As String
        Dim rtbTmp As New RichTextBox
        Dim datobj As New System.Windows.Forms.DataObject
        If rtf1.StartsWith("{\rtf1") Then
            rtbTmp.Rtf = rtf1
        Else
            rtbTmp.Text = rtf1
        End If
        rtbTmp.AppendText(vbCrLf)
        datobj.SetData(DataFormats.Rtf, rtf2)
        Clipboard.SetDataObject(datobj)
        rtbTmp.SelectionStart = rtbTmp.TextLength
        rtbTmp.Paste()
        Return rtbTmp.Rtf
    End Function

    Friend Function ExtractBranchText(ByVal TopNode As TreeNode, Optional ByVal Recursive As Boolean = True) As String
        Try
            Cursor.Current = Cursors.WaitCursor

            ' Copy top node
            Dim rtbTmp As New RichTextBox
            rtbTmp.Rtf = ExtractBranchRTF(TopNode, Recursive)
            Return rtbTmp.Text

        Catch ex As System.Exception
            MessageBox.Show(ex.Message, "Organizer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function

End Module
