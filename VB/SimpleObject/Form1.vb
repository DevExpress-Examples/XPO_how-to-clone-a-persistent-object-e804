Imports System
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
            listBox1 = New Windows.Forms.ListBox()
            Me.SuspendLayout()
            ' 
            ' listBox1
            ' 
            listBox1.Dock = Windows.Forms.DockStyle.Fill
            listBox1.Location = New System.Drawing.Point(0, 0)
            listBox1.Name = "listBox1"
            listBox1.Size = New System.Drawing.Size(413, 277)
            listBox1.TabIndex = 0
            ' 
            ' Form1
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(413, 277)
            Me.Controls.Add(listBox1)
            Me.Name = "Form1"
            Me.Text = "Form1"
             ''' Cannot convert AssignmentExpressionSyntax, System.NullReferenceException: Object reference not set to an instance of an object.
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
'''             this.Load += new System.EventHandler(this.Form1_Load)
'''  Me.ResumeLayout(False)
        End Sub

#End Region
        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Shared Sub Main()
            XpoDefault.DataLayer = New SimpleDataLayer(New InMemoryDataStore())
            Application.Run(New Form1())
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim uow1 As UnitOfWork = New UnitOfWork()
            Dim obj As Parent = New Parent(uow1) With {.Name = "Parent A"}
            Dim ch1 As Child = New Child(uow1) With {.Name = "Child 1"}
            Dim ch2 As Child = New Child(uow1) With {.Name = "Child 2"}
            obj.Children.Add(ch1)
            obj.Children.Add(ch2)
            obj.Save()
            uow1.CommitChanges()
            listBox1.Items.Add(String.Format("Object created: {0}", obj.Name))
            Dim uow2 As UnitOfWork = New UnitOfWork()
            Dim cloneHelper As CloneHelper = New CloneHelper(uow2)
            Dim clone As Parent = cloneHelper.Clone(obj)
            listBox1.Items.Add(String.Format("Object cloned: {0}", clone.Name))
            listBox1.Items.Add(String.Format("Object's child 1: {0}", clone.Children(0).Name))
            listBox1.Items.Add(String.Format("Object's child 2: {0}", clone.Children(1).Name))
        End Sub
    End Class
End Namespace
