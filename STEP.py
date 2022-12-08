import pprint
from ssl import Options
import numpy as np
import matplotlib.pyplot as plt
import tkinter as tk
from tkinter import *
from tkinter import filedialog
import math as m

QUANT_INFO = 7
GRAVITY = 9.8

def drawTrack(info, time):
    n = len(info[0])

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

    for i in range(1 , n+1):
        deltaTime = time[i] - time[i-1]
        #print(deltaTime)
        angX[i] = angX[i-1] + info[4][i-1]*deltaTime
        angY[i] = angY[i-1] + info[5][i-1]*deltaTime
        angZ[i] = angZ[i-1] + info[6][i-1]*deltaTime
        #print(str(angX[i]) + " " + str(angY[i]) + " " + str(angZ[i]))

        #v = v0 + a*t
        #atua = anterior + aceleração entre os dois * o delta tempo
        #velocidade nova = antigavelocidade + novavelocidade*novoangulo
        velX[i] = velX[i-1] + info[0][i-1]*deltaTime 
        velY[i] = velY[i-1] + info[1][i-1]*deltaTime 
        velZ[i] = velZ[i-1] + info[2][i-1]*deltaTime 
        print(str(velX[i]*3.6) + " " + str(velY[i]*3.6) + " " + str(velZ[i]*3.6))

        posX[i] = posX[i-1] + velX[i]*deltaTime
        posY[i] = posY[i-1] + velY[i]*deltaTime
        posZ[i] = posZ[i-1] + velZ[i]*deltaTime

    plt.scatter(posX, posY)
    plt.show()
    return

def converting_acceleration_to_Gforce(array, sen):
    return (array / sen)

def converting_acceleration_to_SI(array, sen):
    return converting_acceleration_to_Gforce(array, sen) * 9.8

def converting_ang_to_rad(array):
    return array * m.pi/180
    
def gravity_compensation(info, time):
    g = [0,0,GRAVITY]
    yaw = 0 #rotação no eixo z 
    pitch = 1 #rotação no eixo y
    roll = 0 #rotação no eixo x

    for i in range(1, len(info[0])):
        p = info[4][i-1] * time[i]
        q = info[5][i-1] * time[i]
        r = info[6][i-1] * time[i]

        roll_ = p + q*np.sin(roll)*np.tan(pitch) + r*np.cos(roll)*np.tan(pitch)
        pitch_ = q*np.cos(roll) - r*np.sin(roll)
        yaw_ = q*(np.sin(roll)/np.cos(pitch)) + r*(np.cos(roll)/np.cos(pitch))


        yaw = yaw + yaw_
        pitch = pitch + pitch_
        roll = roll + roll_
        
        g = rotationM(g, yaw, pitch, roll)

        print("yaw")
        print(yaw)
        print("pitch")
        print(pitch)
        print("roll")
        print(roll) 
        info[0][i] = info[0][i] - g[0]
        info[1][i] = info[1][i] - g[1]
        info[2][i] = info[2][i] - g[2]
        pprint.pprint(g)

    return info

#Multiplica um vetor pela matriz de rotação e retorna o resultado do cálculo
def rotationM(vector, yaw, pitch, roll):
    newVector = np.zeros(3)
    newVector[0] = np.cos(yaw)*np.cos(pitch) * vector[0] + np.cos(pitch)*np.sin(yaw) *vector[1] - np.sin(pitch) * vector[2]
    newVector[1] = vector[0]*(np.cos(yaw)*np.sin(roll)*np.sin(pitch) - np.cos(roll)*np.sin(yaw)) + vector[1]*(np.cos(roll)*np.cos(yaw) + np.sin(roll)*np.sin(yaw)*np.sin(pitch)) + vector[2]*(np.cos(pitch)*np.sin(roll))
    newVector[2] = vector[0]*(np.sin(roll)*np.sin(yaw) + np.cos(roll)*np.cos(yaw)*np.sin(pitch)) + (np.cos(roll)*np.sin(yaw)*np.sin(pitch) - np.cos(yaw)*np.sin(roll)) + vector[2]*(np.cos(roll)*np.cos(pitch))

    return newVector

#        Time      acelX   acelY acelZ temp   gyroX gyroY   gyroZ
#14:27:05.102 ->   -408,   828, 18280,31.12,  -789,   204,  -204
def read_file(file_path):
    #opening file to read
    with open(file_path) as f:
        #separa em linhas
        lines = f.readlines()
        
        #cria matriz de informacao
        info = np.zeros((QUANT_INFO, len(lines)))
        tempo = ["" for x in range(len(lines) + 1)]

        for i in range(0,len(lines)):
            tempo[i] = lines[i].split("->")[0]
            lines[i] = lines[i].split("-> ")[1]
            for j in range(0, len(lines[0].split(","))):
                info[j][i] = lines[i].split(",")[j]
        
        #o vetor de tempo é preenchido com a hora do dia em segundos
        tempSeg = np.zeros(len(tempo), dtype=float)
        for i in range (len(tempo)-1):
            tempSeg[i] = float(tempo[i].split(":")[0]) *3600
            tempSeg[i] += float(tempo[i].split(":")[1]) *60 
            tempSeg[i] += float(tempo[i].split(":")[2])
            #print(tempSeg[i])
        tempSeg[len(tempo) -1] = tempSeg[len(tempo)-2]
    return tempSeg, info

def main():
    #opening file diretory 
    root = tk.Tk()
    root.withdraw()
    file_path = filedialog.askopenfilename()

    time, info = read_file(file_path)

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
        info[0] = converting_acceleration_to_SI(info[0], 16384)
        info[1] = converting_acceleration_to_SI(info[1], 16384)
        info[2] = converting_acceleration_to_SI(info[2], 16384)
        info = gravity_compensation(info, time)
        plt.plot( list(range(0, len(info[0]))), info[0])    
        plt.plot( list(range(0, len(info[1]))), info[1])    
        plt.plot( list(range(0, len(info[2]))), info[2])    
        plt.title('linear xyz')
        plt.show()
    elif gt == "5":
        plt.scatter(converting_acceleration_to_Gforce(info[0], 16384),converting_acceleration_to_Gforce(info[1], 16384), 3)
        plt.title('diagram GG')
        plt.show()
    elif gt == "6":
        info[0] = converting_acceleration_to_SI(info[0], 16384)
        info[1] = converting_acceleration_to_SI(info[1], 16384)
        info[2] = converting_acceleration_to_SI(info[2], 16384)
        info[4] = converting_ang_to_rad(info[4])
        info[5] = converting_ang_to_rad(info[5])
        info[6] = converting_ang_to_rad(info[6])

        gravity_compensation(info)
        #drawTrack(info, time)

main()
