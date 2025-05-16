## Diagramme UML (PlantUML)

```plantuml
@startuml
class Reservation {
    +int Id
    +DateTime ReservationDate
    +string Type
    +string Details
    +bool IsConfirmed
    +Client Client
}

class Client {
    +int Id
    +string FirstName
    +string LastName
    +string Email
    +string Phone
}

class Room {
    +int Id
    +string Name
    +string Description
    +decimal Price
    +bool IsAvailable
    +int Capacity
}

class Menu {
    +int Id
    +string Name
    +string Description
    +decimal Price
    +string Category
}

class SpaService {
    +int Id
    +string Name
    +string Description
    +decimal Price
    +int Duration
}

class Event {
    +int Id
    +string Name
    +string Description
    +DateTime EventDate
    +decimal Price
}

Reservation "1" -- "1" Client
Reservation "0..*" -- "0..1" Room
Reservation "0..*" -- "0..1" Menu
Reservation "0..*" -- "0..1" SpaService
Reservation "0..*" -- "0..1" Event
@enduml
``` 
-------------------------------
  PrgFinalSujet3
 Description
PrgFinalSujet3 est une application web ASP.NET Core MVC permettant la gestion compl�te d�un �tablissement h�telier avec services de restauration, spa et organisation d��v�nements.Elle propose la r�servation en ligne, la gestion des chambres, des menus, des services bien-�tre, des �v�nements et un espace d�administration.
  Fonctionnalit�s principales
�	Gestion des r�servations (h�tel, restaurant, spa, �v�nements)
�	Gestion des chambres (types, prix, disponibilit�)
�	Gestion des menus (plats, cat�gories, prix)
�	Gestion des services de spa (types, dur�e, prix)
�	Gestion des �v�nements (cr�ation, r�servation, tarification)
�	Paiement en ligne (PayPal, carte bancaire)
�	Administration (validation, suppression, suivi des r�servations)
  Technologies utilis�es
�	.NET 8.0 / ASP.NET Core MVC
�	Entity Framework Core (SQL Server)
�	Bootstrap 5
�	PayPal SDK (paiement en ligne)
  Structure du projet
�	Controllers/ : Contr�leurs MVC (logique m�tier)
�	Models/ : Mod�les de donn�es (chambres, menus, spa, �v�nements, r�servations)
�	Service/ : Services m�tiers (gestion des entit�s)
�	Views/ : Vues Razor (pages HTML)
�	Migrations/ : Migrations Entity Framework
�	wwwroot/ : Fichiers statiques (CSS, JS, images)
 Structure de la Base de Donn�es
�	Les mod�les principaux incluent :
�	- `Room` (Chambres)
�	- `Menu` (Carte du restaurant)
�	- `SpaService` (Services de bien-�tre)
�	- `Event` (�v�nements)
�	- `Reservation` (R�servations)
�	- `client` (Clients)
 Exemples d�utilisation
�	R�server une chambre, un menu, un soin spa ou une place � un �v�nement
�	G�rer les r�servations depuis l�espace d�administration
�	Payer en ligne via PayPal ou carte bancaire

  Points Forts
     	**Architecture Modulaire**
	   - S�paration claire des responsabilit�s
	   - Utilisation d'interfaces pour les services
	   - Injection de d�pendances

  Auteurs
Dans le cadre du module de programmation .NET, ce projet est r�alis� par :
�	El Qasri Othman
�	Bellal Mouna
�	Baderra Taha
