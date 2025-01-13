'Imports WebSocketSharp

'Public Class Form1
'    Private ws As WebSocket

'    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        ws = New WebSocket("ws://localhost:4455") ' 根據你的OBS WebSocket地址修改
'        AddHandler ws.OnOpen, AddressOf Ws_OnOpen
'        AddHandler ws.OnMessage, AddressOf Ws_OnMessage
'        AddHandler ws.OnError, AddressOf Ws_OnError
'        AddHandler ws.OnClose, AddressOf Ws_OnClose
'        ws.Connect()
'    End Sub

'    Private Sub Ws_OnOpen(sender As Object, e As EventArgs)
'        ' 連接成功時執行的操作
'        MessageBox.Show("Connected to OBS WebSocket")
'    End Sub

'    Private Sub Ws_OnMessage(sender As Object, e As MessageEventArgs)
'        ' 處理來自OBS的消息
'        MessageBox.Show(e.Data)
'    End Sub

'    Private Sub Ws_OnError(sender As Object, e As ErrorEventArgs)
'        ' 處理連接錯誤
'        MessageBox.Show("Error: " & e.Message)
'    End Sub

'    Private Sub Ws_OnClose(sender As Object, e As CloseEventArgs)
'        ' 連接關閉時執行的操作
'        MessageBox.Show("Disconnected from OBS WebSocket")
'    End Sub

'    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
'        ws.Close()
'    End Sub
'End Class


'Imports WebSocketSharp

'Public Class Form1
'    Private ws As WebSocket

'    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        Try
'            ws = New WebSocket("ws://localhost:4455") ' 根據你的OBS WebSocket地址修改
'            AddHandler ws.OnOpen, AddressOf Ws_OnOpen
'            AddHandler ws.OnMessage, AddressOf Ws_OnMessage
'            AddHandler ws.OnError, AddressOf Ws_OnError
'            AddHandler ws.OnClose, AddressOf Ws_OnClose
'            ws.Connect()
'        Catch ex As Exception
'            MessageBox.Show("Exception: " & ex.Message)
'        End Try
'    End Sub

'    Private Sub Ws_OnOpen(sender As Object, e As EventArgs)
'        ' 連接成功時執行的操作
'        MessageBox.Show("Connected to OBS WebSocket")
'    End Sub

'    Private Sub Ws_OnMessage(sender As Object, e As MessageEventArgs)
'        ' 處理來自OBS的消息
'        MessageBox.Show(e.Data)
'    End Sub

'    Private Sub Ws_OnError(sender As Object, e As ErrorEventArgs)
'        ' 處理連接錯誤
'        MessageBox.Show("Error: " & e.Message)
'    End Sub

'    Private Sub Ws_OnClose(sender As Object, e As CloseEventArgs)
'        ' 連接關閉時執行的操作
'        MessageBox.Show("Disconnected from OBS WebSocket")
'    End Sub

'    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
'        ws.Close()
'    End Sub
'End Class


'Imports System.Net.WebSockets
'Imports System.Threading
'Imports System.Text

'Public Class Form1
'    Private clientWebSocket As ClientWebSocket

'    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        clientWebSocket = New ClientWebSocket()
'        Try
'            Await clientWebSocket.ConnectAsync(New Uri("ws://localhost:4455"), CancellationToken.None)
'            MessageBox.Show("Connected to OBS WebSocket")
'            Await ReceiveMessages()
'        Catch ex As Exception
'            MessageBox.Show("Exception: " & ex.Message)
'        End Try
'    End Sub

'    Private Async Function ReceiveMessages() As Task
'        Dim buffer(1024) As Byte
'        While clientWebSocket.State = WebSocketState.Open
'            Dim result As WebSocketReceiveResult = Await clientWebSocket.ReceiveAsync(New ArraySegment(Of Byte)(buffer), CancellationToken.None)
'            Dim message As String = Encoding.UTF8.GetString(buffer, 0, result.Count)
'            MessageBox.Show("Received: " & message)
'        End While
'    End Function

'    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
'        clientWebSocket.Dispose()
'    End Sub
'End Class


Imports System.Net.WebSockets
Imports System.Threading
Imports System.Text
Imports Newtonsoft.Json.Linq

Public Class Form1
    Private clientWebSocket As ClientWebSocket

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clientWebSocket = New ClientWebSocket()
        Try
            Await clientWebSocket.ConnectAsync(New Uri("ws://localhost:4455"), CancellationToken.None)
            MessageBox.Show("Connected to OBS WebSocket")
            Await Authenticate()
            Await SendGetSourcesMessage()
            Await ReceiveMessages()
        Catch ex As Exception
            MessageBox.Show("Exception: " & ex.Message)
        End Try
    End Sub

    Private Async Function Authenticate() As Task
        ' 發送認證請求
        Dim password As String = "XoKlyGdQdgEqEIDR" ' 使用您的OBS WebSocket密碼
        Dim authMessage As String = "{""op"": ""1"", ""d"": {""rpcVersion"": 1, ""authentication"": """ & password & """}}"
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(authMessage)
        Await clientWebSocket.SendAsync(New ArraySegment(Of Byte)(bytes), WebSocketMessageType.Text, True, CancellationToken.None)
        MessageBox.Show("Sent authentication request")
    End Function

    Private Async Function SendGetSourcesMessage() As Task
        Dim message As String = "{""op"": ""6"", ""d"": {""requestType"": ""GetSourcesList"", ""requestId"": ""1""}}"
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(message)
        Await clientWebSocket.SendAsync(New ArraySegment(Of Byte)(bytes), WebSocketMessageType.Text, True, CancellationToken.None)
        MessageBox.Show("Sent GetSourcesList request")
    End Function

    Private Async Function ReceiveMessages() As Task
        Dim buffer(8192) As Byte
        Dim messageBuilder As New StringBuilder()

        While clientWebSocket.State = WebSocketState.Open
            Dim result As WebSocketReceiveResult
            Do
                result = Await clientWebSocket.ReceiveAsync(New ArraySegment(Of Byte)(buffer), CancellationToken.None)
                Dim messagePart As String = Encoding.UTF8.GetString(buffer, 0, result.Count)
                messageBuilder.Append(messagePart)
            Loop While Not result.EndOfMessage

            Dim fullMessage As String = messageBuilder.ToString()
            messageBuilder.Clear()

            If Not String.IsNullOrEmpty(fullMessage.Trim()) Then
                Try
                    ' 顯示接收到的完整JSON消息
                    MessageBox.Show("Received JSON: " & fullMessage)

                    ' 解析JSON並檢查sources陣列
                    Dim jsonResponse As JObject = JObject.Parse(fullMessage)
                    Dim sources As JArray = TryCast(jsonResponse("d")("sources"), JArray)

                    ' 添加檢查，以確保sources不為空
                    If sources IsNot Nothing Then
                        Dim textSources As New List(Of String)()

                        For Each source As JObject In sources
                            Dim type As String = source("type")?.ToString()
                            If type = "text_gdiplus" OrElse type = "text_ft2_source" Then
                                textSources.Add(source("name")?.ToString())
                            End If
                        Next

                        ' 顯示文字來源清單
                        If textSources.Count > 0 Then
                            MessageBox.Show("Text Sources: " & String.Join(", ", textSources))
                        Else
                            MessageBox.Show("No text sources found")
                        End If
                    Else
                        MessageBox.Show("No sources array found in JSON response.")
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error parsing JSON: " & ex.Message)
                End Try
            Else
                MessageBox.Show("Received empty message")
            End If
        End While
    End Function

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        clientWebSocket.Dispose()
    End Sub
End Class
