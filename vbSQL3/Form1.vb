Public Class Form1

    ''' <summary>
    ''' 参照
    ''' </summary>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '部分一致検索用項目名
        Dim KOUMOKU As String = "タイトル"

        '接続対象            　DB名　　　　 テーブル名
        SQL = "SELECT * FROM [sample].[dbo].[sdata] "

        '部分一致検索
        If TextBox1.Text <> "" Then
            SQL = SQL & "where " & KOUMOKU & " like '%" & TextBox1.Text & "%'"
        End If

        Call SQL_REF(SQL)

        '--------------DataGridViewの編集-------------------------------------
        'キー列幅ゼロ
        'DataGridView1.Columns(0).Width = 0   'SEQ
        DataGridView1.Columns(0).Visible = False　'キー列幅ゼロだけだと隠れない

        DataGridView1.Columns(1).Width = 200   'タイトル
        DataGridView1.Columns(2).Width = 200   'URL

    End Sub

    ''' <summary>
    ''' 更新
    ''' </summary>
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Call SQL_EDT()

    End Sub
End Class
