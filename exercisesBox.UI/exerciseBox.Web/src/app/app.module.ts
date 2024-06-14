import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { AppRoutingModule, routingComponents } from "./app.routing.module";
import { BrowserModule } from "@angular/platform-browser";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NavbarComponent } from "./Components/navbar/navbar.component";
import { TeacherAPIConnection } from "./Services/TeacherAPIConnection";
import { environment } from "../environments/enviroment.develop";
import { API_BASE_URL } from "./Infrastucture/configurations";
import { AuthentificationService } from "./Services/AuthentificationService";
import { CommonModule } from "@angular/common";
import { QuestionsPoolComponent } from "./Components/questions-pool/questions-pool.component";
import { SessionProvider } from "./Services/SessionProvider";
import { ExerciseSheetService } from "./Services/exerciseSheet.service";


@NgModule({
    declarations:[
        AppComponent,
        NavbarComponent,
        QuestionsPoolComponent,
        QuestionsPoolComponent,
        routingComponents
    ],
    imports: [
    CommonModule,
        BrowserModule,
        NgbModule,
        ReactiveFormsModule,
        AppRoutingModule,
        HttpClientModule,
        FormsModule,
    ],
    providers: [
        {
            provide: API_BASE_URL,
            useValue: environment.baseUrl,
        },
        TeacherAPIConnection,
        AuthentificationService,
        ExerciseSheetService,
    ],
    bootstrap:[AppComponent]
})
export class AppModule { }