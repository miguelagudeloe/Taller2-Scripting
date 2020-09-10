# Taller2Scripting
 
 
 
### Assets ThirdParty

Pokemon sprites by SkateFilter5 : https://www.deviantart.com/skatefilter5/art/Pokemon2-621060589

Pokémon Eeveelution Assets by ArcherZenmi : https://archerzenmi.itch.io/pokmon-eeveelution-assets-godot

Charmander Sprite Idle by Runica : https://runica.itch.io/charmander-sprite-idle

Tower Defense - Grass Background by Hassekf: https://opengameart.org/content/tower-defense-grass-background

UI Assets by Fast Solutions channel on youtube: https://www.youtube.com/watch?v=7zMssEdi-uM&list=PLgAF6rpCsTCj9c3__jGQCYgtfQFj1TCoB&ab_channel=FastSolution

### ScriptableObject property drawer

Se probaron las diferentes soluciones que se proponían en este foro, hasta que se halló la opción que más se acomodaba a las necesidades.
Esto se hizo porque decidimos hacer las skills como ScriptableObjects, puesto que las skills se dividen en 2 tipos: ataque y defensa, y cada una de estas habilidades hace algo distinto. Esto es posible hacerlo con los ScriptableObjects, se puede escoger el tipo de habilidad, y se muestran sus parámetros gracias a la solución antes explicada.
Escoger una skill específica y modificarle los parámetros no era posible hacerlo sin los ScriptableObjects, puesto que se podía serializar la clase skill y sus subclases, se podían serializar los parámetros en el inspector, pero no era posible escoger una clase de habilidad específica.

https://forum.unity.com/threads/editor-tool-better-scriptableobject-inspector-editing.484393/
