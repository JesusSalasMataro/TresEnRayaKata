# Tres en raya kata

## Introducci�n
La kata consiste en implementar una versi�n simple del juego del 3 en raya. �nicamente se 
pueden colocar fichas en el tablero pero no cambiarlas de posici�n.

Los requisitos son los siguientes:

### FASE 1
- El juego dispone un tablero de 3x3 casillas vac�o al iniciar el juego.
- Tenemos fichas blancas y rojas que podr�n ser colocadas en el tablero.
- La primera ficha a colocar en el tablero ser� de las blancas.

### FASE 2
- En cada turno se colocar� una �nica ficha en el tablero en una de las casillas desocupadas.
- No se pueden colocar 2 fichas del mismo color en turnos consecutivos.

### FASE 3
- Si no quedan casillas desocupadas en el tablero el juego termina y el resultado es EMPATE.
- Si con la colocaci�n de una ficha se consigue tener en el tablero 3 fichas del mismo color en l�nea el juego
termina y el resultado es GANAN {BLANCAS | ROJAS}