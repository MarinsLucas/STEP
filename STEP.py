from ssl import Options
import numpy as np
import matplotlib.pyplot as plt
import tkinter as tk
from tkinter import *
from tkinter import filedialog    
import math as m

#250º/s 131.072
#500º/s 65.536
#1000º/s 32,768
#2000º/s 16,384
def converting_to_degree(array, sen):
    return array/65.536

def converting_degree_to_angle(array):
    return array * np.pi/180

def converting_acceleration_to_Gforce(array, sen):
    return (array / sen)

def converting_acceleration_to_SI(array, sen):
    return converting_acceleration_to_Gforce(array, sen) * 9.8

def converting_ang_to_rad(array):
    return array * m.pi/180

def read_file(file_path):
    #opening file to read
    with open(file_path) as f:
        lines = f.readlines()
        info = np.zeros((len(lines[0].split(",")), len(lines)-1))
        for i in range(0,len(lines)-1):
            for j in range(0, len(lines[0].split(","))):
                info[j][i] = lines[i].split(",")[j]
    return info

def main():
    #opening file diretory 
    root = tk.Tk()
    root.withdraw()
    file_path = filedialog.askopenfilename()

    info = read_file(file_path)

    print("Selecione uma opção de gráfico:")
    print("===============================")
    print("1 - gráfico linear x")
    print("2 - gráfico linear y")
    print("3 - gráfico linear z")
    print("4 - gráficos lineares x, y, z")
    print("5 - diagrama GxG")

    gt = input()
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
        plt.scatter(converting_acceleration_to_Gforce(info[0], 16384),converting_acceleration_to_Gforce(info[1], 16384), 3)
        plt.title('diagram GG')
        plt.show()


main()