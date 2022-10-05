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

print("Selecione uma opção de gráfico:")
print("===============================")
print("1 - gráfico linear x")
print("2 - gráfico linear y")
print("3 - gráfico linear z")
print("4 - gráficos lineares x, y, z")
print("5 - diagrama GxG")
print("6 - imprimir todos")
gt = int(input())

#opening file to read
with open(file_path) as f:
    lines = f.readlines()
    info = np.zeros((3, len(lines)))
    for i in range(0,len(lines)):
        for j in range(0, 3):
            info[j][i] = lines[i].split(",")[j]


#creating a graphic
    if gt == 1:
        plt.plot( list(range(0, len(info[0]))), info[0], '-*')    
        plt.title('linear x')
        plt.show()
    elif gt == 2:
        plt.plot( list(range(0, len(info[1]))), info[1] , '-*')
        plt.title('linear y')
        plt.show()
    elif gt == 3:
        plt.plot( list(range(0, len(info[2]))), info[2] , '-*')
        plt.title('linear z')
        plt.show()
    elif gt == 4:
        plt.plot( list(range(0, len(info[0]))), info[0] , '-*', list(range(0, len(info[1]))), info[1], '-*', list(range(0, len(info[2]))), info[2], '-*') 
        plt.legend(['linear x', 'linear y' , 'linear z'])
        plt.title('linear xyz')
        plt.show()
    elif gt == 5:
        plt.scatter(info[1], info[0])
        plt.title('diagram GG')
        plt.show()
    elif gt == 6:
        plt.plot( list(range(0, len(info[0]))), info[0], '-*')    
        plt.title('linear x')
        plt.show()

        plt.plot( list(range(0, len(info[1]))), info[1] , '-*')
        plt.title('linear y')
        plt.show()

        plt.plot( list(range(0, len(info[2]))), info[2] , '-*')
        plt.title('linear z')
        plt.show()

        plt.plot( list(range(0, len(info[0]))), info[0] , '-*', list(range(0, len(info[1]))), info[1], '-*', list(range(0, len(info[2]))), info[2], '-*') 
        plt.legend(['linear x', 'linear y' , 'linear z'])
        plt.title('linear xyz')
        plt.show()

        plt.scatter(info[1], info[0])
        plt.title('diagram GG')
        plt.show()