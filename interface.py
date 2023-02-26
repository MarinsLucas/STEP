import numpy as np
import matplotlib.pyplot as plt
from matplotlib.backends.backend_tkagg import FigureCanvasTkAgg
import tkinter as tk
from tkinter import *
from tkinter import filedialog
import math as m
import STEP as program

HOME = 0

window = Tk()
window.title("Suspension Telemetry Program - Escuderia UFJF")

def open_file():
    root = tk.Tk()
    root.withdraw()
    file_path = filedialog.askopenfilename()
    print(file_path)
    if(len(file_path) > 3):
        program.run(file_path)
    else:  
        print("não tem")
    return

def update_sep_chars(timetime, timeinfo, infoinfo):
    program.separation_char(infoinfo)
    program.separation_time_char(timeinfo)
    program.time_char(timetime)
    print("Update separation chars")


def input_layout_editor():
    layout_editor = tk.Tk()
    layout_editor.title("Input Layout Editor")
    timetext = Label(layout_editor, text="time")
    timetext.grid(column=0, row=1)
    timeinput = Entry(layout_editor, width=10)
    timeinput.grid(column=1, row=1)
    timetext2 = Label(layout_editor, text="time")
    timetext2.grid(column=2, row=1)
    timeinfoinput = Entry(layout_editor, width=10)
    timeinfoinput.grid(column=3, row=1)
    infotext = Label(layout_editor, text="info")
    infotext.grid(column=4, row=1)
    infosepinput = Entry(layout_editor, width=10)
    infosepinput.grid(column=5, row=1)
    infotext2 = Label(layout_editor, text="info")
    infotext2.grid(column=6, row=1)

    ok_button = Button(layout_editor, text="OK", command=update_sep_chars(timeinput, timeinfoinput,infosepinput))
    ok_button.grid(column=3, row=2)
    cancel_button = Button(layout_editor, text="Cancel", command=layout_editor.destroy)
    cancel_button.grid(column=4, row=2)
    layout_editor.mainloop()

def main():
    window.geometry("500x500")
    #Menu superior:
    menubar = Menu(window)
    window.config(menu=menubar)
    file_menu = Menu(menubar)
    file_menu.add_command(label='Open File', command=open_file,)
    edit_menu = Menu(menubar)
    edit_menu.add_command(label="Edit input layout", command=input_layout_editor)
    menubar.add_cascade(label='File', menu=file_menu, underline=0)
    menubar.add_cascade(label='Edit', menu=edit_menu, underline=0)

    window.mainloop()

main()