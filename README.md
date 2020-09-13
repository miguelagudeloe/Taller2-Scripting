# Taller2Scripting
 
## Integrantes
### Juan Esteban Ramírez
### Miguel Ángel Agudelo 


## Patrones de diseño

- **Singleton**
  - Se colocó singleton en el Referee, por la razón de que solo va a haber una instancia de este en la escena, además nos resultaba más fácil acceder a los parámetros que contenía como los jugadores, el jugador específico que está atacando, y a su vez, el jugador que está defendiendo, también al Critter atacante y al Critter defensor.
  - El DisplayDialog también es un singleton, este script se encarga de mostrar los textos de estado de las diferentes entidades que participan en la batalla (Referee, y Critters). Se optó por singleton porque se necesitaba acceder a la única instancia de este que había en escena desde diferentes scripts para que estos le manden el estado que debe mostrar en el cuadro de diálogo específico.

- **Commander**
  - Como en la implementación se requiere que ambos jugadores puedan ser controlados ya sea por el usuario tanto por una inteligencia artificial, se utilizó este patrón para encapsular la acción de escoger qué Skill utilizar al momento de que el Referee le notifique que es su turno. Al jugador le aparece dos listas de 
skills dependiendo de los tipos de estas, y al momento de seleccionar una, se aplica, ya sea un ataque o un soporte; mientras que la IA escoge una Skill random de la lista de movimientos del Critter que está en juego.

- **Observer**
  - En nuestro caso, el control de toma de decisiones es un observer, por el motivo que este control notifica el Referee de que ya terminó de tomar decisiones para que el Referee pueda cambiar turno. Esto se hacer porque no podemos saber el jugador cuándo va a seleccionar un ataque o un soporte, es decir, no podemos estar seguros que después de llamar la función ejecutar del commander el jugador ya ha hecho su movimiento. Esto no sucede con el enemigo, que después de llamarse el execute ya ha seleccionado movimiento. Así que el Referee espera a que el PlayerController llame el evento OnEndAction del jugador/enemigo.
  - Varias clases más notifican eventos, y muchas otras escuchan éstos y ejecutan métodos acorde al evento en el que estén suscritas. Ejemplos pueden ser, el Referee llama el evento del cambio de turno, y los scripts de Display actúan acorde al turno de un jugador específico, ya sea cambiando la vida de los Critters en juego o actualizando los contadores de los Critters vivos y muertos de cada jugador. 
 
***Disclaimer***

No estamos seguros que solamente suscribirse, desuscribirse y escuchar un método sea suficiente para considerarse observer, además que ellos mismos deciden cuándo suscribirse y desuscribirse.


## ScriptableObject/MonoBehaviour property drawer

Se probaron las diferentes soluciones que se proponían en este foro, hasta que se halló la opción que más se acomodaba a las necesidades.
Esto se hizo porque decidimos hacer las skills como ScriptableObjects, puesto que las skills se dividen en 2 tipos: ataque y defensa, y cada una de estas habilidades hace algo distinto. Esto es mejor hacerlo con los ScriptableObjects, ya que se puede escoger el tipo de habilidad, y se muestran sus parámetros gracias a la solución antes explicada.

Escoger una skill específica y modificarle los parámetros no era posible hacerlo sin los ScriptableObjects o MonoBehaviour, puesto que se podía serializar la clase skill y sus subclases, se podían serializar los parámetros en el inspector, pero no era posible escoger una clase de habilidad específica.

Para hacer esto último, se escogío ScriptableObjects sobre MonoBevahiour dado que no era necesario crear un prefab para una habilidad y no se necesitaba que la habilidad estuviera dentro de un GameObject, lo único que se requería era poder modificar sus atributos y acceder a sus métodos.

https://forum.unity.com/threads/editor-tool-better-scriptableobject-inspector-editing.484393/


## Assets ThirdParty

* Pokemon sprites by SkateFilter5 : https://www.deviantart.com/skatefilter5/art/Pokemon2-621060589

* Pokémon Eeveelution Assets by ArcherZenmi : https://archerzenmi.itch.io/pokmon-eeveelution-assets-godot

* Charmander Sprite Idle by Runica : https://runica.itch.io/charmander-sprite-idle

* Tower Defense - Grass Background by Hassekf: https://opengameart.org/content/tower-defense-grass-background

* UI Assets by Fast Solutions channel on youtube: https://www.youtube.com/watch?v=7zMssEdi-uM&list=PLgAF6rpCsTCj9c3__jGQCYgtfQFj1TCoB&ab_channel=FastSolution

* La fuente PressStart2P se sacó de un proyecto antiguo, así que no se conoce de dónde se descargó.
