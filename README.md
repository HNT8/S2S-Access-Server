# S2S Remote Access Server
The remote access server for the S2S project.

The C# TCP server can be hosted by your desktop application and can be used to send and receive packets from a TCP client.

You can use the python script below to send a command from a Rasburry Pi.
```py
import socket

COMMAND = b"run application explorer.exe"

HOST = "10.0.0.2"
PORT = 7777

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    s.connect((HOST, PORT))
    s.sendall(COMMAND)
    data = s.recv(10000)

print(f"Recceived {data!r}")
```
