# Tic tac toe kata

## Introduction
The kata consists of implementing a simple version of the popular game "Tic tac toe".
Players can place pieces on the board but not change their positions.

The requirements are:

### STEP 1
- The game has a board of 3x3 empty boxes at the beginning of the game.
- We have white and red pieces that can be placed on the board boxes.
- The first piece to place must be a white piece.

### STEP 2
- At each turn only a single piece can be placed on the board in one of the empty boxes.
- We can't place two pieces of the same color in consecutive turns.

### STEP 3
- If there are not more empty boxes on the board the game ends and the result is DRAW.
- When a player places a piece on the board and gets three pieces of the same color in a row the 
game ends and the result is {WHITE | RED} WINS
