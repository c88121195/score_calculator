from obswebsocket import obsws, requests, events

# 設置連接參數
host = 'localhost'
port = 4455
password = 'L0k9J8h7..'

# 建立OBS WebSocket客戶端
ws = obsws(host, port, password)

# 定義事件處理函數
def on_event(event):
    print(f"New event: {event}")

# 連接到OBS WebSocket伺服器
ws.connect()

# 綁定事件處理函數
ws.register(on_event)

# 獲取OBS版本信息
response = ws.call(requests.GetVersion())
print("OBS version:", response.getObsVersion())

# 獲取場景列表
response = ws.call(requests.GetSceneList())
print("Scene list:", response.getScenes())

# 斷開連接
ws.disconnect()
