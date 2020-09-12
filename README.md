# Taller2Scripting
 
## Integrantes
### Juan Esteban Ramírez
### Miguel Ángel Agudelo 

 
### Assets ThirdParty

Pokemon sprites by SkateFilter5 : https://www.deviantart.com/skatefilter5/art/Pokemon2-621060589

Pokémon Eeveelution Assets by ArcherZenmi : https://archerzenmi.itch.io/pokmon-eeveelution-assets-godot

Charmander Sprite Idle by Runica : https://runica.itch.io/charmander-sprite-idle

Tower Defense - Grass Background by Hassekf: https://opengameart.org/content/tower-defense-grass-background

UI Assets by Fast Solutions channel on youtube: https://www.youtube.com/watch?v=7zMssEdi-uM&list=PLgAF6rpCsTCj9c3__jGQCYgtfQFj1TCoB&ab_channel=FastSolution

### ScriptableObject/MonoBehaviour property drawer

Se probaron las diferentes soluciones que se proponían en este foro, hasta que se halló la opción que más se acomodaba a las necesidades.
Esto se hizo porque decidimos hacer las skills como ScriptableObjects, puesto que las skills se dividen en 2 tipos: ataque y defensa, y cada una de estas habilidades hace algo distinto. Esto es mejor hacerlo con los ScriptableObjects, ya que se puede escoger el tipo de habilidad, y se muestran sus parámetros gracias a la solución antes explicada.
Escoger una skill específica y modificarle los parámetros no era posible hacerlo sin los ScriptableObjects o MonoBehaviour, puesto que se podía serializar la clase skill y sus subclases, se podían serializar los parámetros en el inspector, pero no era posible escoger una clase de habilidad específica.
Para hacer esto último, se escogío ScriptableObjects sobre MonoBevahiour dado que no era necesario crear un prefab para una habilidad y no se necesitaba que la habilidad estuviera dentro de un GameObject, lo único que se requería era poder modificar sus atrubutos y acceder a sus métodos.

https://forum.unity.com/threads/editor-tool-better-scriptableobject-inspector-editing.484393/
