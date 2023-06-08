Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms

Public Class company
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim asc As New Associates
        Dim comp As New Companys
        Dim func As New FunctionAssociates
        Dim funcCompany As New FunctionCompanys

        If Me.ValidateChildren AndAlso (TextBox2.Text <> "" OrElse TextBox3.Text <> "") Then
            Try
                Dim input As String = If(String.IsNullOrEmpty(TextBox1.Text), Nothing, TextBox1.Text)
                Dim integerList As List(Of Integer)

                If String.IsNullOrEmpty(input) Then
                    integerList = New List(Of Integer)()
                Else
                    Dim values As String() = input.Split(","c).Select(Function(x) x.Trim()).ToArray()
                    integerList = values.Where(Function(x) Not String.IsNullOrEmpty(x)).Select(Function(x) Integer.Parse(x)).ToList()
                End If

                comp._AssociateId = integerList
                comp._Name = TextBox3.Text
                comp._Cnpj = TextBox2.Text.Replace(".", "").Replace("-", "").Replace("/", "")


                For Each associateId As Integer In comp._AssociateId
                    Dim associate As Associates = func.GetAssociateById(associateId)

                    If associate._Id = 0 AndAlso asc._Id = 0 Then
                        Throw New Exception("Um ou mais dos valores citados dos associados não existe")
                    End If

                Next
                Dim companyCnpj As String = comp._Cnpj
                Dim compnay As Companys = funcCompany.GetCompanyCnpj(companyCnpj)


                If compnay._Id <> 0 Then
                    Throw New Exception("Cnpj já cadastrado")
                End If

                If Not ValidateCnpj(TextBox2.Text) Then
                    Throw New Exception("Cnpj inválido")
                End If

                If compnay._Id = 0 Then

                    Dim companyId As Companys = funcCompany.InsertCompany(comp)

                    If companyId._Id <> 0 Then
                        For Each associateId As Integer In comp._AssociateId
                            func.InsertAssociateCompany(companyId._Id, associateId)
                        Next

                        MessageBox.Show("Inserido com sucesso", "Companys")
                        TextBox2.Text = ""
                        TextBox3.Text = ""
                        TextBox1.Text = ""
                        UpdateGrid()
                    End If
                Else
                    MessageBox.Show("Já possui esse Cnpj registrado", "Associates")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("Preechar os campos corretamente", "Associates")
        End If
    End Sub

    Private Sub menu_Load(sender As Object, e As EventArgs) Handles Me.Load
        UpdateGrid()
    End Sub

    Public Sub UpdateGrid()
        Dim funcCompany As New FunctionCompanys
        Try
            Dim companysList As List(Of Companys) = funcCompany.GetListCompany()
            Dim dataTable As DataTable = ConvertToDataTableList(companysList)
            Me.DataGridView1.DataSource = dataTable

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function ConvertToDataTableList(ByVal companysList As List(Of Companys)) As DataTable
        Dim dataTable As New DataTable()
        dataTable.Columns.Add("Id", GetType(Integer))
        dataTable.Columns.Add("Name", GetType(String))
        dataTable.Columns.Add("Cnpj", GetType(String))

        For Each company As Companys In companysList

            Dim row As DataRow = dataTable.NewRow()
            row("Id") = company._Id
            row("Name") = company._Name
            row("Cnpj") = company._Cnpj
            dataTable.Rows.Add(row)
        Next

        Return dataTable
    End Function

    Private Function ConvertToDataTable(ByVal company As Companys) As DataTable
        Dim dataTable As New DataTable()

        dataTable.Columns.Add("Id", GetType(Integer))
        dataTable.Columns.Add("Name", GetType(String))
        dataTable.Columns.Add("Cnpj", GetType(String))

        Dim row As DataRow = dataTable.NewRow()
        row("Id") = company._Id
        row("Name") = company._Name
        row("Cnpj") = company._Cnpj
        dataTable.Rows.Add(row)

        Return dataTable
    End Function

    Private Function ValidateCnpj(cnpj As String) As Boolean

        cnpj = New String(cnpj.Where(Function(c) Char.IsDigit(c)).ToArray())

        If cnpj.Length <> 14 Then
            Return False
        End If

        Dim sum As Integer = 0
        Dim multiplier As Integer = 5

        For i As Integer = 0 To 11
            sum += Integer.Parse(cnpj(i).ToString()) * multiplier
            multiplier -= 1

            If multiplier < 2 Then
                multiplier = 9
            End If
        Next

        Dim verificationDigit1 As Integer = sum Mod 11

        If verificationDigit1 < 2 Then
            verificationDigit1 = 0
        Else
            verificationDigit1 = 11 - verificationDigit1
        End If

        If Integer.Parse(cnpj(12).ToString()) <> verificationDigit1 Then
            Return False
        End If

        sum = 0
        multiplier = 6

        For i As Integer = 0 To 12
            sum += Integer.Parse(cnpj(i).ToString()) * multiplier
            multiplier -= 1

            If multiplier < 2 Then
                multiplier = 9
            End If
        Next

        Dim verificationDigit2 As Integer = sum Mod 11

        If verificationDigit2 < 2 Then
            verificationDigit2 = 0
        Else
            verificationDigit2 = 11 - verificationDigit2
        End If

        If Integer.Parse(cnpj(13).ToString()) <> verificationDigit2 Then
            Return False
        End If

        Return True
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim asc As New Associates
        Dim comp As New Companys
        Dim func As New FunctionAssociates
        Dim funcCompany As New FunctionCompanys
        If Me.ValidateChildren AndAlso (TextBox7.Text <> "") Then
            Try
                Dim companyId As Integer = Convert.ToInt32(TextBox7.Text)
                Dim company As Companys = funcCompany.GetCompanyById(companyId)
                Dim dataTable As DataTable = ConvertToDataTable(company)

                If dataTable.Rows.Count = 0 AndAlso company._Id = 0 Then
                    Throw New Exception("Empresa não existe")
                End If

                Dim input As String = If(String.IsNullOrEmpty(TextBox6.Text), Nothing, TextBox6.Text)
                Dim integerList As List(Of Integer)

                If String.IsNullOrEmpty(input) Then
                    integerList = New List(Of Integer)()
                Else
                    Dim values As String() = input.Split(","c).Select(Function(x) x.Trim()).ToArray()
                    integerList = values.Where(Function(x) Not String.IsNullOrEmpty(x)).Select(Function(x) Integer.Parse(x)).ToList()
                End If

                Dim associateCnpj As String = TextBox4.Text.Replace(".", "").Replace("-", "")
                Dim cnpjCompany As Companys = funcCompany.GetCompanyCnpj(associateCnpj)
                TextBox4.Text = ""

                If cnpjCompany._Id <> 0 Then
                    Throw New Exception("Cnpj já cadastrado")
                End If

                comp._AssociateId = integerList
                comp._Name = TextBox5.Text
                comp._Cnpj = TextBox4.Text.Replace(".", "").Replace("-", "")
                comp._Id = TextBox7.Text

                For Each associateId As Integer In comp._AssociateId
                    Dim associate As Associates = func.GetAssociateById(associateId)

                    If company._Id = 0 AndAlso comp._Id = 0 Then
                        Throw New Exception("Um ou mais dos valores citados de associados não existe")
                    End If
                Next

                If CheckBox1.Checked Then
                    For Each associateId As Integer In comp._AssociateId
                        func.DeletionAssociateCompanyByAssociateIdAndCompanyId(associateId, company._Id)
                    Next
                Else
                    For Each associateId As Integer In comp._AssociateId
                        func.InsertAssociateCompany(company._Id, associateId)
                    Next
                End If

                funcCompany.UpdateCompany(comp)
                MessageBox.Show("Atualizado com sucesso", "Companys")
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                UpdateGrid()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("Insira o código para Aatualizar", "Companys")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim asc As New Associates
        Dim comp As New Companys
        Dim func As New FunctionAssociates
        Dim funcCompany As New FunctionCompanys

        If Me.ValidateChildren AndAlso (TextBox10.Text <> "" OrElse TextBox11.Text <> "") Then
            Try
                If TextBox11.Text <> "" Then
                    Dim companyId As Integer = Convert.ToInt32(TextBox11.Text)
                    Dim company As Companys = funcCompany.GetCompanyById(companyId)
                    Dim dataTable As DataTable = ConvertToDataTable(company)

                    comp._Id = TextBox11.Text
                    If dataTable.Rows.Count = 0 AndAlso company._Id = 0 Then
                        Throw New Exception("Empresa não existe")
                    End If

                    If funcCompany.DeleteCompanyeByIdAndDeletionDate(comp) = True Then
                        funcCompany.DeleteAssociateCompanyByIdAndDeletionDate(company._Id)
                        MessageBox.Show("Excluido com sucesso", "Companys")
                        TextBox11.Text = ""
                        UpdateGrid()
                    End If

                Else
                    If Not ValidateCnpj(TextBox10.Text) Then
                        Throw New Exception("Cnpj inválido")
                    End If

                    Dim companyCnpj As String = TextBox10.Text.Replace(".", "").Replace("-", "").Replace("/", "")
                    Dim cnpjCompany As Companys = funcCompany.GetCompanyCnpj(companyCnpj)
                    Dim dataTableCnpj As DataTable = ConvertToDataTable(cnpjCompany)

                    If dataTableCnpj.Rows.Count = 0 AndAlso cnpjCompany._Id = 0 Then
                        Throw New Exception("Empresa não existe")
                    End If
                    If funcCompany.DeleteCompayByCnpjAndDeletionDate(companyCnpj) Then
                        funcCompany.DeleteAssociateCompanyByIdAndDeletionDate(comp._Id)
                        MessageBox.Show("Excluido com sucesso", "Companys")
                        TextBox10.Text = ""
                        UpdateGrid()
                    End If
                    End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("Insira o código para excluir", "Companys")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim funcCompany As New FunctionCompanys()

        If Me.ValidateChildren AndAlso (TextBox8.Text <> "" OrElse TextBox9.Text <> "") Then
            Try
                If TextBox9.Text <> "" Then

                    Dim companyId As Integer = Convert.ToInt32(TextBox9.Text)
                    Dim company As Companys = funcCompany.GetCompanyById(companyId)
                    Dim dataTable As DataTable = ConvertToDataTable(company)

                    If dataTable.Rows.Count = 0 AndAlso company._Id = 0 Then
                        Throw New Exception("Empresa não existe")
                    End If
                    Me.DataGridView1.DataSource = dataTable
                    TextBox9.Text = ""

                ElseIf TextBox8.Text <> "" Then

                    If Not ValidateCnpj(TextBox8.Text) Then
                        Throw New Exception("Cnpj inválido")
                    End If

                    Dim companyCnpj As String = TextBox8.Text.Replace(".", "").Replace("-", "").Replace("/", "")
                    Dim cnpjCompany As Companys = funcCompany.GetCompanyCnpj(companyCnpj)
                    Dim dataTableCnpj As DataTable = ConvertToDataTable(cnpjCompany)

                    If dataTableCnpj.Rows.Count = 0 AndAlso cnpjCompany._Id = 0 Then
                        Throw New Exception("Empresa não existe")
                    End If
                    Me.DataGridView1.DataSource = dataTableCnpj
                    TextBox8.Text = ""
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("Insira um dos valores para pesquisar", "Companys")
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim menu As New menu()
        menu.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim cnpj As String = TextBox2.Text.Replace(".", "").Replace("/", "").Replace("-", "")

        If cnpj.Length = 14 Then
            Dim cnpjFormatted As String = String.Format("{0:00\.000\.000\/0000\-00}", Long.Parse(cnpj))
            TextBox2.Text = cnpjFormatted
            TextBox2.SelectionStart = TextBox2.TextLength
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Dim cnpj As String = TextBox4.Text.Replace(".", "").Replace("/", "").Replace("-", "")

        If cnpj.Length = 14 Then
            Dim cnpjFormatted As String = String.Format("{0:00\.000\.000\/0000\-00}", Long.Parse(cnpj))
            TextBox4.Text = cnpjFormatted
            TextBox4.SelectionStart = TextBox4.TextLength
        End If
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged
        Dim cnpj As String = TextBox10.Text.Replace(".", "").Replace("/", "").Replace("-", "")

        If cnpj.Length = 14 Then
            Dim cnpjFormatted As String = String.Format("{0:00\.000\.000\/0000\-00}", Long.Parse(cnpj))
            TextBox10.Text = cnpjFormatted
            TextBox10.SelectionStart = TextBox10.TextLength
        End If
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        Dim cnpj As String = TextBox8.Text.Replace(".", "").Replace("/", "").Replace("-", "")

        If cnpj.Length = 14 Then
            Dim cnpjFormatted As String = String.Format("{0:00\.000\.000\/0000\-00}", Long.Parse(cnpj))
            TextBox8.Text = cnpjFormatted
            TextBox8.SelectionStart = TextBox8.TextLength
        End If
    End Sub
End Class