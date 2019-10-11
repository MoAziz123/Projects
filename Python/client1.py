import sys
import socket
import select

#for clients it's s

host = sys.argv[1]
port = int(sys.argv[2])
f = open("DBfile.txt", "r") #ensure that r is in string format, or else won't compile cdoe
list = []
list2 = []
y = open("DBfilesizez.txt", "r") #open file to send
for i in f.readlines():
    list.append(i) # append it to the list

message = list


for i in y.readlines():
    list2.append(i)

message2 = list2


with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    s.connect((host, port))
    print("Connected to", host, port)
    for i in message:
        s.sendall(i.encode()) #encode to binary
    for i in message2:
        s.sendall(i.encode())
    s.sendall(b"End of Data")
        #using send takes longer
    data = s.recv(1024)
    if b"Data finished compiling" in data: #is grouped rather than separated
        s.close()# receives data from other socket
    print(data) #ensure you print data



