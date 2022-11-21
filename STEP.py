import pprint
from ssl import Options
import numpy as np
import matplotlib.pyplot as plt
import tkinter as tk
from tkinter import *
from tkinter import filedialog
import math as m
from mpl_toolkits.mplot3d import Axes3D
import pylab

def converting_to_Gforce(array, sen):
    return (array / sen)

def converting_to_SI(array, sen):
    return converting_to_Gforce(array, sen) * 9.8

def drawTrack(info):
    n = len(info[0])

    dr = m.pi/180

    angX = np.zeros(n+1)
    angY = np.zeros(n+1)
    angZ = np.zeros(n+1)

    posX = np.zeros(n+1)
    posY = np.zeros(n+1)
    posZ = np.zeros(n+1)

    velX = np.zeros(n+1)
    velY = np.zeros(n+1)
    velZ = np.zeros(n+1)

    angX[0] = 0
    angY[0] = 0
    angZ[0] = 0 

    posX[0] = 0
    posY[0] = 0
    posZ[0] = 0

    velX[0] = 0
    velY[0] = 0
    velZ[0] = 0

    deltaTime = 0.025
    for i in range(1 , n+1):
        angX[i] = angX[i-1] + info[4][i-1]*deltaTime
        angY[i] = angY[i-1] + info[5][i-1]*deltaTime
        angZ[i] = angZ[i-1] + info[6][i-1]*deltaTime

        #velocidade nova = antigavelocidade + novavelocidade*novoangulo
        velX[i] = velX[i-1] + info[0][i-1]*deltaTime * m.cos(angZ[i-1]*dr) + info[1][i-1] *m.sin(angZ[i-1]*dr) + info[0][i-1]*deltaTime *m.cos(angY[i-1]*dr) + info[2][i-1]*deltaTime *m.sin(angY[i-1]*dr)
        velY[i] = velY[i-1] + info[0][i-1]*deltaTime * m.sin(angZ[i-1]*dr) + info[1][i-1] *m.cos(angZ[i-1]*dr) + info[1][i-1]*deltaTime *m.cos(angX[i-1]*dr) + info[2][i-1]*deltaTime *m.sin(angZ[i-1]*dr)
        velZ[i] = velZ[i-1] + info[0][i-1]*deltaTime *m.sin(angY[i-1]*dr) + info[2][i-1]*deltaTime *m.cos(angY[i-1]*dr) + info[1][i-1]*deltaTime *m.sin(angX[i-1]*dr) + info[2][i-1]*deltaTime *m.cos(angZ[i-1]*dr)

        posX[i] = posX[i-1] + velX[i]*deltaTime
        posY[i] = posY[i-1] + velY[i]*deltaTime
        posZ[i] = posZ[i-1] + velZ[i]*deltaTime

    plt.scatter(posX, posY)
    plt.show()
    print("rodou o código todo")
    return


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

gt = input()

#opening file to read
with open(file_path) as f:
    lines = f.readlines()
    info = np.zeros((len(lines[0].split(",")), len(lines)-1))
    for i in range(0,len(lines)-1):
        for j in range(0, len(lines[0].split(","))):
            info[j][i] = lines[i].split(",")[j]


#creating a graphic
    if gt == "1":
        plt.plot( list(range(0, len(info[3]))), info[3])    
        plt.title('linear x')
        plt.show()
    elif gt == "2":
        plt.plot( list(range(0, len(info[1]))), info[1])    
        plt.title('linear y')
        plt.show()
    elif gt == "3":
        plt.plot( list(range(0, len(info[2]))), info[2])    
        plt.title('linear z')
        plt.show()
    elif gt == "4":
        plt.plot( list(range(0, len(info[0]))), info[0])    
        plt.plot( list(range(0, len(info[1]))), info[1])    
        plt.plot( list(range(0, len(info[2]))), info[2])    
        plt.title('linear xyz')
        plt.show()
    elif gt == "5":
        plt.scatter(converting_to_Gforce(info[0], 16384),converting_to_Gforce(info[1], 16384), 3)
        plt.title('diagram GG')
        plt.show()
    elif gt == "6":
        info[0] = converting_to_SI(info[0], 16384)
        info[1] = converting_to_SI(info[1], 16384)
        info[2] = converting_to_SI(info[2], 16384)
        drawTrack(info)