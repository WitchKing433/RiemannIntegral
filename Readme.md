# Proyecto creado usando Windows Form y el lenguaje de programación C#

### Guía de instalación:

<span style="background-color:#E0F7FA; color:black; font-weight:bold">Instalar dotnet sdk 9.</span>

### Guía de utilización:

<span style="background-color:#FFF5E6; color:black; font-weight:bold">Para utilizar la aplicación se debe ejecutar el archivo: RiemannIntegral.exe</span><br>
![](./img/R.png)<br>
<span style="background-color:#FFF5E6; color:black; font-weight:bold">Ejecutar la aplicación como administrador</span><br>

### Condiciones que debe cumplir el programa para su correcta ejecución:

**1.** **_La función a graficar debe ser continua y positiva en el intervalo desde 0 a el valor definido por el usuario en la esquina inferior derecha de la pantalla._**<br>
![](./img/Intervalo.png)<br>

**2.** **_Para graficar una función es necesario que la sintaxis de la expresión se ajuste a las especificaciones del lenguaje C#, esta se introduce en el cuadro de texto superior de la ventana_**<br>
![](./img/Input.png)<br>
**Operaciones más comunes**<br>
| Operaciones | Expreciones C#|
|--------------|---------------|
| Producto | * |
| Adición |+ |
| Exp: a^b |Pow(a,b) |
|Raíz cuadrada|Sqrt(x)|
|agrupamiento| ()|
|Seno|Sin(x)|

**Alguna otra operación se puede realizar si se encuentra disponible dentro de la clase Math de c#**

**3.** **_En la región inferior de la ventana se encuentran:_**<br> -**Un slider para variar la cantidad de particiones a realizar en tiempo real.**<br> -**La leyenda acerca de las áreas tomadas para cada una de las sumas de Darboux**<br> -**Los resultados aproximados de dichas sumas para la cantidad de particiones elegidas.**<br>

## Información Importante:

**Si el usuario desea cambiar la función graficada es necesario reiniciar la aplicación**

### Ejemplo de una Función

![](./img/Ej1.png)<br>