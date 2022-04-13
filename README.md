# S2S Remote Access Server
The remote access server for the S2S project.

The C# TCP server can be hosted by your desktop application and can be used to send and receive packets from a TCP client. You can send commands to the server via any language as long as they have a library that enables you to do so.

You can use the following python function to send a command.
```py
import S2S_Connection.py

# SendCommand(ip, port, command, protocol)
# 0 = UDP, 1 = TCP
SendCommand("10.0.0.2", 7777, b"run url https://google.com", 0)
```

In order to send a packet using python, you must import the following python class.
```py
# File name: S2S_Connection.py
import socket

def SendCommand(ip, port, command, connectiontype):
    if connectiontype == 1:
        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
            s.connect((ip, port))
            s.sendall(command)
            data = s.recv(1024)
            print(data)
    elif connectiontype == 0:
        with socket.socket(socket.AF_INET, socket.SOCK_DGRAM) as s:
            s.sendto(command, (ip, port))
    else:
        print(f"Unknown connection type.")

    
    ```
