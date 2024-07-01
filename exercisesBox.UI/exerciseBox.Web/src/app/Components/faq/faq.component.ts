import { Component } from '@angular/core';

@Component({
  selector: 'app-faq',
  templateUrl: './faq.component.html',
  styleUrls: ['./faq.component.css']
})
export class FaqComponent {
  toggleAnswer(sectionIndex: number, faqIndex: number): void {
    let faq = this.sections[sectionIndex].faqs[faqIndex];
    faq.isVisible = !faq.isVisible;
}
  sections = [
    {
      title: "Frageerstellung",
      description: "In diesem Abschnitt wird erklärt, wie Benutzer Fragen in das System eingeben können. Das Hinzufügen von Fragen ermöglicht es Lehrern, personalisierte Fragenpools für ihre Unterrichtsstunden zu erstellen und zu verwalten.",
      faqs: [
        {
          question: "Navigieren Sie zur Seite „Fragen Hinzufügen“",
          answer: "Auf die Option „Fragen Hinzufügen“ im Hauptmenü drücken",
          isVisible: false
        },
        {
          question: "Erstellen einer neuen Frage",
          answer: "Füllen Sie das Formular mit den folgenden Informationen aus: Schulstufe (Wählen Sie eine Ihrer Schulstufen aus)",
          isVisible: false
        }
      ]
    },
    {
      title: "Fragenpool",
      description: "Der Fragenpool ermöglicht es Lehrern, Fragen zu durchsuchen, zu speichern oder auszublenden. Sinnvolle Fragen finden und speichern ist die Grundlage der Arbeitsblätter Generierung.",
      faqs: [
        {
          question: "Navigation",
          answer: "Wählen Sie im Hauptmenü den Punkt „Fragenpool“ aus",
          isVisible: false
        },
        {
          question: "Die Suchfilter",
          answer: "Schulart\n"
          +"Hier geht es bei der Filterung um die Schulart, den Schulzweig und die Schulstufe. Wählen Sie die Schulart und falls sie einen bestimmten Zweig hat, können Sie diesen Ebenfalls auswählen. Jeder Schulart hat vordefinierte Schulstufen",
          isVisible: false
        },
        {
          question: "Filter-Beispiel",
          answer: "Der Filter ist dafür gedacht, die Suche nach Fragen einzugrenzen. So können Sie alle Fragen sehen, wenn Sie gar keine Filter setzen. Suchen Sie in Schulart „Berufsschule“, Fach „Informatik“, Thema „Pointers“, so sehen Sie alle Fragen dieses spezifischen Themas sehen, die an einer Berufsschule für Informatiker gedacht sind. Wählen Sie beispielweise zusätzlich eine bestimmte Schulstufe aus, so sehen die Fragen des gewählten Themas, die genau für diese Schulstufe gedacht sind",
          isVisible: false
        }
      ]
    }
  ];
}

