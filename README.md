# Teleport

Ceci est un projet d’exemple sur comment téléporter un avatar ainsi que la caméra virtuelle attachée en masquant la transition avec un fondu enchainé.

# Structure du projet

Explications des différents fichiers ajoutés au projet par rapport à un projet URP vide.

## Materials

*	Eyes: Utilisé pour représenter l’avant de l’avatar.
*	Trigger: Utilisé pour représenter les zones de téléportation. **Attention**, il faut que le paramètre *Surface Type* soit bien en *Transparent* afin de pouvoir diminuer l’alpha de la couleur.

## Prefabs

* LoadingScreen: Canvas qui contient l’écran de chargement.
* Player: L’avatar du projet.
* Spawn: Les points d’arrivée de la téléportation.
* Trigger: Les zones d’activation de la téléportation.

## Scenes

* Game: Scène d’exemple.

## Scripts

* **DestroyOnExit**: *StateMachineBehaviour* qui détruit l’objet attaché quand un état se termine.
* **ForwardVelocityManager**: *MonoBehaviour* qui applique un mouvement vers l’avant/arrière lorsque déclenché.
* **PlayerController**: *MonoBehaviour* qui récupère les inputs de l’Input System afin de déclencher *ForwardVelocityManager* et *RotationManager*.
* **RotationManager**: *MonoBehaviour* qui applique une rotation dans une direction donnée lorsque déclenché.
* **Teleport**: *MonoBehaviour* qui s’attache à un *Collider* en *isTrigger* et permet de téléporter l’objet taggé Player ainsi que sa caméra virtuelle. Fait également apparaitre un écran de chargement pour cacher la téléportation.

# Mise en place du projet

Explications des éléments nécessaires pour faire fonctionner l’ensemble des scripts dans un nouveau projet.

## Préparation de l’avatar

* Sur une capsule, ajoutez un *Rigidbody* ainsi que les scripts *PlayerController*, *ForwardVelocityManager* & *RotationManager*.
* Reliez l’action *Move* du *PlayerInput* au *PlayerController*. 

## Préparation de l’écran de chargement 

* Créez et configurez un canvas qui contient au moins une image noire qui prend tout l’écran. Sur cette image, ajoutez le component *Canvas Group*. Tous les autres éléments de décoration devront être en enfant de cette image. 
* Animez le canvas afin de créer deux animations : 
	* Une animation d’apparition qui passe la valeur *Alpha* du *Canvas Group* de 0 à 1.
	* Une animation de disparition qui passe la valeur *Alpha* du *Canvas Group* de 1 à  0.
* Désactivez le fait que les animations bouclent.
* Dans l’*Animator Controller* associé à l’*Animator* du canvas, mettez l’animation d’apparition comme première animation. Puis reliez-la à l’animation de disparition en ajoutant un trigger qui conditionne le déclenchement de la deuxième animation. Enfin reliez l’animation de disparition à l’état *Exit*.
* Sur l’état lié à l’animation de disparition, ajoutez le script *Destroy On Exit* qui va détruire le canvas une fois la disparition finie.

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