import tkinter as tk

class App(tk.Frame):
    def __init__(self, master=None):
        super().__init__(master)
        master.minsize(height=400, width=400)
        self.widgets()
        self.b = 0



    def widgets(self):
        #buttons for events
        self.title = tk.Label(text="Database")
        self.title.grid(row = 0, column=5)
        self.viewentry = tk.Entry(width=5)
        self.viewentry.grid(row = 60, column=1)
        self.viewbutton = tk.Button(text="Create Database", command=self.viewbutton2)#prevents call of function
        self.viewbutton.grid(row=25, column=1)
        self.lockbutton = tk.Button(text="Lock", command=self.lock)
        self.lockbutton.grid(row=25, column=2)
        self.findbutton = tk.Button(text="Find", command=self.find)
        self.findbutton.grid(row=25, column=3)
        self.savebutton = tk.Button(text="Save", command=self.save)
        self.savebutton.grid(row=25, column=4)
        self.loadbutton = tk.Button(text="Load", command=self.load)
        self.loadbutton.grid(row=25, column=5)


    def viewbutton2(self):
        self.view(int(self.viewentry.get()[0:1]), int(self.viewentry.get()[2])) #splits string and converts to int

    def view(self, columnsize, rowsize):
        if self.viewbutton['text'] == "Reset": #is removed, and then rewritten as you go along the intrepreter
            for i in self.entries:
                i.grid_remove()
            for i in self.titles:
                i.grid_remove()
            for i in self.label2lst:
                i.grid_remove()
        self.columnsize = columnsize
        self.rowsize = rowsize
        self.entries = []
        self.titles = []
        self.label2lst = []
        #for loop iterating through each instance in the 2d array, and basically creating an entry box for that
        for column in range(columnsize): #creates numbers of columns
            for row in range(rowsize):
                self.text = tk.Entry( width=5)
                self.label = tk.Entry()
                self.label2 = tk.Label(text=str(row+1))
                self.label.grid(column=column+1, row =0)
                self.label2.grid(column=0, row=row+1)
                self.text.grid(row=row+1, column=column+1) #row is downwards, column is across
                self.entries.append(self.text) #2d array to iterate through the construct
                self.titles.append(self.label)
                self.label2lst.append(self.label2)
        if self.viewbutton['text'] == "Create Database":
            self.viewbutton['text'] = "Reset"





    def lock(self): #for each in self entries, set their state to read dsabled
        b = 0
        for i in self.entries:
            if b == self.columnsize * self.rowsize:
                break
            self.entries[b].config(state='disabled')
            b = b + 1
            self.savebutton.config(text="Unlock")

        if self.savebutton['text'] == "Unlock":
            self.savebutton.config(command=self.unlock)
        else:
            self.savebutton.config(command=self.lock)

        for i in self.titles: #disable titles too
            i.config(state='disabled')
#reason for above is to allow users to control changes and such - if i don't want to make any changes, use this


    def unlock(self):
        b = 0
        for i in self.entries:
                if b == self.columnsize * self.rowsize:
                    break
                self.entries[b].config(state='normal')
                b = b + 1


    def find(self):
        for i in self.entries:
                if self.viewentry.get() == i.get():
                    print("Found at:", self.entries.index(i))  #states which cell it's found at
                    #+1 because of the fact that it starts at 0, so need to be + 1 for accuracy



    def save(self): #to save a DB
        f = open("DBfile.txt", "w")
        for i in self.entries:
                f.writelines(i.get() + " \n")
        f.close()

        y = open("DBfilesizez.txt", "w")
        y.writelines(str(self.columnsize))
        y.writelines(str(self.rowsize))
        for i in self.titles:
            y.writelines(i.get() + "\n")
        y.close()



    def load(self): #to load a DB
        f = open("DBfile.txt", "r")
        b = 0
        while 1:
            for i in self.entries:
                i.insert('1', f.readline().strip()) #readlines is a problem because it reads everything into first cell..., read increases in character, so use readline to read one by one
            b += 1

            if b == self.columnsize * self.rowsize:
                break

root = tk.Tk()
app = App(master=root)
app.mainloop()
