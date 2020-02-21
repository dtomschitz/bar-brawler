# Technische Dokumentation

# Übersicht
## Zusammenfassung
## Plattform
Das Spiel wurde ausschließlich für den Computer entwickelt, sollte jedoch für einen angenehmeren Spielfluss unbedingt mit dem Controller gespielt werden.

# Entwicklung
## Team
[Christof Schwarzenberger](https://gitlab.mi.hdm-stuttgart.de/cs267)

Zuständig für Modellierung des Raumes, Designer für Grafiken wie Plakate, Shop.

[David Tomschitz](https://gitlab.mi.hdm-stuttgart.de/dt035)

Fokus auf die Gameplay Programmierung. Movement und Combat, Entity Systeme.

[Duane Englert](https://gitlab.mi.hdm-stuttgart.de/de030)

Gameplay Programmierung und Game Designer. Fokus auf Wave System und Overlay Erstellung.

[Florian Rapp](https://gitlab.mi.hdm-stuttgart.de/fr061)

Modellierung der Details im Raum, sowie erstellen der Texturen.

[Sundar Arz](https://gitlab.mi.hdm-stuttgart.de/sa070)

Erstellen der Charaktere, seine Outfits und Raumdetails 

## Genutzte Hardware
## Genutzte Werkzeuge und Engine
## Externe Komponenten
Für das Spiel wurden verschiedene Komponenten, die von dritten entwickelt wurden genutzt. Dazu gehören beispielsweise die gesamten Animationen, welche bei [Mixamo](https://www.mixamo.com/#/) frei erhältlich sind. Diese sind professionell entwickelt worden und wurden teilweise sogar mit dem Motion Capture Verfahren erstellt. Des Weiteren sind alle Sounds, welche im Spiel genutzt wurden, von [Freesounds](https://freesound.org/) erworben. 

# Spielmechaniken
## Technische Hauptanforderungen
## Architektur
## Spielfluss
Das Spiel beginnt im Hauptmenü, von wo aus der Nutzer entweder ein neues Spiel starten kann oder das gesamte Spiel beendet. Startet der Nutzer ein neues Spiel, wird durch eine Fade-Animation das Hauptmenü durch das Level ersetzt. Ist das Level geladen, findet sich der Spieler in einem Saloon der als Arena dient wieder. Der Nutzer sieht dann das Hud, in welchem die Hotbar, die Lebensanzeige, die Außdaueranzeige, die Munitionsanzeige, die Geldanzeige sowie der Countdown für die nächste Runde zu sehen ist. Der genannte Countdown zählt zu Beginn von 30 Rückwärts und soll den Spieler vor den kommenden Gegner warnen. Dieser Countdown kann jeder Zeit durch das Betätigen der B-Taste übersprungen werden. Ist der Countdown abgelaufen werden die ersten Gegner an verschiedenen Punkten im Level gespawnt und werden von nun an versuchen den Spieler zu verletzten, bis dieser keine Lebenspunkte mehr besitzt. Der Spieler kann sich mittels seiner Fäuste, welche er immer zur Verfügung hat, gegen die zahlreichen Gegner verteidigen. Für jeden erfolgreichen Kill, bekommt der Spieler je nach Spielfortschritt einen gewissen Betrag an Geld, mit dem er im Shop während einer Pause neue Gegenstände erwerben kann. Diese Gegenstände können dem Spieler im Verlauf gegen die immer stärker und vor allem zahlreicher werdenden Gegner helfen. Sollte der Spieler sterben, gelangt er automatisch nach einer kurzen Animation in das GameOver-Menu von wo aus er entweder ein neues Spiel starten oder zum Hauptmenü zurückkehren kann. Wurde die jeweilige Runde überlebt, beginnt der Countdown erneut. In dieser Art "Pause" kann der Spieler mit seinem verdienten Geld neue Gegenstände im Shop erwerben, welchen er beim Barkeeper öffnen kann. Nach jeder Welle bzw. nach gewissen Rundenzahlen werden verschiedene Gegnertypen gespawnt. Diese unterscheiden sich Hauptsächlich durch verschiedene Waffen und Lebenspunkte. Der Vorgang, von Erledigen der Gegner und kaufen neuer Gegenstände, wiederholt sich immer wieder bis der Spieler sterben sollte oder er das Spiel beendet.

## Models
Die Erstellung der Models erfolgte in Blender. Die Models sollten einem Comic Stil entsprechend einfach gehalten sein. Als Referenzen wurden Bilder verwendet.

## Texturen
Für das Erstellen der Textur Dateien wurden die Models in Blender mit dem SmartUVProject unwrapped. Dabei wurde darauf geachtet, dass zwischen den einzelnen Flächen ein Abstand vorhanden ist. Zudem mussten wir darauf achten, dass Flächen, welche eine höhere Auflösung besitzen sollen, auch eine größere Fläche im UV-Grid zugewiesen bekommen. Nach dem Bemalen der Texture Ebene wurde das UV-Grid wieder entfernt, um Schwarze Linien in der Texture.png Datei zu verhindern. Die Auflösung der Texturen beträgt 1024x1024 Pixeln. Eine höhere Auflösung wird für dieses Projekt nicht benötigt, da die Grafik im Comic Stil gehalten wird.Dementsprechend werden häufig für große Flächen einzelne Farben genutzt oder allgemein wenig detaillierte Texturen erstellt wurden.

Für manche Models wurden nach der Erstellung des UV-Grids in Photoshop die einzelnen Parts mit Farbe bemalt, hierbei wurde das UV-Grid in Photoshop importiert, um die Flächen im Texture.png der jeweiligen UV-Grid-Flächen zuzuordnen.

Für weitere Models wurden direkt in Blende Farben durch verschiedene Materials zu bestimmten Faces zugeordnet. Schließlich wurde das Model mit der Render Engine Cycles und dem Bake Type Diffuse gebaket, wodurch man eine erste Textur Datei erhält und exportieren kann. Diese Dateien wurden anschließend mit Gimp oder Photoshop überarbeitet.

Für einen Teil der gezeichneten Texturen wurde die TexturePaint Funktion in Blender genutzt. Die gezeichneten und einfarbigen Texturen für die Flächen eines Models wurden nachfolgend auch in Gimp und Photoshop zu einer Texture Datei zusammengefügt.

## Audio
Wie bereits erwähnt,  wurden alle Sounds die im Spiel zu höheren sind, von [Freesounds](https://freesound.org/)  erworben. Während dem gesamten Spielverlauf wird eine Hintergrundmelodie abgespielt, welche auch im Hauptmenü sowie in dem Pausenmenü, GameOver-Menü und dem Shop zu hören sind. Für jede Aktion die der Spieler ausführt, wie z.B. das Angreifen oder das Drücken eines UI-Buttons, werden entsprechend Sounds abgespielt. Auch für den erfolgreichen Treffer gibt es verschiedene Sounds, welche je nach Waffentyp abgespielt werden.

## Physik
## Nicht Implementierte Spielmechaniken
Die Power-UPs sowie die Flasche, welche der Spieler im Shop erwerben könnte, wurden nicht implementiert. Außerdem gibt es nicht für alle Aktionen im Spiel entsprechende Sounds. 

# User Interface
## HUD
Das Hud besteht aus verschiedenen Anzeigeflächen die dem Spieler visuell darstellen sollen in welchem Zustand sich das Spiel aktuell befindet. Zu diesen gehört die Hotbar, die Lebens- und Ausdaueranzeige, die Munitionsinfo und eine Info über den gesamt Betrag des gesammelten Geldes. In der Hotbar kann der Spieler zu jeder Zeit sehen welche Items er erworben hat und auch benutzen kann. Des Weiteren ist es möglich ein Damage-Overlay für einen kurzen Zeitraum im Hud anzuzeigen, wenn der Spieler von einer Attacke getroffen wurde.

## Shop
Der Shop kann nach jeder runde vom Spieler geöffnet werden, wenn dieser an der Bar steht. Durch den Shop kann der Spieler sein erworbenes Geld für neue Waffen und Getränke ausgeben, welche ihm im fortlaufenden Spiel helfen sollten.

## Hauptmenü
Das Hauptmenü beinhaltet den Titel des Spiels sowie die Buttons um das Spiel zu starten und zu beenden. Im Hintergrund kann der Nutzer den Saloon mit dem Barkeeper, einem Pianist und dem Spieler selbst sehen.

## Pausenmenü
Im Pausemenü kann der Spieler das Spiel fortsetzen, die aktuelle Spielsitzung neustarten oder ins Hauptmenü zurück gehen. Durch das betätigen der Start-Taste am Controller öffnet sich das Pausemenü und die Zeit im Spiel wird durch die *OnEnable* Methode eingefroren.
```csharp
    public void OnEnable()
    {
        Time.timeScale = 0f;
    }

    public void OnDisable()
    {
        Time.timeScale = 1f;
    }
```
Sämtliche anderen Overlays werden durch *TogglePauseMenu* deaktiviert, sowie auch das Movement des Charakters
```csharp
    void TogglePauseMenu()
    {
        Player.instance.controls.IsMovementEnabled = false;
        DisableTargetAcquisition();

        UIManager.instance.SetHUDActive(false, false);
        UIManager.instance.SetShopActive(false);
        UIManager.instance.SetGameOverMenuActive(false);
        UIManager.instance.SetPauseMenuActive(true);
```
## GameOver-Menü
Das Game Over Overlay wird aufgerufen, wenn der Spieler stirbt. Wie im Pausemenü werden sämtliche anderen Overlays durch *ToggleGameOver* deaktiviert. Das Menü wird durch eine Animation auf den Bildschirm gebracht. Im Game Over Menü kann der Spieler Statistiken einsehen, die aus einer Runde gesammelt wurden.

# Implementierung
## Entity
Die *Entity* Klasse, ist die Hauptklasse für die Gegner, den Spieler und den Barkeeper. Sie implementiert die wichtigsten übergreifenden Methoden. Zu diesen gehören zum einen die *OnHit* und *OnDamaged* sowie die *OnDeath* Methode. Die letzten zwei Methoden stellen dabei die Brücke zwischen der [EntityStats](#EntityStats) Klasse und dieser Klasse, welche als Hauptklasse fungiert dar. Sie abonnieren die Events aus der  [EntityStats](#EntityStats) Klasse und werden aufgerufen, sobald diese gefeuert wurden. Die Methode *OnHit* hingegen muss an der Stelle wo ein Kollisionstreffer erkannt wurde gecallt werden. Alle Methoden in der Klasse sind außerdem als virtual gegenzeichnet damit sie von den erbenden Klassen überschrieben werden können. Damit diese Hauptklasse nicht zu voll wurde, sind die einzelnen Parts wie die Verwaltung der Lebenspunkte oder des Combat States in verschiedene Klasse unterteilt, welche in den folgenden Abschnitten näher erläutert werden.
```csharp
public class Entity : MonoBehaviour
{
    public EntityStats stats;
    public EntityCombat combat;
    public EntityAnimator animator;
    public EntityEquipment equipment;

    protected virtual void Start()
    {
        stats.OnDamaged += OnDamaged;
        stats.OnDeath += OnDeath;
    }
    
    public virtual void OnHit(Entity offender, Equipment item)
    {
        if (stats.IsDead) return;
        offender.combat.Attack(stats, item);
        animator.OnHit(0);
    }
    
    public virtual void OnDamaged(float damage, Equipment item) {}
    public virtual void OnDeath() {}
}
```

### EntityStats
Die *EntityStats* Klasse fungiert, als Basisklasse für alle Dinge die mit den Lebenspunkten des Entites zu tun hat. Sie implementiert beispielsweise die Methoden *Damage* und *Heal*. Erstere fügt dem Spieler den angegebenen Schaden hinzu, in dem dieser von der aktuellen Anzahl an Lebenspunkten subtrahiert wird. Zusätzlich wird das Event *OnDamaged* gefeuert,
welches die Information für andere Klassen wie z.B. der [HealthBar](#HealthBar) Klasse anbieten soll. Sollt außerdem der Spieler nach Abzug der angebenden Lebenspunkte keine mehr besitzen, wird das Event *OnDeath* gecallt, welches beispielsweise dafür sorgt, dass die Todesanimation gestartet und das GameOver-Menü angezeigt wird.
```csharp
public virtual void Damage(float damage, Equipment item = null)
{
	damage = Mathf.Clamp(damage, 0, maxHealth);
	CurrentHealth -= damage;
	OnDamaged?.Invoke(damage, item);

	if (IsDead) OnDeath?.Invoke();
}
```
Die Methode *Heal* hingegen heilt den Spieler um die angegeben Lebenspunkte. Sie ruft außerdem das Event *OnHeal* auf um die Information über die neu hinzugefügten Lebenspunkte verschiedenen Klassen zur verfügung zustellen.
```csharp
public virtual void Heal(float amount)
{
	CurrentHealth += amount;
	CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);
	OnHealed?.Invoke(amount);
}
```

### EntityCombat
Die *EntityCombat* Klasse ist ebenfalls eine Unterklasse und wird als Basisklasse für alle Kampf relevanten Dingen genutzt. Dazu gehört das Verwalten des Combat States der jeweiligen Entität sowie das der Mana Regeneration. 
#### Combat State
Der Combat State definiert den aktuellen allgemeinen Zustand der Entität. Je nachdem in welchem Zustand sich der jeweilige Entity befindet, kann dieser verschiedene Aktionen ausführen oder nicht. Ist der aktuelle Combat State beispielsweise auf *Drinking* gesetzt, kann der Spieler keine Angriffe mehr ausführen. Der Combat State kann dabei die folgenden Enum-Werte annehmen: 
```csharp
public enum CombatState
{
    Idle,
    FistBlock,
    FistAttack,
    BottleAttack,
    KnifeAttack,
    RevolverAttack,
    Stunned,
    Drinking
}
```

#### Ausdauer
Die Ausdauer wird verwendet, wenn der jeweilige Entity einen Angriff mit der Blocken-Taste abwehrt. Für jeden erfolgreich abgewehrten Angriff verliert die Entität Ausdauer. Durch die Methoden *AddMana* und *UseMana* kann Ausdauer hinzugefügt oder entfernt werden. Jedes Mal wird außerdem das entsprechende Event gefeuert, um über die Aktualisierung zu informieren.

```csharp
public void AddMana(float amount)
{
    CurrentMana += amount;
    CurrentMana = Mathf.Clamp(CurrentMana, 0f, maxMana);
    OnManaAdded?.Invoke();
}

public void UseMana(float amount = 1f)
{
    CurrentMana -= amount;
    OnManaUsed?.Invoke();
}
```
Mit der Zeit wird die Ausdauer automatisch mithilfe der Parameter *manaRegenerationSpeed* und *manaRegenerationAmount*  wieder aufgefüllt. Dies geschieht in der Update-Methode:
```csharp
protected virtual void Update()
{
	if (!IsBlocking)
	{
		AddMana(manaRegenerationAmount * Time.deltaTime / manaRegenerationSpeed);
	}
}
```

### EntityEquipment
Auch diese Klasse ist eine Unterklasse der [Entity](#Entity) Klasse und wird als Basisklasse für das Verwalten der Ausrüstung der jeweiligen Entität genutzt und speichert den jeweils ausgerüsteten Gegenstand zwischen. Außerdem kann durch ´die Methoden *UsePrimary*, *UseSecondary* und *UseConsumable* die definierten Aktionen der jeweiligen Gegenstände ausgeführt werden. Die *UsePrimary* dient dazu die Hauptaktion auszuführen und kann nur getriggert werden, wenn es sich bei dem Item um eine Waffe handelt.  Sie wählt außerdem eine zufällige Animation, aus die für das benutzten der Waffe abgespielt werden soll und aktualisiert die Handposition des Items. 
```csharp
public void UsePrimary()
{
	if (... && currentEquipment is Weapon)
	{
		EquipmentAnimation[] animations = currentEquipment.equipmentAnimations;
		if (animations.Length != 0)
		{
			EquipmentAnimation animation = 
				currentEquipment.equipmentAnimations[Random.Range(0, animations.Length)];
			UpdateItemPosition(animation);
			GetComponent<EntityAnimator>().SetEquipmentAnimation(animation);
		}
		currentItem.OnPrimary();
	}
}
```
Die Methode *UseSecondary* hingegen wird genutzt die Zweitaktion des Items auszuführen. Auch hier kann diese nur ausgeführt werden, wenn es sich bei dem Item um eine Waffe handelt. 
```csharp
public void UsePrimary()
{
	if (... && currentEquipment is Weapon)
	{
		currentItem.OnSecondary();
	}
}
```
Damit der Spieler mit dem aktuell ausgerüstete Item nicht nur angriffe, sondern diese auch benutzten und verbrauchen kann, gibt es die *UseSecondary* Methode. Sie kann nur ausgeführt werden, wenn es sich bei dem Gegenstand um ein Getränk handelt und callt für dieses die *OnPrimary* Methode. 
```csharp
public void UseConsumable()
{
	if (... && currentEquipment is Drink)
	{
		currentItem.OnPrimary();
	}
}
```
### EntityAnimator

## Player
### PlayerAnimator
### PlayerCombat
### PlayerStats
### PlayerEquipment
### Inventory

## Enemy

## Barkeeper

## Wave-System
### WaveSpawner
### WaveConfig
### SpawnPoint
## Items
## UI
### Shop
### Hotbar
