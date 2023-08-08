Imports System.Data.SqlClient
Module Module1
    Public con As SqlConnection
    Public ad As SqlDataAdapter
    Public ds As DataSet
    Public SQL As String

    ''' <summary>
    ''' 参照
    ''' </summary>
    ''' <param name="SQL">SQL文</param>
    Public Sub SQL_REF(ByVal SQL As String)
        '接続文字列の設定
        Dim ServerName As String = "xxx.xx.xxx.xxx"
        Dim DBName As String = "youtube"
        Dim SsID As String = "test1"
        Dim SsPS As String = "test1"


        '接続設定
        con = New SqlConnection()
        con.ConnectionString = "Data Source = " & ServerName _
             & ";Initial Catalog = " & DBName _
             & ";uid = " & SsID & " ;pwd = " & SsPS & " ;Connection Timeout=60;"

        'DBへの接続
        con.Open()

        'データの取得
        ds = New DataSet()
        ad = New SqlDataAdapter()
        ad.SelectCommand = New SqlCommand(SQL, con)
        ad.SelectCommand.CommandType = CommandType.Text
        ad.Fill(ds)

        'DataGridViewにセット
        Form1.DataGridView1.DataSource = ds.Tables(0)

        'これが重要
        ad.MissingSchemaAction = MissingSchemaAction.AddWithKey

    End Sub

    ''' <summary>
    ''' 更新用SQLの取得
    ''' DataGridViewの行を削除すると削除される
    ''' </summary>
    Public Sub SQL_EDT()

        Dim builder As SqlCommandBuilder = New SqlCommandBuilder(ad)
        builder.GetUpdateCommand()

        Dim result As Integer
        'データの更新
        result = ad.Update(ds.Tables(0))

        '後始末
        'ad.Dispose()
        'con.Close()
        'con.Dispose()

    End Sub

End Module
