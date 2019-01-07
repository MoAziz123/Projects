import socket
import sys
import select

#for server, it's conn
host, port = sys.argv[1], int(sys.argv[2]) #gets argument from terminal
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)#internet, and TCP
s.bind((host, port))
s.listen(2)
print("listening on", host, port)
datalist = []

conn, addr = s.accept()
with conn: #event loop to receive data
    print("Connected to,", addr)
    while True:
        data = conn.recv(8192) #hits max byte limit
        print(data.decode())
        datalist.append(data.decode())
        # when sending server side - use conn
        if b"End of Data" in data: #data is grouped
            conn.sendall(b"Data finished compiling")
            s.close()
            break
        if ConnectionAbortedError:
            pass





f = open("website2.txt", "w")
for i in datalist:
    f.writelines(i)










