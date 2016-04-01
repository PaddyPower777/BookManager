Public Class MainForm

    Private Sub exitMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitMenuItem.Click
        Close()
    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'LibraryDataSet.BookCondition' table. You can move, or remove it, as needed.
        Me.BookConditionTableAdapter.Fill(Me.LibraryDataSet.BookCondition)
        'TODO: This line of code loads data into the 'LibraryDataSet.Book' table. You can move, or remove it, as needed.
        Me.BookTableAdapter.Fill(Me.LibraryDataSet.Book)
        choiceComboBox.SelectedIndex = 1
    End Sub

    Private Sub updateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles updateButton.Click
        Try
            BookBindingSource.EndEdit()
            BookTableAdapter.Update(LibraryDataSet.Book)
            MessageBox.Show("Update successful")
        Catch ex As Exception
            MessageBox.Show("Update failed")
        End Try
    End Sub

    Private Sub findButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles findButton.Click
        If bookStateTextBox.Text = "" Then
            BookConditionBindingSource.Filter = Nothing
        Else
            BookConditionBindingSource.Filter = "StateOfBook ='" + bookStateTextBox.Text + "'"
        End If
    End Sub

    Private Sub choiceComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles choiceComboBox.SelectedIndexChanged
        If choiceComboBox.SelectedIndex = 0 Then
            conditionGridView.DataSource = BookConditionBindingSource
        Else
            conditionGridView.DataSource = FKBookConditionBookBindingSource
        End If
    End Sub

    Private Sub FillByStateOfBookToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FillByStateOfBookToolStripButton.Click
        Try
            Me.BookConditionTableAdapter.FillByStateOfBook(Me.LibraryDataSet.BookCondition, StateOfBookToolStripTextBox.Text)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub resetToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resetToolStripButton.Click
        BookConditionBindingSource.Filter = Nothing
        BookConditionTableAdapter.Fill(LibraryDataSet.BookCondition)
        StateOfBookToolStripTextBox.Clear()
        bookStateTextBox.Clear()
    End Sub

    Private Sub findAllButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles findAllButton.Click
        Dim aStateOfBookDialog As StateOfBookDialog
        aStateOfBookDialog = New StateOfBookDialog
            aStateOfBookDialog.stateDataGridView.DataSource = BooksOfStateBindingSource
        BooksOfStateTableAdapter.Fill(LibraryDataSet.BooksOfState, bookStateTextBox.Text)
        aStateOfBookDialog.ShowDialog()
        aStateOfBookDialog.Dispose()
    End Sub
End Class
