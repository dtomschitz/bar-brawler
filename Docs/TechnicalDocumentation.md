
# Technische Dokumentation

# Übersicht
## Zusammenfassung
Bar Brawler ist ein rundenbasierter Brawler, bei dem Sie in die Rolle eines Gesetzlosen schlüpfen und gegen andere feindselige Gesetzlosen sich durchsetzen müssen. 
Umso mehr Wellen Sie vollständig schlagen, desto schwieriger werden die Nächsten. Die Gegner haben mehr Leben und können auch Waffen mit sich tragen, die mehr Schaden anrichten. Aber nicht nur das, auch die Anzahl der Gegner steigt pro Runde.
Um sich gegen die stärkeren Wellen zu wehren, bekommen sie pro besiegtem Gegner Geld, dass Sie beim Barkeeper für neue Items ausgeben können. Darunter finden sich unter anderem Waffen, wie ein Messer oder eine Pistole, deren Aufgabe es ist mehr Schaden anzurichten, aber auch Getränke, die ihr verlorenes Leben wieder auffüllen. 
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
Im Pausemenü kann der Spieler das Spiel fortsetzen, die aktuelle Spielsitzung neustarten oder ins Hauptmenü zurück gehen. Durch das betätigen der Start-Taste am Controller öffnet sich das Pausemenü. Das Spiel wird während dessen pausiert.

## GameOver-Menü
Das Game Over Overlay wird aufgerufen, wenn der Spieler stirbt. Das Menü wird durch eine Animation auf den Bildschirm gebracht. Im Game Over Menü kann der Spieler Statistiken einsehen, die aus einer Runde gesammelt wurden. Der Spieler hat hier zwei Auswahlmöglichkeiten. Er kann das Spiel neustarten oder zurück zum Hauptmenü gehen.

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

### EntityStats Klasse
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
Die Methode *Heal* hingegen heilt den Spieler um die angegeben Lebenspunkte. Sie ruft außerdem das Event *OnHeal* auf um die Information über die neu hinzugefügten Lebenspunkte verschiedenen Klassen zur Verfügung zustellen.
```csharp
public virtual void Heal(float amount)
{
	CurrentHealth += amount;
	CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);
	OnHealed?.Invoke(amount);
}
```

### EntityCombat Klasse
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

### EntityEquipment Klasse
Auch diese Klasse ist eine Unterklasse der [Entity](##Entity) Klasse und wird als Basisklasse für das Verwalten der Ausrüstung der jeweiligen Entität genutzt und speichert den jeweils ausgerüsteten Gegenstand zwischen. Außerdem kann durch ´die Methoden *UsePrimary*, *UseSecondary* und *UseConsumable* die definierten Aktionen der jeweiligen Gegenstände ausgeführt werden. Die *UsePrimary* dient dazu die Hauptaktion auszuführen und kann nur getriggert werden, wenn es sich bei dem Item um eine Waffe handelt.  Sie wählt außerdem eine zufällige Animation, aus die für das benutzten der Waffe abgespielt werden soll und aktualisiert die Handposition des Items. 
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
Damit jeder Zeit neue Items ausgerüstet werden können, gibt es die Methode *EquipItem*. Diese erstellt eine Kopie aus dem Prefab des gegebenen Items. Ist das erstellte GameObject valide kann es ausgerüstet werden. Damit auch beispielsweise die [Entity](#Entity) diese Information bekommt, wird das Event *OnItemEquipped* gefeuert. Sollte der Spieler schon einen Gegenstand ausgerüstet haben, wird dieser mit der Methode *Unequip* abgelegt und das erstellte GameObject zerstört. Das Item bleibt weiterhin im Inventar des Spielers bestehen. Schlussendlich wird das neue Item ausgerüstet und in den dazugehörigen Parametern zwischen gespeichert. Der Parameter *currentItem* speichert in diesem Fall das erstellte GameObject und *currentEquipment* das eigentliche Item aus dem Inventar.
```csharp
public void EquipItem(Equipment item)
{
	GameObject prefabCopy = Instantiate(item.prefab);
	Equippable equippable = prefabCopy.GetComponent<Equippable>();

	 if (equippable != null)
	 {
		 OnItemEquipped?.Invoke(item, currentEquipment);
		 equippable.OnEquip();
		 
		 if (currentItem != null) Unequip();
		 Equip(prefabCopy, item);
		 
		 currentItem = equippable;
		 currentEquipment = item;
	 }
 }
```
Der eigentliche Prozess wird jedoch durch verschiedene Hilfsmethoden übernommen. Wird ein Gegenstand beispielsweise ausgerüstet, wird nach dem die Methode *EquipItem* aufgerufen wurde, die Methode *Equip* gecallt. Sie 
Sucht mittels der gegebenen Standardhand, die richtige Position des Items und gibt das Item dem Entity schlussendlich in die Hand.
```csharp
protected void Equip(Equippable equippable, Equipment item)
{
	currentHand = GetHandGameObject(item.defaultHand);
	SetItemPosition(
		equippable,
		currentHand.transform,
		item.defaultPosition,
		item.defaultRotation
	);
}
```
Die richtige Hand, in welcher das Item später vom Spieler gehalten werden soll, wird mit der Methode *GetHandGameObject* herausgefunden. Sie gibt jeweils das vorab definierte GameObject der jeweiligen Hand des Entity-Models zurück. 
```csharp
private GameObject GetHandGameObject(Hand hand)
{
	if (hand == Hand.Left) return leftHand;
	else return rightHand;
}
```
Um für die verschiedenen Gegenstände auch unterschiedliche Positionen verwenden zu können, gibt es die Methode *SetItemPosition*, welche wie der Name schon sagt, die Position und Rotation des Items in der Entity-Hand überschreibt. Die hierfür notwendigen Parameter werden in dem [Equipment](#Equipment) Item gespeichert.
```csharp
protected void SetItemPosition(Equippable e, Transform hand, Vector3 position, Vector3 rotation)
{
	e.transform.parent = hand;
	e.transform.localPosition = position;
	e.transform.localEulerAngles = rotation;
}
```
Die zu Beginn gesetzte Position und Rotation des Gegenstands kann im Nachhinein mit *UpdateItemPosition* noch verändert werden. Dies ist zwingend notwendig, da beispielsweise Waffen verschiedene Animationen besitzen. Dies hat zur Folge, dass die unterschiedlichen Gegenstände unter anderem zwischen den beiden Händen getauscht werden müssen und gegeben Falls die Position und die Rotation neu angepasst werden. Diese Parameter sind in dem jeweiligen [Equipment](#Equipment) Item gespeichert mittels der [EquipmentAnimation](#EquipmentAnimation) gespeichert.
```csharp
public void UpdateItemPosition(EquipmentAnimation animation)
{
	UpdateItemPosition(animation.hand, animation.specificPosition, animation.specificRotation);
}

public void UpdateItemPosition(Hand hand, Vector3 position, Vector3 rotation)
{
	currentHand = GetHandGameObject(hand);
	SetItemPosition(currentItem, currentHand.transform, position, rotation);
}
```
Um einen Gegenstand letztendlich auch wirklich aus der Hand der Entität zu entfernen, damit ein neuer ausgerüstet werden kann, gibt es die Methode *Unequip*. Diese gibt die Parameter wieder frei, versteckt den Gegenstand in dem dieser Inaktiv gestellt wird und löscht den Gegenstand nach kurzer Zeit vollständig.
```csharp
protected void Unequip()
{
	Destroy(currentItem, 10f);
	currentItem.gameObject.SetActive(false);
	currentItem = null;
	currentHand = null;
}
```

### EntityAnimator Klasse
Die EntityAnimator Klasse ist wie alle vorherigen Klassen, eine Unterklasse der [Entity](#Entity) Klasse und dient als Basisklasse dazu jegliche Animationen für Entites zu verwalten. Um dies zu gewährleisten implementiert die Klasse für alle möglichen Animationen verschiedene Methoden um diese zu triggern, zu aktiveren oder zu deaktivieren. Die Methode *OnPrimary* dient hier beispielsweise um die aktuell ausgewählte und zu einem bestimmten Item zugehörige Animation abzuspielen, wenn die primäre Aktion ausgeführt wurde.  Für die sekundäre Attacke gibt es die äquivalente *OnSecondary* Methode, welche aufgerufen wird, wenn der Nutzer die sekundäre Aktion des aktuell ausgerüsteten Items getriggert hat.
```csharp
public virtual void OnPrimary() => animator.SetTrigger("Primary");
public virtual void OnSecondary() => animator.SetTrigger("Secondary");
```
Sollte der Spieler eine weitere Runde überlebt haben wird die Methode *OnVictory* aufgerufen, um die Jubel-Animation abzuspielen. Diese wird auch verwendet, wenn der Spieler sterben sollte, jedoch für die Gegner. Um eine Todes-Animation abzuspielen wird die *OnDeath* Methode aufgerufen, welche für alle Entities gleich ist. 

```csharp
public virtual void OnDeath() => animator.SetTrigger("Death");
public virtual void OnVictory() => animator.SetTrigger("Victory");
```
Um dem Spieler einen erfolgreichen Treffer visuell besser darzustellen bzw. im auch Umgekehrt zu zeigen, wann er getroffen wurde, gibt es die Methode *OnHit* welche basierend auf der gegeben ID die jeweilige Hit-Animation abspielt.
```csharp
public virtual void OnHit(int id)
{
	animator.SetInteger("HitAnimation", id);
	animator.SetTrigger("Hit");
}
```
Damit sich die jeweilige Entität auch bewegen kann bzw. damit eine Bewegung zu sehen ist, gibt es die Methoden *Move*, *SetForward* und *SetStrafe*. Die letzteren sind dabei die Key-Methoden, welche die Vorwärts und Seitwärts-Geschwindigkeit dem *Animator* übergeben. Basierend auf den Parametern versucht der Animator dann, die verschiedenen Bewegungs-Animationen miteinander zu vermischen, damit letztendlich eine flüssige und für den Nutzer nachvollziehbare Bewegung entsteht.
```csharp
public virtual void Move(float forward, float strafe)
{
	SetForward(forward);
	SetStrafe(strafe);
}

public void SetForward(float forward) => animator.SetFloat("Forward", forward);
public void SetStrafe(float strafe) => animator.SetFloat("Strafe", strafe);
```
Da die Entität verschiedenen Items in den Händen halten kann und diese auch unterschiedliche Animationen besitzen, gibt es die Methoden *SetEquipment* und *SetEquipmentAnimation*. Erstere aktualisiert die Item ID im *Animator*, damit dort die richtigen Transitions aktiviert werden und *SetEquipmentAnimation* hingegen die Animations-ID 
```csharp
public void SetEquipment(Equipment item)
{
	int currentType = animator.GetInteger("Item");
	int type = (int)item.type;

	if (currentType == type) return;
	animator.SetInteger("Item", type);
}

public void SetEquipmentAnimation(EquipmentAnimation animation)
{
	if (animator.GetInteger("ItemAnimation") == animation.index) return;
	animator.SetInteger("ItemAnimation", animation.index);
}
```
Die meisten Methoden in der Klasse sind als *virtual* gekennzeichnet, damit sie von erbenden Klassen überschrieben werden können. Dies ist beispielsweise bei der Methode *Move* wichtig, welche die Parameter für die Bewegungs-Animation setzt, da sich Spieler und Gegner mit verschiedenen Mechaniken fortbewegen. 

## Player Klasse
Die Player Klasse erbt von der Basisklasse [Entity](#Entity), wird als *Singelton* genutzt und implementiert alle notwendigen Methoden damit der Spieler als Entität gehandhabt werden kann um beispielsweise schaden zu erleiden oder Angriffe zu tätigen.
 Die Klasse wird außerdem durch die Methoden *AddMoney* und *RemoveMoney* erweitert. Diese dienen dazu dem Spieler Geld durch beispielsweise erfolgreiche Tötungen zu geben oder durch Investitionen zu nehmen. Die jeweiligen Methoden feuern zusätzlich noch die dazugehörigen Events, damit unter anderem die Anzeigen im Hud aktuell sind und der Spieler im Shop nur die Items erwerben kann, welche sein Budget nicht überschreiten. Des Weiteren wurde die Methode *OnDeath* aus der [Entity](#Entity)  Klasse überschrieben, um für alle noch lebenden Gegner die Erfolgs-Animation abzuspielen und den [GameState](#GameState) zu aktualisieren. Dies führt letztendlich dann dazu, dass das GameOver-Menü angezeigt wird.
```csharp
public class Player : Entity
{
	Singleton

    public delegate void MoneyRecived(int amount, int currentBalance);
    public delegate void MoneySpend(int amount, int currentBalance);
    public event MoneyRecived OnMoneyReceived;
    public event MoneySpend OnMoneySpend;

    [Header("Player specific")]
    public PlayerControls controls;
    public Inventory inventory;

    public int CurrentBalance { get; set; } = 300;

    public override void OnDeath()
    {
        base.OnDeath();
        
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        if (enemies != null)
        {
            foreach (Enemy enemy in enemies) enemy.animator.OnVictory();
        }
        
        GameState.instance.SetState(GameStateType.GameOver);
    }
    
    public void AddMoney(int amount)
    {
        CurrentBalance += amount;
        OnMoneyReceived?.Invoke(amount, CurrentBalance);
        AudioManager.instance.PlaySound(Sound.ReceiveMoney);
    }
    
    public void RemoveMoney(int amount)
    {
        CurrentBalance -= amount;
        OnMoneySpend?.Invoke(amount, CurrentBalance);
    }
}
```

### PlayerAnimator Klasse
Diese Klasse überschreibt ausschließlich die *Move* Methode aus der Basisklasse [EntityAnimator](#EntityAnimator), um die Bewegungs-Animation für den Spieler basierend auf den beiden Parametern *forward* und *strafe* zu erstellen.
```csharp
public class PlayerAnimator : EntityAnimator
{
    public override void Move(float forward, float strafe)
    {
        base.Move(forward, strafe);
    }
}
```

### PlayerCombat Klasse
Die Klasse *PlayerCombat* implementiert die Klasse  [EntityCombat](#EntityCombat) und fügt zusätzliche Methoden hinzu, die genutzt werden, um die Angriffe verschiedener Gegner besser zu managen. 
Um einen besseren Spielfluss zu kreieren ist es möglich in der Klasse vorab zu definieren, wie viele Angreifer gleichzeitig den Spieler attackieren können. Die beiden Methoden *OnRequestAttack* und *OnCancelAttack* verwalten dieses beschriebe Szenario. *OnRequestAttack* wird dabei genutzt um die Anfrage eines einzelnen Gegners zu validieren.  Dies geschieht in dem überprüft wird, wie viele Attackierer es aktuell gibt und wie groß die maximale Anzahl sein darf. Ist der Angriff eines weiteren Gegners möglich, wird dieser in die Liste mit aufgenommen und hat ab dann das Recht den Spieler jeder Zeit anzugreifen.
```csharp
public void OnRequestAttack(GameObject enemy)
{
	attackers.RemoveAll(attacker => attacker == null);
	if (attackers.Count < simultaneousAttackers)
	{
		if (!attackers.Contains(enemy)) attackers.Add(enemy);
		enemy.SendMessage("OnAllowAttack", gameObject);
	}
}
```
Die Methode *OnCancelAttack* hingegen wird genutzt, um einen aktuell zugelassenen Gegner wieder von der Liste zu entfernen, wenn dieser z.B. gestorben ist und somit den Spieler nicht mehr angreifen kann.
```csharp
public void OnCancelAttack(GameObject enemy) => attackers.Remove(enemy);
```

### PlayerStats Klasse
Die Klasse *PlayerStats* implementiert die Klasse  [EntityStats](#EntityStats) und fügt zusätzliche Methoden hinzu, die genutzt werden um den Schaden, den der Spieler bei einer erfolgreichen Attacke verteilen kann, basierend auf einem neu ausgerüsteten Gegenständen zu aktualisieren. Die *OnItemEquipped* Methode erledigt den zu vor beschrieben Fall in dem sie das *OnItemEquipped* Event der EntityEquipment Klasse abonniert.
```csharp
protected override void Start()
{
	... 
	equipment = GetComponent<PlayerEquipment>();
	equipment.OnItemEquipped += OnItemEquipped;
}

public void OnItemEquipped(Equipment newItem, Equipment oldItem)
{
	if (newItem != null && newItem is Weapon)
	{
		damage = (newItem as Weapon).damage;
	}
}
```
Es wird außerdem die Methode *Damage* überschrieben, um den Spieler ein haptisches Feedback zu geben, wenn er Schaden durch einen Gegner erlitten hat. Dafür wird eine Coroutine gestartet, welche das Gamepad für einen kurzen Moment vibrieren lässt. Die stärke, der Vibration hängt dabei von der Größe des erlittenen Schadens ab.
```csharp
public override void Damage(float damage, Equipment item = null)
{
	base.Damage(damage, item);
	StopAllCoroutines();
	StartCoroutine(StartGamePadVibration(damage));
}
private IEnumerator StartGamePadVibration(float damage)
{
	Gamepad.current.SetMotorSpeeds(damage / 100, damage / 100);
	yield return new WaitForSeconds(.5f);
	Gamepad.current.SetMotorSpeeds(0, 0);
}
```
### PlayerEquipment Klasse
Die Klasse PlayerEquipment  erbt von der [EntityEquipment](#EntityEquipment) Klasse und überschreibt die *Start* Methode, um die Events *OnItemRemoved* und *OnItemSelected* zu abonnieren. Das Event *OnItemSelected*  spielt dabei die wichtigste Rolle, da dieses gefeuert wird, wenn der Spieler einen neuen Gegenstand in seinem Inventar ausgewählt hat. Da der Spieler im Vergleich zu den Gegner zwischen seinen Items variieren kann, muss deshalb die Methode *EquipItem* welche in der Basisklasse [EntityEquipment](#EntityEquipment)  implementiert wurde dieses Event abonnieren. 
```csharp
protected override void Start()
{
	base.Start();
	inventory = Player.instance.inventory;
	inventory.OnItemRemoved += OnItemRemoved;

	hotbar = FindObjectOfType<Hotbar>();
	hotbar.OnItemSelected += EquipItem;
}
```
Die Methode *OnItemRemoved* wird gecallt, wenn ein Gegenstand aus dem Inventar des Spielers entfernt wurde. Sollte das entfernte Item, dem des aktuell ausgerüsteten entsprechen, wird die in der Basisklasse [EntityEquipment](#EntityEquipment) implementierte Methode  *Unequip* aufgerufen.
```csharp
private void OnItemRemoved(object sender, InventoryEvent e)
{
	if (e.item == currentEquipment) Unequip();
}
```
Die *PlayerEquipment* Klasse speichert außerdem die Standardgegenstände, die der Spieler zum Beginn des Spiels erhält. Um dabei den ersten Gegenstand dieser Liste auszurüsten, damit es zum Beginn keine Fehler gibt und der Spieler automatisch seine Faust ausgerüstet hat gibt es die Methode *EquipFirstItem*.
```csharp
public void EquipFirstItem()
{
	if (defaultItems.Length != 0)
	{
		EquipItem(defaultItems[0] as Equipment);
	}
}
```
### PlayerInventory Klasse
Die PlayerInventory Klasse wird verwendet, um erworbene Gegenstände aus dem Shop zu speichern, damit der Nutzer diese z.B. durch Interaktion mit der [Hotbar](#Hotbar) nutzen kann. 

Das Inventar besteht aus insgesamt 5 *InventorySlots*, wobei der erste Slot durch das nicht stapelbare Faust Item von Beginn an des Spiels belegt ist. Jeder andere Slot kann jegliche Items aufnehmen, solang der Slot nicht die maximale Größe des jeweiligen Itemtyps überschritten hat. Die InventorySlot Klasse implementiert hierfür die Methoden *Add*, *Remove* und andere Hilfsmethoden wie z.B. *IsStackable*, welche überprüft, ob noch Platz im Stack ist.
```csharp
public class InventorySlot
{
    private int id = 0;
    private Stack<Item> stack;

    public InventorySlot(int id)
    {
        this.id = id;
        stack = new Stack<Item>();
    }

    public void Add(Item item)
    {
        item.slot = this;
        stack.Push(item);
    }

    public bool Remove(Item item)
    {
        if (IsEmpty) return false;

        Item first = stack.Peek();
        if (first.name == item.name)
        {
            stack.Pop();
            return true;
        }
        return false;
    }

    public bool IsStackable(Item item)
    {
        if (IsEmpty || !item.isStackable) return false;

        Item first = stack.Peek();
        if (first.name == item.name && stack.Count < item.maxStackSize) return true;

        return false;
    }
    
    public Item FirstItem
    {
        get
        {
            if (IsEmpty) return null;
            return stack.Peek();
        }
    }

    public bool IsFull
    {
        get { return FirstItem != null && Count == FirstItem.maxStackSize; }
    }
    
    public bool IsEmpty
    {
        get { return Count == 0; }
    }

    public int Count
    {
        get { return stack.Count; }
    }

    public int Id
    {
        get { return id; }
    }
}
```

Um Items hinzuzufügen oder zu entfernen gibt es die Methoden *AddItem* und *RemoveItem*. Erstere fügt Items dem Inventar hinzu, wenn dies in dem jeweiligen Item aktiviert ist. Sollte das Item dem Inventar hinzugefügt werden können, wird ein *InventorySlot* gesucht der Items beinhaltet die vom selben Itemtyp sind und noch genug Platz für einen weiteren Gegenstand hat. Sollte kein Slot gefunden worden sein, wird ein komplett leerer Item Slot gesucht. Wurde einer gefunden, wird das Item diesem *InventorySlot* hinzugefügt, und das Event *OnItemAdded* wird gecallt, damit beispielsweise die [Hotbar](#Hotbar) aktualisiert werden kann.
```csharp
public void AddItem(Item item)
{
	if (item == null) return;
	if (item.addToInventory)
	{
		InventorySlot freeSlot = FindStackableSlot(item);
		if (freeSlot == null) freeSlot = FindNextEmptySlot();
		if (freeSlot != null)
		{
			freeSlot.Add(item);
			OnItemAdded?.Invoke(item);
		}
	}
}
public InventorySlot FindStackableSlot(Item item)
{
	foreach (InventorySlot slot in Slots)
	{
		if (slot.IsStackable(item)) return slot;
	}
	return null;
}

public InventorySlot FindNextEmptySlot()
{
	foreach (InventorySlot slot in Slots)
	{
		if (slot.IsEmpty) return slot;
	}
	return null;
}
```
Um Items zu entfernen, die sich im Inventar befinden, wenn diese z.B. verbraucht oder gelöscht wurden, kann die Methode *RemoveItem* genutzt werden. Sie sucht den gegebenen Gegenstand in den *InventorySlot*'s. Wurde das Item in einem Slot gefunden, wird es aus diesem entfernt und das Event *OnItemRemoved* um unter anderem die [Hotbar](#Hotbar) zu aktualisieren.
```csharp
public void RemoveItem(Item item)
{
	if (item == null) return;
	foreach (InventorySlot slot in Slots)
	{
		if (slot.Remove(item))
		{
			OnItemRemoved?.Invoke(item);
			break;
		}
	}
}
```
Außerdem sind im Inventar die Methoden *AddMunition* und *UseMunition* implementiert um den Munitionsstand des Spielers zu verwalten. Des Weiteren wird auch hier ein entsprechendes Event gecallt, damit die UI-Elemente im HUD aktuell bleiben.
```csharp
public void AddMunition(int ammount)
{
	currentMunition += ammount;
	OnMunitionUpdate?.Invoke(currentMunition);
}

public void UseMunition()
{
	currentMunition--;
	OnMunitionUpdate?.Invoke(currentMunition);
}
```


## Enemy

## Barkeeper

## Wave-System
### WaveSpawner
### WaveConfig
### SpawnPoint
## Items
## UI
### UIManag
### Shop
### Hotbar

