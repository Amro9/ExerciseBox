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
import { HashGenerator } from "./Services/HashGenerator";

@NgModule({
    declarations:[
        AppComponent,
        NavbarComponent,
        routingComponents
    ],
    imports: [
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
        HashGenerator
    ],
    bootstrap:[AppComponent]
})
export class AppModule { }