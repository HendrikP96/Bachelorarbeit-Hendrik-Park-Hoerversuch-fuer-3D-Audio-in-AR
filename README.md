# Analyse der Lokalisationsfähigkeit und des Darbietungsempfinden des Menschen für 3D-Audio in einer Mixed Reality Umgebung
Bachelorarbeit von Hendrik Park

In diesem Repository finden Sie die Assets der Applikation für den Hendrik Park durchgeführten Hörversuch in einer Mixed Reality Umgebung. 

Im Rahmen der Bachelorarbeit wurde ein Hörversuch mit Unity3D Version 2018.3.0f2 entwickelt, bei dem Probanden audiovisuelle Inhalte lokalisieren und anhand bestimmter Kriterien bewerten sollten. 
Der Fokus lag hierbei darauf die von Microsoft erstellten 3D-Audio-Tools zu verwenden und so eine Auralisation mit den Hörereignissen durchzuführen. 

In diesem Repository werden die benötigten Assets zur Erstellung der App verwaltet. 

Zur eigenen Erstellung der App in Unity folgen Sie bitte den folgenden Anweisungen:

1. Unity und Visual Studio 2017 Installieren
2. Unity Projekt mit Namen "BA_Hendrik_Park"erstellen 
3. Assets aus dem Repository in das Project-Window importieren (Drag and Drop)
4. Szene "Main" im "Scenes" Ordner laden
5. File -> Build Settings öffnen und Universal Windows Platform auswählen

6. Player Settings... drücken
Other Settings -> Configuration -> Scripting Backend -> .NET
XR Settings -> Virtual Realy Supported aktivieren

- Add Open Scene drücken 
- Folgende Parameter anpassen:
Target Device -> HoloLens
Architecture -> x86
Build Type -> D3D
Build and Run on -> Local Machine
Build configuration -> Release

Unity c# Projects -> aktivieren
Development Build -> aktivieren

--> Switch Platform 

7. Window -> Package Manager -> Windows Mixed Reality installieren
8. Edit -> Project Settings 
- Parameter anpassen:
-> Audio:
System Sample Rate -> 48000
Spatializer Plugin -> MS HRTF Spatializer
-> Quality:
- Ganz oben bei Default für Universal Windows Platform(UWP) "Quality" auf "Very Low" festlegen

9. Build Settings -> Build -> Ordner erstellen, den Ordner "App" benennen und Ordner auswählen drücken
10. Im "App"-Ordner BA_Hendrik_Park.sln starten
11. Einstellung neben Play-Button anpassen:
- "Debug" auf "Release" ändern
- "ARM" auf "x86" ändern 
- Neben "Start" auf den Pfeil drücken und "Remotecomputer" auswählen
- Bei Adresse die IP-Adresse der HoloLens auswählen (In den Einstellungen auf der HoloLens zu finden) und bestätigen
12. HoloLens aktivieren 
13. Build starten 







