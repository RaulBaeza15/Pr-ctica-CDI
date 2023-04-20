# Construcción y diseño de interfaces gráficas de usuario

📱 Práctica de realidad aumentada para un smartphone Android utilizando Unity 3D como motor de desarrollo junto con el paquete de Vuforia. La práctica será una variante simplificada del juego Angry Birds AR.

## 🎯 Objetivo
El objetivo de esta práctica consiste en desarrollar una aplicación de realidad aumentada para un smartphone Android utilizando Unity 3D como motor de desarrollo junto con el paquete de Vuforia. La práctica será una variante simplificada del juego Angry Birds AR.

## Mecánica del juego
Al presentar un activador concreto, se mostrará una torre de ladrillos estable que deberá ser derribada con el menor número de lanzamientos de una bola.

Cada activador mostrará un modelo diferente de torre con base cuadrada o rectangular con parámetros que definan su altura y el número de ladrillos por lado.

### Características del muro
Los muros se construirán de manera procedural en tiempo de ejecución de una forma similar a la construcción de un muro real.

Cada ladrillo tendrá un color diferente y un tamaño de 2x1x1 y se colocará de manera que encaje perfectamente para cerrar las esquinas de la torre.

### Activadores
Los activadores serán imágenes 2D que pueden ser aportadas por los miembros del grupo de prácticas. Dichas imágenes tendrán suficientes puntos de control (features) para que puedan ser identificadas desde cualquier ángulo que se mire, es decir, deberán tener al menos 4 estrellas en la web de Vuforia.

Ejemplo de dos activadores para cada tipo de torre.

### Interfaz de usuario

#### Pantalla de inicio
En esta pantalla aparecerá el nombre de la aplicación Android y además debe mostrar un menú inicial con tres opciones:

- Una opción Juego que muestre al usuario la posibilidad de iniciar el juego.
- Una opción Configuración que permita introducir los parámetros de las torres.
- Una opción Créditos que muestre los nombres de los miembros del grupo de la práctica.

En todos los casos se debe poder volver al menú inicial.

#### Juego
En esta opción se activará la cámara AR y empezará la búsqueda de un activador. Una vez encontrado, mostrará la torre correspondiente al activador y se iniciará el juego. El usuario puede girar alrededor de la torre virtual para buscar el mejor punto de impacto.

Cada toque en la pantalla lanzará una bola con masa suficiente para derribar parte del muro al impactar contra él. La bola saldrá frontalmente en línea recta desde la parte de debajo de la pantalla.

En la esquina superior izquierda se mostrará un contador con el número de bolas lanzadas.

En la esquina superior derecha se mostrará el porcentaje de ladrillos derribados.

Cuando se alcance el porcentaje definido en la configuración, por defecto 90%, se dará por acabado el juego y se mostrará una ventana flotante de partida finalizada mostrando el número de bolas lanzadas y el número de ladrillos derribados.

