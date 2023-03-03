# Blockchain

Die Funktionsweise: 
Die Implementierung der Blockchain erfolgt mittels einer einfachen Liste, welche durch Objekte des Typs Block ergänzt wird. Die Klasse Block besitzt dabei Eigenschaften zur Speicherung von ID, Zeitstempel und ähnlichen Informationen.

Der Ablauf:
Im Ablauf der Implementierung wird zunächst die Liste deklariert und der erste Block, auch bekannt als Genesisblock, hinzugefügt. Bei der Erstellung der weiteren Blöcke wird eine For-Schleife verwendet. Der zuletzt hinzugefügte Block wird als "current block" deklariert und dessen Daten werden als Parameter für die Erstellung eines neuen Blocks (generate_Block) verwendet. Dabei erhält der neue Block den Hash-Wert des alten Blocks und erstellt einen neuen eigenen Hash-Wert.
