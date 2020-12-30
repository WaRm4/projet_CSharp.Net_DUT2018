# PC COMPARATOR
-------------------------------------------------------------------------------------------
Cette application sert a gere ses composants, pouvoir les comparer, ajouter, modifier et supprimer.
Elle fonctionne en **local**.

## Specifications :
-------------------------------------------------------------------------------------------

-Obligé de lancer l'appli en tant qu'administrateur pour pouvoir sauvegarder le fichier de 
stockage des composants (donc pour pouvoir ajouter,supprimer ou modifier un composant comme 
la sauvegarde est automatique).

-Tentative dans le setup de placer les fichiers de stockage et d'image dans ProgramData mais 
problème pour y accéder avec les chemins et problème de droits lors de l'écriture (Alors les 
données et images seront placées dans le dossier avec l'application, mais il y a quand même 
un dossier de créé dans ProgramData avec les données).

-L'icone du shortcut après avoir installé l'application ne fonctionne pas.

-HashCode : Utilisation du GUID (Identifiant Unique) car problème de HashCode lors de la modification



#Répartition du travail :

+ Killian : principalement partie code c# et xaml, documentation du code, et mises des documents en fonction, esthétique de l'appli.
+ Maxime : principalement diagrammes, mockup, esthétique de l'appli.
