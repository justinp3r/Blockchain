# Blockchain

Die Funktion dieses Ansatzes ist folgende:
-Die Implementierung der Blockchain selbst erfolgt mittels einer simplen Liste
-Dieser werden Objekte des Typs Block hinzugefügt
-Klasse Block besitzt Eigenschaften zum speichern der ID, Zeit, usw...

Der Ablauf:
-Es wird die Liste deklariert und der erste Block (Genesisblock) hinzugefügt
-Bei für das erstellen der Blöcke wird eine Forloop verwendet
-Es wird der zul. hinzugefügte Block als [current block] deklariert
-Mit dessen Daten als Parameter wird ein neuer Block erstellt (generate_Block)
-Der neue Block erhält den Hash des alten und erstellt einen eigenen neuen


