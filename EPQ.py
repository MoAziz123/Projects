import tkinter


class Application(tkinter.Frame):
    def __init__(self, master=None):
        super().__init__(master)
        self.pack()
        self.widgets()
        self.dictionary = {}
        self.dictionary2 = {}
        self.list = []
        master.minsize(width="400", height="400")

    def widgets(self):
        #these are the widgets that will be created for the note-taking app
        self.note_title = tkinter.Label(text="Note Title:")
        self.note_title.pack()
        self.entry = tkinter.Entry(width="40") #entry widget for Title
        self.entry.pack()
        self.note_text = tkinter.Label(text="Note Text:") #entry widget for text
        self.note_text.pack()
        self.text = tkinter.Text(width="40", height="10")

        //scrollbar and listbox to scroll through a listbox which stores notes
        self.scrollbar = tkinter.Scrollbar(self, orient=tkinter.VERTICAL, )
        self.listbox = tkinter.Listbox(self, height="5", width="20", selectmode="EXTENDED", yscrollcommand=self.scrollbar.set)
        self.scrollbar['command'] = self.listbox.yview()
        self.scrollbar.grid(row=0, column=0, sticky=tkinter.N + tkinter.S + tkinter.E)
        self.scrollbar.tkraise(aboveThis=self.listbox) #raises up levels
        self.listbox.grid(row = 0, column=0, sticky=tkinter.N + tkinter.S + tkinter.E)
        self.listbox.grid_forget()
        self.scrollbar.grid_forget()

        self.note_title.pack()
        self.text.pack()
        self.box = tkinter.Button(self, text="Done", fg="black", command=self.store_text2) #these are all buttons which when clicked on, execute their event handler
        self.box.grid(row="40")
        self.view_list = tkinter.Button(self, text="View Notes", fg="black", command=self.view_list)
        self.view_list.grid(row="40", column="10")
        self.loadnotes = tkinter.Button(self, text="Load", fg="black", command=self.load_notes)
        self.loadnotes.grid(row="40", column="60")
        self.savenotes = tkinter.Button(self, text="Save", fg="black", command=self.save_notes)
        self.savenotes.grid(row="40", column="50")
        self.quit = tkinter.Button(self, text="Quit", fg="black",command=root.destroy)
        self.quit.grid(row="40", column="20")
        self.clear = tkinter.Button(self, text="Clear", fg="black", command=self.clear_list)
        self.clear.grid(row="40", column="30")


    def store_text2(self):
        self.dictionary = {}
        self.text_data = self.text.get('1.0', tkinter.END)
        self.entry_data = self.entry.get()
        self.dictionary[self.entry.get()] = [self.text_data]
        for i in range(len(self.dictionary)):
            self.item = i
        self.entry.delete(0, tkinter.END)
        self.text.delete('1.0', tkinter.END)
        for i in self.dictionary:
            self.listbox.insert(tkinter.END, '{}: {}'.format(self.entry_data, self.text_data))
        print(self.dictionary)
        self.listbox.bind("<Double-Button-1>", self.click)


    def click(self, event): #on click, removes entry and text, so it can be easier for user, rather than having to remove
        self.entry.delete(0, tkinter.END)
        self.text.delete('1.0', tkinter.END)
        widget = event.widget
        selection = widget.curselection() #gets the currently selected item in listbox
        value = widget.get(selection[self.item]) #gets the first item in listbox
        x = ":"
        if x in value: #gets text from the value
            value = str(value)
            end = len(value)
            for i in value:
                if x == i:
                    x = value.find(":")
            print(value)
            value2 = value[0:x] #prints entry
            self.entry.insert(0, value2)
            self.text.insert('1.0', value[x+1:end])

    def view_list(self): #toggles between view and hide notes

        if self.view_list['text'] == "View Notes":
            self.scrollbar.grid(row="10", column="10", sticky=tkinter.N + tkinter.S + tkinter.E)
            self.listbox.grid(row="10", column="10", sticky=tkinter.N + tkinter.S + tkinter.E)
            self.view_list.configure(text="Hide Notes")


        else:
            self.scrollbar.grid_forget()
            self.listbox.grid_forget()
            self.view_list.configure(text="View Notes")

    def load_notes(self):
            f = open("EPQsave.txt", "r+")
            for i in f.readlines(): #so that we can iterate through the file, and put into listbox what's found
                self.listbox.insert(tkinter.END, i)
            print(self.list)
            f.close()

    def save_notes(self):
            f = open("EPQsave.txt", "a+")
            for i in self.listbox.get(tkinter.END):
                f.writelines(i) #writes new notes into listbox
            f.close()

    def clear_list(self):
        self.listbox.delete(0, tkinter.END)
        f = open("EPQsave.txt", "w+")
        f.writelines("") #removes everything from listbox, as well as doc storage






root = tkinter.Tk()
app = Application(master=root)
app.mainloop()
