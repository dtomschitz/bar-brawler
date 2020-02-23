
# Technische Dokumentation
## Zusammenfassung
Bar Brawler ist ein rundenbasierter Brawler, bei dem der Spieler in die Rolle eines Gesetzlosen schlüpfen und sich gegen andere feindselige Gesetzlosen durchsetzen müssen. 
Umso mehr Wellen Sie vollständig bestehen, desto schwieriger werden die Darauffolgenden. Die Gegner haben mehr Leben und können auch Waffen mit sich tragen, die mehr Schaden anrichten. Neben der zunehmenden Stärke der Gegner steigt auch deren Anzahl.
Um sich in den stärkeren Wellen beweisen zu können, bekommet der Spieler pro besiegtem Gegner Geld, das beim Barkeeper für neue Items ausgegeben werden kann. Um den Schaden bei Gegnern zu erhöhen können Waffen, wie ein Messer oder eine Pistole erworben werden. Zur Wiederherstellung der eigenen Lebenspunkte können unterschiedlich starke Getränke erworben werden.

# Entwicklung
## Team
[Christof Schwarzenberger](https://gitlab.mi.hdm-stuttgart.de/cs267)
Modellierung der relevanten Spielgegenstände und Designer für Grafiken.

[David Tomschitz](https://gitlab.mi.hdm-stuttgart.de/dt035)
Gameplay Entwicklung. Entity-, Item- und Shop-System, Spielmechaniken.

[Duane Englert](https://gitlab.mi.hdm-stuttgart.de/de030)
Gameplay Entwicklung und Game Design. Fokus auf Wave System und Overlay erstellung.

[Florian Rapp](https://gitlab.mi.hdm-stuttgart.de/fr061)
Modellierung der relevanten Spielgegenstände und Erstellung der Texturen.

[Sundar Arz](https://gitlab.mi.hdm-stuttgart.de/sa070)
Modellierung der Charaktere und Erstellung der Texturen.

## Genutzte Hardware
## Genutzte Werkzeuge und Engine
Das Spiel wurde mit der Unity-Engine entwickelt. Für die verschiedenen Skripte wurde die von Unity vorgesehene Programmiersprache C# verwendet.  Alle Models wurden in Blender erzeugt und die dazugehörigen Texturen mit Photoshop und Gimp erstellt. Die Versions-Kontrolle erfolgte über das GitLab der HdM.

## Zielplattform
Das Spiel wurde ausschließlich für Windows und Mac OS entwickelt und sollte ausschließlich mit Controller gespielt werden, da nur so alle Mechaniken des Spiels vollständig funktionsfähig sind.

## Externe Komponenten
Für das Spiel wurden verschiedene Komponenten genutzt, die von Drittanbietern entwickelt wurden. Dazu gehören die gesamten Animationen, welche bei [Mixamo](https://www.mixamo.com/#/) frei erhältlich sind. Diese sind professionell entwickelt worden und wurden teilweise sogar mit dem Motion Capture Verfahren erstellt. Des Weiteren sind alle Sounds, welche im Spiel genutzt wurden, von [Freesounds](https://freesound.org/). Alle anderen Spielbestandteile sind ausnahmslos Eigenkomponenten.

# Spielmechaniken, Gameplay und Komponenten
## Spielablauf
Das Spiel beginnt im Hauptmenü, in dem der Spieler ein neues Spiel starten oder das gesamte Spiel beenden kann. Startet der Nutzer ein neues Spiel, wird durch eine Fade-Animation das Hauptmenü durch das Level ersetzt. Ist das Level geladen, findet sich der Spieler in einem Saloon wieder, der als Arena dient. Der Nutzer sieht dann das HUD, in welchem die Hotbar, die Lebensanzeige, Ausdaueranzeige, Munitionsanzeige, Geldanzeige sowie der Countdown für die nächste Runde zu sehen ist. Der Countdown zählt zu Beginn von 30 Rückwärts und soll den Spieler vor den kommenden Gegner warnen. Dieser Countdown kann jeder Zeit durch das Betätigen der B-Taste übersprungen werden. Ist der Countdown abgelaufen, werden die ersten Gegner an verschiedenen Punkten im Level gespawnt. Diese versuchen den Spieler zu verletzten, bis dieser keine Lebenspunkte mehr besitzt. Der Spieler kann sich mittels seiner Fäuste, die er immer zur Verfügung hat, gegen die zahlreichen Gegner verteidigen. Für jedes erfolgreiche K.O., bekommt der Spieler je nach Spielfortschritt einen gewissen Betrag an Geld, mit dem er im Shop während einer Pause neue Gegenstände erwerben kann. Diese Gegenstände können dem Spieler im Verlauf gegen die immer stärker und vor allem zahlreicher werdenden Gegner helfen. Sollte der Spieler sterben, gelangt er automatisch nach einer kurzen Animation in das GameOver-Menü, in dem er ein neues Spiel starten oder zum Hauptmenü zurückkehren kann. Wurde die jeweilige Runde überlebt, beginnt der Countdown erneut. In dieser Unterbrechung kann der Spieler mit seinem verdienten Geld neue Gegenstände im Shop erwerben, auf den er über Barkeeper zugreifen kann. Mit steigender Rundenanzahl werden verschiedene Gegnertypen gespawnt. Diese unterscheiden sich hauptsächlich durch verschiedene Waffen und Lebenspunkte. Der Vorgang, von Erledigen der Gegner und kaufen neuer Gegenstände, wiederholt sich solange bis der Spieler sterben sollte oder er das Spiel beendet wird.

## Models

**Vorgehen**
Die Models wurden in der 3D Objektmodellierungssoftware Blender 2.8 gefertigt. Es wurden verschiedene Formen, wie Kugeln, Quader, Ringe und Zylinder deformiert, bis das gewünschte Ergebnis ersichtlich war. Alle Objekte wurden einzeln gespeichert und später in einer Blender File (room.blend) zusammengebaut. Das hat den Vorteil, den Programmieren in Unity Flexibilität zu bieten, um zu testen, ob sich der Zusammenbau in Blender oder in Unity besser anbietet. So konnten direkt in Blender Wände, Elemente und Größen aufeinander abgestimmt werden, um ein realistisches Ergebnis zu erhalten. Auf diese Weise war eine effiziente Nachbearbeitung ebenfalls möglich. Musste ein Objekt in der room.blend angepasst werden, konnte man dies in der Datei des einzelnen Objektes machen. Da das einzelne Objekt in der Room Datei den gleichen Platz im Koordinatensystem bekommen hat, wie in dessen eigener Datei, konnte das einzelne Objekt nach einer Bearbeitung zum richtigen Punkt im Koordinatensystem importiert werden. Es handelt sich bei allen Modellen um Eigenkomponenten.

**Stil**
Die Objekte wurden aus mehreren Gründen so einfach wie möglich gehalten. Umso detaillierter ein Objekt gestaltet wird, desto mehr Speicherplatz erfordert dies. Da viele Objekte mehrmals im Spiel verwendet wird, verursacht eine zu detaillierte Flasche oder zu rundes Stuhlbein einen sehr hohen Speicherbedarf. Außerdem sollte das Spiel im Comic Stil gehalten sein, worauf bereits die Texturen hinweisen.
Der Stil der einzelnen Objekte ist durch „Lucky Luke“ Comics und dem Spiel „Read Dead Redemption 2“ inspiriert worden. Dort wurde auf das Aussehen der gängigen Möbel und Gegenstände geachtet, um ein authentisches Spielerlebnis zu schaffen.

**Vorbereitung für Unity**
Um die Models für Unity importieren zu können, musste geprüft werden, ob alle Flächen eines Objekts wirklich geschlossen sind. Durch Aktivierung des „Backface Culling“ wurden nicht geschlossene Stellen ersichtlich. Um Probleme in Unity vorzubeugen, mussten „Scale“, „Location“ und „Rotation“ zurückgesetzt werden. Oftmals gab es in Unity Probleme mit der Skalierung, da sich diese in Blender während der Erstellung eines Objektes verändert hatte. Beim FBX Export wurde nur das „Mesh" ausgewählt, da in Blender nur die Objektmodellierung erfolgen sollte. Zusätzlich wurde die Option „!EXPERIMENTAL! Apply Transform“ ausgewählt, da sich die Koordinatensysteme in Blender und Unity entgegengesetzt zueinander verhalten. Nach diesen Schritten konnte das Modell an den Entwickler weitergegeben werden.


## Texturen
Für die Erstellung der Texturen wurden die Models in Blender mit dem SmartUVProject unwrapped. Dabei wurde darauf geachtet, dass zwischen den einzelnen Flächen ein Abstand vorhanden ist. Damit größere Flächen die passende Auflösung erhalten, wurde eine entsprechend große Zuweisung im UV-Grid getätigt. Die Auflösung der Texturen beträgt 1024x1024 Pixeln. Eine höhere Auflösung wird für dieses Projekt nicht benötigt, da die Grafik im Comic Stil gehalten wurden. Dementsprechend werden häufig für große Flächen einzelne Farben genutzt oder allgemein wenig detaillierte Texturen erstellt wurden.

Teilweise wurde nach der Erstellung des UV-Grids die einzelnen Parts der Modelle in Photoshop mit Farbe texturiert, hierbei wurde das UV-Grid in Photoshop importiert, um die Flächen im Texture.png der jeweiligen UV-Grid-Flächen zuzuordnen. Nach der Farbgebung der Texture Ebene wurde das UV-Grid wieder entfernt, um Schwarze Linien in der Texture.png Datei zu verhindern.

Für weitere Models wurden direkt in Blender Farben durch verschiedene Materials zu bestimmten Faces zugeordnet. Schließlich wurde das Model mit der Render Engine Cycles, dem Bake Type Diffuse und dem Influence Color gebaket, wodurch man eine erste png Datei für die Textur erhält und diese exportieren kann. Diese Dateien wurden anschließend mit Gimp oder Photoshop überarbeitet.

Für einen Teil der gezeichneten Texturen wurde die TexturePaint Funktion in Blender genutzt. Die gezeichneten und einfarbigen Texturen für die Flächen eines Models wurden nachfolgend auch in Gimp und Photoshop zu einer Textur Datei zusammengefügt.

## Audio
Wie bereits erwähnt wurden alle Sounds, die im Spiel zu hören sind, von [Freesounds](https://freesound.org/)  genutzt. Während des gesamten Spielverlaufs wird eine Hintergrundmelodie abgespielt, die auch in den verschiedenen Menüs und im Shop zu hören ist. Für jede Aktion die der Spieler ausführt, wie z.B. das Angreifen oder das Drücken eines UI-Buttons, werden entsprechende Sounds abgespielt. Auch für den erfolgreichen Treffer gibt es verschiedene Sounds, welche je nach Waffentyp abgespielt werden.

## Nicht Implementierte Spielmechaniken

**Power Up’s**
Die geplanten Power-UPs wurden nicht implementiert, da die Getränke und Waffen dem funktionierenden Spielprinzip ausreichen. Von einer weiteren Kaufoption im Shop wurde abgesehen, da der Fokus auf der Verbesserung anderer Bereichen lag.

**Zerbrochene Flasche**
Die zerbrochene Flasche, die der Spieler im Shop als Waffe erwerben hätte können, wurde aufgrund der Abnutzung des Gegenstandes und der resultierenden Frustration des Spielers aus dem Spiel entfernt. Es war verwirrend für den Spieler warum die Flasche bereits nach einer Welle wieder verschwunden war.

**Sounds**
Es gibt nicht für alle Aktionen im Spiel entsprechende Sounds.

**KI**
Der Spielumgebung in Bar Brawler beschreibt einen zweistöckigen Saloon, wo sich der Spieler frei bewegen kann. Die Steuerung der Gegner hat teilweise Probleme zu erkennen, in welchem Stockwerk sich der Spieler befindet. Das Problem wurde bei der Besprechung des Prototypen ersichtlich und konnte bis zur Media Night deutlich verbessert werden. Jedoch ist das Problem bis heute nicht vollständig behoben. Der Spieler empfand dieses Problem als nicht störend und konnte so vorausschauend mit den Reaktionen der Gegner rechnen. Das Problem ist im aktuellen Ausmaß zwar nicht schwerwiegend, stellt aber eine Verbesserungsmöglichkeit dar.

# User Interface
## Umsetzung Design
Das Design für Buttons und Menüs wurde in Adobe Illustrator und Adobe Photoshop erstellt. Icons und Formen für die Buttons wurden durch Deformierung bestimmter Formen erzeugt. Als Vorbild dienten meist Fotos von reellen Gegenständen, die dann in eine Illustration umgesetzt wurden. Die Typografie des Logos konnte ebenfalls selbstständig erzeugt werden und ist keine existierende Schriftart. Hierfür wurden Buchstaben der Schriftart Times New Roman als Vektoren umgewandelt und anschließend in die passende Form gebracht. Für das Plakat und den Loading Screen wurde neben den Icons und der Logo Typografie, ebenfalls ein Filter verwendet, der in Photoshop erzeugt wurde. Dieser entspringt ebenfalls keiner Vorlage und erhielt durch verschiedene Effekte seine papierartige Optik. Der Filter wurde anschließen unter einen roten Hintergrund und den Plakatinhalt gelegt.
## HUD
Das HUD besteht aus verschiedenen Anzeigeflächen, die dem Spieler visuell darstellen sollen, in welchem Zustand sich das Spiel aktuell befindet. Zu diesen gehört die Hotbar, Lebens- und Ausdauer-Anzeige, Munitions-Info und eine Information über den gesamten Geldbetrag. In der Hotbar kann der Spieler zu jeder Zeit sehen, welche Items er erworben hat und auch benutzen kann. Des Weiteren ist es möglich, ein Damage-Overlay für einen kurzen Zeitraum im HUD anzuzeigen, wenn der Spieler von einer Attacke getroffen wurde.
## Shop
Der Shop kann nach jeder Runde vom Spieler geöffnet werden, wenn dieser an der Bar steht. Durch den Shop kann der Spieler sein erworbenes Geld für neue Waffen und Getränke ausgeben, die ihm im fortlaufenden Spiel helfen. Der Shop ist durch die Item Kategorien Waffen und Getränke unterteilt, von denen aus die jeweiligen Hauptübersichten erreicht werden können. Wurde eine Kategorie angewählt, sieht der Spieler auf der linken Seite alle Gegenstände die erworben werden können und auf der rechten eine detaillierte Beschreibung des Items, sowie den Titel, ein Bild und Preis. Durch Betätigen des Buttons auf der linken Seite können Gegenstände erworben werden. Ist es zu einem Fehler gekommen, wird dieser unter dem Inventar in Form eines kurzen Textes angezeigt.
## Hauptmenü
Das Hauptmenü beinhaltet den Titel des Spiels sowie die Buttons, um das Spiel zu starten und zu beenden. Im Hintergrund kann der Nutzer den Saloon, den Barkeeper, einen Pianist und den Spieler selbst sehen.
## Pausenmenü
Im Pausemenü kann der Spieler das Spiel fortsetzen, die aktuelle Spielsitzung Neustarten oder ins Hauptmenü zurückkehren. Durch das Betätigen der Start-Taste am Controller öffnet sich das Pausemenü. Das Spiel wird währenddessen pausiert.
## GameOver-Menü
Das GameOver-Overlay wird aufgerufen, wenn der Spieler stirbt. Das Menü wird durch eine Animation auf den Bildschirm gebracht. Im GameOver-Menü kann der Spieler Statistiken einsehen, die aus den allen Runden gesammelt wurden. Im Menü hat der Spieler zwei Auswahlmöglichkeiten. Er kann das Spiel entweder Neustarten oder zurück zum Hauptmenü gehen.

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

### EntityCombatBehaviour Klasse
Die *EntityCombatBehaviour* Klasse wird als StateMachine verwendet und wird für die meisten Animationen, die der Spieler triggern kann genutzt. Die primäre Aufgabe dieser Klasse ist es, den *CombatState* der jeweiligen Entität zu aktualisieren, was durch die *Entity.combat.SetState* Methode erreicht wird. Dieser wird der aktuell ausgerüstete Gegenstand der Entität übergeben, 
```csharp
public class EntityCombatBehaviour : StateMachineBehaviour
{
   public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Entity entity = animator.GetComponentInParent<Entity>();
        if (entity != null && entity.equipment.CurrentEquipment != null && !entity.combat.IsBlocking)
        {
            entity.combat.SetState(entity.equipment.CurrentEquipment);
            ...
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Entity entity = animator.GetComponentInParent<Entity>();
        if (entity != null && entity.equipment.CurrentEquipment != null)
        {
            entity.combat.SetState(CombatState.Idle);
            ...
        }
    }
}
```

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

### PlayerControls Klasse
Die *PlayerControls* Klasse ist wohl mit die wichtigste im gesamten Spiel. Mit ihr kann der Nutzer die Spielfigur im Level bewegen und die verschiedenen Aktionen ausführen, die ihm geboten werden. Die Tastenbelegung wurde mithilfe des neuen Input-Systems von Unity realisiert, automatisch erstellt und in der Klasse *PlayerInputActions* gespeichert. Diese erzeugten Events werden dann in der *Awake* Methode des Skripts abonniert, um im Verlauf des Spiels diese verarbeiten zu können. Diese abonnierten Methoden stellen die Hauptfunktionen des Spiels dar. Andere Kontrollfunktionen werden in den jeweiligen Klassen deklariert.
```csharp
void Awake()
{
	inputActions = new PlayerInputActions();
	inputActions.PlayerControls.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
	inputActions.PlayerControls.Rotation.performed += ctx => lookPosition = ctx.ReadValue<Vector2>();

	inputActions.PlayerControls.Primary.performed += UsePrimary;
	inputActions.PlayerControls.Secondary.performed += UseSecondary;
	inputActions.PlayerControls.UseItem.performed += UseItem;
	inputActions.PlayerControls.Pause.performed += PauseGame;
}
```
Die Methoden *UsePrimary*, *UseSecondary* und *UseItem* werden aufgerufen, wenn der Nutzer die dazugehörige Taste betätigt hat. Sie triggern die primär oder sekundäre Aktion des aktuell ausgerüsteten Items mithilfe der [EntityEquipment](#EntityEquipment) Klasse. 
```csharp
public void UsePrimary(CallbackContext ctx)
{
	if (GameState.instance.IsInTargetAcquisition) return;
	equipment.UsePrimary();
}

public void UseSecondary(CallbackContext ctx)
{
	if (GameState.instance.IsInTargetAcquisition) return;
	equipment.UseSecondary();
}

public void UseItem(CallbackContext ctx)
{
	if (GameState.instance.IsInTargetAcquisition) return;
	equipment.UseConsumable();
}
```
In dieser Klasse wird außerdem die Funktion implementiert das Spiel zu pausieren. Dies geschieht mit der folgenden Methode.
```csharp
public void PauseGame(CallbackContext ctx)
{
	GameState.instance.SetState(GameStateType.GamePaused);
}
```
Damit sich der Spieler jedoch letztendlich bewegen und rotieren kann wurde eine eigens dafür angepasste Steuerung implementiert. Die Bewegung des Spielers wird mittels der Input-Werte der Joysticks eines Gamepads oder der Pfeiltasten sowie der Bewegungsrichtung der Kamera kalkuliert. Diese Logik befindet sich in der *Update* Methode in welcher die Variable *desiredDirection* letztendlich für jeden Update-Zyklus neu ermittelt wird. Dieser Richtungsvektor gibt an, in welche Richtung sich der Spieler Bewegen soll und wie die Bewegungs-Animation durch den *Animator* erzeugt werden soll.
```csharp
void Update()
{
	if (IsMovementEnabled)
	{
		float h = movementInput.x;
		float v = movementInput.y;

		Vector3 input = new Vector3(h, 0f, v);
		inputDirection = Vector3.Lerp(inputDirection, input, Time.deltaTime * 10f);

		Vector3 cameraForward = mainCamera.transform.forward;
		Vector3 cameraRight = mainCamera.transform.right;

		cameraForward.y = 0f;
		cameraRight.y = 0f;

		Vector3 desiredDirection = cameraForward * inputDirection.z + cameraRight * inputDirection.x;

		MovePlayer(desiredDirection);
		RotatePlayer();
		AnimatePlayerMovement(desiredDirection);
	}
}
```
Mithilfe der *MovePlayer* Methode wird das Spieler-Model basierend auf dem übergebenen Parameter bewegt. Dieser wird auf der x- und z-Achse mit der vorab definierten Geschwindigkeit, der delta Zeit und sich selbst multipliziert. Dieser dadurch entstanden Bewegungsvektor wird dann an den *CharacterController*, welcher von Unity zur Verfügung gestellt wird, übergeben. Des Weiteren wird auf der y-Achse noch die Gravität errechnet, damit der Spieler von einer erhöhten Ebene herunterfallen und nicht in der Luft laufen kann.
```csharp
private void MovePlayer(Vector3 desiredDirection)
{
	movement.Set(desiredDirection.x, movement.y, desiredDirection.z);
	movement = movement * speed * Time.deltaTime;

	character.Move(movement);

	movement.y += (Physics.gravity.y * gravityScale * Time.deltaTime * 0.6f);
}
```
Mittels der gewünschten Bewegungsrichtung wird außerdem durch die [EntityAnimator](#EntityAnimator) Klasse eine Bewegungs-Animation "gebaut", welche zuvor in einem Blend-Tree definiert wurde. 
```csharp
private void AnimatePlayerMovement(Vector3 desiredDirection)
{
	if (!playerAnimator) return;

	Vector3 movement = new Vector3(desiredDirection.x, 0f, desiredDirection.z);
	float forward = Vector3.Dot(movement, playerModel.transform.forward);
	float strafe = Vector3.Dot(movement, playerModel.transform.right);
	playerAnimator.Move(forward, strafe);
}
```
Damit sich das Spieler-Model auch rotieren lässt, gibt es die *RotatePlayer* Methode. Sie errechnet anhand der Kamerarichtung die Rotationsbewegung des Spielers. Sollte der Spieler jedoch zuvor im Zielerfassungsmodus einen Gegner ausgewählt haben, rotiert sich der Spieler nur noch in die Richtung des ausgewählten Gegners.
```csharp
private void RotatePlayer()
{
	if (TargetAcquisition.instance.CurrentEnemy != null)
	{
		TurnPlayerToEnemy();
		return;
	}

	Vector2 input = lookPosition;
	Vector3 lookDirection = new Vector3(input.x, 0, input.y);

	Vector3 lookRotation = mainCamera.transform.TransformDirection(lookDirection);
	lookRotation = Vector3.ProjectOnPlane(lookRotation, Vector3.up);

	if (lookRotation != Vector3.zero)
	{
		Quaternion newRotation = Quaternion.LookRotation(lookRotation);
		playerModel.transform.rotation = Quaternion.Lerp(playerModel.transform.rotation, newRotation, Time.deltaTime * 8f);
	}
}

private void TurnPlayerToEnemy()
{
	Enemy enemy = TargetAcquisition.instance.CurrentEnemy;
	Vector3 lookDirection = (enemy.transform.position - playerModel.transform.position).normalized;
	Quaternion lookRotation = Quaternion.LookRotation(new Vector3(lookDirection.x, 0, lookDirection.z));
	playerModel.transform.rotation = Quaternion.Lerp(playerModel.transform.rotation, lookRotation, Time.deltaTime * 10000f);
}
```
### TargetAcquisition Klasse
Die *TargetAcquisition* wurde implementiert um dem Nutzer die Möglichkeit zu bieten einzelne Gegner besser anzuvisieren bzw. anzugreifen. Dies geschieht in einem Zeitlupen-Modus, in welchem der Spieler dann durch die dafür vorgesehenen Tasten, die einzelnen Gegner anwählen kann und den Zielerfassungsmodus schlussendlich verlässt. Um diesen zu aktiveren gibt es die *Toggle* Methode.  Sie aktiviert oder deaktiviert den Zeitlupen-Modus und aktualisiert den GameState entsprechend. Sollte der Zielerfassungsmodus zum ersten Mal aktiviert werden, wird außerdem automatisch der erste Gegner in der Nähe des Spielers mittels der *SelectClosestEnemy* Methode ausgewählt
```csharp
public void Toggle()
{
	if (!GameState.instance.IsInGame) return;
	
	IsEnabled = !IsEnabled;
	Time.timeScale = IsEnabled ? 0.2f : 1.0f;
	GameState.instance.SetState(IsEnabled ? GameStateType.TargetAcquisition : GameStateType.InGame);
	
	if (IsEnabled && CurrentEnemy == null)
	{
		SelectClosestEnemy();
	}
}

public void SelectClosestEnemy()
{
	SelectEnemy(FindClosestEnemy());
}
```
Das Auswählen eines einzelnen Gegners geschieht durch die *SelectEnemy* Methode, welche den aktuell ausgewählten Gegner durch den neuen ersetzt. Außerdem wird das Crosshair, was unter dem ausgewählten Gegner zusehen ist jenachdem de- und aktivert.
```csharp
public void SelectEnemy(Enemy enemy) =>  SetCurrentEnemy(enemy);

private void SetCurrentEnemy(Enemy enemy)
{
	if (CurrentEnemy != null) CurrentEnemy.SetCrosshairActive(false);

	currentIndex = enemy == null ? -1 : enemies.IndexOf(enemy);
	CurrentEnemy = enemy;

	if (CurrentEnemy != null) CurrentEnemy.SetCrosshairActive(true);
}
```
Um beispielsweiße einen ausgewählten Gegner nicht mehr als solch einen Anzuzeigen, weil dieser beispielsweise gestorben ist, gibt es die Methode *UnselectCurrentEnemy*. Ihr kann auch der Übergabeparameter autoSelect übergeben werden, welcher standardmäßig auf *false* gesetzt ist. Ist er jedoch *true*, wir nach dem "abwählen" ein neuer Gegner ausgwählt und mit dem roten Crosshair angezeigt.

Um wie am Anfang den nähsten Gegner zu finden bzw. allgemein zwischen den Gegner hin und her wechseln zu können gibt es die Methoden *UpdateEnemies* und *FindClosestEnemy*. Die UpdateEnemies Methode dient hierbei dazu eine Liste an lebenden Gegner immer aktuell zuhalten, solang sich der Spieler im TargetAcquisition-Modus befindet. Nur so ist es auch möglich, das der Nutzer mittels der dafür vorgesehenen Tasten zwischen den lebenden Gegnern hin und her wählen kann. 
```csharp
private void UpdateEnemies()
{
	enemies.Clear();
	foreach (Enemy enemy in FindObjectsOfType<Enemy>())
	{
		if (enemy.stats.IsDead) continue;
		enemies.Add(enemy);
	}
}
```
Mit der vorher angesprochenen Methode *FindClosestEnemy* kann der näheste Gegner zum Spieler ermittelt werden. Sie wird vorallem bei der aktiverung des Moduses genutzt um den ersten Gegner zu markieren. Dies wird durch das errechnen der Distanzen zwischen dem Spieler und dem jeweiligen Gegner erreicht. Wurde der nähste Gegner ermittelt, gibt ihn die Methode zurück.
```csharp
private Enemy FindClosestEnemy()
{
	Enemy enemy = null;
	UpdateEnemies();
	if (enemies != null && enemies.Count != 0)
	{
		Vector3 playerPositon = Player.instance.gameObject.transform.position;
		for (int i = 0; i < enemies.Count; i++)
		{
			float distance = Vector3.Distance(enemies[i].transform.position, playerPositon);
			if (distance < minDistance) enemy = enemies[i];
		}
	}
	return enemy;
}
```

## Enemy

## Barkeeper Klasse
Die Barkeeper Klasse wird genutzt damit der Spieler mit diesem an der Bar interagieren kann, um somit den [Shop](#Shop) zu schließen oder zu öffnen. Dies wird erreicht in dem in der Klasse gespeichert wird, ob sich der Spieler in Reichweite befindet oder nicht. Außerdem Spielt der aktuelle [GameState](#GameState) eine wichtige Rolle. Ist dieser nämlich auf *GameStateType.GamePaused* oder *GameStateType.GameOver* kann der Shop nicht geöffnet werden. Auch wenn sich der Spieler aktuell in einer Runde befindet, kann nicht mehr mit dem Barkeeper interagiert werden. Die Klasse hat somit ausschließlich den Zweck den Shop zu öffnen und zu schließen.

## Items

### Base Items
Da die verschiedenen Items auch unterschiedliche Parameter speicher müssen, wurden anhand der verschiedenen Itemtypen, die es im Spiel gibt, verschiedene Basisklassen implementiert. Die hauptsächliche Aufgabe dieser Klassen besteht also darin, die verschiedenen Parameter des Gegenstands und das Prefab zu speichern. Zu diesen Parameter gehören z.B. die initiale Position in der Hand, die maximale Stapel Größe,  eine Referenz auf das Icon sowie der Name. 

#### Item Klasse
Die Item Klasse ist die zentrale Basisklasse, von der alle anderen Item Klassen erben. Sie deklariert die wichtigsten Parameter wie z.B. den Namen, Itemtyp oder die Referenz zum Icon. Des Weiteren implementiert sie die Methode *OnCollection* welche aufgerufen wird, wenn der Spieler ein Item eingesammelt hat. Durch diese wird der Gegenstand dann zum Inventar hinzugefügt, wenn dies aktiviert ist.
```csharp
[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    new public string name;
    public Sprite icon;
    public ItemKind kind;

    public bool addToInventory = true;
    public bool isStackable = true;
    public int maxStackSize = 1;
    public InventorySlot slot;

    public virtual void OnCollection()
    {
        Player.instance.inventory.AddItem(this);
    }
}

public enum ItemKind
{
    Consumable,
    Weapon
}

public enum ItemType
{
    Fist,
    Revolver,
    Bottle,
    Knife,
    Whiskey,
    Beer,
    Feuersaft
}
```

#### Money Item Klasse
Die Money Klasse wird um die [Item](#Item) Basisklasse erweitert und fügt lediglich die Variable *amount*
Hinzu, welche Später den Geldbetrag des Money-Items beinhalten soll. 
```csharp
[CreateAssetMenu(fileName = "New Money Item", menuName = "Items/Money")]
public class Money : Item
{
    public int amount;
}
```
#### Munition Item Klasse
Wie auch beim Money-Item, wird beim Munition-Item die Klasse [Item](#Item) implementiert und ebenfalls durch den Parameter *amount* erweitert, welcher später die Anzahl der Patronen beinhaltet, die der Spieler erhalten soll, wenn er das Item erworben hat.
```csharp
[CreateAssetMenu(fileName = "New Munition", menuName = "Items/Munition")]
public class Munition : Item
{
    public int amount;
}
```
#### Equipment Item Klasse
Die *Equipment* Item Klasse erbt ebenfalls wie die vorherigen Klassen von der [Item](#Item) Klasse, jedoch erweitert sie diese durch viele neue Funktionen und Variablen, die benötigt werden damit diese Art von Item durch die Klasse [EntityEquipment](#EntityEquipment) ausgerüstet werden kann.  Dazugehören die Variablen *prefab*, *defaultHand*, *defaultPosition*, *defaultRotation* und *defaultDropRotation*. Erstere speichert eine Referenz zu dem GameObject das die eigentliche Funktionsweise implementiert und das Model des Gegenstands beinhaltet. Die anderen Parameter dienen dazu die Standardposition und Standardrotation zu speichern. Diese werden benötigt, wenn das Item zum ersten Mal durch die Klasse [EntityEquipment](#EntityEquipment) ausgerüstet wurde.

Des Weiteren implementiert die *Equipment* Klasse die Funktionsweise der Abnutzung für alle Gegenstände dieser Art. Jedes Item kann sich nämlich mit der Zeit z.B. bei erfolgreichen Treffern abnutzen, bis es irgendwann kaputtgeht. Diese Haltbarkeit wird durch die Variablen *hasDuration*, *duration* und *currentDuration* verwaltet und kann mit der Methode *UseItem* aktualisiert werden.  Damit auch in der [Hotbar](#Hotbar) immer die richtige Haltbarkeit des jeweiligen Items angezeigt wird, gibt es das Event *OnDurationUpdate*.
```csharp
[CreateAssetMenu(fileName = "New Equipment", menuName = "Items/Equipment")]
public class Equipment : Item
{
    public delegate void DurationUpdate(float normalizedDuration);
    public event DurationUpdate OnDurationUpdate;

    public ItemType type;
    public GameObject prefab;

    public bool hasDuration;
    public float duration;
    private float currentDuration;

    public Hand defaultHand;
    public Vector3 defaultPosition;
    public Vector3 defaultRotation;
    public Vector3 defaultDropRotation;

    public EquipmentAnimation[] equipmentAnimations;

    ...

    public bool UseItem()
    {
        currentDuration--;
        OnDurationUpdate?.Invoke(NormalizedDuration);

        if (currentDuration <= 0)
        {
            Player.instance.inventory.RemoveItem(this);
            return true;
        }

        return false;
    }

    ..
}
```
Zusätzlich werden in dieser Klasse auch die möglichen Animationen, durch die Hilfsklasse *EquipmentAnimation* gespeichert. Sie implementiert die Variablen,  *index*, *hand*, *specificPosition* und *specificRotation*. Diese Variablen werden genutzt um zum einen Festzustellen, welche Animation durch den  [EntityAnimator](#EntityAnimator)  abgespielt werden soll. Zum anderen werden sie benötigt um für die jeweilige Animation, den Gegenstand zwischen den Händen gegeben Falls zu tauschen und die Position und Rotation zu überschreiben. Damit diese Werte aber auch durch die [EntityEquipment](#EntityEquipment)  Klasse überschrieben werden, muss dies durch die Variablen *useSpecifcPosition* und *useSpecificRotation* aktiviert werden.
```csharp
[System.Serializable]
public class EquipmentAnimation
{
    public int index;
    public Hand hand;

    public bool useSpecifcPosition;
    public bool useSpecificRotation;

    public Vector3 specificPosition;
    public Vector3 specificRotation;
}
```

#### Drink Item Klasse
Die *Drink* Klasse dient als Speicherklasse für alle konsumierbaren Items und erbt von der [Equipment](#Equipment) Klasse und erweitert diese durch die Variablen *healingAmount*, *healingSpeed* und *healingDelay*. Diese werden in den Klassen verwendet, in welchen die eigentliche Logik der Getränke implementiert ist. 
```csharp
[CreateAssetMenu(fileName = "New Drink", menuName = "Items/Drink")]
public class Drink : Equipment
{
    public int healingAmount;
    public float healingDelay;
}
```
#### Weapon Item Klasse 
Die Weapon Klasse erbt ebenfalls von der [Equipment](#Equipment) Klasse und erweitert diese durch die einzige Variable *damage*, welche den Standardschaden der Waffe speichern soll.
```csharp
[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
public class Weapon : Equipment
{
    public float damage;
}
```
### Collectable Item Klasse
Die *Collectable* Klasse dient dazu, das grundsätzliche Verhalten zu implementieren, wenn der Spieler einen neuen Gegenstand vom Boden aufnimmt. Dies wird erreicht durch das benutzten von Kollisions-Boxen, welche dann die Methode *OnTriggerEnter* callt. Sollte es sich bei dem Verursacher um einen Spieler handeln, wird wie Methode *OnCollection* der [Item](#Item) Klasse aufgerufen, welche in der unveränderten Variante dieses dann dem Inventar hinzufügt.
```csharp
public class Collectable : MonoBehaviour
{
	public Equipment item;
	public bool isCollected = false;

	 private void OnTriggerEnter(Collider other)
	 {
		 if (other.CompareTag("Player") && !isCollected)
		 {
			 isCollected = true;
			 item.OnCollection();
			 OnCollection();
		 }
	 }
	 
	 public virtual void OnCollection()
	 {
		 Destroy(gameObject);
	 }
 }
```
### Consumable Item Klasse
Die Consumable Klasse implementiert das Verhalten der Getränke, welches durch die Parameter *healingAmount*, *healingSpeed* und *healingDelay* der *Drink* Basisklasse modifiziert werden kann. Da es sich bei konsumierbaren Gegenständen auch um Items handelt, die vom Spieler ausgerüstet werden können und müssen, erbt die Klasse von der *Equippable* Klasse diese Funktionalität. So ist es möglich das der Spieler die verschiedenen Getränke konsumieren kann, um seine Lebenspunkte wieder zu regenerieren.
```csharp
public class Consumable : Equippable
{
    public override void OnPrimary()
    {
        base.OnPrimary();
        if (owner.combat.IsAttacking || owner.combat.IsBlocking || owner.combat.IsDrinking || owner.stats.HasFullLife) return;

        owner.animator.OnPrimary();
        StartCoroutine(StartHealing(item as Drink));
    }

    private IEnumerator StartHealing(Drink drink)
    {
        yield return new WaitForSeconds(drink.healingDelay);
        owner.stats.Heal(drink.healingAmount);

        Player.instance.inventory.RemoveItem(item);
    }
}
```
### Equippable Item Klasse
Mithilfe der Klasse *Equippabe*,  können Gegenstände primär und sekundär Aktionen ausführen, solang diese durch die Variablen *isPrimaryEnabled* und *isSecondaryEnabled* aktiviert sind. Die Methoden sind deshalb auch alle als virtual gekennzeichnet, damit sie durch die erbenden Klassen erweitert werden können. Aufgerufen werden diese hauptsächlich durch die [EntityEquipment](#EntityEquipment) Klasse.
```csharp
public class Equippable : Collectable
{
	public bool isPrimaryEnabled = true;
	public bool isSecondaryEnabled = false;

	protected Entity owner;

	protected virtual void Start()
	{
		owner = GetComponentInParent<Entity>();
		if (owner == null) throw new ArgumentException("The item owner can't be null!");
	}

	public virtual void OnPrimary()
	{
		if (!isPrimaryEnabled) return;
	}

	public virtual void OnSecondary()
	{
		if (!isSecondaryEnabled) return;
	}

	public virtual void OnEquip()
	{
		isCollected = true;
	}
}
```
### Weapon Item Klasse
Die *WeaponItem* Klasse erbt von der [Equippable](#Equippable) Klasse und erweitert die Funktionsweise der primär und sekundär Attacke durch einen Cooldown. Außerdem wird die Methode *OnHit* hinzugefügt, welche gecallt wird, wenn der Spieler einen erfolgreichen Treffer mit seiner Waffe gelandet hat. Mithilfe dieser Methode ist es möglich dem Gegner schaden hinzuzufügen und den Abnutzungsprozess zu starten. Damit *OnHit* jedoch überhaupt aufgerufen wird, werden auch hier Kollisions-Boxen verwendet und deren Trigger-Methoden verwendet. 

Trifft der Besitzer des Items beispielsweise einen Gegner, wird geschaut, ob dieser aktuell wirklich einen Angriff ausführt oder nicht. Sollte dies der Fall sein wird versucht die gegnerische Seite zu ermitteln, um dieser dann unter anderem Schaden hinzuzufügen. Außerdem wird eine Art Block-Mechanismus aktiviert, damit doppelte Kollisionen ausgeschlossen werden können.
```csharp
void OnTriggerEnter(Collider other)
{
	if (hasCollided) return;
	if (... && (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player"))
	{
		if (owner.combat.IsAttacking)
		{
			Entity entity = other.gameObject.GetComponent<Entity>();
			if (entity != null) OnHit(entity);

			hasCollided = true;
		}
	}
}

void OnTriggerExit(Collider other)
{
	if (!hasCollided) return;
	if (... && (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player"))
	{
		hasCollided = false;
	}
}
```
Wurde eine Entität erfolgreich getroffen und die Methode OnHit gecallt, werden die weiteren Prozesse gestartet. Zu diesen gehört die Abnutzung des benutzen Gegenstands und der Aufruf der *OnHit* Methode aus der [Entity](#Entity) Klasse.
```csharp
public virtual void OnHit(Entity entity)
{
	if (entity.combat.IsBlocking && owner.equipment.CurrentEquipment.type == ItemType.Fist) return;
	if (entity is Enemy && owner is Player && item.hasDuration)
	{
		bool isDestroyed = item.UseItem();
		if (isDestroyed) return;
	}
	entity.OnHit(owner, item);
}
```
Damit jede Waffe auch einen Cooldown besitzt und nur dann die Aktionen ausgeführt werden können, wenn der Cooldown abgelaufen ist, wurden die Methoden *OnPrimary* und *OnSecondary* mit dieser Funktionalität erweitert.
```csharp
public override void OnPrimary()
{
	base.OnPrimary();

	if (...&& (owner.combat.IsDrinking || owner.combat.IsAttacking || owner.combat.IsStunned)) return;
	if (primaryCooldown <= 0f)
	{
		primaryCooldown = 1f / primaryAttackRate;
		owner.animator.OnPrimary();
	}
}

public override void OnSecondary()
{
	base.OnSecondary();
	if (...&& (owner.combat.IsDrinking || owner.combat.IsAttacking || owner.combat.IsStunned)) return;
	if (secondaryCooldown <= 0f && owner.combat.CurrentMana >= secondaryManaRequired)
	{
		secondaryCooldown = 1f / secondaryAttackRate;
		owner.animator.OnSecondary();
	}
}
```

## GameState Klasse
Die *GameState* Klasse speichert den aktuellen State des Spieles, was notwendig ist damit gewisse Aktionen blockiert werden können. So kann beispielsweise verhindert werden, dass der Spieler den Shop öffnen kann, obwohl er sich gerade im Pausenmenü befindet. Außerdem werden durch das Aktualisieren des Game States, mithilfe der *SetState* Methode, auch verschiedene UI-Element ein- und ausgeblendet. Dies geschieht durch die jeweiligen Toggel-Methoden und durch die [UIManager](#UIManager) Klasse, welche Zugriff auf alle UI-Elemente im Spiel hat.
```csharp
public void SetState(GameStateType newState)
{
	if (State == newState) return;
	State = newState;

	switch(newState)
	{
		case GameStateType.GamePaused:
			TogglePauseMenu();
			break;

		case GameStateType.GameOver:
			ToggleGameOver();
			break;

		case GameStateType.InGame:
			ToggleIngame();
			break;

		case GameStateType.InShop:
			ToggleShop();
			break;

		case GameStateType.TargetAcquisition:
			ToggleTargetAcquisition();
			break;
	}
}
```

## Wave-System
Das Wave-System ist neben den anderen Spielmechaniken, wie das Kämpfen oder Bewegen des Spielers essenziell. Um dieses System so modular wie möglich zu gestalten, wurde die eigentliche Logik für die Verwaltung der Schwierigkeitsstufen aus der *WaveSpawner* Klasse heraus genommen und in der *WaveConfig*  Klasse implementiert. So ist es möglich jeder Zeit für verschiedene Abschnitten im Spielverlauf, verschiedene Konfigurationen zu benutzten, um dadurch letztendlich die Schwierigkeit dynamisch anzupassen. 

### WaveConfig Klasse
Die *WaveConfig* wird genutzt um das Wave-System modular und dynamischer zu gestalten. Sie speichert wichtige Informationen, wie die Rundenzahl, in der die Config geladen werden soll, die dazugehörige Schwierigkeitsstufe, das Enemy-Prefab was zur Instantiierung notwendig ist und die für diese Runde vorgesehene *EnemyConfig*. Wird eine *WaveConfig* aktiviert, werden die zuvor aufgezählten Parameter an den *WaveSpawner* weiter gegeben, welcher dann letztendlich auch die *EnemyConfig* der aktuellen *WaveConfig* an die erzeugten Gegner übergibt.
```csharp
public class WaveConfig : ScriptableObject
{
	public int round;
	public Difficulty difficulty;
	public GameObject enemy;

	public EnemyConfig enemyConfig;
}
```
#### EnemyConfig Klasse
In der *EnemyConfig* Klasse können neben der Referenz zu einer *EnemyStatsConfig* auch die möglichen Money-Drops sowie die verschiedenen Waffen definiert werden, die der Gegner eventuell bekommen kann. Das *moneyDrops* wird also beispielsweise genutzt, wenn der Gegner gestorben ist. Der Spieler erhält für den Kill dann einen gewissen Betrag an Geld, welcher zufällig aus dieser List entnommen wurde. 
```csharp
public class EnemyConfig : ScriptableObject
{
    public EnemyStatsConfig stats;

    public int[] moneyDrops;
    public RandomItem[] items;
}
```
Damit die Gegner wie schon zuvor erwähnt auch mit verschiedenen Waffen spawnen, gibt es das Array *items*. In diesem können vorab alle Items gespeichert werden, die der Gegner eventuell ausrüsten können sollte. Damit letztendlich bei der Erzeugung ein zufälliges Item aus der Liste gezogen wird, wurde die Klasse *RandomItem* implementiert. Diese speichert neben der eigentlichen Wahrscheinlichkeit für das Item auch eine Referenz für das Item selbst, sowie die Variablen *damageOverride* und *healthOverride*. Die letzten beiden Variablen können dafür genutzt werden, den Standardschaden oder die Standardlebenspunkte zu überschreiben, was teilweise notwendig ist, da der Gegner erst im Verlauf des Spiels mit diversen Waffen mehr Schaden machen darf.
```csharp
public class RandomItem
{
    public int percentage;
    public Equipment item;
    public int damageOverride;
    public int healthOverride;
}
```

#### EnemyStatsConfig
Die *EnemyStatsConfig* speichert die Standardlebenspunkte die Gegner bekommen soll und den Schaden den er verursacht. Diese Werte können jedoch durch die *EnemyConfig* Klasse überschrieben werden.
```csharp
public class EnemyStatsConfig : ScriptableObject
{
    public float maxHealth;
    public float minHealth;
    public float damage;
}
```

### WaveSpawner Klasse
Die WaveSpawner Klasse implementiert die eigentliche Logik des Erstellens der Wellen und der dazugehörigen Gegner. Um immer klar definieren zu können in welchem Zustand sich der WaveSpawner aktuell befindet und um so vorzubeugen, dass der Spieler durch etwaige Bugs beispielsweise die Runde vorzeitig überspringen könnte oder zu viele Gegner gespawnt werden, wurde das Enum WaveState implementiert. Der WaveSpawner kann immer nur einen dieser definierten Zustände annehmen. 
```csharp
public enum WaveState { 
	Spawning, // Ist gesetzt, wenn der WaveSpawner in diesem Moment Gegner spawnen lässt.
	Counting, // Ist gesetzt, wenn der WaveSpawner pausiert ist und den Countdown für die nächste Runde anzeigt.
	Running // Ist gesetzt, wenn der WaveSpawner pausiert ist, da die aktuelle Runde noch läuft.
}
```
Mittels der *Update* Methode wird zwischen den verschiedenen States gewechselt. In ihr wird also entweder eine neue Runde gestartet oder der Countdown für die kommende Runde angezeigt und verwaltet. 
```csharp
void Update()
{
	if (enableWaveSpawner && (GameState.instance.State != GameStateType.GameOver || GameState.instance.State != GameStateType.GamePaused))
	{
		if (State == WaveState.Running)
		{
			if (IsEnemyAlive) return;
			Player.instance.animator.OnVictory();
			ResetWaveSpawner();
		} 
		
		if(waveCountdown <= 0f)
		{
			 waveCountdown = 0f;
			 if (State != WaveState.Spawning) StartNextWave();
			 return;
		 }
		 
		 waveCountdown -= Time.deltaTime;
		 if (waveCountdown > 0f) OnWaveCountdownUpdate?.Invoke(waveCountdown);
	 }
 }

private void ResetWaveSpawner()
{
	SetState(WaveState.Counting);
	waveCountdown = timeBetweenWaves;
}
```
Ist aktuell eine Runde gestartet und die Gegner wurden erfolgreich erzeugt, muss immer wieder überprüft werden, ob von diesen Gegnern noch welche am Leben sind oder nicht. Hierfür wird die Methode *IsEnemyAlive* genutzt, welche im letzten Codebeispiel zu sehen war. Sie überprüft in kurzen Intervallen mithilfe der *GameObject.FindGameObjectWithTag* Funktion, ob noch Gegner leben oder nicht.
```csharp
private bool IsEnemyAlive
{
	get
	{
		searchCountdown -= Time.deltaTime;
		if (searchCountdown <= 0f)
		{
			searchCountdown = 1f;
			if (GameObject.FindGameObjectWithTag("Enemy") == null) return false;
		}
		return true;
	}
}
```
Um eine neue Runde zu starten und die Welle an Gegner zu erzeugen, wird die Methode *StartNextWave* genutzt. Sie lädt die aktuelle [WaveConfig](#WaveConfig), und starte eine Coroutine, welche dann die einzelnen Gegner an zufällig ausgewählten Spawnpoints erstellt. Um für jede Runde auch die richtige *WaveConfig* zu laden, wird jede einzelne in dem vorab definierten Array *configs*, basierend auf der jeweiligen Rundenzahl der Config mit der aktuellen verglichen. Sollte die Rundenzahl der speziellen WaveConfig mit der erspielten Rundenzahl übereinstimmen, wird diese Config von nun an verwendet. So ist gewährleistet, dass die Config's immer weiter ausgetauscht werden, solang es in dem Array welche gibt, die im Vergleich zur aktuellen Rundenzahl eine höher definierte besitzen.
```csharp
private void StartNextWave()
{
	WaveConfig nextConfig = GetNextWaveConfig();
	if (nextConfig != null) SetConfig(nextConfig);
	
	Rounds++;
	StartCoroutine(SpawnRoutine());
	Statistics.instance.AddRound();
}

private WaveConfig GetNextWaveConfig()
{
	foreach (WaveConfig config in configs)
	{
		if (config.round == Rounds) return config;
	}
	return null;
}

private void SetConfig(WaveConfig config)
{
	CurrentConfig = config;
	CurrentDifficulty = config.difficulty;
}
```
Erstellt werden die einzelnen Gegner letztendlich durch die Methode *SpawnRoutine*. Damit die Gegner an verschiedenen Positionen gespawnt werden, wird für jeden eine neue zufällige Position aus der Liste der  [SpawnPoint](#Spawnpoint)'s gewählt. Außerdem bekommt jeder Gegner bei der Initialisierung die *EnemyConfig* übergeben, welche in der aktuellen WaveConfig definiert ist. So ist garantiert, dass für die meisten Runden unterschiedliche Gegnertypen den Spieler angreifen.
```csharp
private IEnumerator SpawnRoutine()
{
	SetState(WaveState.Spawning);
	
	for (int i = 0; i < Rounds * 1.25; i++)
	{
		SpawnPoint spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
		Enemy enemy = Instantiate(CurrentConfig.enemy, spawnPoint.Position, spawnPoint.Rotation).GetComponent<Enemy>();
		
		if (enemy != null) enemy.Init(CurrentConfig.enemyConfig);
		
		yield return new WaitForSeconds(1f);
	}
	
	SetState(WaveState.Running);
	yield break;
}
```
### Spawnpoint Klasse
Die Spawnpoint Klasse wird ausschließlich genutzt, um die Position für den Punkt zu definieren. So konnte ein Prefab erstellt werden, das man einfach im Level platziert kann und dem WaveSpawner übergibt.```csharp
public class SpawnPoint : MonoBehaviour
{
	public Vector3 Position
	{
		get { return transform.position; }
	}

	public Quaternion Rotation
	{
		get { return transform.rotation; }
	}
}
```

## UI
### UIManager und HUDManager
Die Klassen UIManager und HUDManager, sind wie der Name schon sagt ausschließlich für die Verwaltung der verschiedenen UI-Elemente zuständig. Deshalb beinhalten beide Klassen Referenzen zu den jeweiligen Game-Objekten, da die meisten Elemente eigene Verwaltungsklassen besitzen.

Die *UIManager* Klasse hat beispielsweise die Aufgabe die verschiedenen Menüs ein- und auszublenden oder das HUD zu aktivieren/deaktivieren. Außerdem wurde die Klasse als Singelton implementiert, damit ihre Variablen von überall aus erreicht werden können und es garantiert werden kann, dass es immer nur eine Instanz dieser Klasse gibt.
```csharp
public class UIManager : MonoBehaviour
{
    Singelton

    public HUDManager hud;
    public Canvas shopCanvas;
    public Canvas gameOverCanvas;
    public PauseMenu pauseMenu;

	...

    public void SetHUDActive(...) => SetHUDActive(...);
    public void SetShopActive(bool active) => shopCanvas.gameObject.SetActive(active);
    public void SetPauseMenuActive(bool active) => pauseMenu.gameObject.SetActive(active);
    public void SetGameOverMenuActive(bool active) => gameOverCanvas.gameObject.SetActive(active);
}
```
Die HUDManager Klasse hingegen, ist speziell für das HUD zuständig und besitzt Zugriff auf alle Elemente, die sich in ihm befinden. Neben den Methoden zur Aktivierung oder Deaktivierung diverser Anzeigen, können so auch die einzelnen Verwaltungsklassen aufgerufen werden. 

```csharp
public class HUDManager : MonoBehaviour
{
    public Hotbar hotbar;
    public HealthBar healthBar;
    public ManaBar manaBar;
    public MoneyInfo moneyInfo;
    public WaveInfo waveInfo;
    public InteractionHint interactionHint;
    public HelpInfo helpInfo;
   
	...
	
    public void DisplayHotbar(bool active) =>  hotbar.gameObject.SetActive(active);
    public void DisplayHealthBar(bool active) => healthBar.gameObject.SetActive(active);
    public void DisplayManaBar(bool active) => manaBar.gameObject.SetActive(active);
    public void DisplayWaveInfo(bool active) => waveInfo.gameObject.SetActive(active);
    public void DisplayInteractionHint(bool active) => interactionHint.gameObject.SetActive(active);
}
```
### HUD


### Shop
Die *Shop* Klasse wird verwendet, um im Spiel den Shop zu öffnen, zu schließen und die Inhalte semi-dynamisch zu laden. Damit der Shop ordnungsgemäß funktioniert, müssen durch den Editor die verschiedenen Kategorien(*CategoryButton*) und Shop-Seiten(*ShopPage*) erstellt und übergeben werden. Der Nutzer kann so dann später zwischen den Kategorien und den dafür vorgesehen Shop-Seiten navigieren. Dies kann durch die Methode *OnPageSelected* erzielt werden, welche im Editor zwingend vorab an das OnClick-Event des jeweiligen Buttons gebindet werden muss. Die Methode fungiert letztendlich hauptsächlich "Austauschmethode". Sie deaktiviert die zuletzt geöffnete Shop-Seite, wenn bis zu diesem Zeitpunkt schon eine geöffnet wurde und aktiviert die neue Seite basierend auf der gegebenen ID.
```csharp
public void OnPageSelected(int id)
{
	UpdateCategoryHighlight(id);

	if (currentPage != null)
	{
		ShopPage newPage = shopPages[id];
		currentPage.SetActive(false);
		newPage.SetActive(true);
		currentPage = newPage;
		return;
	}

	currentPage = shopPages[id];
	currentPage.SetActive(true);
}
```
Die Klasse ShopPage, welche die einzelnen Seiten verwaltet implementiert die Methode *OnItemSelected*, welche benötigt wird, um die Informationen für das aktuell ausgewählte Item zu aktualisieren. Sie wird aufgerufen, wenn der Nutzer einen Button auf der linken Seite des Shops ausgewählt hat.
```csharp
public class ShopPage : MonoBehaviour
{
	public ItemInfo itemInfo;

	public void OnItemSelected(ShopItem item)
	{
		itemInfo.SetItem(item);
	}
	
	...
}
```
Für das Überschreiben der letzten Informationen ist die Klasse *ItemInfo* mit der Methode *SetItem* zuständig. 
```csharp
public void SetItem(ShopItem shopItem)
{
	gameObject.SetActive(true);
	title.text = shopItem.item.name.ToUpper();
	price.text = "$" + shopItem.price.ToString();
	info.text = shopItem.infoText.ToUpper();
	image.sprite = shopItem.item.icon;
}
```
Die dafür benötigten Parameter bekommt werden durch die Klasse *ShopItem* übergeben, welches eine Referenz du dem jeweiligen Item, den dazugehörigen Preis und einen kurzen Text zur Beschreibung des Items beinhaltet. Die Klasse implementiert außerdem die *OnItemBought* Methode welche aufgerufen wird, wenn der Spieler dieses Item erwerben will. Sie fügt das gewünschte Item letztendlich dem Inventar des Spielers hinzu, zieht ihm den Preis von seinem aktuellen Budget ab und aktualisiert die Statistiken. 
Für das Munitions-Item gibt es für diesen Vorgang noch eine eigene Klasse in welcher diese Methode überschrieben wird, da Munition nicht direkt in einem der [InventorySlot](#InventorySlot)'s gespeichert, sondern einfach nur auf einen Counter addiert wird.
```csharp
[CreateAssetMenu(fileName = "ShopItem", menuName = "Shop/Item")]
public class ShopItem : ScriptableObject
{
	public Item item;
	public string infoText;
	public int price;

	public virtual void OnItemBought()
	{
		Player.instance.inventory.AddItem(item);
		Player.instance.RemoveMoney(price);

		Statistics.instance.AddMoney(price);
	}
}
```
Gegenstände kann der Spieler erwerben, in dem er einen der Buttons auf der linken Seite der jeweiligen Shop-Seite drückt. Durch diese Aktion wird die Methode *OnClick* getriggert, welche dann überprüft, ob der Spieler genug Geld für den Kauf hat, sein Inventar genug Platz bietet oder ob er das Item schon zu oft besitzt. Treffen diese Fälle zu, wird er durch einen kurzen Text unterhalb der Shop-UI informiert. Sollte jedoch keiner dieser Fälle zutreffen, wird der endgültige Kauf durch die Methode *ShopItem.OnItemBought*, welche zuvor schon näher beschrieben wurde, in die Wege geleitet.
```csharp
public void OnClick()
{
	StopAllCoroutines();
	eventText.text = "";
	eventText.color = Color.white;

	FadeIn(eventText, .5f);
	PlayerInventory inventory = Player.instance.inventory;
	if (inventory != null)
	{
		if (Player.instance.CurrentBalance < shopItem.price)
		{
			eventText.text = "Du hast nicht genug Geld!".ToUpper();
			StartCoroutine(HideEventText());
			return;
		}
		if (!(shopItem is Munition))
		{
			if (!inventory.HasItem(shopItem.item) && inventory.FindStackableSlot(shopItem.item) == null && inventory.FindNextEmptySlot() == null)
			{
				eventText.text = "Dein Inventar ist voll!".ToUpper();
				StartCoroutine(HideEventText());
				return;
			}

			if (inventory.HasItem(shopItem.item) && inventory.FindStackableSlot(shopItem.item) == null)
			{
				eventText.text = "Du hast schon zu viele Items dieser Art".ToUpper();
				StartCoroutine(HideEventText());
				return;
			}
		}
		shopItem.OnItemBought();
	}
}

private IEnumerator HideEventText()
{
	yield return new WaitForSeconds(2f);
	FadeOut(eventText, .5f);
	yield return new WaitForSeconds(.5f);
	eventText.text = "";
}
```

## UI
### UIManager und HUDManager
Die Klassen UIManager und HUDManager, sind wie der Name schon sagt ausschließlich für die Verwaltung der verschiedenen UI-Elemente zuständig. Deshalb beinhalten beide Klassen Referenzen zu den jeweiligen Game-Objekten, da die meisten Elemente eigene Verwaltungsklassen besitzen.

Die *UIManager* Klasse hat beispielsweise die Aufgabe die verschiedenen Menüs ein- und auszublenden oder das HUD zu aktivieren/deaktivieren. Außerdem wurde die Klasse als Singelton implementiert, damit ihre Variablen von überall aus erreicht werden können und es garantiert werden kann, dass es immer nur eine Instanz dieser Klasse gibt.
```csharp
public class UIManager : MonoBehaviour
{
    Singelton

    public HUDManager hud;
    public Canvas shopCanvas;
    public Canvas gameOverCanvas;
    public PauseMenu pauseMenu;

	...

    public void SetHUDActive(...) => SetHUDActive(...);
    public void SetShopActive(bool active) => shopCanvas.gameObject.SetActive(active);
    public void SetPauseMenuActive(bool active) => pauseMenu.gameObject.SetActive(active);
    public void SetGameOverMenuActive(bool active) => gameOverCanvas.gameObject.SetActive(active);
}
```
Die HUDManager Klasse hingegen, ist speziell für das HUD zuständig und besitzt Zugriff auf alle Elemente, die sich in ihm befinden. Neben den Methoden zur Aktivierung oder Deaktivierung diverser Anzeigen, können so auch die einzelnen Verwaltungsklassen aufgerufen werden. 

```csharp
public class HUDManager : MonoBehaviour
{
    public Hotbar hotbar;
    public HealthBar healthBar;
    public ManaBar manaBar;
    public MoneyInfo moneyInfo;
    public WaveInfo waveInfo;
    public InteractionHint interactionHint;
    public HelpInfo helpInfo;
   
	...
	
    public void DisplayHotbar(bool active) =>  hotbar.gameObject.SetActive(active);
    public void DisplayHealthBar(bool active) => healthBar.gameObject.SetActive(active);
    public void DisplayManaBar(bool active) => manaBar.gameObject.SetActive(active);
    public void DisplayWaveInfo(bool active) => waveInfo.gameObject.SetActive(active);
    public void DisplayInteractionHint(bool active) => interactionHint.gameObject.SetActive(active);
}
```
### HUD Elemente
Das HUD besteht aus insgesamt 6 Elementen, von denen die meisten durchgehend für den Spieler zu sehen sind. Alle UI-Elemente bzw. deren Verwaltungsklassen können über den *HUDManager* erreicht werden.
#### DamageOverlay Klasse
Die DamageOverlay Klasse wird verwendet, um für einen kurzen Moment ein Overlay anzuzeigen, welches dem Spieler signalisieren soll, dass er von einem gegnerischen Angriff getroffen wurde. Hierfür wird ein vorgefertigtes GameObject durch eine Animation auf der Canvas angezeigt und nach einer bestimmten Zeit wieder ausgeblendet.
```csharp
public class DamageOverlay : MonoBehaviour
{
    public float time = 1f;
    private EntityStats stats;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        stats = Player.instance.stats;
        stats.OnDamaged += OnTakeDamage;
    }
    
    void OnTakeDamage(float damage, Equipment item)
    {
        if (GameState.instance.IsInGame)
        {
            StopAllCoroutines();
            StartCoroutine(ShowDamgeOverlay());
        }
    }
    
    IEnumerator ShowDamgeOverlay()
    {
        animator.SetBool("damage", true);
        yield return new WaitForSeconds(time);
        animator.SetBool("damage", false);
    }
}
```
#### HealthBar und ManaBar Klasse
Die HealthBar zeigt dem Spieler an, wie viele Lebenspunkte er noch besitzt. Hierfür werden die Events OnDamaged und OnHealed abonniert, welche dafür Zuständig sind das Healthbar-Image entsprechend anzuzeigen. Wie in dem Code Beispiel zu sehen ist, erbt die HealthBar Klasse von der *ShrinkBar* Klasse. Diese Klasse implementiert die grundsätzlich notwendigen Funktionen um eine Bar dynamisch zu füllen oder zu verkleinern.
```csharp
public class HealthBar : ShrinkBar
{
    private EntityStats stats;

    void Start()
    {
        stats = Player.instance.stats;
        stats.OnDamaged += OnDamaged;
        stats.OnHealed += OnHealed;
    }

    void OnHealed(float amount)
    {
        SetBarFillAmount(stats.HealthNormalized);
        AlignBars();
    }

    void OnDamaged(float damage, Equipment item)
    {
        ResetShrinkTimer();
        SetBarFillAmount(stats.HealthNormalized);
    }
}

public class ShrinkBar : MonoBehaviour
{
	public Image barImage;
	public Image shrinkBarImage;
	public float maxShrinkTimer = 0.6f;
	private float shrinkTimer;

	void Update()
	{
		shrinkTimer -= Time.deltaTime;
		if (shrinkTimer < 0)
		{
			if (barImage.fillAmount < shrinkBarImage.fillAmount)
			{
				float shrinkSpeed = 1f;
				shrinkBarImage.fillAmount -= shrinkSpeed * Time.deltaTime;
			}
		}
	}
	
	protected void AlignBars()
	{
		shrinkBarImage.fillAmount = barImage.fillAmount;
	}
	
	protected void ResetShrinkTimer()
	{
		shrinkTimer = maxShrinkTimer;
	}

	protected void SetBarFillAmount(float amount)
	{
		barImage.fillAmount = amount;
	}
}
```
Die *ManaBar* Klasse, welche die Ausdauer des Spielers anzeigt, ist im Vergleich zur *HealthBar* so gut wie identisch. Der einzige unterschied liegt darin, dass anstatt den Events der EntityStats Klasse, die Events *OnManaAdded* und *OnManaUsed* der *EntityCombat* Klasse genutzt werden.

#### MoneyInfo Klasse
Die Klasse *MoneyInfo* wird während dem Spiel genutzt, um die Anzeige für das gesammelte Geld zu verwalten. Dies geschieht durch das Abonnieren der *OnMoneyReceived* und *OnMoneySpend*  Events. Damit der Nutzer ein besseres visuelles Feedback bekommt, ob er Geld verdient oder ausgegeben hat, wurden für die jeweiligen Szenarien Prefabs erstellt. Diese besitzen einen Text mit dem jeweiligen Betrag und der entsprechenden Farbe (rot für Verlust, grün für Gewinn), sowie einer Animation die das GameObject ein- und ausblenden lässt.
```csharp
public class MoneyInfo : MonoBehaviour
{
    public GameObject moneyRecived;
    public GameObject moneySpend;
    public float destroyText;
    private Text currentBalanceText;

    void Start()
    {
        currentBalanceText = GetComponent<Text>();
        Player.instance.OnMoneyReceived += OnMoneyReceived;    
        Player.instance.OnMoneySpend += OnMoneySpend;    
    }

    public void OnMoneyReceived(int amount, int currentBalance)
    {
        InstantiateMoneyText(moneyRecived, amount, "+");
        StartCoroutine(MoneyUpdateRoutine(currentBalance, .7f));
    }
    
    public void OnMoneySpend(int amount, int currentBalance)
    {
        InstantiateMoneyText(moneySpend, amount, "-");
        StartCoroutine(MoneyUpdateRoutine(currentBalance, .1f));
    }

    private void InstantiateMoneyText(GameObject gameObject, int amount, string a)
    {
        GameObject popup = Instantiate(gameObject, transform);
        popup.GetComponent<Text>().text = a + amount + "$";
        Destroy(popup, destroyText);
    }

    private IEnumerator MoneyUpdateRoutine(int currentBalance, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        currentBalanceText.text = "$ " + currentBalance;

    }
}
```
#### MunitionInfo Klasse
Die MunitionInfo Klasse, ist teilweise ähnlich strukturiert wie die MoneyInfo Klasse, zeigt jedoch nur den aktuellen Munitionsstand des Spielers ohne weitere Animation oder jeglichem anderen Feedback an.
```csharp
public class MunitionInfo : MonoBehaviour
{
    public Text currentMunition;

    void Start()
    {
        PlayerInventory inventory = Player.instance.inventory;
        inventory.OnMunitionUpdate += OnMunitionUpdate;
    }

    public void OnMunitionUpdate(int currentAmount)
    {
        currentMunition.text = currentAmount.ToString();
    }
}
```
#### WaveInfo Klasse
Die WaveInfo Klasse, wird verwendet um die erspielte Rundenzahl, den Countdown für die nächste Welle und die Skip-Info anzuzeigen. Hierfür wird auf die Events OnWaveStateUpdate und OnWaveCountdownUpdate gehört, welche von der *WaveSpawner* Klasse gefeuert werden. Ersteres der beiden Events, wird genutzt, um die aktuelle Rundenzahl sowie die Skip-Info für den eventuell laufenden Countdown anzuzeigen. Das Event *OnWaveCountdownUpdate* hingegen wird wie der Name schon sagt für die Darstellung des Countdowns genutzt. 
```csharp
public class WaveInfo : MonoBehaviour
{
    public Text stateOfGameText;
    public Text skipCountdownText;

    public Color defaultColor;
    public Color warningColor;
    public float nextRoundWarning;

    void Start()
    {
        WaveSpawner waveSpawner = WaveSpawner.instance;
        if (waveSpawner == null) throw new ArgumentNullException("WaveSpawner class cannot be null!");

        waveSpawner.OnWaveStateUpdate += OnWaveStateUpdate;
        waveSpawner.OnWaveCountdownUpdate += OnWaveCountdownUpdate;
    }

    public void OnWaveStateUpdate(WaveState state, int rounds)
    {
        if (state == WaveState.Counting)
        {
            skipCountdownText.gameObject.SetActive(true);
        }

        if (WaveSpawner.instance.IsWaveRunning)
        {
            skipCountdownText.gameObject.SetActive(false);

            stateOfGameText.color = defaultColor;
            stateOfGameText.text = string.Format("RUNDE {0}", rounds.ToString());
        }
    }

    public void OnWaveCountdownUpdate(float countdown)
    {
        if (countdown <= nextRoundWarning)
        {
            skipCountdownText.gameObject.SetActive(false);
            stateOfGameText.color = warningColor;
        } else
        {
            stateOfGameText.color = defaultColor;
        }

        stateOfGameText.text = string.Format("NÄCHSTE RUNDE IN {0}s", Mathf.Floor(countdown).ToString());
    }
}
```

### Shop
Die *Shop* Klasse wird verwendet, um im Spiel den Shop zu öffnen, zu schließen und die Inhalte semi-dynamisch zu laden. Damit der Shop ordnungsgemäß funktioniert, müssen durch den Editor die verschiedenen Kategorien(*CategoryButton*) und Shop-Seiten(*ShopPage*) erstellt und übergeben werden. Der Nutzer kann so dann später zwischen den Kategorien und den dafür vorgesehen Shop-Seiten navigieren. Dies kann durch die Methode *OnPageSelected* erzielt werden, welche im Editor zwingend vorab an das OnClick-Event des jeweiligen Buttons gebindet werden muss. Die Methode fungiert letztendlich hauptsächlich "Austauschmethode". Sie deaktiviert die zuletzt geöffnete Shop-Seite, wenn bis zu diesem Zeitpunkt schon eine geöffnet wurde und aktiviert die neue Seite basierend auf der gegebenen ID.
```csharp
public void OnPageSelected(int id)
{
	UpdateCategoryHighlight(id);

	if (currentPage != null)
	{
		ShopPage newPage = shopPages[id];
		currentPage.SetActive(false);
		newPage.SetActive(true);
		currentPage = newPage;
		return;
	}

	currentPage = shopPages[id];
	currentPage.SetActive(true);
}
```
Die Klasse ShopPage, welche die einzelnen Seiten verwaltet implementiert die Methode *OnItemSelected*, welche benötigt wird, um die Informationen für das aktuell ausgewählte Item zu aktualisieren. Sie wird aufgerufen, wenn der Nutzer einen Button auf der linken Seite des Shops ausgewählt hat.
```csharp
public class ShopPage : MonoBehaviour
{
	public ItemInfo itemInfo;

	public void OnItemSelected(ShopItem item)
	{
		itemInfo.SetItem(item);
	}
	
	...
}
```
Für das Überschreiben der letzten Informationen ist die Klasse *ItemInfo* mit der Methode *SetItem* zuständig. 
```csharp
public void SetItem(ShopItem shopItem)
{
	gameObject.SetActive(true);
	title.text = shopItem.item.name.ToUpper();
	price.text = "$" + shopItem.price.ToString();
	info.text = shopItem.infoText.ToUpper();
	image.sprite = shopItem.item.icon;
}
```
Die dafür benötigten Parameter bekommt werden durch die Klasse *ShopItem* übergeben, welches eine Referenz du dem jeweiligen Item, den dazugehörigen Preis und einen kurzen Text zur Beschreibung des Items beinhaltet. Die Klasse implementiert außerdem die *OnItemBought* Methode welche aufgerufen wird, wenn der Spieler dieses Item erwerben will. Sie fügt das gewünschte Item letztendlich dem Inventar des Spielers hinzu, zieht ihm den Preis von seinem aktuellen Budget ab und aktualisiert die Statistiken. 
Für das Munitions-Item gibt es für diesen Vorgang noch eine eigene Klasse in welcher diese Methode überschrieben wird, da Munition nicht direkt in einem der [InventorySlot](#InventorySlot)'s gespeichert, sondern einfach nur auf einen Counter addiert wird.
```csharp
[CreateAssetMenu(fileName = "ShopItem", menuName = "Shop/Item")]
public class ShopItem : ScriptableObject
{
	public Item item;
	public string infoText;
	public int price;

	public virtual void OnItemBought()
	{
		Player.instance.inventory.AddItem(item);
		Player.instance.RemoveMoney(price);

		Statistics.instance.AddMoney(price);
	}
}
```
Gegenstände kann der Spieler erwerben, in dem er einen der Buttons auf der linken Seite der jeweiligen Shop-Seite drückt. Durch diese Aktion wird die Methode *OnClick* getriggert, welche dann überprüft, ob der Spieler genug Geld für den Kauf hat, sein Inventar genug Platz bietet oder ob er das Item schon zu oft besitzt. Treffen diese Fälle zu, wird er durch einen kurzen Text unterhalb der Shop-UI informiert. Sollte jedoch keiner dieser Fälle zutreffen, wird der endgültige Kauf durch die Methode *ShopItem.OnItemBought*, welche zuvor schon näher beschrieben wurde, in die Wege geleitet.
```csharp
public void OnClick()
{
	StopAllCoroutines();
	eventText.text = "";
	eventText.color = Color.white;

	FadeIn(eventText, .5f);
	PlayerInventory inventory = Player.instance.inventory;
	if (inventory != null)
	{
		if (Player.instance.CurrentBalance < shopItem.price)
		{
			eventText.text = "Du hast nicht genug Geld!".ToUpper();
			StartCoroutine(HideEventText());
			return;
		}
		if (!(shopItem is Munition))
		{
			if (!inventory.HasItem(shopItem.item) && inventory.FindStackableSlot(shopItem.item) == null && inventory.FindNextEmptySlot() == null)
			{
				eventText.text = "Dein Inventar ist voll!".ToUpper();
				StartCoroutine(HideEventText());
				return;
			}

			if (inventory.HasItem(shopItem.item) && inventory.FindStackableSlot(shopItem.item) == null)
			{
				eventText.text = "Du hast schon zu viele Items dieser Art".ToUpper();
				StartCoroutine(HideEventText());
				return;
			}
		}
		shopItem.OnItemBought();
	}
}

private IEnumerator HideEventText()
{
	yield return new WaitForSeconds(2f);
	FadeOut(eventText, .5f);
	yield return new WaitForSeconds(.5f);
	eventText.text = "";
}
```

### Hotbar
Die Hotbar Klasse wird verwendet, um dem Spieler unter anderem visuell darzustellen, welche Items er besitzt und welchen er davon zurzeit ausgerüstet hat. Die Items werden wie im Inventar durch einzelne Slots verwaltet. Diese Hotbarslots werden  durch die Events *OnItemAdded* und *OnItemRemoved* aus der PlayerInventory Klasse aktuell gehalten.

Damit dieses Verhalten realisiert werden konnte, besitzt die*HotbarSlot* Klasse, die Methoden *Add* und *Clear*.  Die Add Methode dient ausschließlich dazu, zu Beginn ein Item dem Slot hinzuzufügen. Durch das hinzufügen, wird das Icon des Slots, der Stackcount sowie die Haltbarkeit angezeigt. Die zuvor angesprochene Haltbarkeit wird durch das Event OnDurationUpdate der [Equipment](#Equipment) Klasse aktuell gehalten. Damit der Slot für neue Items freigegeben werden kann, muss zuvor die Methode *Clear* aufgerufen worden sein.
```csharp

public class HotbarSlot : MonoBehaviour
{
    public Image background;
    public Sprite selectedSprite;
    public Sprite defaultSprite;

    public Equipment item;
    public Image icon;
    public Sprite iconPlaceholder;
    public Text count;
    public GameObject durationPanel;
    public Image durationImage;

    public void Add(Equipment item)
    {
        this.item = item;

        icon.sprite = item.icon;
        icon.color = Color.white;
        icon.enabled = true;

        if (item.isStackable)
        {
            count.gameObject.SetActive(true);
            count.text = item.slot.Count.ToString();
        }

        if (item.hasDuration)
        {
            durationPanel.SetActive(true);
            durationImage.fillAmount = 1;
            item.OnDurationUpdate += OnDurationUpdate;
        }
    }
    
    public void Clear()
    {
        ...
    }
    
    public void UpdateCount(int currenCount) => count.text = currenCount.ToString();
    
    public void OnDurationUpdate(float normalizedDuration) => durationImage.fillAmount = normalizedDuration;
}

```

Um der Hotbar neue Gegenstände hinzuzufügen, wird die Methode *OnItemAdded* genutzt, welche automatisch aufgerufen wird, wenn das Event *PlayerInventory.OnItemAdded* gefeuert wurde. Diese Methode sucht dann für das neue Item einen Slot, in welchem sich schon Items vom gleichen Typ befinden. Sollte hierbei jedoch kein *HotbarSlot* gefunden werden, wird versucht einen noch nicht befüllten zu finden. Nur wenn letztendlich auch ein HotbarSlot gefunden wurde, wird der Gegenstand diesem hinzugefügt. 
```csharp

    private void OnItemAdded(Item item)
    {
        HotbarSlot slot = FindHotbarSlot(item);
        if (slot == null) slot = FindEmptyHotbarSlot();

        if (slot != null && item is Equipment)
        {
            slot.Add(item as Equipment);
        }
    }
    
	private HotbarSlot FindHotbarSlot(Item item)
    {
        foreach (HotbarSlot slot in slots)
        {
            if (slot.item != null && slot.item.name == item.name) return slot;
        }
        return null;
    }

    private HotbarSlot FindEmptyHotbarSlot()
    {
        foreach (HotbarSlot slot in slots) if (slot.item == null) return slot;
        return null;
    }
	
```
Damit auch Items aus der Hotbar entfernt werden können, wird die Methode *OnItemRemoved* genutzt, welche durch das gleichnamige Event aufgerufen wird.  Sie versucht das Item in der Hotbar zu finden und zuerst den Stack-Count zu aktualisieren. Sollte der Spieler keinen Gegenstand von dem jeweiligen Itemtyp besitzen, wird er vollständig aus der Hotbar verschwinden. Danach wird automatisch die gesamte Hotbar durch die *UpdateItems* Methode geleert und anschließend wieder befüllt um zwischen drin leere Hotbarslots zu vermeiden.
```csharp
    
    private void OnItemRemoved(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i == item.slot.Id)
            {
                int itemCount = item.slot.Count;
                slots[i].UpdateCount(itemCount);

                if (itemCount == 0)
                {
                    slots[i].Clear();
                    UpdateItems();
                    SelectLastItem();
                }

                if (itemCount > 0) SelectItem(currentItemIndex);
                break;
            }
        }
    }

    private void UpdateItems()
    {
        for (int i = 0; i < slots.Length; i++) slots[i].Clear();

        List<InventorySlot> inventorySlots = new List<InventorySlot>(inventory.Slots);
        inventorySlots.RemoveAll(slot => slot.Count == 0);

        for (int i = 0; i < slots.Length; i++)
        {
            if (List.InBounds(i, inventorySlots.Count))
            {
                Item item = inventorySlots[i].FirstItem;
                if (item != null && item is Equipment)
                {
                    slots[i].Add(item as Equipment);
                }
            }
        }
    }
    
```

## AudioManager Klasse
Die *AudioManager* Klasse wird genutzt, um verschiedene vorab definierte Sounds abzuspielen. Hierfür wird die Methode *PlaySound* genutzt. Diese überladene Methode kann entweder einen Sound an einer Stelle oder allgemein abspielen. Dies ist notwendig, damit beispielsweise der Bewegungs-Sound oder der Sound für eine erfolgreiche Attacke nicht zu monoton wirken, sondern sich dynamisch an die Szene anpassen. 

Wie schon erwähnt, wurden alle Sounds vorab definiert und in der Klasse als ein *SoundClip*-Array gespeichert. Die Klasse *SoundClip* ist nur als allgemeiner Speicherort für einen Sound genutzt und beinhaltet verschiedene Konfigurationsparameter, sowie die eigentliche AudioSource und den dazugehörigen Sound. Des Weiteren kann auch der Parameter *maxTimer* gesetzt werden, welcher später genutzt wird um zu überprüfen, ob der Sound erneut abgespielt werden kann oder nicht. Dies soll verhindern das *Sounds* doppelt oder zu schnell wieder abgespielt werden.
```csharp
[System.Serializable]
public class SoundClip
{
    public Sound sound;
    public AudioClip clip;
    public float maxTimer;

    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop;

    [Range(0, 1)]
    public float spatialBlend = 1f;
    public float maxDistance = 100f;
}
```

Um  den Effekt zu erreichen, dass der Sound an einer speziellen Position abgespielt wird, gibt es die *PlaySound* Methode mit den Parametertypen *Sound* und *Vector3*. Sie erstellt ein GameObject an der gegebenen Position und fügt diesem die *AudioSource* Komponente hinzu.  Danach wird der richtige *SoundClip* anhand des gegebenen *Sound*'s ermittelt und dem *AudioSource* Script mithilfe der Methode *SetAudioSourceConfig* übergeben. Das erzeugte GameObject wird automatisch zerstört, wenn der *AudioClip* zu Ende gespielt wurde.
```csharp
public void PlaySound(Sound sound, Vector3 position)
{
	if (CanPlay(sound))
	{
		GameObject soundGameObject = new GameObject("Sound");
		soundGameObject.transform.position = position;

		AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
		SoundClip soundClip = GetSoundClip(sound);

		SetAudioSourceConfig(audioSource, soundClip);
		audioSource.Play();

		Destroy(soundGameObject, audioSource.clip.length);
	}
}
```
Die zweite Methode nimmt nur einen *Sound* als Übergabeparameter entgegen. Sie unterscheidet sich zu ersten Methode nur dadurch, dass ein allgemeines GameObject ohne Position verwendet wurde.
```csharp
public void PlaySound(Sound sound)
{
	if (CanPlay(sound))
	{
		if (oneShotGameObject == null)
		{
			oneShotGameObject = new GameObject("One Shot Sound");
			oneShotAudioSource = oneShotGameObject.AddComponent<AudioSource>();
		}
		SoundClip soundClip = GetSoundClip(sound);
		SetAudioSourceConfig(oneShotAudioSource, soundClip);
		oneShotAudioSource.PlayOneShot(oneShotAudioSource.clip);
	}
}
```
Bevor jedoch die zuvor beschrieben Vorgänge durchgeführt werden können, wird überprüft, ob der Sound aktuell überhaupt abgespielt werden kann. Hierfür wird die Variable *maxTimer* aus der SoundClip Klasse verwendet. Mithilfe dieser Zahl wird geschaut, wie lange es her ist das der Sound abgespielt wurde und ob es jetzt wieder möglich ist. Sollte diese der Fall sein, wird der aktuelle Zeitstempel in Verbindung mit dem jeweiligen Sound dem soundTimer Dictionary hinzugefügt und der AudioClip abgespielt. Sollte der zu überprüfende Sound vorab nicht in dem *soundTimer* Dictionary hinzugefügt worden sein, wird der Überprüfungsvorgang übersprungen.
```csharp
private Dictionary<Sound, float> soundTimer;

void Start()
{
	soundTimer = new Dictionary<Sound, float>();
	soundTimer[Sound.PlayerMove] = 0f;
}

...

private bool CanPlay(Sound sound)
{
	foreach (KeyValuePair<Sound, float> soundTime in soundTimer)
	{
		if (soundTime.Key == sound)
		{
			float lastTimePlayed = soundTimer[sound];
			float maxTimer = GetSoundClip(sound).maxTimer;
			                 
			if (lastTimePlayed + maxTimer < Time.time)
			{
				soundTimer[sound] = Time.time;
				return true;
			}
			return false;
		}
	}
	return true;
}
```
In den vorherigen Methoden wurden unter anderem die Funktionen *SetAudioSourceConfig* und *GetSoundClip* genutzt, welche nun für ein besseres Verständnis aufgezeigt werden.
```csharp
private void SetAudioSourceConfig(AudioSource audioSource, SoundClip soundClip)
{
	audioSource.clip = soundClip.clip;
	audioSource.volume = soundClip.volume;
	audioSource.maxDistance = soundClip.maxDistance;
	audioSource.spatialBlend = soundClip.spatialBlend;
	audioSource.rolloffMode = AudioRolloffMode.Linear;
	audioSource.dopplerLevel = 0f;
}

private SoundClip GetSoundClip(Sound sound)
{
	foreach (SoundClip soundClip in soundClips)
	{
		if (soundClip.sound == sound)
		{
			return soundClip;
		}
	}

	return null;
}
```

## Statistics Klasse
Die Statistics hat den Zweck, während des gesamten Spiels verschiedene Aktionen und Erfolge des Spielers zu speichern, damit diese am Ende des Spiels, wenn der Nutzer sterben sollte angezeigt werden können. Gespeichert werden die überlebten Runden, die Kill's, der Schaden, den der Spieler verursacht und das Geld das er beim Barkeeper ausgegeben hat. Damit die Klasse nur einmalig initialisiert werden kann, wurde auch hier ein Singelton-Mechanismus implementiert. So kann die Klasse außerdem von jeglichen anderen Scripten und Klassen verwendet werden.
```csharp
public class Statistics : MonoBehaviour
{
    Singelton
    
    public int SurvivedRounds { get; protected set; }
    public int Kills { get; protected set; }
    public float DamageCaused { get; protected set; }
    public int SpendMoney { get; protected set; }

    public void AddRound() => SurvivedRounds++;
    public void AddKill() => Kills++;
    public void AddDamage(float damage) => DamageCaused += damage;
    public void AddMoney(int amount) => SpendMoney += amount;
}
```

