# S2S Remote Access Server
The remote access server for the S2S project.

The C# TCP server can be hosted by your desktop application and can be used to send and receive packets from a TCP client. You can send commands to the server via any language as long as they have a library that enables you to do so.

You can use the following function to send a command.
```py
SendCommand("10.0.0.2", 7777, b"run url https://google.com")
```

This will work as long as you import the following script.
```py
import socket

def SendCommand(ip, port, command):
    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
        s.connect((ip, port))
        s.sendall(command)
        data = s.recv(10000)

    print(f"Recceived {data!r}")
```
