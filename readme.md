# Bar Brawler
1898 - Amerika

Kehre in die vergangene Zeit der Gesetzlosen zurück und überlebe eine Schlägerei im Saloon.
In einem wellenbasierten Brawler übernimmst du die Rolle des gesetzlosen Bill Morgan, der in der Lage ist verschiedene Waffen geschickt einzusetzen, um sich zu verteidigen.
Raufe dich mit den anderen Gästen - Kaufe dir neue Waffen - Trinke deinen Feuersaft.

## Zusammenfassung
Der Spieler kämpft in mehreren Runden gegen Gegner, welche zunehmend stärker werden und den Spieler mit verschiedenen Gegenständen und Attacken angreifen.

## Gameplay
Ziel des Spieles ist es, so viele Runden wie möglich zu überstehen, ohne KO geschlagen zu werden. Dies kann durch geschicktes Kämpfen und durch erworbene Gegenstände erreicht werden. Hier zu zählen beispielsweise neue Waffen, aber auch Medipacks in Form eines Shots(oder auch Feuerwasser) mit dem der Spieler seine Lebenspunkte bis zu einem vordefinierten Punkt wieder auffüllen kann. Diese Items können in einer kurzen Pause zwischen den Levels beim Barkeeper erworben werden. Sollte sich der Spieler dafür entscheiden keine Items zu erwerben kann die Pause übersprungen werden. Wird der Spieler in einer Runde KO geschlagen, verliert er all seine Items und die Runden Anzahl wird zurückgesetzt. 
Das Level sollte die Möglichkeiten bieten die KI in die Irre zu führen, aber auch genug Platz bieten, um sich frei zu bewegen.  
Die Bewegungen der KI sollten deshalb in einem gewissen Maß voraussehbar sein, damit der Spieler seine eigenen Strategien entwickeln kann.

### Economy
Für jeden erledigten Gegner erhält der Spieler einen Geldbetrag, dessen Höhe variieren kann. 
Durch das erworbene Geld kann der Spieler beim Barkeeper neue Items kaufen, die ihm im Kampf gegen neue und härtere Gegner helfen. Die gesammte Summe kann der Spieler jederzeit im HUD sehen.

### Gegnertypen
Im Spiel gibt es nur einen speziellen Typ von Gegner, wobei Anzahl und Stärke ansteigen, um die Schwierigkeit zu erhöhen. Die Gegner werden nach einer gewissen Anzahl an Runden deshalb mit Flaschen oder auch Pistolen ausgestatt, mit der sie dem Spieler erheblichen Schaden zufügen können. Um dem Spieler trotzdem die Chance zu geben die Runde zu überleben, werden maximal 1-2 Gegner mit diesen Waffen ausgestattet. Je nach Ausstattung der Gegner ist es auch Möglich, das diese ihre Flasche oder wenn sie eine Pistole hatte, die Munition fallen lassen.

### Barkeeper
Der Barkeeper bietet im Verlauf des Spieles folgende Gegenstände zum Verkauf an:
- verschieden große Getränke, die Lebenspunkte des Spielers wieder füllen
- Flaschen, die erhöhten Schaden verursachen
- eine Revolver, der die meisten Gegner mit einem Schuss ausschaltet
- Munition für den Revolver

### Items
Die Items kann der Spieler zu jeder Zeit im HUD sehen und durch definierte Tasten auswählen.
- *Feuerwasser:* Gibt dem Spieler eine gewisse Anzahl an Lebenspunkten wieder (gibt es in verschiedenen Varianten)
- *Flasche:* Fügt Gegner erhöten Schaden zu, kann aber nach einer Gewissen Zeit zerstört werden
- *Revolver:* Kann Gegner mit einem Schuss töten, Munition ist jedoch rar. Einmal gekauft, kann der Spieler seine Waffe nicht mehr verlieren.
- *Munition:* Wird für den Revolver benötigt

## Level
Das Level soll einen Saloon aus dem wilden Westen repräsentieren und besteht aus großen Bartheke und mehreren Tischen mit Stühlen. 
Diese sind so angeordnet, dass der Spieler sich frei und ohne große Mühe bewegen kann. Der Spieler kann darüber hinaus die Anordnung strategisch nutzen, um seinen Gegnern auszuweichen.

## Assets
### Models + Texturen
- Flaschen
- Theke
- Stühle
- Barhocker
- Tische (rund, eckig)
- Revolver
- Munition
- Geld / Münzen
- Öllampe
- Bilder mit Rahmen

### Charaktere (inkl. Animationen und Texturen)
- Spieler
- Gegner
- Barkeeper

## Interface
### HUD
Das HUD besteht aus:
- einer Lebensanzeige (untere Mitte des Bildschirms)
- einer Anzeige für das gesammelte Geld (obere rechte Ecke)
- einer Anzeige für die gesammelten Items (unterhalb der Anzeige für das gesammelte Geld)
- einer Anzeige für die Anzahl der absolvierten Runden (oben links)

### Controls
Der Spieler kann sich mittels der Tasten A, S, D, W frei im Level bewegen und durch Mausbewegungen nach links, recht, oben und unten die Blickrichtungen wechseln. 
Durch das klicken der linke Maustaste können einzelne Schläge ausgeführt werden. Die rechte Taste dient hingegen dazu Schläge der Gegner zu blocken.

## Milestones
**1. Prototyp**
Der erste Prototyp soll eine simples Layout des Levels ohne jegliche Texturen und die Hauptmechaniken beinhalten. Zu diesen Zählt: 
1.	die Steuerung des Spielers
2.  eine einfache Physik (Collision, Springen, Treffer)
3.	eine einfache KI die den Spieler angreift
4.	ein System um die Gegner in Wellen auf den Spieler zu kommen zu lassen
5. *Simple Schlag Animationen sowohl für den Gegner als auch für den Spieler*	

**Milestone 1: Fertiges Konzeptdokument und Projektplan (06.11.2019)**
- [ ] Konzeptdokument
- [ ] Projektplan

**Milesonte 2**: Spielbarer Prototyp - *01.12.2019*
- [ ] Game Design Dokument
- [ ] Angepasster Projektplan
- [ ] Prototyp 1.

**Milestone 3**:
- [ ] Vortrag beim MI-Präsentationstag
- [ ] Vorführung bei der MediaNight

**Milestone 4**:
- [ ] Projektdokumentation
- [ ] Assets und Source Code
- [ ] Lauffähige Version des Spiels
- [ ] Vollständiger Eintrag in der Stage  

## Teamrollen
- **Christof Schwarzenberger**: Modellierung/Level Designer
- **David Tomschitz**: Gameplay Programmierung
- **Duane Englert**: Game Design/Gameplay Programmierung
- **Florian Rapp**: Künstliche Intelligenz
- **Sundar Arz**: Charakterdesign/Animationen