import numpy as np
import matplotlib.pyplot as plt
#from matplotlib.backends.backend_tkagg import FigureCanvasTkAgg
import tkinter as tk
from tkinter import *
from tkinter import filedialog
import math as m
import STEP as step

HOME = 0

window = Tk()
window.title("Suspension Telemetry Program - Escuderia UFJF")

INFO_PATH = "./config.json"
program = step.STEP(INFO_PATH)


def mode_selection():
    unidimensional_graphic_button = Button(window, text="Unidimensional Graphic", command=print("unidimensional_graphic_button") )
    unidimensional_graphic_button.grid(column=1, row=1)
    tridimensional_graphic_button = Button(window, text="Tridimensional Graphic", command=print("tridimensional"))
    tridimensional_graphic_button.grid(column=2, row= 1)
    gg_diagram_button = Button(window, text= "GG Diagram", command=print("gg diagram"))
    gg_diagram_button.grid(column=3, row=1)
    track_layout_button = Button(window, text="Track Layout", command=print("track layout"))

def read_file_situation(value):
    if(value > 0):
        warning = tk.Tk()
        warning.title("File could not open")
        problem = ['Time-time char', 'Time-info char', 'Info-info char']
        warning_text = Label(warning, text="Failed to open file:")
        warning_text.grid(column=0, row=0)
        warning_text2 = Label(warning, text=str(problem[value]) + " was not found")
        warning_text2.grid(column=0, row = 1)
        warning_text3 = Label(warning, text= "Try to change config in: Edit->Edit Input Layout")
        warning_text3.grid(column=0, row= 2)
        ok_button = Button(warning, text= "OK", command=warning.destroy)
        ok_button.grid(column=0, row=3)

        warning.mainloop()
        return -1
    else:
        return 0

def open_file():
    root = tk.Tk()
    root.withdraw()
    file_path = filedialog.askopenfilename()
    print(file_path)
    if(len(file_path) > 3):
        program.set_file_path(file_path)
        if read_file_situation(program.read_file(file_path)) == 0:
            #abre esse arquivo
            mode_selection()

    else:  
        print("não tem")


def update_sep_chars(timetime, timeinfo, infoinfo):
    program.separation_char(infoinfo)
    program.separation_time_char(timeinfo)
    program.time_char(timetime)
    program.write_config_info(INFO_PATH)
    #print("Update separation chars")


def input_layout_editor():
    layout_editor = tk.Tk()
    layout_editor.title("Input Layout Editor")

    #Define caractere entre os dígitos do tempo
    timetext = Label(layout_editor, text="time")
    timetext.grid(column=0, row=1)
    timeinput = Entry(layout_editor, width=10)
    timeinput.grid(column=1, row=1)
    timeinput.insert(0, program.get_time_char())

    #Define Caractere entre os dígitos de tempo e de informação
    timetext2 = Label(layout_editor, text="time")
    timetext2.grid(column=2, row=1)
    timeinfoinput = Entry(layout_editor, width=10)
    timeinfoinput.grid(column=3, row=1)
    timeinfoinput.insert(0, program.get_separation_time_char())

    #Define caractere entre os dígitos de informação
    infotext = Label(layout_editor, text="info")
    infotext.grid(column=4, row=1)
    infosepinput = Entry(layout_editor, width=10)
    infosepinput.grid(column=5, row=1)
    infosepinput.insert(0, program.get_separation_char())
    infotext2 = Label(layout_editor, text="info")
    infotext2.grid(column=6, row=1)

    #Botão de confirmação
    ok_button = Button(layout_editor, text="OK", command=lambda: [update_sep_chars(timeinput.get(), timeinfoinput.get(),infosepinput.get()), layout_editor.destroy()])
    ok_button.grid(column=2, row=2)

    #Botão de cancelamento
    cancel_button = Button(layout_editor, text="Cancel", command=layout_editor.destroy)
    cancel_button.grid(column=3, row=2)

    #default button
    default_button = Button(layout_editor, text= "Return to Default", command=lambda :[update_sep_chars(':', '->', ';') , layout_editor.destroy()])
    default_button.grid(column= 4, row= 2)

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