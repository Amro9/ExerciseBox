>**Note 07.08.24:**
in diesem Projekt wurden folgende Techniken und Best Practices verwendet:
Clean Architecture, DI, Repository Pattern, CQRS, MediatR
Die Dokumentationen sind aktuell in Bearbeitung
Unit Tests werden zum Üben geschrieben


> **Note 03.07.24:**
folgende Dokumentationen folgen demnächst:
"Wie kann ich mich in den Code einarbeiten? Codestruktur einfach verstehen"
"Allgemeine Dokumentation - die relevanten Informationen aus dem Projekthandbuch"

> **Note 06.08.24:**
update: 

# Einleitung
Hallo, wir sind Thomas und Amro. Bei diesem Projekt handelt es sich um ExercisesBox, ein Tool, das Lehrern ermöglicht, Prüfungsfragen manuell zu erstellen, zu verwalten und daraus automatisiert Arbeitsblätter zu generieren. Nachdem unser Informatiklehrer in der Berufsschule Interesse als Nutzer gezeigt hat, wird das Projekt zukünftig von potenziellen Schülern im nächsten Schuljahr übernommen und an seine Anforderungen angepasst. Für dieses Projekt haben wir die Note 1,0 erhalten.

# Worum geht es hier?
Das Ziel von ExercisesBox ist es, Lehrkräften die Arbeit zu erleichtern, indem sie Fragen und Übungen in einem zentralen System speichern und organisieren können. Mithilfe von Funktionen wie dem Fragenpool, der zufälligen Auswahl von Fragen und der Erstellung von Arbeitsblättern soll der Unterricht effizienter gestaltet werden.

# Prerequisites
## Systemanforderungen
### Backend
Das Backend ist in C# ASP.NET 8 implementiert.

Datenbank: Die Datenbank wurde exportiert und kann in SQL Server Management Studio (SSMS) samt Testdaten importiert werden. Dazu einfach auf "Databases" rechts klicken und "Import Data-Tier Application" auswählen, um den Import zu starten.
### Frontend
Node.js (Version 16.x oder höher)
Angular CLI (Version 14.x oder höher)

# Wie starte ich das Programm?
Datenbank importieren: Importiere die Datenbank wie oben beschrieben.
Backend starten: Navigiere in das Verzeichnis exerciseBox.Rest und starte den Server.
Frontend starten:
Navigiere in Visual Studio Code in das Verzeichnis exerciseBox.Web.
Installiere die Abhängigkeiten mit npm install.
Starte den Angular-Entwicklungsserver mit ng serve.
Website aufrufen: Die Anwendung ist nun unter http://localhost:4200 erreichbar und kann mit dem Server kommunizieren.
Testanmeldedaten: Verwende die Testanmeldedaten te@st.com, um dich anzumelden.
Software Architektur
ExercisesBox folgt einer klassischen Client-Server-Architektur. Das Projekt ist in zwei Hauptkomponenten unterteilt:

Frontend (Angular): Das Frontend ist in Angular implementiert und sorgt für die Benutzeroberfläche und die Interaktion mit dem Backend.
Backend (ASP.NET 8): Das Backend stellt die REST-API-Endpunkte zur Verfügung, verwaltet die Datenbankoperationen und enthält Services wie die Sessionserstellung und den ExerciseSheetGenerator.
# Welche Kenntnisse muss ich mitbringen, um am Code zu arbeiten?
Backend:
Clean Architecture: Die Kernidee ist, dass die Business-Logik unabhängig von externen Abhängigkeiten ist. Der Kern der Anwendung (Business-Logik und Core) ist nicht direkt von der Datenbank oder externen APIs abhängig. Stattdessen definieren wir Interfaces im Kern der Anwendung, die dann in den entsprechenden Datenbankprojekten implementiert werden.

Repository Pattern: Für die Kommunikation mit dem DbContext wurden Repositories erstellt, die das Interface IRepository implementieren. Dies fördert die Trennung der Anwendungsschichten und ermöglicht eine klare, strukturierte Kommunikation mit der Datenbank.

CQRS (Command Query Responsibility Segregation): CQRS trennt die Lese- und Schreiboperationen, was die Codeverständlichkeit und Wartbarkeit fördert.

MediatR: MediatR fungiert als Schnittstelle zwischen den Schichten der Anwendung. Anstatt dass der Controller direkt die Repositories aufruft, übergibt er die Aufgabe an den MediatR. Dieser weiß, welche Aufrufe erforderlich sind, um die benötigten Daten zu beschaffen und vereinfacht so die Logik im Controller.

Use Cases: Die Anwendung ist in verschiedene Use Cases unterteilt, die jeweils spezifische Anwendungsfälle abbilden. Ein Use Case könnte beispielsweise das Erstellen einer neuen Frage oder das Abrufen aller Fragen sein. Innerhalb jedes Use Cases wird die CQRS-Trennung eingehalten und der MediatR verwendet.
