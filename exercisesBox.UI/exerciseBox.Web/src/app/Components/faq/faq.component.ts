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
      title: "Weitere Sektion",
      description: "Beschreibung der weiteren Sektion.",
      faqs: [
        {
          question: "Beispiel Frage 1",
          answer: "Beispiel Antwort 1",
          isVisible: false
        }
      ]
    }
  ];
}

