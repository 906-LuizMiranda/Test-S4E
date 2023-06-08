Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms

Public Class associate
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim asc As New Associates
        Dim comp As New Companys
        Dim func As New FunctionAssociates
        Dim funcCompany As New FunctionCompanys

        If Me.ValidateChildren AndAlso (TextBox5.Text <> "" OrElse TextBox4.Text <> "") Then
            Try
                Dim input As String = If(String.IsNullOrEmpty(TextBox3.Text), Nothing, TextBox3.Text)
                Dim integerList As List(Of Integer)

                If String.IsNullOrEmpty(input) Then
                    integerList = New List(Of Integer)()
                Else
                    Dim values As String() = input.Split(","c).Select(Function(x) x.Trim()).ToArray()
                    integerList = values.Where(Function(x) Not String.IsNullOrEmpty(x)).Select(Function(x) Integer.Parse(x)).ToList()
                End If

                asc._CompanyId = integerList
                asc._Name = TextBox5.Text
                asc._Cpf = TextBox4.Text.Replace(".", "").Replace("-", "")
                asc._DateOfBirth = DateTimePicker1.Value.Date

                For Each companyId As Integer In asc._CompanyId
                    Dim company As Companys = funcCompany.GetCompanyById(companyId)

                    If company._Id = 0 AndAlso comp._Id = 0 Then
                        Throw New Exception("Um ou mais dos valores citados de empresas não existe")
                    End If

                Next
                Dim associateCpf As String = asc._Cpf
                Dim associate As Associates = func.GetAssociateByCpf(associateCpf)


                If associate._Id <> 0 Then
                    Throw New Exception("Cpf já cadastrado")
                End If

                If Not ValidateCpf(TextBox4.Text) Then
                    Throw New Exception("Cpf inválido")
                End If

                If associate._Id = 0 Then

                    Dim associateId As Associates = func.InsertAssociate(asc)

                    If associateId._Id <> 0 Then
                        For Each companyId As Integer In asc._CompanyId
                            func.InsertAssociateCompany(companyId, associateId._Id)
                        Next

                        MessageBox.Show("Inserido com sucesso", "Associates")
                        TextBox5.Text = ""
                        TextBox4.Text = ""
                        TextBox3.Text = ""
                        UpdateGrid()
                    End If
                Else
                    MessageBox.Show("Já possui esse cpf registrado", "Associates")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("Preechar os campos corretamente", "Associates")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim func As New FunctionAssociates()

        If Me.ValidateChildren AndAlso (TextBox1.Text <> "" OrElse TextBox6.Text <> "") Then
            Try
                If TextBox1.Text <> "" Then
                    Dim associateId As Integer = Convert.ToInt32(TextBox1.Text)
                    Dim associate As Associates = func.GetAssociateById(associateId)
                    Dim dataTable As DataTable = ConvertToDataTable(associate)
                    TextBox1.Text = ""
                    If dataTable.Rows.Count = 0 AndAlso associate._Id = 0 Then
                        Throw New Exception("Associado não existe")
                    End If
                    Me.DataGridView1.DataSource = dataTable
                ElseIf TextBox6.Text <> "" Then
                    If Not ValidateCpf(TextBox6.Text) Then
                        Throw New Exception("Cpf inválido")
                    End If
                    Dim associateCpf As String = TextBox6.Text.Replace(".", "").Replace("-", "")
                    Dim cpfAssociate As Associates = func.GetAssociateByCpf(associateCpf)
                    Dim dataTableCpf As DataTable = ConvertToDataTable(cpfAssociate)
                    TextBox6.Text = ""
                    If dataTableCpf.Rows.Count = 0 AndAlso cpfAssociate._Id = 0 Then
                        Throw New Exception("Associado não existe")
                    End If
                    Me.DataGridView1.DataSource = dataTableCpf
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("Insira um dos valores para pesquisar", "Associates")
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim menu As New menu()
        menu.Show()
        Me.Hide()
    End Sub

    Private Sub menu_Load(sender As Object, e As EventArgs) Handles Me.Load
        UpdateGrid()
    End Sub
    Public Sub UpdateGrid()
        Dim func As New FunctionAssociates()
        Try
            Dim associatesList As List(Of Associates) = func.GetListAssociate()
            Dim dataTable As DataTable = ConvertToDataTableList(associatesList)
            Me.DataGridView1.DataSource = dataTable

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function ConvertToDataTableList(ByVal associatesList As List(Of Associates)) As DataTable
        Dim dataTable As New DataTable()
        dataTable.Columns.Add("Id", GetType(Integer))
        dataTable.Columns.Add("Name", GetType(String))
        dataTable.Columns.Add("Cpf", GetType(String))
        dataTable.Columns.Add("DateOfBirth", GetType(Date))

        For Each associate As Associates In associatesList

            Dim row As DataRow = dataTable.NewRow()
            row("Id") = associate._Id
            row("Name") = associate._Name
            row("Cpf") = associate._Cpf
            row("DateOfBirth") = associate._DateOfBirth

            dataTable.Rows.Add(row)
        Next

        Return dataTable
    End Function

    Private Function ConvertToDataTable(ByVal associate As Associates) As DataTable
        Dim dataTable As New DataTable()

        dataTable.Columns.Add("Id", GetType(Integer))
        dataTable.Columns.Add("Name", GetType(String))
        dataTable.Columns.Add("Cpf", GetType(String))
        dataTable.Columns.Add("DateOfBirth", GetType(String))

        Dim row As DataRow = dataTable.NewRow()
        row("Id") = associate._Id
        row("Name") = associate._Name
        row("Cpf") = associate._Cpf
        row("DateOfBirth") = associate._DateOfBirth
        dataTable.Rows.Add(row)

        Return dataTable
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim asc As New Associates
        Dim func As New FunctionAssociates

        If Me.ValidateChildren AndAlso (TextBox2.Text <> "" OrElse TextBox7.Text <> "") Then
            Try
                If TextBox2.Text <> "" Then
                    Dim associateId As Integer = Convert.ToInt32(TextBox2.Text)
                    Dim associate As Associates = func.GetAssociateById(associateId)
                    Dim dataTable As DataTable = ConvertToDataTable(associate)

                    asc._Id = TextBox2.Text
                    If dataTable.Rows.Count = 0 AndAlso associate._Id = 0 Then
                        Throw New Exception("Associado não existe")
                    End If

                    If func.DeleteAssociateByIdAndDeletionDate(asc) = True Then
                        func.DeleteAssociateCompanyByIdAndDeletionDate(asc._Id)
                        MessageBox.Show("Excluido com sucesso", "Associates")
                        TextBox2.Text = ""
                        UpdateGrid()
                    End If

                Else
                    If Not ValidateCpf(TextBox7.Text) Then
                        Throw New Exception("Cpf inválido")
                    End If

                    Dim associateCpf As String = TextBox7.Text.Replace(".", "").Replace("-", "")
                    Dim cpfAssociate As Associates = func.GetAssociateByCpf(associateCpf)
                    Dim dataTableCpf As DataTable = ConvertToDataTable(cpfAssociate)

                    If dataTableCpf.Rows.Count = 0 AndAlso cpfAssociate._Id = 0 Then
                        Throw New Exception("Associado não existe")
                    End If
                    If func.DeleteAssociateByCpfAndDeletionDate(associateCpf) Then
                        func.DeleteAssociateCompanyByIdAndDeletionDate(asc._Id)
                        MessageBox.Show("Excluido com sucesso", "Associates")
                        TextBox7.Text = ""
                        UpdateGrid()
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("Insira o código para excluir", "Associates")
        End If
    End Sub

    Public Sub TextBox4_ValidateCpf(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

        Dim cpf As String = New String(TextBox4.Text.Where(Function(c) Char.IsDigit(c)).ToArray())

        If cpf.Length = 11 Then
            Dim cpfformatted As String = String.Format("{0:000\.000\.000\-00}", Long.Parse(cpf))
            TextBox4.Text = cpfformatted
            TextBox4.SelectionStart = TextBox4.TextLength
        End If
    End Sub

    Private Function ValidateCpf(cpf As String) As Boolean

        cpf = New String(cpf.Where(Function(c) Char.IsDigit(c)).ToArray())

        If cpf.Length <> 11 Then
            Return False
        End If

        If cpf.Distinct().Count() = 1 Then
            Return False
        End If

        Dim sum As Integer = 0
        For i As Integer = 0 To 8
            sum += (10 - i) * Integer.Parse(cpf(i).ToString())
        Next
        Dim remainder As Integer = sum Mod 11
        Dim verificationDigit1 As Integer = If(remainder < 2, 0, 11 - remainder)

        If Integer.Parse(cpf(9).ToString()) <> verificationDigit1 Then
            Return False
        End If

        sum = 0
        For i As Integer = 0 To 9
            sum += (11 - i) * Integer.Parse(cpf(i).ToString())
        Next
        remainder = sum Mod 11
        Dim verificationDigit2 As Integer = If(remainder < 2, 0, 11 - remainder)

        If Integer.Parse(cpf(10).ToString()) <> verificationDigit2 Then
            Return False
        End If

        Return True
    End Function

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        Dim cpf As String = New String(TextBox6.Text.Where(Function(c) Char.IsDigit(c)).ToArray())
        If cpf.Length = 11 Then
            Dim cpfformatted As String = String.Format("{0:000\.000\.000\-00}", Long.Parse(cpf))
            TextBox6.Text = cpfformatted
            TextBox6.SelectionStart = TextBox6.TextLength
        End If
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        Dim cpf As String = New String(TextBox7.Text.Where(Function(c) Char.IsDigit(c)).ToArray())
        If cpf.Length = 11 Then
            Dim cpfformatted As String = String.Format("{0:000\.000\.000\-00}", Long.Parse(cpf))
            TextBox7.Text = cpfformatted
            TextBox7.SelectionStart = TextBox6.TextLength
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim asc As New Associates
        Dim comp As New Companys
        Dim func As New FunctionAssociates
        Dim funcCompany As New FunctionCompanys
        If Me.ValidateChildren AndAlso (TextBox11.Text <> "") Then
            Try
                Dim associateId As Integer = Convert.ToInt32(TextBox11.Text)
                Dim associate As Associates = func.GetAssociateById(associateId)
                Dim dataTable As DataTable = ConvertToDataTable(associate)
                If dataTable.Rows.Count = 0 AndAlso associate._Id = 0 Then
                    Throw New Exception("Associado não existe")
                End If

                Dim input As String = If(String.IsNullOrEmpty(TextBox10.Text), Nothing, TextBox10.Text)
                Dim integerList As List(Of Integer)

                If String.IsNullOrEmpty(input) Then
                    integerList = New List(Of Integer)()
                Else
                    Dim values As String() = input.Split(","c).Select(Function(x) x.Trim()).ToArray()
                    integerList = values.Where(Function(x) Not String.IsNullOrEmpty(x)).Select(Function(x) Integer.Parse(x)).ToList()
                End If

                Dim associateCpf As String = TextBox8.Text.Replace(".", "").Replace("-", "")
                Dim cpfAssociate As Associates = func.GetAssociateByCpf(associateCpf)
                TextBox8.Text = ""

                If cpfAssociate._Id <> 0 Then
                    Throw New Exception("Cpf já cadastrado")
                End If

                asc._CompanyId = integerList
                asc._Name = TextBox9.Text
                asc._Cpf = TextBox8.Text.Replace(".", "").Replace("-", "")
                asc._DateOfBirth = DateTimePicker2.Value.Date
                asc._Id = TextBox11.Text


                For Each companyId As Integer In asc._CompanyId
                    Dim company As Companys = funcCompany.GetCompanyById(companyId)

                    If company._Id = 0 AndAlso comp._Id = 0 Then
                        Throw New Exception("Um ou mais dos valores citados de empresas não existe")
                    End If
                Next

                If CheckBox1.Checked Then
                    For Each companyId As Integer In asc._CompanyId
                        func.DeletionAssociateCompanyByAssociateIdAndCompanyId(associate._Id, companyId)
                    Next
                Else
                    For Each companyId As Integer In asc._CompanyId
                        func.InsertAssociateCompany(companyId, associate._Id)
                    Next
                End If

                func.UpdateAssociate(asc)
                MessageBox.Show("Atualizado com sucesso", "Associates")
                TextBox9.Text = ""
                TextBox8.Text = ""
                TextBox11.Text = ""
                TextBox10.Text = ""
                UpdateGrid()


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("Insira o código para Aatualizar", "Associates")
        End If
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        Dim cpf As String = New String(TextBox8.Text.Where(Function(c) Char.IsDigit(c)).ToArray())
        If cpf.Length = 11 Then
            Dim cpfformatted As String = String.Format("{0:000\.000\.000\-00}", Long.Parse(cpf))
            TextBox8.Text = cpfformatted
            TextBox8.SelectionStart = TextBox8.TextLength
        End If
    End Sub

End Class