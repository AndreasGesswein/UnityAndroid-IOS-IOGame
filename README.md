(Mit C# Visualstudio programmiert)

Aktueller Stand des Unity Spiels:

Alle wichtigen Daten werden mit Json binär verschlüsselt bzw. gespeichert!!!

Werbung:
![Screenshot (246)](https://user-images.githubusercontent.com/50133435/171042733-f04a8301-7a6e-4b95-9feb-894cc9193584.png)
![Screenshot (245)](https://user-images.githubusercontent.com/50133435/171043037-6e8684fd-9678-4dd1-9f26-6898627276f5.png)



Highscore(Sortieren, Hinzufügen bzw. Löschen):
(passiert alles automatisch nach dem man gestorben ist)
![Screenshot (247)](https://user-images.githubusercontent.com/50133435/171044220-140a031e-cbdb-45fc-8e84-3036ba2bbbc6.png)


Das Spiel selbst:
1. Enthält Npc's welche die gleichen Funktionen erledigen wie der Spieler selbst.
2. Minimap mit aktuellem Standort
3. Oben Links: Anzeige der vorhandenen Munition etc
![Screenshot (248)](https://user-images.githubusercontent.com/50133435/171045332-5c9c4ffe-bc8a-4806-9057-c6f6d059a332.png)

4. Level Funktion: Objekte verleihen bei Zerstörung Xp/highscore, mit diesen kann man seine Basiswerte(Schild,Dmg, Treibstoff) vergrößern. 
![Screenshot (250)](https://user-images.githubusercontent.com/50133435/171047819-8e98552c-0212-43e2-98ec-f90ff7b6b6a8.png)


5. Bei berührung mit den Objekten: Umwandlung von Objekt(Farben abhängig) in Munition, Schild, Treibstoff oder der spezialfähigkeit(Modifier).

VOR der Berührung mit dem MunitionsObjekt und dem Upgrade:
![Screenshot (253)](https://user-images.githubusercontent.com/50133435/171048685-1f932772-a78b-47bc-8ac5-daeccf2f7154.png)
NACHHER:
![Screenshot (254)](https://user-images.githubusercontent.com/50133435/171048762-3d673422-6132-4d35-8146-c6ddd00fbb43.png)

6. Eigener Name darf natürlich nicht Fehlen:
![Screenshot (255)](https://user-images.githubusercontent.com/50133435/171049738-c180c2df-ea02-410d-9d50-5ae2eadeba92.png)
![Screenshot (260)](https://user-images.githubusercontent.com/50133435/171050500-f73f1244-6dea-4988-858d-0d160523e96e.png)

7. Die map Objekte werden nach verschiedenen Mustern generiert, genauso wie der Nps Name, oder die Route die er einnimmt wenn der Spieler nicht in sicht ist. Der nps entscheidet nach bedarf ob er aufstocken oder Flüchten muss, ob er bereit ist den spieler Anzugreifen oder nicht
