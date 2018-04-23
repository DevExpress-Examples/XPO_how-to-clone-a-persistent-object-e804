Imports System
Imports System.Windows.Forms
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB

Namespace SimpleObject
    ''' <summary>
    ''' Summary description for Form1.
    ''' </summary>
    Public Class Form1
        Inherits Form

        Private listBox1 As ListBox
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private ReadOnly components As System.ComponentModel.Container = Nothing


        Public Sub New()
            InitializeComponent()
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If components IsNot Nothing Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.listBox1 = New System.Windows.Forms.ListBox()
            Me.SuspendLayout()
            ' 
            ' listBox1
            ' 
            Me.listBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.listBox1.Location = New System.Drawing.Point(0, 0)
            Me.listBox1.Name = "listBox1"
            Me.listBox1.Size = New System.Drawing.Size(413, 277)
            Me.listBox1.TabIndex = 0
            ' 
            ' Form1
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(413, 277)
            Me.Controls.Add(Me.listBox1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            Me.ResumeLayout(False)

        End Sub
        #End Region

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread> _
        Shared Sub Main()
            XpoDefault.DataLayer = New SimpleDataLayer(New InMemoryDataStore())
            Application.Run(New Form1())

        End Sub
        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            Dim uow1 As New UnitOfWork()
            Dim obj As New Parent(uow1) With {.Name = "Parent A"}
            Dim ch1 As New Child(uow1) With {.Name = "Child 1"}
            Dim ch2 As New Child(uow1) With {.Name = "Child 2"}
            obj.Children.Add(ch1)
            obj.Children.Add(ch2)
            obj.Save()
            uow1.CommitChanges()
            listBox1.Items.Add(String.Format("Object created: {0}", obj.Name))
            Dim uow2 As New UnitOfWork()
            Dim cloneHelper As New CloneHelper(uow2)
            Dim clone As Parent = cloneHelper.Clone(Of Parent)(obj)
            listBox1.Items.Add(String.Format("Object cloned: {0}", clone.Name))
            listBox1.Items.Add(String.Format("Object's child 1: {0}", clone.Children(0).Name))
            listBox1.Items.Add(String.Format("Object's child 2: {0}", clone.Children(1).Name))
        End Sub
    End Class
End Namespace
