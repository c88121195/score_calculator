import sys
from obswebsocket import obsws, requests

host = 'localhost'
port = 4455
password = 'L0k9J8h7..'

scene_name = sys.argv[1]

ws = obsws(host, port, password)
ws.connect()

ws.call(requests.SetCurrentProgramScene(sceneName=scene_name))

ws.disconnect()
