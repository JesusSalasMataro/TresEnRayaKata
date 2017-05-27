# Tres en raya kata

## Introducción
La kata consiste en implementar una versión simple del juego del 3 en raya. Únicamente se 
pueden colocar fichas en el tablero pero no cambiarlas de posición.

Los requisitos son los siguientes:

### FASE 1
- El juego dispone un tablero de 3x3 casillas vacío al iniciar el juego.
- Tenemos fichas blancas y rojas que podrán ser colocadas en el tablero.
- La primera ficha a colocar en el tablero será de las blancas.

### FASE 2
- En cada turno se colocará una única ficha en el tablero en una de las casillas desocupadas.
- No se pueden colocar 2 fichas del mismo color en turnos consecutivos.

### FASE 3
- Si no quedan casillas desocupadas en el tablero el juego termina y el resultado es EMPATE.
- Si con la colocación de una ficha se consigue tener en el tablero 3 fichas del mismo color en línea el juego
termina y el resultado es GANAN {BLANCAS | ROJAS}