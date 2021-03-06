# Teleport

Ceci est un projet d’exemple sur comment téléporter un avatar ainsi que la caméra virtuelle attachée en masquant la transition avec un fondu enchainé.

# Structure du projet

Explications des différents fichiers ajoutés au projet par rapport à un projet URP vide.

## Materials

* Eyes: Utilisé pour représenter l’avant de l’avatar.
* Trigger: Utilisé pour représenter les zones de téléportation. **Attention**, il faut que le paramètre *Surface Type* soit bien en *Transparent* afin de pouvoir diminuer l’alpha de la couleur.

## Prefabs

* LoadingScreen: Canvas qui contient l’écran de chargement.
* Player: L’avatar du projet.
* Spawn: Les points d’arrivée de la téléportation.
* Trigger: Les zones d’activation de la téléportation.

## Scenes

* Game: Scène d’exemple.

## Scripts

Tous les scripts sont commentés afin d’apporter des précisions techniques sur leurs fonctionnements.

* **DestroyOnExit**: *StateMachineBehaviour* qui détruit l’objet attaché quand un état se termine.
* **ForwardVelocityManager**: *MonoBehaviour* qui applique un mouvement vers l’avant/arrière lorsque déclenché.
* **PlayerController**: *MonoBehaviour* qui récupère les inputs de l’Input System afin de déclencher *ForwardVelocityManager* et *RotationManager*.
* **RotationManager**: *MonoBehaviour* qui applique une rotation dans une direction donnée lorsque déclenché.
* **Teleport**: *MonoBehaviour* qui s’attache à un *Collider* en *isTrigger* et permet de téléporter l’objet taggé Player ainsi que sa caméra virtuelle. Fait également apparaitre un écran de chargement pour cacher la téléportation.

# Mise en place du projet

Explications des éléments nécessaires pour faire fonctionner l’ensemble des scripts dans un nouveau projet.

## Préparation de l’avatar

* Sur une capsule, ajoutez un *Rigidbody* ainsi que les scripts *PlayerController*, *ForwardVelocityManager* & *RotationManager*.

![Tuto1](https://user-images.githubusercontent.com/14953106/166448105-281c85ff-c675-4104-9417-f6cd7269ae1a.png)

* Reliez l’action *Move* du *PlayerInput* au *PlayerController*. 

![Tuto2](https://user-images.githubusercontent.com/14953106/166448266-16e15f97-8b14-4625-b91e-adc7a43c0e16.png)

## Préparation de l’écran de chargement 

* Créez et configurez un canvas qui contient au moins une image noire qui prend tout l’écran. Sur cette image, ajoutez le component *Canvas Group*. Tous les autres éléments de décoration devront être en enfant de cette image. 

![Tuto3](https://user-images.githubusercontent.com/14953106/166448399-faf79d6a-7497-4fe0-9f04-27dd351377e1.png)

* Animez le canvas afin de créer deux animations : 
	* Une animation d’apparition qui passe la valeur *Alpha* du *Canvas Group* de 0 à 1.
	* Une animation de disparition qui passe la valeur *Alpha* du *Canvas Group* de 1 à  0.

![Tuto4](https://user-images.githubusercontent.com/14953106/166448574-b60c20a2-90aa-45c8-9d51-31adbbd1bc82.png)

* Désactivez le fait que les animations bouclent.
* Dans l’*Animator Controller* associé à l’*Animator* du canvas, mettez l’animation d’apparition comme première animation. Puis reliez-la à l’animation de disparition en ajoutant un trigger qui conditionne le déclenchement de la deuxième animation. Enfin reliez l’animation de disparition à l’état *Exit*.

![Tuto5](https://user-images.githubusercontent.com/14953106/166448738-014617db-a6d0-47f0-9533-09f1a3dfb361.png)

* Sur l’état lié à l’animation de disparition, ajoutez le script *Destroy On Exit* qui va détruire le canvas une fois la disparition finie.

![Tuto6](https://user-images.githubusercontent.com/14953106/166448816-67231779-fc14-471c-bd83-2228229e1ecf.png)

## Préparation d’une nouvelle scène

Pour que les scripts fonctionnent, il faut :
* Que l’avatar du jeu ait un component qui déclenche les triggers
* Que l’avatar du jeu soit taggé *Player*
* Que la caméra ayant le *Cinemachine Brain* soit taggée *MainCamera*

Également chaque zone de téléportation doit avoir:

* Un collider marqué en *isTrigger*
* Le script *Teleport* d’attaché
* La valeur *End Point* de *Teleport* qui représente un *Transform* présent **dans la scène**.
* La valeur *Loading Screen* de *Teleport* qui représente **le prefab** de l’écran de chargement.

![Tuto7](https://user-images.githubusercontent.com/14953106/166449236-7fbf09e4-8681-4a70-b313-e4052465c926.png)
![Tuto8](https://user-images.githubusercontent.com/14953106/166449272-1852cad0-1567-4dd0-8094-1cc143922f49.png)

