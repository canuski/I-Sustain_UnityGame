# Documentatie Project
## Introductie
Welkom bij onze game. Deze game heet 'I Sustain' en bevindt zich in een wereld die 'Discordia' heet.

Je zal in het eerste level zien hoe Discordia is vernietigd en zelf kunnen ervaren hoe het is om in een wereld van verwoesting en anti-sustainability te zijn.

In het tweede level zal je beginnen aan een missie als de leider van een volk dat zich probeert af te weren van het leger dat de eerste wereld (eerste level) volledig heeft vernietigd. Dit leger probeert alle grondstoffen te stelen van uw landen, dit is te merken aan het reuze boorgat in de grond. Je zal verschillende taken moeten uitvoeren zoals het verzamelen van afval, het opblazen van de slechteriken en genieten van de mooie wereld. Ben je hier succesvol in en lukt het om het kasteel van de vijand te vernietigen dan komt je volk vrij en kan je naar het volgende level gaan.

Het derde level is gebaseerd op een wereld die op Discordia lijkt, maar het is al volledig verwoest geweest. Je kan dit zien aan de talloze mijnen verspreid over de grond en hoe de laatste mensheid zich heeft opgesloten achter krachtvelden. Het is de taak van de robot om de wereld op te ruimen door verlaten voertuigen te vernietigen. Daarnaast ligt het lot van de laatste mensheid in handen van de robot. Hij moet namelijk munten verzamelen om windmolens te activeren. Worden deze niet geactiveerd, dan verslechteren de leefomstandigheden van de mensheid nog meer.

Als je level 3 hebt voltooid, zal er in level 4 een zeer moeilijke opdracht te wachten staan. Deze opdracht is een 'only-up' game waarbij je elektrische auto-onderdelen moet verzamelen. Deze elektrische auto zal in de volgende level weer tevoorschijn komen. Het is belangrijk voor Discordia om met elektrische voertuigen te rijden omdat die de kostbare grondstoffen besparen.

In het laatste level, level 5, is er een rustige afsluiter. Je kan hier genieten van een rustige cruise door een mooi landschap. De rustgevende vibe van deze level, geïnspireerd door 'I Drive' van Ryan Gosling, is een ideale afsluiter voor een leuke en informatieve game. Laat je niet verleiden door de rust! Je moet namelijk 'Discordia leaves' verzamelen voordat de tijd uitloopt! Als het je lukt om de Discordia leaves te verzamelen en het einde van de level te bereiken, zal je nog de mooie zonsondergang kunnen bekijken voordat onze game wordt beëindigd.

## Designproces
#### 1. Vooronderzoek en projectdefinitie
  - Vergadering gehouden om het project te bespreken, op ideeën te komen en om rollen toe te wijzen.
  - Basisproject vastgesteld.
#### 2. Brainstorming
  - Brainstormsessies gehouden tijdens lab-momenten.
  - Bepaal de haalbaarheid binnen de toegewezen tijd.
#### 3. Definiteif ontwerp
  - Tijdens de laatste lables een grondig idee hebben van het project en hoe het er gaat uit zien.
  - Elk teamlid een level toewijzen.
  - Communicatiemiddelen opgezet (discord groep).
#### 4. Ontwikkeling en programming
  - Tijdens de toegewezen tijd de opdrachten uitvoeren.
  - Het ontwikkelen van de game begint nu.
  - Communicatie onderhouden met andere teamleden over voortgang en status.
#### 5. Definiteive documentatie
  - README en desgin document opstellen en uittypen
  - Als er nog updates gebeuren, ervoor zorgen dat de documentatie juist wordt aangepast

## Technische implementatie
De game is gebouwd in Unity 2022.3.10f1. We gebruiken Visual Studio om onze scripts in C# te programmeren. Sommige teamleden hebben gebruik gemaakt van Blender om bepaalde dingen te ontwerpen. Deze .blend bestanden worden geëxporteerd als .fbx files. Alle teamleden maken gebruik van assets uit de Unity Asset Store [https://assetstore.unity.com/]. Hieronder wordt per teamlid meer uitleg gegeven over het gebruik van specifieke assets.

Voor het toevoegen van audio gebruiken we websites zoals [https://freesound.org/] en open source software zoals NewPipe [https://github.com/TeamNewPipe/NewPipe/]. We maken gebruik van de URP (Universal Render Pipeline) pipeline. Die beidt optimale prestaties, is gemakkelijk om te gebruiken voor cross-platform implementaties, ideaal is voor VR en AR programmering en eenvoudig te gebruiken is. We hebben veel gebruik gemaakt van de built-in pipeline -> URP converter die standaard aanwezig is in Unity 2022.3.10f1.

Het is de bedoeling dat onze game op Windows draait: voor andere platforms bieden we geen ondersteuning en hebben we geen mogelijkheid om te testen.

## Haitam Baqoul - Level 1
#### Contribution
- welke taak, level, componenten heb je aan gewerkt
- welke problemen had je en hoe lost je ze op
#### Educational value
- welke sustainability leert je game aan
#### Rescources used 
- zet hier de dingen die je hebt gebruikt:youtube, assets die je gebruikt, turtorials,...

## Oscar Alexander - Level 2
#### Contribution
- Ik heb me beziggehouden met het beheer van de projectrepository op Github. Ik had meerdere taken, zoals het ondersteunen van mensen die iets niet begrepen, oplossen van alle merge conflicten, beheren van branches, het aanmaken en bijhouden van de README, en zorgen voor goede communicatie over alles wat ik heb aangepast, veranderd of toegevoegd aan de projectrepo.
- Ik hield me ook bezig met het proberen te origaniseren van momenten dat we samen kwamen om de vooruitgang te bespreken.
- Ik heb level 2 gemkaat, met het oog op mooie graphics, een leuke maar niet moeilijk gameplay en educatief op vlak van sustainability
##### Problems
- Ik ondervond veel problemen bij het gebruik van Github. Github niet gemaakt om vlot te kunnen integreren met een Unity-project.
- Het was moeilijk om een goede .gitignore op te stellen wanneer iedereen zeer grote geïmporteerde assets gebruikt. Daarnaast duurde het ook heel lang om te pushen. Je moet elke map apart pushen, anders wordt het limiet van Github bereikt en mislukt de push. Ik heb het gitignore-probleem kunnen oplossen door iedereen een "ImportedAssets" map aan te laten maken en daarin alle grote geïmporteerde assets tijdelijk te plaatsen, totdat ze konden verwijderen wat ze niet meer nodig hadden.
- Ik had weinig problemen met Unity zelf. Als ik een tutorial vond in de online documentatie, was het altijd gemakkelijk om mee te volgen en te leren. Ik had wel een probleem met mijn camera die schudde. Om dit op te lossen, maak ik gebruik van de .smoothFollow().
- Ik heb veel kleinere foutjes gehad, zoals het niet hebben van een Rigidbody ergens of het activeren van de verkeerde soort collision. Deze waren altijd gemakkelijk op te lossen.
#### Educational value
- Mijn level leert dat het van groot belang is om afval op te ruimen en te proberen niet veel afval te creëren. Daarnaast leert mijn level ook aan dat we moeten opkomen voor onze natuur. We mogen ons niet zomaar laten doen terwijl grote bedrijven (in het geval van mijn level het leger van Hayatam) onze grondstoffen opzuigen en enkel om geld denken.
#### Rescources used
- Ik heb gebruik gemaakt van YouTube, meer specefiek veel video's van *Brackeys* en *BurgZerg Arcade*. Ik maakte ook gebruik van online documentatie en forums, vooral voor het oplossen van problemen.
- Ik heb gebruikt gemaakt van veel assets vanuit de unity store;
  - `Tree Collection Pack 2` by ALIyerEdon
  - `Countryside gas station` by VGtiXN
  - `Oil Tank` by Pixel Games
  - `4 Industrial barrels` by Vertex Field
  - `Free Fire VFX - URP` by Vefects
  - `Outdoor Ground Textures` by A dog's life software
  - `Terrain Sample Asset Pack` by Unity Technologies
  - `Star Sparrow Modular Spaceship` by Ebal Studios
  - ...

## Mohammed Asad - Level 3
#### Contribution
- Ik heb het team financieel ondersteund bij het verbeteren van de GitHub LFS subscription voor de repository owner. 
- Ik heb level 3 ontworpen met educatieve doeleinden in gedachten, terwijl ik de spelers nog steeds uitdaag met boeiende taken.
##### Problems
- Bij het creëren van eigen assets in Blender ontdekte ik dat de hoeveelheid polygonen invloed heeft op de prestaties van mijn gameplays, net zoals de bestandsgrootte aanzienlijk toeneemt als je Blender-assets niet correct exporteert naar een .fbx-bestand.
- De bestandsgrootte heeft invloed op de GitHub-repo, aangezien je slechts 2 GB LFS bandbreedte per maand gratis hebt.
#### Educational value
- Ik heb een level 3 gecreëerd waarin spelers de gevolgen van menselijke hebzucht, oorlogen en financiële problemen ervaren. In dit level navigeer je door bossen, ontwijk je landmijnen, verzamel je munten voor zuivere energie en leer je dat energiezuinigheid kostbaar is. Tegelijkertijd tracht ik de spelers aan te moedigen om zoveel mogelijk resources te recyclen en de natuur op te ruimen, terwijl ik benadruk dat zuivere energie een hoge prijs heeft. Daarnaast leg ik uit dat oorlogen en corporate greed invloed hebben op de levensomstandigheden van komende generaties.
#### Rescources used
- De meerderheid van mijn assets zijn zelf gemaakt zoals:
  - Windmolens
  - Speler
  - Enemies
  - Landmijnen
  - Coins
  - Checkpoints
- De spelers krijgen extra uitleg via een AI-voice die de huidige situatie van het level uitlegt.

## Maximilan Duda - Level 4
#### Contribution
- welke taak, level, componenten heb je aan gewerkt
- welke problemen had je en hoe lost je ze op
#### Educational value
- welke sustainability leert je game aan
#### Rescources used
- zet hier de dingen die je hebt gebruikt:youtube, assets die je gebruikt, turtorials,...

## Turgay Fatih Yaşar - Level 5
#### Contribution
- welke taak, level, componenten heb je aan gewerkt
- welke problemen had je en hoe lost je ze op
#### Educational value
- welke sustainability leert je game aan
#### Rescources used
- zet hier de dingen die je hebt gebruikt:youtube, assets die je gebruikt, turtorials,...

