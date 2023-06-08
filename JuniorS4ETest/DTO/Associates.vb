Imports System.Collections.Generic

Public Class Associates
    Private Id As Integer
    Private Name As String
    Private Cpf As String
    Private DateOfBirth As Date
    Private CreationDate As Date
    Private UpdateDate As Date
    Private DeletionDate As Date
    Private CompanyId As List(Of Integer) = New List(Of Integer)()


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

    Public Property _Cpf As String
        Get
            Return Cpf
        End Get
        Set(value As String)
            Cpf = value
        End Set
    End Property

    Public Property _DateOfBirth As Date
        Get
            Return DateOfBirth
        End Get
        Set(value As Date)
            DateOfBirth = value
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

    Public Property _CompanyId As List(Of Integer)
        Get
            Return CompanyId
        End Get
        Set(value As List(Of Integer))
            CompanyId = value
        End Set
    End Property
End Class
