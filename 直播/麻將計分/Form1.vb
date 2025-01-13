Imports WebSocketSharp
Imports Newtonsoft.Json


Public Class Form1
    Private obs As WebSocketSharp.WebSocket

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 初始化控制項，這裡假設你在設計器中已添加了 TextBoxIP、TextBoxPort、TextBoxPW 和 BtnCnt 以及 ListBoxSources 控制項
        AddHandler BtnCnt.Click, AddressOf RegisterEventHandlers
    End Sub

    ' 註冊事件處理程序
    Private Sub RegisterEventHandlers()
        TryCatch(AddressOf ConnectToWebSocket)
    End Sub

    ' 連接到 OBS WebSocket 伺服器
    Private Sub ConnectToWebSocket()
        Dim websocketIP As String = TextBoxIP.Text
        Dim websocketPort As String = TextBoxPort.Text
        Dim websocketPassword As String = TextBoxPW.Text
        Dim url As String = $"ws://{websocketIP}:{websocketPort}"

        ' 用正確的 URL 初始化 WebSocket
        obs = New WebSocketSharp.WebSocket(url)

        ' 首先設置錯誤事件處理程序
        AddHandler obs.OnError, Sub(sender, e) Console.WriteLine($"Socket error: {e.Message}")

        ' 在連接之前設置消息事件處理程序
        AddHandler obs.OnMessage, AddressOf OnMessageReceived

        Try
            obs.Connect()
            Console.WriteLine("Connected to OBS WebSocket")
            ' 如果需要，發送認證消息
            obs.Send("{""request-type"": ""Authenticate"", ""message-id"": ""1"", ""auth"": """ & websocketPassword & """}")
        Catch ex As Exception
            Console.WriteLine($"Failed to connect: {ex.Message}")
        End Try

        ' 獲取文字源
        GetTextSources()
    End Sub

    ' 獲取文字源列表
    Private Sub GetTextSources()
        Try
            Dim request As String = "{""request-type"": ""GetInputList"", ""message-id"": ""1"", ""inputKind"": ""text_gdiplus_v2""}"
            obs.Send(request)
        Catch ex As Exception
            Console.WriteLine($"Error retrieving text sources: {ex.Message}")
        End Try
    End Sub

    ' 接收來自 OBS 的消息並顯示在 ListBox 中
    Private Sub OnMessageReceived(sender As Object, e As MessageEventArgs)
        Dim response As String = e.Data
        If response.Contains("""inputName""") Then
            ' 假設 response 是 JSON 格式，可以解析並提取 inputName
            ' 這裡用簡單的方式示例，實際應該使用 JSON 庫來解析
            Dim inputNames As List(Of String) = ExtractInputNamesFromResponse(response)
            For Each inputName In inputNames
                ListBoxSources.Items.Add(inputName)
            Next
        End If
    End Sub

    ' 假設這是一個簡單的函數來提取 inputName（實際應使用 JSON 庫來解析）
    Private Function ExtractInputNamesFromResponse(response As String) As List(Of String)
        ' 假設 response 格式類似於: {"inputName":"Source1"}, {"inputName":"Source2"}
        Dim inputNames As New List(Of String)
        Dim parts As String() = response.Split(New String() {"""inputName"" : """}, StringSplitOptions.None)
        For Each part In parts.Skip(1)
            Dim inputName As String = part.Split(""""c)(0)
            inputNames.Add(inputName)
        Next
        Return inputNames
    End Function

    ' 用於捕獲和處理異常的通用方法
    Private Sub TryCatch(callback As Action)
        Try
            callback()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
End Class
