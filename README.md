# 📜 ACTIVITAT: CODEQUEST - JOC DE ROL PER CONSOLA

## Chapter 1  / Train your wizard
En este capitulo primero pido el nombre del mago y guardo el texto introducido.
Después recorro el nombre carácter por carácter, comprobando que cada uno sea una letra entre ‘A’ y ‘Z’ o entre ‘a’ y ‘z’.

Si todos los caracteres son letras, validateName se mantiene en true y el nombre es válido.
Si encuentro algún carácter que no sea una letra, pongo validateName = false y fuerzo la salida del bucle.

Finalmente, independientemente de si el nombre es true  o false, transformo el nombre para que empiece en mayúscula y el resto esté en minúsculas usando Substring() y  ToUpper() o ToLower().

Si el nombre es true entraré al entrenamiento y si no lo es, mostraré un mensaje de error y te regresara al menu .


### Juego de pruebas - Caso normal
|     i | inputName[i] |  validateName|
| ----  | -----------  |  ----------- |
|     0 | S            |         true |
|     1 | e            |         true |
|     2 | b            |         true |
|     3 | a            |         true |
|     4 | s            |         true |
| result| —            |     **true** |

### Juego de pruebas - Caso Limite
|     i | inputName[i] |  validateName|
| ----  | -----------  |  ----------- |
|     0 | A          |           true |
|result | -           |      **true** |
### Juego de pruebas - Caso Error
|     i | inputName[i] | validateName | 
| ----  | -----------  | -----------| 
|     0 | s            |       true | 
|     1 | e            |       true |
|     2 | b            |       true | 
|     3 | a            |       true | 
|     4 | s            |       true | 
| **5** | **1**        |  **false** | 
| (fin) | —            |  **false** |


## Chapter 2 / Increase LVL (Combat amb daus)
Primero genero un monstruo aleatorio seleccionando su nombre y su cantidad de vida (hpBattle) desde los arrays monsterName y monsterHp.
Luego entro en un bucle mientras el monstruo tenga vida (hpBattle > 0).

En cada turno muestro el nombre del monstruo y su vida actual, y uso una constante de dado que se seleciona a travez de damage que es una variable aleatoria entre 1 y 6, simulando el lanzamiento de un dado.
Dependiendo del número , muestro un mensaje indicando el ataque realizado y resto esa cantidad de vida al monstruo.
El jugador debe presionar una tecla para avanzar turno a turno, de modo que vea cómo va disminuyendo la vida del enemigo.

Cuando la vida del monstruo llega a 0, verifico el nivel del jugador si el nivel es menor a 5, muestro un mensaje de subida de nivel y aumento level en 1 y si ya está en el nivel máximo, solo muestro un mensaje indicando que no puede subir más de nivel.

## Chapter 3 / Loot the mine (Mineria)
Primero preparo dos matrices de 5×5. El mapa real, llamado mining, decide si cada casilla tiene una moneda o un fallo, con un 30% de probabilidad de una moneda.
El segundo mapa, showMining, empieza  con el símbolo “➖” en cada posicion, que es lo que verá el jugador.
Después comienzo un bucle mientras el jugador tenga intentos.
En cada turno muestro el mapa descubierto hasta ahora, pido las coordenadas Y y X, y compruebo si están dentro del rango.
Si las coordenadas son válidas, reviso la matriz real:

Si hay una moneda y la casilla todavía no estaba excavada, la descubro, genero un número aleatorio de bits, lo sumo a bitCharacter y marco esa casilla como “🪙”.
Si el jugador cava donde ya había encontrado una moneda antes, le aviso que ya excavó allí y marco la casilla como “❌”.

Si en esa posición no había nada, marco el fallo con “❌”.Si las coordenadas están fuera de rango o el formato es incorrecto, muestro un error y resto un intento igualmente.

Cada acción del jugador consume un intento.
Cuando los intentos llegan a cero, muestro los bits conseguidos y te regresa al menu.

### Juego de pruebas - Caso normal
| i | mapY | mapX | mining[mapY,mapX] | showMining | bitRandom | bitCharacter | attemps |
| ----   | --- |  --- | -------------|   --------| --------  | ----------- | ----- |
|     1 |    0 |    2 |           🪙 |  🪙    |        17 |           17 |       4 |
|     2 |    3 |    0 |           🪙 | 🪙    |        32 |           49 |       3 |
|     3 |    0 |    2 |          🪙  | ❌     |         — |           49 |       2 |
|     4 |    1 |    1 |           ❌ | ❌     |         — |           49 |       1 |
|     5 |    4 |    3 |           🪙 | 🪙    |        22 |           71 |       0 |

### Juego de pruebas - Caso Limite
| i | mapY | mapX | mining[mapY,mapX] | showMining | bitRandom | bitCharacter | attemps |
| - | ---- | ---- | ----------------- | ---------- | --------- | ------------ | ------- |
| 1 | 1    | 4    | 🪙                | 🪙         | 12        | 12           | 4       |
| 2 | 0    | 0    | ❌                 | ❌          | —         | 12           | 3       |
| 3 | 4    | 0    | ❌                 | ❌          | —         | 12           | 2       |
| 4 | 2    | 2    | ❌                 | ❌          | —         | 12           | 1       |
| 5 | 3    | 3    | ❌                 | ❌          | —         | 12           | 0       |

### Juego de pruebas - Caso Error
| i | mapY | mapX | mining[mapY,mapX] | showMining  | bitRandom | bitCharacter | attemps |
| - | ---- | ---- | ----------------- | ----------- | --------- | ------------ | ------- |
| 1 | 0    | 1    | 🪙                | 🪙          | 14        | 14           | 4       |
| 2 | 3    | 3    | ❌                 | ❌           | —         | 14           | 3       |
| 3 | 9    | 2    | —                 | —  | —         | 14           | 2       |
| 4 |    1 |    1 |           ❌ | ❌     |         — |           14 |       1 |
| 5 |    4 |    3 |           🪙 | 🪙    |        22 |           66|       0 |

## Chapter 4 / Show inventory
Primero creo un array de 5 espacios llamado inventory, donde cada posición representa un objeto diferente y el valor indica cuántas unidades tiene el jugador de ese objeto.
Si todos los valores del array son 0, significa que el jugador no ha comprado ningún objeto, así que muestro un mensaje indicando que el inventario está vacío.

Si hay objetos en el inventario, recorro cada posición del array. Por cada valor diferente a cero, imprimo el nombre del objeto correspondiente desde el array shop tantas veces como indique el valor del inventario. Esto permite mostrar la cantidad de cada objeto que posee el jugador.



## Chapter 5 / Buy items
Primero muestro la lista de objetos disponibles en la tienda con sus precios.
El jugador escribe el número del objeto que quiere comprar y compruebo si la opción existe (entre 1 y 5).
Si existe, reviso si el jugador tiene los bits suficientes. Si puede comprarlo, incremento en 1 la posición correspondiente del array inventory, y resto los bits del precio.
Si no tiene dinero, muestro un mensaje correspondiente y si la entrada es una letra o algo no válido, salto al catch y muestro error de formato.
El jugador también puede salir de la tienda si escribe 0.
### Juego de pruebas - Caso normal
| i | shopOption | bitCharacter    | price[shopOption-1] | shopOption >= 1 && shopOption <= 5 |inventory |   validateShop |
| - | ---------- | -------------------- | ------------------- | --------------- | --------------- |-----|
| 1 | 4          | 60                   | 40                  | true              | {0,0,0,0,0}     |   true         |
| 2 | 4          | 20                  | -                 | -             | {0,0,0,1,0}     |   true         |
### Juego de pruebas - Caso Error
| i | shopOption | bitCharacter  | price[shopOption-1] | shopOption válido | inventory   | validateShop |
| - | ---------- | ------------- | ------------------- | ----------------- | ----------- | ------------ |
| 1 | 9          |  60           | false              | false             | {0,0,0,0,0} | —            |
| 2 | 9          | 60           | false               | -             | {0,0,0,1,0}     |   true         |
## Chapter 6 / Show attacks by LVL
Primero preparo un jagged array llamado powerLevel, donde cada fila representa un nivel y contiene los ataques disponibles para ese nivel.
Cuando el jugador accede a este capítulo, recorro cada fila del powerLevel y comparo su nivel level - 1 con el índice de la fila si el índice coincide con level - 1, imprimo todos los ataques de esa fila y si el nivel del jugador supera el tamaño del array, entonces muestro los ataques del último nivel disponible para evitar errores. Esto lo hice con la idea de que se podia subir aun mas de nivel luego me di cuenta que el enunciado declara que el level maximo es 5 . 

De esta manera, el jugador siempre ve únicamente los ataques que le corresponden según su nivel, y el código maneja correctamente casos donde el nivel pueda ser mayor que el número de filas definidas en el powerLevel.
## Chapter 7 / Decode ancient Scroll (Desxifratge de pergamins)
Primero muestro un menú con los tres pergaminos disponibles y pido al jugador que seleccione uno mediante scrollOpcion.

Cada pergamino tiene una función diferente:

- Primer pergamino: tomo el texto completo, elimino los espacios y lo guardo en result para mostrarlo como mensaje descifrado.
- Segundo pergamino: recorro el texto y cuento todas las vocales (a, e, i, o, u) y muestro el total encontrado.
- Tercer pergamino: busco todos los números del 1 al 9 en el texto y los concateno en secretNumber, que luego muestro.

Cada vez que el jugador completa un pergamino, se igual countCase1, countCase2, countCase3 a 1 .
Si los tres contadores suman 3, significa que el jugador ha descifrado los tres pergaminos y muestro un mensaje.

Si el jugador introduce un valor fuera del rango de opciones o un formato inválido como letras en lugar de números, capturo la excepción, muestro un mensaje de error y regreso al menú.
### Juego de pruebas - Caso normal
| i | scrollOpcion | countCase1 | countCase2 | countCase3 |  countCase1 + countCase2 + countCase3 == 3                                      |
| - | ------------ | ---------- | ---------- | ---------- | ----------------------------------------------- |
| 1 | 1            | 1          | 0          | 0          | false         |
| 2 | 2            | 0          | 1          | 0          | false        |
| 3 | 3            | 0          | 0          | 1          | false        |
| 4  | result      | 1          | 1          | 1          | true     (Msg de decodificaste todo los pergaminos )    |

### Juego de pruebas - Caso Error
| i | scrollOpcion | countCase1 | countCase2 | countCase3 | countCase1 + countCase2 + countCase3 == 3                   |
| - | ------------ | ---------- | ---------- | ---------- | --------------------------------------- |
| 1 | 1            | 1          | 0          | 0          | false                                   |
| 2 | 4            | 1          | 0          | 0          | false (Opción inválida, vuelve al menú) |

