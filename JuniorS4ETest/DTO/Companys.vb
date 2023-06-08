Imports System.Collections.Generic

Public Class Companys
    Private Id As Integer
    Private Name As String
    Private Cnpj As String
    Private CreationDate As Date
    Private UpdateDate As Date
    Private DeletionDate As Date
    Private AssociateId As List(Of Integer) = New List(Of Integer)()

    Public Property _AssociateId As List(Of Integer)
        Get
            Return AssociateId
        End Get
        Set(value As List(Of Integer))
            AssociateId = value
        End Set
    End Property

    Public Property _Id As Integer
        Get
            Return Id
        End Get
        Set(value As Integer)
            Id = value
        End Set
    End Property

    Public Property _Name As String
        Get
            Return Name
        End Get
        Set(value As String)
            Name = value
        End Set
    End Property

    Public Property _Cnpj As String
        Get
            Return Cnpj
        End Get
        Set(value As String)
            Cnpj = value
        End Set
    End Property

    Public Property _CreationDate As Date
        Get
            Return CreationDate
        End Get
        Set(value As Date)
            CreationDate = value
        End Set
    End Property

    Public Property _UpdateDate As Date
        Get
            Return UpdateDate
        End Get
        Set(value As Date)
            UpdateDate = value
        End Set
    End Property

    Public Property _DeletionDate As Date
        Get
            Return DeletionDate
        End Get
        Set(value As Date)
            DeletionDate = value
        End Set
    End Property
End Class
