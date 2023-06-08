Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient

Public Class FunctionCompanys
    Dim cn As New SqlConnection(My.Settings.conexao)
    Dim cmd As New SqlCommand()

    Public Function GetCompanyById(ByVal Id As Integer) As Companys
        Dim companyeResult As New Companys()

        Try
            cn.Open()
            cmd = New SqlCommand("SP_GetCompanyById", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@paramId", Id)

            Dim reader As SqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                companyeResult._Id = Convert.ToInt32(reader("Id"))
                companyeResult._Name = reader("Name").ToString()
                companyeResult._Cnpj = reader("Cnpj").ToString()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try

        Return companyeResult
    End Function

    Public Function GetCompanyCnpj(ByVal Cnpj As String) As Companys
        Dim companyeResult As New Companys()

        Try
            cn.Open()
            cmd = New SqlCommand("SP_GetCompanyByCnpj", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@paramCnpj", Cnpj)

            Dim reader As SqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                companyeResult._Id = Convert.ToInt32(reader("Id"))
                companyeResult._Name = reader("Name").ToString()
                companyeResult._Cnpj = reader("Cnpj").ToString()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try

        Return companyeResult
    End Function
    Public Function InsertCompany(ByVal Data As Companys) As Companys
        Dim companyResult As New Companys()
        Try
            cn.Open()
            cmd = New SqlCommand("SP_InsertCompany", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@paramName", Data._Name)
            cmd.Parameters.AddWithValue("@paramCnpj", Data._Cnpj)

            Using reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    companyResult._Id = Convert.ToInt64(reader("Id"))
                    companyResult._Name = reader("Name").ToString()
                    companyResult._Cnpj = reader("Cnpj").ToString()
                    companyResult._CreationDate = Convert.ToDateTime(reader("CreationDate"))
                    companyResult._UpdateDate = Convert.ToDateTime(reader("UpdateDate"))
                    companyResult._DeletionDate = If(reader("DeletionDate") IsNot DBNull.Value, Convert.ToDateTime(reader("DeletionDate")), Nothing)
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try

        Return companyResult
    End Function

    Public Function GetListCompany() As List(Of Companys)
        Dim companysList As New List(Of Companys)()

        Try
            cn.Open()
            cmd = New SqlCommand("SP_GetListCompany", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim companys As New Companys()
                companys._Id = Convert.ToInt32(reader("Id"))
                companys._Name = reader("Name").ToString()
                companys._Cnpj = reader("Cnpj").ToString()
                companysList.Add(companys)
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try

        Return companysList
    End Function
    Public Function DeleteCompanyeByIdAndDeletionDate(ByVal Id As Companys) As Boolean
        Try
            cn.Open()
            cmd = New SqlCommand("SP_UpdateCompanyByIdAndDeletionDate", cn)
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
    Public Function DeleteAssociateCompanyByIdAndDeletionDate(ByVal Id As Integer) As Boolean
        Try
            cn.Open()
            cmd = New SqlCommand("SP_UpdateCompanyAssociateByCompanyIdAndDeletionDate", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@paramCompanyId", Id)

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
    Public Function DeleteCompayByCnpjAndDeletionDate(ByVal Cnpj As String) As Boolean
        Try
            cn.Open()
            cmd = New SqlCommand("SP_UpdateCompayByCnpjAndDeletionDate", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@paramCnpj", Cnpj)

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
    Public Function UpdateCompany(ByVal Data As Companys) As Boolean
        Try
            cn.Open()
            cmd = New SqlCommand("SP_UpdateCompany", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@paramCompanyId", Data._Id)

            If Data._Name <> "" Then
                cmd.Parameters.AddWithValue("@paramName", Data._Name)
            End If

            If Data._Cnpj <> "" Then
                cmd.Parameters.AddWithValue("@paramCnpj", Data._Cnpj)
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
End Class
