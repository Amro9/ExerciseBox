>**Note 07.08.24:**
in diesem Projekt wurden folgende Techniken und Best Practices verwendet:
Clean Architecture, DI, Repository Pattern, CQRS, MediatR.
>Das Projekt wurde ausführlich dokumentiert.


# Einleitung
Hallo, wir sind Thomas und Amro. Bei diesem Projekt handelt es sich um ExercisesBox, ein Tool, das Lehrern ermöglicht, Prüfungsfragen zu posten, zu speichern und daraus PDF-Arbeitsblätter zu generieren.
Das Projekt richtet sich an Schulen und soll den Lehrkräften eine einfache Möglichkeit bieten, angepasste Übungsblätter für ihre Schüler zu erstellen. Diese README-Datei bietet eine Übersicht über das Projekt und liefert die wichtigsten Informationen für die Weiterentwicklung.
Nachdem unser Informatiklehrer in der Berufsschule Interesse als Anwender gezeigt hat, wird das Projekt zukünftig von potenziellen Schülern im nächsten Schuljahr übernommen und an seine Anforderungen angepasst. Für dieses Projekt haben wir die Note 1,0 erhalten.

# Prerequisites
### Backend
Das Backend ist in C# ASP.NET 8 implementiert.
Datenbank: Die Datenbank wurde exportiert und kann in SQL Server Management Studio (SSMS) samt Testdaten importiert werden. Dazu im SSMS links auf "Databases" rechts klicken und "Import Data-Tier Application" auswählen, um den Import zu starten. Die Datei ist im Ordner .Database
### Frontend
Node.js (Version 16.x oder höher)
Angular CLI (Version 14.x oder höher)

# Wie starte ich das Programm?
### Datenbank importieren:
Importiere die Datenbank wie oben beschrieben.
### Backend starten:
Navigiere in das Verzeichnis exerciseBox.Rest und starte den Server.
### Frontend starten:
Navigiere in Visual Studio Code in das Verzeichnis exerciseBox.Web.
Installiere die Abhängigkeiten mit dem Befehl npm install.
Starte den Angular-Entwicklungsserver mit ng serve.
Website aufrufen: Die Anwendung ist nun unter http://localhost:4200 erreichbar und kann mit dem Server kommunizieren.
Testanmeldedaten: Verwende die Testanmeldedaten te@st.com mit dem Passwort 123, um dich anzumelden. Wenn dies Fehlschlägt, kannst du in der DB einen User erstellen und ein RSA verschlüsseltes Passwort speichern.
### Software Architektur
ExercisesBox folgt einer klassischen Client-Server-Architektur. Das Projekt ist in zwei Hauptkomponenten unterteilt:

Frontend (Angular): Das Frontend ist in Angular implementiert und sorgt für die Benutzeroberfläche und die Interaktion mit dem Backend.
Backend (ASP.NET 8): Das Backend stellt die REST-API-Endpunkte zur Verfügung, verwaltet die Datenbankoperationen und enthält Services wie die Sessionserstellung und den ExerciseSheetGenerator.

# Welche Kenntnisse muss ich mitbringen, um am Code zu arbeiten?
Backend:
Clean Architecture: Die Kernidee ist, dass die Business-Logik unabhängig von externen Abhängigkeiten ist. Der Kern der Anwendung (Business-Logik und Core) ist nicht direkt von der Datenbank oder externen APIs abhängig. Stattdessen definieren wir Interfaces im Kern der Anwendung, die dann in den entsprechenden Datenbankprojekten implementiert werden.

Repository Pattern: Für die Kommunikation mit dem DbContext wurden Repositories erstellt, die das Interface IRepository implementieren. Dies fördert die Trennung der Anwendungsschichten und ermöglicht eine klare, strukturierte Kommunikation mit der Datenbank.

CQRS (Command Query Responsibility Segregation): CQRS trennt die Lese- und Schreiboperationen, was die Codeverständlichkeit und Wartbarkeit fördert.

MediatR: MediatR fungiert als Schnittstelle zwischen den Schichten der Anwendung. Anstatt dass der Controller direkt die Repositories der Datenbank aufruft, übergibt er die Aufgabe an den MediatR. Dieser weiß, welche Aufrufe erforderlich sind, um die benötigten Daten zu beschaffen und vereinfacht so die Logik im Controller.

Use Cases: Die Anwendung ist in verschiedene Use Cases unterteilt, die jeweils spezifische Anwendungsfälle abbilden. Ein Use Case könnte beispielsweise das Erstellen einer neuen Frage oder das Abrufen aller Fragen sein. Innerhalb jedes Use Cases wird die CQRS-Trennung eingehalten und der MediatR verwendet.

> [!TIP]
> Bevor du im Internet nach den Begriffen suchst, liest die Technische Dokumentation im exerciseBox.documentations. Diese bietet allgemeine Einführung in das Technische-Know-How
----
## Wie kann ich mich in den Code einarbeiten? Codestruktur einfach verstehen

Um die Codestruktur von **ExercisesBox** besser zu verstehen, schauen wir uns den Workflow eines typischen Use Cases an: Das Abrufen einer Schule anhand ihrer unique E-Mail-Adresse (Id). Dieser Workflow zeigt, wie der Controller, MediatR, Handler und das Repository zusammenarbeiten, um eine Datenbankabfrage durchzuführen, ohne dass der Controller direkt mit der Datenquelle interagiert.

### 1. Der Controller-Aufruf

Der Einstiegspunkt ist die Methode im Controller, die auf einen HTTP-GET-Request reagiert. Diese Methode ruft den MediatR auf, um die benötigten Daten abzurufen:

```csharp

[HttpGet("School/{email}")]
public async Task<SchoolDto> GetSchoolByEmail(string email)
{
    try
    {
        return await _mediator.Send(new GetSchoolById { Email = email });
    }
    catch (Exception ex)
    {
        return null;
    }
}
```

Hier sehen wir, dass der Controller eine Anfrage an den MediatR sendet und ein GetSchoolById-Objekt mit der E-Mail-Adresse der Schule übergibt. Der Controller muss dabei nicht wissen, wie oder woher die Daten stammen – er delegiert diese Aufgabe vollständig an den MediatR.
## 2. Der Request und Handler
Für JEDEN Request, den der MediatR empfängt, gibt es einen EIGENEN entsprechenden Handler. Der GetSchoolByIdHandler ist für die Verarbeitung des Requests "GetSchoolById" zuständig:
```csharp
public class GetSchoolByIdHandler : IRequestHandler<GetSchoolById, SchoolDto>
{
    private readonly ISchoolRepository _schoolRepository;

    public GetSchoolByIdHandler(ISchoolRepository schoolRepository)
    {
        _schoolRepository = schoolRepository;
    }

    public async Task<SchoolDto> Handle(GetSchoolById request, CancellationToken cancellationToken)
    {
        var school = await _schoolRepository.ReadByIdAsync(request.Email);
        return school;
    }
}
```
Der GetSchoolByIdHandler nimmt den Request entgegen, der die E-Mail der Schule enthält, und verwendet das Repository, um die entsprechenden Daten aus der Datenbank abzurufen. Der Handler ist dafür verantwortlich, die Datenbankoperation auszuführen und das Ergebnis an den MediatR zurückzugeben, der es dann dem Controller liefert.

## 3. Der Datenbankzugriff im Repository
Die eigentliche Datenbankoperation findet im Repository statt. Hier wird die Datenbank abgefragt, um die Schule anhand der E-Mail-Adresse zu finden:
```csharp
public async Task<Schools> ReadByIdAsync(string email)
{
    return await _context.Schools
                         .Include(x => x.SchoolTypeNavigation)
                         .FirstOrDefaultAsync(x => x.Email == email);
}
```
Das Repository ist dafür zuständig, die Datenbankoperationen auszuführen. Es stellt sicher, dass die Datenbankzugriffe sauber und konsistent gehandhabt werden.

Zusammenfassung des Workflows
Controller: Nimmt den HTTP-Request entgegen und sendet einen Request an den MediatR.
MediatR: Leitet den Request an den entsprechenden Handler weiter.
Handler: Verarbeitet den Request, indem er das Repository verwendet, um die Datenbankabfrage auszuführen.
Repository: Führt die eigentliche Datenbankabfrage durch und gibt das Ergebnis zurück.
Nach diesem Schema funktionieren die Datenbankabrufe, wenn dies verstanden hast, kannst du dich ziemlich schnell in den Code einarbeiten.

----
Was ist verbesserungsbedürftig in unserem Code?
> [!WARNING]
> Am Anfang konnten wir uns nicht einigen ob das Projekt "ExercisesBox" oder "ExerciseBox" heißen soll. Man kann es bei der Benennung immer wieder sehen. Dies gehört verbessert.


