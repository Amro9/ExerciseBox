import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { AppRoutingModule, routingComponents } from "./app.routing.module";
import { BrowserModule } from "@angular/platform-browser";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NavbarComponent } from "./Components/navbar/navbar.component";
import { TeacherService } from "./Services/api-services/Teacher";
import { environment } from "../environments/enviroment.develop";
import { API_BASE_URL } from "./Infrastucture/configurations";
import { AuthentificationService } from "./Services/AuthentificationService";
import { CommonModule } from "@angular/common";
import { QuestionsPoolComponent } from "./Components/questions-pool-components/questions-pool/questions-pool.component";
import { ExerciseSheetService } from "./Services/api-services/exerciseSheet.service";
import { NgxEditorModule } from 'ngx-editor';
import { FolderService } from "./Services/api-services/Folder.Service";
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { PdfViewerModule } from "ng2-pdf-viewer";
import { SessionStorageProvider } from "./Services/SessionProvider";
import { FilterFormularComponent } from "./Components/questions-pool-components/filter-formular/filter-formular.component";
import { FoldersPopupComponent } from "./Components/questions-pool-components/folders-popup/folders-popup.component";
import { QuestionListComponent } from "./Components/questions-pool-components/question-list/question-list.component";
import { HideQuestionPopupComponent } from "./Components/questions-pool-components/hide-question-popup/hide-question-popup.component";
import { AuthGuard } from "./Services/AuthGuard";
import { ProfileQuestionListComponent } from "./Components/user-profile/profile-question-list/profile-question-list.component";
import { RemoveQuestionPopupComponent } from "./Components/user-profile/remove-question-popup/remove-question-popup.component";
import { PersonalDataComponent } from "./Components/user-profile/personal-data/personal-data.component";
import { PasswordGuard } from "./Services/PasswordGuard";
import { FaqComponent } from "./Components/faq/faq.component";
// import { PdfViewerModule } from "ng2-pdf-viewer";

@NgModule({
    declarations: [
        AppComponent,
        NavbarComponent,
        QuestionsPoolComponent,
        FilterFormularComponent,
        FoldersPopupComponent,
        HideQuestionPopupComponent,
        QuestionListComponent,
        ProfileQuestionListComponent,
        RemoveQuestionPopupComponent,
        PersonalDataComponent,
        FaqComponent,
        routingComponents
    ],
    imports: [
        CommonModule,
        BrowserModule,
        BrowserAnimationsModule,
        MatSnackBarModule,
        NgbModule,
        ReactiveFormsModule,
        AppRoutingModule,
        HttpClientModule,
        FormsModule,
        NgxEditorModule,
        PdfViewerModule
    ],
    providers: [
        {
            provide: API_BASE_URL,
            useValue: environment.baseUrl,
        },
        TeacherService,
        AuthentificationService,
        ExerciseSheetService,
        FolderService,
        SessionStorageProvider,
        AuthGuard,
        PasswordGuard,
        provideAnimationsAsync()
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
