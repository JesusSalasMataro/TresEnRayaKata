# Tres en ratlla kata

## Introducció
La kata consisteix en implementar una versió simple del joc del 3 en ratlla. Únicament es
poden col·locar fitxes al taulell però no canviar-les de posició.

Els requisits són els següents:

### FASE 1
- El joc disposa d'un taulell de 3x3 caselles buides al començar el joc.
- Tenim fitxes blanques i vermelles que poden ser col·locades al taulell.
- La primera fitxa a col·locar al taulell ha de ser blanca.

### FASE 2
- A cada torn es col·loca una única fitxa al taulell en una de les caselles buides.
- No es permet col·locar dues fitxes del mateix color en torns consecutius.

### FASE 3
- Si no resten caselles buides al taulell el joc termina i el resultat és EMPAT.
- Si amb la col·locació d'una fitxa al taulell hi han tres fitxes del mateix color en linia el joc
finalitza i el resultat és GUANYEN {BLANQUES | VERMELLES}
