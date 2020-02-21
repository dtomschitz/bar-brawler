# Technische Dokumentation
# Übersicht
## Zusammenfassung
## Plattform

# Entwicklung
## Team
## Genutzte Hardware
## Genutzte Werkzeuge und Engine
## Externe Komponenten
Für das Spiel wurden verschiedene Komponenten, die von dritten entwickelt wurden genutzt. Dazu gehören beispielsweise die gesamten Animationen, welche bei [Mixamo](https://www.mixamo.com/#/) frei erhältlich sind. Diese sind professionell entwickelt worden und wurden teilweise sogar mit dem Motion Capture Verfahren erstellt. Des Weiteren sind alle Sounds, welche im Spiel genutzt wurden, von [Freesounds](https://freesound.org/) erworben. 

# Spielmechaniken
## Technische Hauptanforderungen
## Architektur
## Spielfluss
Das Spiel beginnt im Hauptmenü, von wo aus der Nutzer entweder ein neues Spiel starten kann oder das gesamte Spiel beendet. Startet der Nutzer ein neues Spiel, wird durch eine Fade-Animation das Hauptmenü durch das Level ersetzt. Ist das Level geladen, findet sich der Spieler in einem Saloon der als Arena dient wieder. Der Nutzer sieht dann das Hud, in welchem die Hotbar, die Lebensanzeige, die Außdaueranzeige, die Munitionsanzeige, die Geldanzeige sowie der Countdown für die nächste Runde zu sehen ist. Der genannte Countdown zählt zu Beginn von 30 Rückwärts und soll den Spieler vor den kommenden Gegner warnen. Dieser Countdown kann jeder Zeit durch das Betätigen der B-Taste übersprungen werden. Ist der Countdown abgelaufen werden die ersten Gegner an verschiedenen Punkten im Level gespawnt und werden von nun an versuchen den Spieler zu verletzten, bis dieser keine Lebenspunkte mehr besitzt. Der Spieler kann sich mittels seiner Fäuste, welche er immer zur Verfügung hat, gegen die zahlreichen Gegner verteidigen. Für jeden erfolgreichen Kill, bekommt der Spieler je nach Spielfortschritt einen gewissen Betrag an Geld, mit dem er im Shop während einer Pause neue Gegenstände erwerben kann. Diese Gegenstände können dem Spieler im Verlauf gegen die immer stärker und vor allem zahlreicher werdenden Gegner helfen. Sollte der Spieler sterben, gelangt er automatisch nach einer kurzen Animation in das GameOver-Menu von wo aus er entweder ein neues Spiel starten oder zum Hauptmenü zurückkehren kann. Wurde die jeweilige Runde überlebt, beginnt der Countdown erneut. In dieser Art "Pause" kann der Spieler mit seinem verdienten Geld neue Gegenstände im Shop erwerben, welchen er beim Barkeeper öffnen kann. Nach jeder Welle bzw. nach gewissen Rundenzahlen werden verschiedene Gegnertypen gespawnt. Diese unterscheiden sich Hauptsächlich durch verschiedene Waffen und Lebenspunkte. Der Vorgang, von Erledigen der Gegner und kaufen neuer Gegenstände, wiederholt sich immer wieder bis der Spieler sterben sollte oder er das Spiel beendet.

## Grafik
## Models
## Audio
Wie bereits erwähnt,  wurden alle Sounds die im Spiel zu höheren sind, von [Freesounds](https://freesound.org/)  erworben. Während dem gesamten Spielverlauf wird eine Hintergrundmelodie abgespielt, welche auch im Hauptmenü sowie in dem Pausenmenü, GameOver-Menü und dem Shop zu hören sind. Für jede Aktion die der Spieler ausführt, wie z.B. das Angreifen oder das Drücken eines UI-Buttons, werden entsprechend Sounds abgespielt. Auch für den erfolgreichen Treffer gibt es verschiedene Sounds, welche je nach Waffentyp abgespielt werden.

## Physik
## Nicht Implementierte Spielmechaniken
Die Power-UPs sowie die Flasche, welche der Spieler im Shop erwerben könnte, wurden nicht implementiert. Außerdem gibt es nicht für alle Aktionen im Spiel entsprechende Sounds. 

# User Interface
## HUD
## Shop
## Hauptmenü
## Pausenmenü
## GameOver-Menü

# Implementierung
## Entity
Die *Entity* Klasse, ist die Hauptklasse für die Gegner, den Spieler und den Barkeeper. Sie implementiert die wichtigsten übergreifenden Methoden. Zu diesen gehören zum einen die *OnHit* und *OnDamaged* sowie die *OnDeath* Methode. Die letzten zwei Methoden stellen dabei die Brücke zwischen der [EntityStats](#EntityStats) Klasse und dieser Klasse, welche als Hauptklasse fungiert dar. Sie abonnieren die Events aus der  [EntityStats](#EntityStats) Klasse und werden aufgerufen, sobald diese gefeuert wurden. Die Methode *OnHit* hingegen muss an der Stelle wo ein Kollisionstreffer erkannt wurde gecallt werden. Alle Methoden in der Klasse sind außerdem als virtual gegenzeichnet damit sie von den erbenden Klassen überschrieben werden können. 
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
Die *EntityStats* Klasse fungiert, als Basisklasse für alle Dinge die mit den Lebenspunkten des Entites zu tun hat. Sie implementiert beispielsweise die Methoden *Damage* und *Heal*, welche genutzt werden, um den jeweiligen Entity zu heilen oder schaden hinzuzufügen. Werden diese Hauptmethoden aufgerufen, werden außerdem die Events *OnDamaged* und *OnHealed* gefeuert, welche in verschiedene Klassen wie z.B. der [Entity](#Entity) oder der [HealthBar](#HealthBar) Klasse abgefangen werden.  
```csharp
public class EntityStats : MonoBehaviour
{
    public float maxHealth;
    public float damage;

    public float CurrentHealth { get; set; }
    public event System.Action OnDeath;

    public delegate void Damaged(float damage, Equipment item = null);
    public event Damaged OnDamaged;

    public delegate void Healed(float amount);
    public event Healed OnHealed;
    
    public virtual void Damage(float damage, Equipment item = null)
    {
        damage = Mathf.Clamp(damage, 0, maxHealth);
        CurrentHealth -= damage;
        OnDamaged?.Invoke(damage, item);

        if (IsDead) OnDeath?.Invoke();
    }
    
    public virtual void Heal(float amount)
    {
        CurrentHealth += amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);

        OnHealed?.Invoke(amount);
    }
	
	...
```

### EntityCombat
### EntityEquipment
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
