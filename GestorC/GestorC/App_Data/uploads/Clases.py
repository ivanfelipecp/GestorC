from Funciones import *

class Persona:
    def __init__(self,n,e):
        self.__nombre = n
        self.__edad = e
        
    def saludar(self):
        print("Mi nombre es "+self.nombre+" y tengo "+self.edad+" años")

    def setNombre(self,n):
        self.__nombre = n

    def getNombre(self):
        return self.__nombre



a = Persona("Ivan","20")
print(a.getNombre())
a.setNombre("David")
print(a.getNombre())
