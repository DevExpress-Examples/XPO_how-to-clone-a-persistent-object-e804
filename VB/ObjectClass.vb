Imports DevExpress.Xpo

Namespace SimpleObject

    Public Class Parent
        Inherits XPObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub

        Private _Name As String

        Public Property Name As String
            Get
                Return _Name
            End Get

            Set(ByVal value As String)
                SetPropertyValue("Name", _Name, value)
            End Set
        End Property

        <Association("ParentChildren"), Aggregated>
        Public ReadOnly Property Children As XPCollection(Of Child)
            Get
                Return GetCollection(Of Child)("Children")
            End Get
        End Property
    End Class

    Public Class Child
        Inherits XPObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub

        Private _Name As String

        Public Property Name As String
            Get
                Return _Name
            End Get

            Set(ByVal value As String)
                SetPropertyValue("Name", _Name, value)
            End Set
        End Property

        Private _Parent As Parent

        <Association("ParentChildren")>
        Public Property Parent As Parent
            Get
                Return _Parent
            End Get

            Set(ByVal value As Parent)
                SetPropertyValue("Parent", _Parent, value)
            End Set
        End Property
    End Class
End Namespace
