#ZooTopie

Un jeu de gestion de zoo en C# où vous gérez des animaux, des habitats, un budget et faites face à des événements aléatoires.

#Table des matières

- Présentation
- Animaux
- Habitats
- Visiteurs & Revenus
- Budget
- Événements
- Actions disponibles
- Architecture

# Présentation

Zoo Manager est un jeu au tour par tour. Chaque tour représente **un mois**. Vous devez gérer vos animaux, votre nourriture, vos habitats et votre budget pour faire prospérer votre zoo.

# Animaux

# Espèces disponibles

Tigre
Aigle
Poule

La saison "haute" s'étend de "mai à septembre", la saison "basse" le reste de l'année.

# Reproduction

Un animal peut se reproduire : uniquement si :

- Il y a assez d'espace dans l'habitat pour lui et le futur jeune.
- Il n'est pas malade.

# Maladies

Chaque mois, un individu peut tomber malade selon sa probabilité annuelle (divisée par 12 pour le calcul mensuel).

| Animal | Probabilité (par an) | Durée de maladie | Variation durée |
|--------|----------------------|-----------------|-----------------|
| Tigre  | 30%                  | 15 jours        | ± 20%           |
| Aigle  | 10%                  | 30 jours        | ± 20%           |
| Poule  | 5%                   | 5 jours         | ± 20%           |

- Taux de mortalité** lors d'une maladie : 10%
- Un animal malade **ne se reproduit pas**

## Habitats

Les habitats ont une capacité limitée. Si la population dépasse la capacité, un événement de **surpopulation** est déclenché.

### Actions possibles sur les habitats

- Acheter un habitat
- Vendre un habitat

# Visiteurs & Revenus

# Tarifs d'entrée

| Catégorie | Prix |
|-----------|------|
| Adulte    | 17 € |
| Enfant    | 13 € |

# Topologie type d'un groupe de visiteurs

2 adultes + 2 enfants → 34 € + 26 € = 60 € par groupe

Le nombre de visiteurs dépend du nombre d'animaux par espèce et de la saison. Chaque valeur varie de ± 20% aléatoirement.

# Budget

# Budget initial

80 000 €

# Subventions annuelles (espèces protégées)

| Espèce | Subvention par individu / an |
|--------|------------------------------|
| Aigle  | 2 190 €                      |
| Tigre  | 43 800 €                     |

Les subventions sont versées "annuellement", proportionnellement au nombre d'individus vivants.

# Événements

# Événements réguliers (chaque mois)

| Événement        | Déclencheur                          |
|-----------------|--------------------------------------|
| Grossesse        | Conditions de reproduction réunies   |
| Naissance        | Après une grossesse                  |
| Mort infantile   | Probabilité à la naissance           |
| Fin de vie       | Animal trop vieux                    |
| Surpopulation    | Habitat plein                        |
| Maladie          | Probabilité mensuelle par espèce     |

# Événements exceptionnels (probabilité mensuelle)

| Événement      | Probabilité | Conséquence                    |
|---------------|-------------|-------------------------------|
| Incendie       | 1%          | Perte d'1 habitat              |
| Vol            | 1%          | Perte d'1 spécimen             |
| Nuisibles      | 20%         | Perte de 10% des graines       |
| Viande avariée | 10%         | Perte de 20% de la viande      |

# Actions disponibles

À chaque tour, le joueur peut effectuer les actions suivantes :

- Achat / vente d'un animal
- Achat de nourriture (viande, graines)
- Achat / vente d'un habitat
- Passer au tour suivant

# Architecture

Le projet suit une architecture orientée objet avec les classes principales suivantes :

Zoo
├── Budget
├── Tarif
├── StockNourriture
├── Saison (enum)
├── List<Animal>
│   ├── Tigre
│   ├── Aigle
│   └── Poule
├── List<Habitat>
├── List<Evenement>
│   ├── EvenementMaladie
│   ├── EvenementVol
│   ├── EvenementIncendie
│   └── EvenementNuisibles
└── GestionnaireSave

# Sauvegarde

Le jeu supporte 3 slots de sauvegarde.

#  Technologies

- Langage : C#
