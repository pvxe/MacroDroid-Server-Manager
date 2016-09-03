# MacroDroid
### Español
MacroDroid es un conjunto de dos aplicaciones (cliente-servidor) que permite al usuario configurar una serie de combinaciones de teclas(macros) en su ordenador para posteriormente mediante una conexión en la misma red usar un smartphone Android que muestre el teclado de macros y permita su ejecución.

Este conjunto fue entregado como proyecto final para el Ciclo Formativo de Grado Superior en Desarollo de Aplicaciones Multiplataforma en el I.E.S Nervion en el curso 2015/2016

Puedes encontrar la documentación del proyecto completo en el siguiente [enlace](https://drive.google.com/folderview?id=0B-jZomcW1NqTOUV6cEM2Nnlrakk&usp=sharing)
## MacroDroid-Server-Manager
### Español
Este es el repositorio para la aplicación del lado del servidor para el sistema MacroDroid.  
>Puedes encontrar el repositorio para la aplicación cliente [aquí](https://github.com/JMGuisadoG/MacroDroid-Client-Android)  

Maneja una conexión con un cliente y permite a su vez configurar hasta seis macros distintas.

![Pantalla principal macros](http://i68.tinypic.com/33ndpjr.png)

Al pulsar en una macro se abren los detalles de la misma, donde se puede activar el *Modo escucha* para que (casi todas) las teclas pulsadas sean capturadas y se guarden dentro de la macro.

![Pantalla detalles macro](http://i63.tinypic.com/2w4a9z4.png)

En segundo plano existe un servidor a la escucha de una conexión, en el apartado *Conexión* de la pantalla principal podemos observar el estado actual, el cual se actualiza en tiempo real.

![Pantalla principal conexión](http://i65.tinypic.com/20gd7om.png),
#### Tecnologías

* .NET Framework 4.5.2
* Interfaz de usuario desarrollada en WPF
* C#  

---
#### Aviso
* Actualmente el código fuente subido corresponde a un volcado de toda la aplicación el momento de la entrega, existen ciertos proyectos dentro de la solución que no tienen uso alguno en el funcionamiento de la aplicación.
* Bugs no listados (por ahora)
