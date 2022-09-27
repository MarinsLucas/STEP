from ssl import Options
import numpy as np
import matplotlib.pyplot as plt
import tkinter as tk
from tkinter import *
from tkinter import filedialog

#opening file diretory 
root = tk.Tk()
root.withdraw()

file_path = filedialog.askopenfilename()

#opening file to read
with open(file_path) as f:
    lines = f.readlines()
    info = np.zeros((3, len(lines)))
    for i in range(1,len(lines)):
        for j in range(0, 3):
            info[j][i] = lines[i].split(",")[j]


    #creating a graphic
    plt.plot( list(range(0, len(info[1]))), info[0])    
    plt.title('G-G diagram')
    plt.show()


