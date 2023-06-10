# Task Manager - Clean Architecture

*<u>Auteurs</u>: Paul Barrié - Luigi Carole - Thomas Lemaire - Si-Mohammed Sonia-taous*

## Description des cas d'usage métiers

## Description de l'Architecture retenue

Les cas d'usage métiers demandés sont globalement assez pauvre en complexité. Il s'agit peu ou proux
d'un CRUD. Le problème à traiter est au final assez simple et se découpe systématiquement en trois
phases :
* Traiter l'input fourni par l'utilisateur (via la ligne de commande)
* Opérer un traitement qui est en gros une requête à la base de données JSON
* Renvoyer des informations à l'utilisateur (par la sortie standard)

Nous avons donc simplement découpé notre solution pour traiter ces trois grands blocs : interface utilisateur,
domaine des tâches et retour utilisateur.
Nous avons pris soin de diviser les actions liées aux tâches en commande (ajout, suppression, mise à jour) 
et requêtes (get, list).