import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { AppRoutingModule, routingComponents } from "./app.routing.module";
import { BrowserModule } from "@angular/platform-browser";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NavbarComponent } from "./Components/navbar/navbar.component";
import { TeacherAPIConnection } from "./Services/api-services/TeacherAPIConnection";
import { environment } from "../environments/enviroment.develop";
import { API_BASE_URL } from "./Infrastucture/configurations";
import { AuthentificationService } from "./Services/AuthentificationService";
import { CommonModule } from "@angular/common";
import { QuestionsPoolComponent } from "./Components/questions-pool/questions-pool.component";
import { ExerciseSheetService } from "./Services/api-services/exerciseSheet.service";
import { NgxEditorModule } from 'ngx-editor';
import { FolderService } from "./Services/api-services/Folder.Service";
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { PdfViewerModule } from "ng2-pdf-viewer";
import { SessionStorageProvider } from "./Services/SessionProvider";
// import { PdfViewerModule } from "ng2-pdf-viewer";

@NgModule({
    declarations: [
        AppComponent,
        NavbarComponent,
        QuestionsPoolComponent,
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
        TeacherAPIConnection,
        AuthentificationService,
        ExerciseSheetService,
        FolderService,
        SessionStorageProvider,
        provideAnimationsAsync()
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
