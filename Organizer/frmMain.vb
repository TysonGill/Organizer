Imports Microsoft.Office.Interop.Outlook
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Uri
Imports Utility

Public Class frmMain

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If My.Settings.LastPos.X > 0 AndAlso My.Settings.LastPos.X < SystemInformation.VirtualScreen.Width AndAlso My.Settings.LastPos.Y > 0 AndAlso My.Settings.LastPos.Y < SystemInformation.VirtualScreen.Height Then
            Me.Location = My.Settings.LastPos
            Me.Size = My.Settings.LastSize
        End If
        If My.Settings.SplitterDistance >= splitter.Panel1MinSize Then splitter.SplitterDistance = My.Settings.SplitterDistance
        rte.BackColor = Color.White

        If My.Settings.LastFile.Trim <> "" AndAlso Not File.Exists(My.Settings.LastFile.Trim) Then My.Settings.LastFile = ""
        LoadTreeFile()
        ShowStatus()

    End Sub

    Private Sub ShowStatus()
        If My.Settings.LastFile.Trim = "" Then
            sbFile.Text = "No Data File"
        Else
            sbFile.Text = My.Settings.LastFile
        End If
    End Sub

    Sub LoadTreeFile()

        If My.Settings.LastFile.Trim <> "" AndAlso File.Exists(My.Settings.LastFile) Then
            LoadTree()
        Else
            dtTree = New DataTable
            dtTree.TableName = "Organizer Tree"
            dtTree.Columns.Add("Parent Key", GetType(String))
            dtTree.Columns.Add("Key", GetType(String))
            dtTree.Columns.Add("Description", GetType(String))
            dtTree.Columns.Add("Tag", GetType(String))
            dtTree.Columns.Add("Link", GetType(String))
        End If
        ShowTree()
        EnableButtons()

    End Sub

    Private Sub ShowTree()
        txtTitle.Text = ""
        txtLink.Text = ""
        rte.Text = ""
        tv.Nodes.Clear()
        Try
            Dim NewNode As TreeNode
            For Each r As DataRow In dtTree.Rows
                If r("Parent Key") = "" Then
                    NewNode = tv.Nodes.Add(r("Key"), r("Description"))
                Else
                    Dim ParentNode As TreeNode = tv.Nodes.Find(r("Parent Key").ToString, True)(0)
                    NewNode = ParentNode.Nodes.Add(r("Key"), r("Description"))
                End If
                NewNode.Tag = r
            Next
            tv.CollapseAll()
            If tv.Nodes.Count > 0 Then tv.SelectedNode = tv.Nodes(0)
        Catch ex As System.Exception
            MessageBox.Show(ex.Message, "Organizer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tv_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tv.DragDrop

        ' Get the drop node
        Dim DropPoint As New Point(e.X, e.Y)
        DropPoint = tv.PointToClient(DropPoint)
        Dim DropNode As TreeNode = tv.GetNodeAt(DropPoint)

        ' Get the info to add
        Dim NewDesc As String = "New Node"
        Dim OpenPath As String = ""
        Dim NewTag As String = ""
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filenames As String() = DirectCast(e.Data.GetData(DataFormats.FileDrop), String())
            If filenames.Count > 0 Then
                OpenPath = filenames(0)
                NewDesc = Path.GetFileName(OpenPath)
                If NewDesc = "" Then NewDesc = OpenPath
            End If
        ElseIf e.Data.GetFormats.Contains("RenPrivateMessages") Then
            Dim dropString As String = e.Data.GetData(DataFormats.UnicodeText).ToString
            Dim mailData As Hashtable = ParseOutlookDropData(dropString)
            NewDesc = FindOutlookItem(mailData).Subject
            NewTag = FindOutlookItem(mailData).Body
            OpenPath = ""
        ElseIf e.Data.GetDataPresent(DataFormats.Text) AndAlso IsURL(e.Data.GetData(DataFormats.Text).ToString) Then
            OpenPath = e.Data.GetData(DataFormats.Text).ToString
            NewDesc = GetDomainFromURL(OpenPath)
        ElseIf e.Data.GetDataPresent(DataFormats.Text) AndAlso e.Data.GetData(DataFormats.Text).ToString = "New Organizer Node" Then
            NewDesc = txtTitle.Text
            OpenPath = txtLink.Text
            NewTag = rte.Text
        ElseIf e.Data.GetDataPresent(DataFormats.Text) Then
            NewTag = e.Data.GetData(DataFormats.Text).ToString
            NewDesc = GetShortDesc(NewTag)
        End If

        ' Create the new data row
        Dim NewKey As String = Now.Ticks.ToString
        Dim NewRow As DataRow = dtTree.NewRow
        If DropNode IsNot Nothing Then
            NewRow("Parent Key") = DropNode.Name
        End If
        NewRow("Key") = NewKey
        NewRow("Description") = NewDesc
        NewRow("Tag") = NewTag
        NewRow("Link") = OpenPath
        dtTree.Rows.Add(NewRow)

        ' Add the new node
        Dim NewNode As TreeNode = Nothing
        If DropNode Is Nothing Then
            ' Add a top level node
            NewNode = tv.Nodes.Add(NewKey, NewDesc)
        Else
            ' Add a child node
            NewNode = DropNode.Nodes.Add(NewKey, NewDesc)
            DropNode.Expand()
        End If
        NewNode.Tag = NewRow
        tv.Sort()

        ' Save the tree file
        SaveTreeFile()

        ' Display the new node
        tv.SelectedNode = NewNode
        ShowCurrentNode()
        EnableButtons()

    End Sub

    Private Function ParseOutlookDropData(ByVal data As String) As Hashtable
        Dim infoLines As String() = data.Split(Microsoft.VisualBasic.Chr(10))
        Dim headers As String() = infoLines(0).Split(Microsoft.VisualBasic.Chr(9))
        Dim record As String() = infoLines(1).Split(Microsoft.VisualBasic.Chr(9))
        Dim mailData As Hashtable = New Hashtable
        Dim i As Integer = 0
        While i < headers.Length
            mailData.Add(headers(i), record(i))
            System.Math.Min(System.Threading.Interlocked.Increment(i), i - 1)
        End While
        Return mailData
    End Function

    Private Function FindOutlookItem(ByVal mailData As Hashtable) As Outlook.MailItem
        Try
            Dim outlook As Outlook.Application
            outlook = CType(Microsoft.VisualBasic.Interaction.GetObject("", "Outlook.Application"), Outlook.Application)
            Dim explorer As Outlook.Explorer = outlook.ActiveExplorer
            Dim mail As Outlook.MailItem = CType(explorer.Selection.Item(1), Outlook.MailItem)
            Dim x As Integer = 1
            Return mail
        Catch ex As System.Exception
            MsgBox(ex, "Error - Outlook request not found")
            Return Nothing
        End Try
    End Function

    Private Sub LoadTree()
        Dim xml As String = File.ReadAllText(My.Settings.LastFile)
        dtTree = db.XmlToDatatable(xml)
        dtTree.TableName = "OrganizerData"
    End Sub

    Private Sub ShowCurrentNode()
        Try
            If tv.SelectedNode Is Nothing Then Exit Sub

            Dim r As DataRow = tv.SelectedNode.Tag
            txtTitle.Text = tv.SelectedNode.Text
            txtTitle.Tag = txtTitle.Text
            txtLink.Text = fmt.ToStr(r("Link"))
            txtLink.Tag = txtLink.Text
            rte.Text = fmt.ToStr(r("Tag"))
            EnableButtons()

        Catch ex As System.Exception
            MessageBox.Show(ex.Message, "Organizer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OpenFile()
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim OpenLink As String = txtLink.Text.Trim
            If OpenLink = "" Then Exit Sub

            Process.Start(OpenLink)

        Catch ex As System.Exception
            MessageBox.Show("You must specify a valid file name or URL in the Link field.", "Error Opening Link", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub EnableButtons()
        If tv.SelectedNode Is Nothing Then
            tbUpdate.Enabled = False
            tbDelete.Enabled = False
            tbOpen.Enabled = False
            tbPrint.Enabled = False
            tbCollapse.Enabled = False
            tbExpand.Enabled = False
        Else
            Dim r As DataRow = tv.SelectedNode.Tag
            tbUpdate.Enabled = ((txtTitle.Text.Trim <> txtTitle.Tag) Or (txtLink.Text.Trim <> txtLink.Tag) Or rte.Modified) And txtTitle.Text.Trim <> ""
            tbDelete.Enabled = True
            tbOpen.Enabled = (txtLink.Text.Trim <> "")
            tbPrint.Enabled = (rte.Text.Trim <> "")
            tbCollapse.Enabled = True
            tbExpand.Enabled = True
        End If
        tbDrag.Enabled = (txtTitle.Text.Trim <> "")
    End Sub

    Private Function PromptForFile() As Boolean
        Try
            Cursor = Cursors.WaitCursor

            ' Show the file selector
            Dim dlg As New OpenFileDialog
            dlg.Title = "Select your Organizer data file"
            dlg.CheckPathExists = True
            dlg.CheckFileExists = False
            dlg.DefaultExt = "dat"
            dlg.AddExtension = True
            dlg.Multiselect = False
            dlg.FileName = My.Settings.LastFile
            If dlg.FileName = "" Then dlg.FileName = System.AppDomain.CurrentDomain.BaseDirectory() + "Organizer.dat"
            dlg.Filter = "Organizer (*.dat)|*.dat|All (*.*)|*.*"
            dlg.FilterIndex = 1
            If dlg.ShowDialog(Me) <> DialogResult.OK Then Return True

            ' Save the folder
            My.Settings.LastFile = dlg.FileName
            ShowStatus()
            Return True

        Catch ex As System.Exception
            MessageBox.Show(ex.Message, "Organizer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            Cursor = Cursors.Default
        End Try
    End Function

    Private Function PromptForBackup() As Boolean
        Try
            Cursor = Cursors.WaitCursor

            ' Show the file selector
            Dim dlg As New OpenFileDialog
            dlg.Title = "Select your Organizer backup file"
            dlg.CheckPathExists = True
            dlg.CheckFileExists = False
            dlg.DefaultExt = "bak"
            dlg.AddExtension = True
            dlg.Multiselect = False
            dlg.FileName = My.Settings.LastBackup
            If dlg.FileName = "" Then dlg.FileName = System.AppDomain.CurrentDomain.BaseDirectory() + "Organizer.bak"
            dlg.Filter = "Organizer (*.bak)|*.bak|All (*.*)|*.*"
            dlg.FilterIndex = 1
            If dlg.ShowDialog(Me) <> DialogResult.OK Then Return True

            ' Save the folder
            My.Settings.LastBackup = dlg.FileName
            Return True

        Catch ex As System.Exception
            MessageBox.Show(ex.Message, "Organizer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            Cursor = Cursors.Default
        End Try
    End Function

    Private Sub BackupTreeFile()
        Try
            Cursor = Cursors.WaitCursor

            ' Show the file selector
            File.Copy(My.Settings.LastFile, My.Settings.LastBackup, True)

        Catch ex As System.Exception
            MessageBox.Show(ex.Message, "Organizer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

#Region "Worker Functions"

    Private Sub SaveTreeFile()
        Try
            Cursor.Current = Cursors.WaitCursor

            ' Prompt for a file if needed
            If My.Settings.LastFile.Trim = "" Then
                If Not PromptForFile() Then Exit Sub
            End If

            ' Copy the treeview to a datatable
            Dim dtNew As DataTable = dtTree.Clone
            Dim NewRow As DataRow
            For Each n As TreeNode In tv.Nodes
                Dim r As DataRow = n.Tag
                NewRow = dtNew.NewRow
                NewRow("Parent Key") = ""
                NewRow("Key") = n.Name
                NewRow("Description") = r("Description")
                NewRow("Link") = r("Link")
                NewRow("Tag") = r("Tag")
                dtNew.Rows.Add(NewRow)
                SaveTreeRecursive(dtNew, n)
            Next
            dtNew.AcceptChanges()
            dtTree = dtNew.Copy

            ' Write the datatable to an XML file
            Dim xml As String = db.XmlFromDatatable(dtTree)
            File.WriteAllText(My.Settings.LastFile, xml)

        Catch ex As System.Exception
            MessageBox.Show(ex.Message, "Organizer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub SaveTreeRecursive(ByVal dtNew As DataTable, ByVal NodeIn As TreeNode)
        For Each n As TreeNode In NodeIn.Nodes
            Dim r As DataRow = n.Tag
            Dim NewRow As DataRow = dtNew.NewRow
            NewRow("Parent Key") = NodeIn.Name
            NewRow("Key") = n.Name
            NewRow("Description") = r("Description")
            NewRow("Link") = r("Link")
            NewRow("Tag") = r("Tag")
            dtNew.Rows.Add(NewRow)
            SaveTreeRecursive(dtNew, n)
        Next
    End Sub

    Private Function GetShortDesc(ByVal FullText As String)
        Dim ShortDesc As String = ""
        ShortDesc = Microsoft.VisualBasic.Left(FullText, 100)
        ShortDesc = Replace(ShortDesc, vbCrLf, " ")
        Dim s() As String = Split(ShortDesc, " ")
        ShortDesc = ""
        Dim c As Integer = 0
        Dim i As Integer = 0
        Do
            If s(i).Trim <> "" Then
                ShortDesc += s(i).Trim + " "
                c += 1
            End If
            i += 1
        Loop While c < 3
        Return ShortDesc.Trim
    End Function

    Public Function IsURL(ByVal Path As String) As Boolean
        Path = Path.Trim.ToLower
        If Path.StartsWith("http://") OrElse Path.StartsWith("https://") OrElse Path.StartsWith("www.") Then Return True
        Return False
    End Function

    Public Function GetDomainFromURL(ByVal Path As String) As String
        Try
            Path = Path.Trim
            Path = Path.Replace("http://", "")
            Path = Path.Replace("https://", "")
            Path = Split(Path, "/")(0)
            Path = Path.Replace("www.", "")
            Return Path
        Catch
            Return ""
        End Try
    End Function

#End Region

#Region "Event Handlers"

    Private Sub tv_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tv.AfterSelect
        ShowCurrentNode()
    End Sub

    Private Sub tv_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tv.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        If rte.Modified Then
            If MessageBox.Show("The current topic has been edited but not saved." + vbCrLf + vbCrLf + "Are you sure you wish to exit?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        End If
        Me.Close()
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        My.Settings.LastPos = Me.Location
        My.Settings.LastSize = Me.Size
        My.Settings.SplitterDistance = splitter.SplitterDistance
    End Sub

    Private Sub txtLabel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTitle.TextChanged, txtLink.TextChanged, rte.TextChanged
        EnableButtons()
    End Sub

    Private Sub DragNew(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tbDrag.MouseDown
        toolbar.DoDragDrop("New Organizer Node", DragDropEffects.Copy)
    End Sub

    Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
        Dim frm As New frmAbout
        frm.ShowDialog(Me)
    End Sub

    Private Sub txtLabel_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTitle.KeyDown
        If e.KeyCode = Keys.Return AndAlso txtTitle.Text <> txtTitle.Tag Then
            Dim CurNode As TreeNode = tv.SelectedNode
            CurNode.Text = txtTitle.Text
            txtTitle.Tag = txtTitle.Text
            tv.Sort()
            tv.SelectedNode = CurNode
        End If
    End Sub

    Private Sub mnuOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpen.Click
        If PromptForFile() Then LoadTreeFile()
    End Sub

    Private Sub mnuSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaveAs.Click
        If PromptForFile() Then SaveTreeFile()
    End Sub

    Private Sub mnuBackupTo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuBackupTo.Click
        If PromptForBackup() Then BackupTreeFile()
    End Sub

    Private Sub tbExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbExpand.Click
        If tv.Nodes.Count = 0 Then Exit Sub
        tv.ExpandAll()
    End Sub

    Private Sub tbCollapse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCollapse.Click
        If tv.Nodes.Count = 0 Then Exit Sub
        tv.CollapseAll()
        tv.SelectedNode = tv.Nodes(0)
    End Sub

    Private Sub tbOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbOpen.Click
        OpenFile()
    End Sub

    Private Sub tbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbDelete.Click
        Try
            Cursor = Cursors.WaitCursor

            If tv.SelectedNode Is Nothing Then Exit Sub
            If tv.SelectedNode.Nodes.Count = 0 Then
                If MessageBox.Show("Topic: " + tv.SelectedNode.Text + vbCrLf + vbCrLf + "Are you sure you wish to delete this node?", "Delete Node", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then Exit Sub
            Else
                If MessageBox.Show("Topic: " + tv.SelectedNode.Text + vbCrLf + vbCrLf + "Are you sure you wish to delete this node and all child nodes?", "Delete Nodes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then Exit Sub
            End If
            tv.SelectedNode.Remove()
            SaveTreeFile()

            txtTitle.Text = ""
            txtLink.Text = ""
            rte.Text = ""
            ShowCurrentNode()
            tv.Select()

        Catch ex As System.Exception
            MessageBox.Show(ex.Message, "Organizer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub tbNew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbNew.Click

        txtTitle.Text = ""
        txtTitle.Tag = ""
        txtLink.Text = ""
        txtLink.Tag = ""
        rte.Text = ""
        rte.Tag = ""
        tv.SelectedNode = Nothing
        EnableButtons()
        txtTitle.Select()

    End Sub

    Private Sub tbUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbUpdate.Click
        Try
            Cursor = Cursors.WaitCursor

            Dim CurNode As TreeNode = tv.SelectedNode
            Dim r As DataRow = CurNode.Tag

            ' Confirm if changing title
            Dim OldTitle As String = r("Description").trim
            Dim NewTitle As String = txtTitle.Text.Trim
            If OldTitle <> NewTitle Then
                If MessageBox.Show("You have edited the title of this topic." + vbCrLf + vbCrLf + "Do you want to overwrite the current topic?", "Update Topic", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            End If

            ' Update
            r("Key") = NewTitle
            r("Description") = txtTitle.Text
            r("Link") = txtLink.Text
            r("Tag") = rte.Text
            dtTree.AcceptChanges()
            CurNode.Text = txtTitle.Text
            txtTitle.Tag = txtTitle.Text
            CurNode.Tag = r
            rte.Modified = False
            SaveTreeFile()

            tv.Sort()
            tv.SelectedNode = CurNode
            EnableButtons()

        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub tbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPrint.Click
        Cursor = Cursors.WaitCursor
        rte.Print()
        Cursor = Cursors.Default
    End Sub

    Private Sub mnuUsersGuide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUsersGuide.Click
        Try
            Dim TempName As String = Path.GetTempPath + "EQ Log Analyzer.pdf"
            File.WriteAllBytes(TempName, My.Resources.organizer_guide)
            ui.OpenFile(TempName)
        Catch ex As system.Exception
            ReportError(ex)
        End Try
    End Sub

#End Region

#Region "Context Menu"

    Dim IsContext As Boolean = False

    Private Sub tv_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tv.MouseDown
        IsContext = False
        If e.Button <> Windows.Forms.MouseButtons.Right Then Exit Sub
        Dim SelectedNode As TreeNode = tv.GetNodeAt(e.X, e.Y)
        If SelectedNode Is Nothing Then Exit Sub
        tv.SelectedNode = SelectedNode
        IsContext = True
    End Sub

    Private Sub ctxMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxMenu.Opening

        If Not IsContext Then
            e.Cancel = True
            Exit Sub
        End If

        ' Determine if children are present
        Dim ChildCount As Integer = -1
        If tv.SelectedNode IsNot Nothing Then
            ChildCount = tv.SelectedNode.Nodes.Count
        End If

        ' Configure the copy items
        Select Case ChildCount
            Case -1
                ctxCopyTopic.Visible = False
                ctxCopyBranch.Visible = False
            Case 0
                ctxCopyTopic.Visible = True
                ctxCopyBranch.Visible = False
            Case Else
                ctxCopyTopic.Visible = True
                ctxCopyBranch.Visible = True
        End Select

        ' Configure the paste items
        Dim dt As DataTable = FetchFromClipboard()
        If dt Is Nothing Then
            ctxPaste.Visible = False
            ctxSplit.Visible = False
        Else
            ctxPaste.Visible = True
            ctxSplit.Visible = True
            If dt.Rows.Count = 1 Then
                ctxPaste.Text = "Paste Topic"
            Else
                ctxPaste.Text = "Paste Branch"
            End If
            ctxSplit.Visible = True
        End If

    End Sub

    Private Sub ctxCopyTopicText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxCopyTopicText.Click
        Dim sTree As String = ExtractBranchText(tv.SelectedNode, False)
        Clipboard.SetData(DataFormats.Text, sTree)
    End Sub

    Private Sub ctxCopyTopicRich_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxCopyTopicRich.Click
        Dim sTree As String = ExtractBranchRTF(tv.SelectedNode, False)
        Clipboard.SetData(DataFormats.Rtf, sTree)
    End Sub

    Private Sub ctxCopyTopicOrganizer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxCopyTopicOrganizer.Click
        Try

            Dim xml As String = db.XmlFromDatatable(ExtractBranchTable(tv.SelectedNode, False))
            Clipboard.SetData(DataFormats.Html, xml)

        Catch ex As System.Exception
            MessageBox.Show("Could not extract the branch.", "Error Extracting Branch", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ctxCopyBranchText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxCopyBranchText.Click
        Dim sTree As String = ExtractBranchText(tv.SelectedNode, True)
        Clipboard.SetData(DataFormats.Text, sTree)
    End Sub

    Private Sub ctxCopyBranchRich_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxCopyBranchRich.Click
        Dim sTree As String = ExtractBranchRTF(tv.SelectedNode, True)
        Clipboard.SetData(DataFormats.Rtf, sTree)
    End Sub

    Private Sub ctxCopyBranchOrganizer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxCopyBranchOrganizer.Click
        Try

            Dim xml As String = db.XmlFromDatatable(ExtractBranchTable(tv.SelectedNode, True))
            Clipboard.SetData(DataFormats.Html, xml)

        Catch ex As System.Exception
            MessageBox.Show("Could not extract the branch.", "Error Extracting Branch", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function FetchFromClipboard() As DataTable
        Try
            Dim xml As String = Clipboard.GetData(DataFormats.Html)
            If xml Is Nothing OrElse Not xml.Contains(My.Resources.NodeIdentifier) Then Return Nothing
            Dim dt As DataTable = db.XmlToDatatable(xml)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return Nothing
            Return dt
        Catch ex As System.Exception
            Return Nothing
        End Try
    End Function

    Private Sub ctxPasteSame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxPasteSame.Click
        PasteNodes(False)
    End Sub

    Private Sub ctxPasteUnder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxPasteUnder.Click
        PasteNodes(True)
    End Sub

    Private Sub PasteNodes(Optional ByVal AsChild As Boolean = True)

        Dim dtInsert As DataTable = FetchFromClipboard()
        If dtInsert Is Nothing OrElse dtInsert.Rows.Count = 0 Then Exit Sub

        ' Update parent key
        Dim TopRow As DataRow = tv.SelectedNode.Tag
        If AsChild Then
            dtInsert.Rows(0)("Parent Key") = TopRow("Key")
        Else
            dtInsert.Rows(0)("Parent Key") = TopRow("Parent Key")
        End If

        ' Update all other IDs
        Dim TickDiff As Long = Now.Ticks - Convert.ToInt64(dtInsert.Rows(0)("Key"))
        For i As Integer = 0 To dtInsert.Rows.Count - 1
            If i > 0 Then dtInsert.Rows(i)("Parent Key") = (Convert.ToInt64(dtInsert.Rows(i)("Parent Key")) + TickDiff).ToString("F0")
            dtInsert.Rows(i)("Key") = (Convert.ToInt64(dtInsert.Rows(i)("Key")) + TickDiff).ToString("F0")
        Next
        dtInsert.AcceptChanges()

        ' Insert the datatable at the current position
        For Each InsertedRow As DataRow In dtInsert.Rows
            dtTree.ImportRow(InsertedRow)
        Next
        dtTree.AcceptChanges()

        ' Redisplay the tree
        ShowTree()
        tv.Sort()

        ' Select the added node
        Dim NewKey As String = dtInsert.Rows(0)("Key")
        tv.SelectedNode = tv.Nodes.Find(NewKey, True)(0)
        ShowCurrentNode()
        EnableButtons()

        ' Save the changes
        SaveTreeFile()

    End Sub

#End Region

End Class
