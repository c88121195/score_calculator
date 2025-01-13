<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        BtnCnt = New Button()
        Label1 = New Label()
        TextBoxIP = New TextBox()
        TextBoxPort = New TextBox()
        Label2 = New Label()
        TextBoxPW = New TextBox()
        Label3 = New Label()
        ListBoxSources = New ListBox()
        SuspendLayout()
        ' 
        ' BtnCnt
        ' 
        BtnCnt.Font = New Font("Microsoft JhengHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        BtnCnt.Location = New Point(337, 454)
        BtnCnt.Name = "BtnCnt"
        BtnCnt.Size = New Size(337, 54)
        BtnCnt.TabIndex = 0
        BtnCnt.Text = "Connect to OBS WebSocket Server"
        BtnCnt.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft JhengHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(355, 51)
        Label1.Name = "Label1"
        Label1.Size = New Size(291, 22)
        Label1.TabIndex = 1
        Label1.Text = "Enter WebSocket Server IP Address"
        ' 
        ' TextBoxIP
        ' 
        TextBoxIP.Font = New Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxIP.Location = New Point(355, 89)
        TextBoxIP.Name = "TextBoxIP"
        TextBoxIP.Size = New Size(291, 33)
        TextBoxIP.TabIndex = 2
        ' 
        ' TextBoxPort
        ' 
        TextBoxPort.Font = New Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxPort.Location = New Point(355, 228)
        TextBoxPort.Name = "TextBoxPort"
        TextBoxPort.Size = New Size(291, 33)
        TextBoxPort.TabIndex = 4
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Microsoft JhengHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(355, 190)
        Label2.Name = "Label2"
        Label2.Size = New Size(291, 22)
        Label2.TabIndex = 3
        Label2.Text = "Enter WebSocket Server IP Address"
        ' 
        ' TextBoxPW
        ' 
        TextBoxPW.Font = New Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxPW.Location = New Point(355, 366)
        TextBoxPW.Name = "TextBoxPW"
        TextBoxPW.Size = New Size(291, 33)
        TextBoxPW.TabIndex = 6
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Microsoft JhengHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(355, 328)
        Label3.Name = "Label3"
        Label3.Size = New Size(291, 22)
        Label3.TabIndex = 5
        Label3.Text = "Enter WebSocket Server IP Address"
        ' 
        ' ListBoxSources
        ' 
        ListBoxSources.FormattingEnabled = True
        ListBoxSources.ItemHeight = 19
        ListBoxSources.Location = New Point(45, 54)
        ListBoxSources.Name = "ListBoxSources"
        ListBoxSources.Size = New Size(222, 384)
        ListBoxSources.TabIndex = 7
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(9F, 19F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(982, 553)
        Controls.Add(ListBoxSources)
        Controls.Add(TextBoxPW)
        Controls.Add(Label3)
        Controls.Add(TextBoxPort)
        Controls.Add(Label2)
        Controls.Add(TextBoxIP)
        Controls.Add(Label1)
        Controls.Add(BtnCnt)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents BtnCnt As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxIP As TextBox
    Friend WithEvents TextBoxPort As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxPW As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ListBoxSources As ListBox
End Class
