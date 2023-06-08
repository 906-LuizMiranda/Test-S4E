Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient

Public Class FunctionAssociates
    Dim cn As New SqlConnection(My.Settings.conexao)
    Dim cmd As New SqlCommand()

    Public Function DeleteAssociateByIdAndDeletionDate(ByVal Id As Associates) As Boolean
        Try
            cn.Open()
            cmd = New SqlCommand("SP_UpdateAssociateByIdAndDeletionDate", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@paramId", Id._Id)

            If cmd.ExecuteNonQuery() Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False

        Finally
            cn.Close()

        End Try
        Return True
    End Function
    Public Function DeleteAssociateByCpfAndDeletionDate(ByVal Cpf As String) As Boolean
        Try
            cn.Open()
            cmd = New SqlCommand("SP_UpdateAssociateByCpfDeletionDate", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@paramCpf", Cpf)

            If cmd.ExecuteNonQuery() Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False

        Finally
            cn.Close()

        End Try
        Return True

    End Function
    Public Function GetListAssociate() As List(Of Associates)
        Dim associatesList As New List(Of Associates)()

        Try
            cn.Open()
            cmd = New SqlCommand("SP_GetListAssociate", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim associate As New Associates()
                associate._Id = Convert.ToInt32(reader("Id"))
                associate._Name = reader("Name").ToString()
                associate._Cpf = reader("Cpf").ToString()
                associate._DateOfBirth = Convert.ToString(reader("DateOfBirth"))
                associatesList.Add(associate)
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try

        Return associatesList
    End Function
    Public Function GetAssociateById(ByVal Id As Integer) As Associates
        Dim associateResult As New Associates()

        Try
            cn.Open()
            cmd = New SqlCommand("SP_GetAssociateById", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@paramId", Id)

            Dim reader As SqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                associateResult._Id = Convert.ToInt32(reader("Id"))
                associateResult._Name = reader("Name").ToString()
                associateResult._Cpf = reader("Cpf").ToString()
                associateResult._DateOfBirth = Convert.ToString(reader("DateOfBirth"))
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try

        Return associateResult
    End Function
    Public Function InsertAssociate(ByVal Data As Associates) As Associates
        Dim associateResult As New Associates()
        Try
            cn.Open()
            cmd = New SqlCommand("SP_InsertAssociate", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@paramName", Data._Name)
            cmd.Parameters.AddWithValue("@paramCpf", Data._Cpf)
            cmd.Parameters.AddWithValue("@paramDateOfBirth", Data._DateOfBirth)

            Using reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    associateResult._Id = Convert.ToInt64(reader("Id"))
                    associateResult._Name = reader("Name").ToString()
                    associateResult._Cpf = reader("Cpf").ToString()
                    associateResult._DateOfBirth = Convert.ToDateTime(reader("DateOfBirth"))
                    associateResult._CreationDate = Convert.ToDateTime(reader("CreationDate"))
                    associateResult._UpdateDate = Convert.ToDateTime(reader("UpdateDate"))
                    associateResult._DeletionDate = If(reader("DeletionDate") IsNot DBNull.Value, Convert.ToDateTime(reader("DeletionDate")), Nothing)
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try

        Return associateResult
    End Function

    Public Function GetAssociateByCpf(ByVal Cpf As String) As Associates
        Dim associateResult As New Associates()

        Try
            cn.Open()
            cmd = New SqlCommand("SP_GetAssociateByCpf", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@paramCpf", Cpf)

            Dim reader As SqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                associateResult._Id = Convert.ToInt32(reader("Id"))
                associateResult._Name = reader("Name").ToString()
                associateResult._Cpf = reader("Cpf").ToString()
                associateResult._DateOfBirth = Convert.ToString(reader("DateOfBirth"))
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try

        Return associateResult
    End Function
    Public Function UpdateAssociate(ByVal Data As Associates) As Boolean
        Try
            cn.Open()
            cmd = New SqlCommand("SP_UpdateAssociate", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@paramAssociateId", Data._Id)

            If Data._Name <> "" Then
                cmd.Parameters.AddWithValue("@paramName", Data._Name)
            End If

            If Data._Cpf <> "" Then
                cmd.Parameters.AddWithValue("@paramCpf", Data._Cpf)
            End If

            If Data._DateOfBirth <> DateTime.Now.Date Then
                cmd.Parameters.AddWithValue("@paramDateOfBirth", Data._DateOfBirth)
            End If

            If cmd.ExecuteNonQuery() Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False

        Finally
            cn.Close()

        End Try
        Return True
    End Function
    Public Function InsertAssociateCompany(ByVal companyId As Integer, ByVal associateId As Integer) As Boolean
        Try
            cn.Open()
            cmd = New SqlCommand("SP_InsertAssociateCompany", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@paramCompanyId", companyId)
            cmd.Parameters.AddWithValue("@paramAssociateId", associateId)

            If cmd.ExecuteNonQuery() Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False

        Finally
            cn.Close()

        End Try
        Return True

    End Function

    Public Function DeleteAssociateCompanyByIdAndDeletionDate(ByVal Id As Integer) As Boolean
        Try
            cn.Open()
            cmd = New SqlCommand("SP_UpdateAssociateCompanyByAssociateIdAndDeletionDate", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@paramAssociateId", Id)

            If cmd.ExecuteNonQuery() Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False

        Finally
            cn.Close()

        End Try
        Return True

    End Function

    Public Function DeletionAssociateCompanyByAssociateIdAndCompanyId(ByVal AssociateId As Integer, ByVal CompanyId As Integer) As Boolean
        Try
            cn.Open()
            cmd = New SqlCommand("SP_DeletionAssociateCompanyByAssociateIdAndCompanyId", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@paramAssociateId", AssociateId)
            cmd.Parameters.AddWithValue("@paramCompanyId", CompanyId)

            If cmd.ExecuteNonQuery() Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False

        Finally
            cn.Close()

        End Try
        Return True

    End Function

End Class
