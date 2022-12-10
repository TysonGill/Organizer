<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBackupTo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUsersGuide = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSep2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.tv = New System.Windows.Forms.TreeView()
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxCopyTopic = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxCopyTopicText = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxCopyTopicRich = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxCopyTopicOrganizer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxCopyBranch = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxCopyBranchText = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxCopyBranchRich = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxCopyBranchOrganizer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxSplit = New System.Windows.Forms.ToolStripSeparator()
        Me.ctxPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxPasteSame = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxPasteUnder = New System.Windows.Forms.ToolStripMenuItem()
        Me.splitter = New System.Windows.Forms.SplitContainer()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.lblLink = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.rte = New RichEditor.RichEditor()
        Me.txtLink = New System.Windows.Forms.TextBox()
        Me.toolbar = New System.Windows.Forms.ToolStrip()
        Me.tbNew = New System.Windows.Forms.ToolStripButton()
        Me.tbOpen = New System.Windows.Forms.ToolStripButton()
        Me.tbDrag = New System.Windows.Forms.ToolStripButton()
        Me.tbUpdate = New System.Windows.Forms.ToolStripButton()
        Me.tbDelete = New System.Windows.Forms.ToolStripButton()
        Me.tbSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbPrint = New System.Windows.Forms.ToolStripButton()
        Me.tbSep2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbCollapse = New System.Windows.Forms.ToolStripButton()
        Me.tbExpand = New System.Windows.Forms.ToolStripButton()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.sb = New System.Windows.Forms.StatusStrip()
        Me.sbFile = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.ctxMenu.SuspendLayout()
        CType(Me.splitter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitter.Panel1.SuspendLayout()
        Me.splitter.Panel2.SuspendLayout()
        Me.splitter.SuspendLayout()
        Me.toolbar.SuspendLayout()
        Me.sb.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuHelp})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(936, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOpen, Me.mnuSaveAs, Me.mnuBackupTo, Me.mnuSep1, Me.mnuExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(37, 20)
        Me.mnuFile.Text = "&File"
        '
        'mnuOpen
        '
        Me.mnuOpen.Name = "mnuOpen"
        Me.mnuOpen.Size = New System.Drawing.Size(137, 22)
        Me.mnuOpen.Text = "&Open..."
        '
        'mnuSaveAs
        '
        Me.mnuSaveAs.Name = "mnuSaveAs"
        Me.mnuSaveAs.Size = New System.Drawing.Size(137, 22)
        Me.mnuSaveAs.Text = "&Save As..."
        '
        'mnuBackupTo
        '
        Me.mnuBackupTo.Name = "mnuBackupTo"
        Me.mnuBackupTo.Size = New System.Drawing.Size(137, 22)
        Me.mnuBackupTo.Text = "&Backup To..."
        '
        'mnuSep1
        '
        Me.mnuSep1.Name = "mnuSep1"
        Me.mnuSep1.Size = New System.Drawing.Size(134, 6)
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(137, 22)
        Me.mnuExit.Text = "E&xit"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuUsersGuide, Me.mnuSep2, Me.mnuAbout})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(44, 20)
        Me.mnuHelp.Text = "&Help"
        '
        'mnuUsersGuide
        '
        Me.mnuUsersGuide.Name = "mnuUsersGuide"
        Me.mnuUsersGuide.Size = New System.Drawing.Size(180, 22)
        Me.mnuUsersGuide.Text = "&User's Guide..."
        '
        'mnuSep2
        '
        Me.mnuSep2.Name = "mnuSep2"
        Me.mnuSep2.Size = New System.Drawing.Size(177, 6)
        '
        'mnuAbout
        '
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(180, 22)
        Me.mnuAbout.Text = "&About..."
        '
        'tv
        '
        Me.tv.AllowDrop = True
        Me.tv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tv.ContextMenuStrip = Me.ctxMenu
        Me.tv.HideSelection = False
        Me.tv.HotTracking = True
        Me.tv.Location = New System.Drawing.Point(3, 3)
        Me.tv.Name = "tv"
        Me.tv.Size = New System.Drawing.Size(159, 453)
        Me.tv.TabIndex = 0
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxCopyTopic, Me.ctxCopyBranch, Me.ctxSplit, Me.ctxPaste})
        Me.ctxMenu.Name = "ContextMenuStrip1"
        Me.ctxMenu.Size = New System.Drawing.Size(143, 76)
        '
        'ctxCopyTopic
        '
        Me.ctxCopyTopic.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxCopyTopicText, Me.ctxCopyTopicRich, Me.ctxCopyTopicOrganizer})
        Me.ctxCopyTopic.Name = "ctxCopyTopic"
        Me.ctxCopyTopic.Size = New System.Drawing.Size(142, 22)
        Me.ctxCopyTopic.Text = "Copy Topic"
        '
        'ctxCopyTopicText
        '
        Me.ctxCopyTopicText.Name = "ctxCopyTopicText"
        Me.ctxCopyTopicText.Size = New System.Drawing.Size(166, 22)
        Me.ctxCopyTopicText.Text = "Text Format"
        '
        'ctxCopyTopicRich
        '
        Me.ctxCopyTopicRich.Name = "ctxCopyTopicRich"
        Me.ctxCopyTopicRich.Size = New System.Drawing.Size(166, 22)
        Me.ctxCopyTopicRich.Text = "Rich Format"
        '
        'ctxCopyTopicOrganizer
        '
        Me.ctxCopyTopicOrganizer.Name = "ctxCopyTopicOrganizer"
        Me.ctxCopyTopicOrganizer.Size = New System.Drawing.Size(166, 22)
        Me.ctxCopyTopicOrganizer.Text = "Organizer Format"
        '
        'ctxCopyBranch
        '
        Me.ctxCopyBranch.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxCopyBranchText, Me.ctxCopyBranchRich, Me.ctxCopyBranchOrganizer})
        Me.ctxCopyBranch.Name = "ctxCopyBranch"
        Me.ctxCopyBranch.Size = New System.Drawing.Size(142, 22)
        Me.ctxCopyBranch.Text = "Copy Branch"
        '
        'ctxCopyBranchText
        '
        Me.ctxCopyBranchText.Name = "ctxCopyBranchText"
        Me.ctxCopyBranchText.Size = New System.Drawing.Size(166, 22)
        Me.ctxCopyBranchText.Text = "Text Format"
        '
        'ctxCopyBranchRich
        '
        Me.ctxCopyBranchRich.Name = "ctxCopyBranchRich"
        Me.ctxCopyBranchRich.Size = New System.Drawing.Size(166, 22)
        Me.ctxCopyBranchRich.Text = "Rich Format"
        '
        'ctxCopyBranchOrganizer
        '
        Me.ctxCopyBranchOrganizer.Name = "ctxCopyBranchOrganizer"
        Me.ctxCopyBranchOrganizer.Size = New System.Drawing.Size(166, 22)
        Me.ctxCopyBranchOrganizer.Text = "Organizer Format"
        '
        'ctxSplit
        '
        Me.ctxSplit.Name = "ctxSplit"
        Me.ctxSplit.Size = New System.Drawing.Size(139, 6)
        '
        'ctxPaste
        '
        Me.ctxPaste.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxPasteSame, Me.ctxPasteUnder})
        Me.ctxPaste.Name = "ctxPaste"
        Me.ctxPaste.Size = New System.Drawing.Size(142, 22)
        Me.ctxPaste.Text = "Paste"
        '
        'ctxPasteSame
        '
        Me.ctxPasteSame.Name = "ctxPasteSame"
        Me.ctxPasteSame.Size = New System.Drawing.Size(161, 22)
        Me.ctxPasteSame.Text = "At Same Level"
        '
        'ctxPasteUnder
        '
        Me.ctxPasteUnder.Name = "ctxPasteUnder"
        Me.ctxPasteUnder.Size = New System.Drawing.Size(161, 22)
        Me.ctxPasteUnder.Text = "Under This Topic"
        '
        'splitter
        '
        Me.splitter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitter.Location = New System.Drawing.Point(0, 24)
        Me.splitter.Name = "splitter"
        '
        'splitter.Panel1
        '
        Me.splitter.Panel1.Controls.Add(Me.tv)
        Me.splitter.Panel1MinSize = 100
        '
        'splitter.Panel2
        '
        Me.splitter.Panel2.Controls.Add(Me.Splitter1)
        Me.splitter.Panel2.Controls.Add(Me.lblLink)
        Me.splitter.Panel2.Controls.Add(Me.lblTitle)
        Me.splitter.Panel2.Controls.Add(Me.rte)
        Me.splitter.Panel2.Controls.Add(Me.txtLink)
        Me.splitter.Panel2.Controls.Add(Me.toolbar)
        Me.splitter.Panel2.Controls.Add(Me.txtTitle)
        Me.splitter.Panel2MinSize = 200
        Me.splitter.Size = New System.Drawing.Size(936, 459)
        Me.splitter.SplitterDistance = 165
        Me.splitter.TabIndex = 3
        Me.splitter.TabStop = False
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(37, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 459)
        Me.Splitter1.TabIndex = 12
        Me.Splitter1.TabStop = False
        '
        'lblLink
        '
        Me.lblLink.AutoSize = True
        Me.lblLink.Location = New System.Drawing.Point(41, 36)
        Me.lblLink.Name = "lblLink"
        Me.lblLink.Size = New System.Drawing.Size(27, 13)
        Me.lblLink.TabIndex = 11
        Me.lblLink.Text = "Link"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(41, 10)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(27, 13)
        Me.lblTitle.TabIndex = 10
        Me.lblTitle.Text = "Title"
        '
        'rte
        '
        Me.rte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rte.Location = New System.Drawing.Point(41, 59)
        Me.rte.Modified = False
        Me.rte.Name = "rte"
        Me.rte.Size = New System.Drawing.Size(723, 397)
        Me.rte.TabIndex = 9
        '
        'txtLink
        '
        Me.txtLink.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLink.BackColor = System.Drawing.SystemColors.Window
        Me.txtLink.Location = New System.Drawing.Point(74, 32)
        Me.txtLink.Name = "txtLink"
        Me.txtLink.Size = New System.Drawing.Size(690, 20)
        Me.txtLink.TabIndex = 8
        '
        'toolbar
        '
        Me.toolbar.Dock = System.Windows.Forms.DockStyle.Left
        Me.toolbar.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.toolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbNew, Me.tbOpen, Me.tbDrag, Me.tbUpdate, Me.tbDelete, Me.tbSep1, Me.tbPrint, Me.tbSep2, Me.tbCollapse, Me.tbExpand})
        Me.toolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.toolbar.Location = New System.Drawing.Point(0, 0)
        Me.toolbar.Name = "toolbar"
        Me.toolbar.Size = New System.Drawing.Size(37, 459)
        Me.toolbar.TabIndex = 7
        Me.toolbar.Text = "ToolStrip1"
        '
        'tbNew
        '
        Me.tbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbNew.Image = CType(resources.GetObject("tbNew.Image"), System.Drawing.Image)
        Me.tbNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbNew.Name = "tbNew"
        Me.tbNew.Size = New System.Drawing.Size(34, 36)
        Me.tbNew.Text = "Create a new topic"
        '
        'tbOpen
        '
        Me.tbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbOpen.Image = CType(resources.GetObject("tbOpen.Image"), System.Drawing.Image)
        Me.tbOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbOpen.Name = "tbOpen"
        Me.tbOpen.Size = New System.Drawing.Size(34, 36)
        Me.tbOpen.ToolTipText = "Open the file or web link"
        '
        'tbDrag
        '
        Me.tbDrag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbDrag.Image = CType(resources.GetObject("tbDrag.Image"), System.Drawing.Image)
        Me.tbDrag.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbDrag.Name = "tbDrag"
        Me.tbDrag.Size = New System.Drawing.Size(34, 36)
        Me.tbDrag.ToolTipText = "Drag to outline to create a new topic"
        '
        'tbUpdate
        '
        Me.tbUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbUpdate.Image = CType(resources.GetObject("tbUpdate.Image"), System.Drawing.Image)
        Me.tbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbUpdate.Name = "tbUpdate"
        Me.tbUpdate.Size = New System.Drawing.Size(34, 36)
        Me.tbUpdate.ToolTipText = "Update the current topic"
        '
        'tbDelete
        '
        Me.tbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbDelete.Image = CType(resources.GetObject("tbDelete.Image"), System.Drawing.Image)
        Me.tbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbDelete.Name = "tbDelete"
        Me.tbDelete.Size = New System.Drawing.Size(34, 36)
        Me.tbDelete.ToolTipText = "Delete the current topic"
        '
        'tbSep1
        '
        Me.tbSep1.Name = "tbSep1"
        Me.tbSep1.Size = New System.Drawing.Size(34, 6)
        '
        'tbPrint
        '
        Me.tbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbPrint.Image = CType(resources.GetObject("tbPrint.Image"), System.Drawing.Image)
        Me.tbPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbPrint.Name = "tbPrint"
        Me.tbPrint.Size = New System.Drawing.Size(34, 36)
        Me.tbPrint.ToolTipText = "Print the current topic"
        '
        'tbSep2
        '
        Me.tbSep2.Name = "tbSep2"
        Me.tbSep2.Size = New System.Drawing.Size(34, 6)
        '
        'tbCollapse
        '
        Me.tbCollapse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbCollapse.Image = CType(resources.GetObject("tbCollapse.Image"), System.Drawing.Image)
        Me.tbCollapse.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbCollapse.Name = "tbCollapse"
        Me.tbCollapse.Size = New System.Drawing.Size(34, 36)
        Me.tbCollapse.ToolTipText = "Collapse the outline"
        '
        'tbExpand
        '
        Me.tbExpand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbExpand.Image = CType(resources.GetObject("tbExpand.Image"), System.Drawing.Image)
        Me.tbExpand.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbExpand.Name = "tbExpand"
        Me.tbExpand.Size = New System.Drawing.Size(34, 36)
        Me.tbExpand.ToolTipText = "Expand the outline"
        '
        'txtTitle
        '
        Me.txtTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTitle.BackColor = System.Drawing.SystemColors.Window
        Me.txtTitle.Location = New System.Drawing.Point(74, 6)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(690, 20)
        Me.txtTitle.TabIndex = 5
        '
        'sb
        '
        Me.sb.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sbFile})
        Me.sb.Location = New System.Drawing.Point(0, 483)
        Me.sb.Name = "sb"
        Me.sb.Size = New System.Drawing.Size(936, 22)
        Me.sb.TabIndex = 4
        Me.sb.Text = "StatusStrip1"
        '
        'sbFile
        '
        Me.sbFile.Name = "sbFile"
        Me.sbFile.Size = New System.Drawing.Size(60, 17)
        Me.sbFile.Text = "File Name"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(936, 505)
        Me.Controls.Add(Me.splitter)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.sb)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(400, 300)
        Me.Name = "frmMain"
        Me.Text = "Organizer"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ctxMenu.ResumeLayout(False)
        Me.splitter.Panel1.ResumeLayout(False)
        Me.splitter.Panel2.ResumeLayout(False)
        Me.splitter.Panel2.PerformLayout()
        CType(Me.splitter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitter.ResumeLayout(False)
        Me.toolbar.ResumeLayout(False)
        Me.toolbar.PerformLayout()
        Me.sb.ResumeLayout(False)
        Me.sb.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tv As System.Windows.Forms.TreeView
    Friend WithEvents splitter As System.Windows.Forms.SplitContainer
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSep2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolbar As System.Windows.Forms.ToolStrip
    Friend WithEvents tbOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbDrag As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbUpdate As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbSep2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbExpand As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbCollapse As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtLink As System.Windows.Forms.TextBox
    Friend WithEvents rte As RichEditor.RichEditor
    Friend WithEvents lblLink As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents mnuBackupTo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuSaveAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents sb As System.Windows.Forms.StatusStrip
    Friend WithEvents sbFile As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mnuUsersGuide As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxCopyTopic As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxCopyBranch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxSplit As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ctxPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxCopyTopicText As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxCopyTopicRich As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxCopyTopicOrganizer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxCopyBranchText As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxCopyBranchRich As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxCopyBranchOrganizer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxPasteSame As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxPasteUnder As System.Windows.Forms.ToolStripMenuItem

End Class
