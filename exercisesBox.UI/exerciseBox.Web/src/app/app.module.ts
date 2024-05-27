import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { routingComponents } from "./app.routing.module";
import { BrowserModule } from "@angular/platform-browser";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';
import { QuestionCreationFormComponent } from "./question-form/question-form.component";
@NgModule({
    declarations:[
        AppComponent,
        routingComponents
    ],
    imports: [
        BrowserModule,
        NgbModule,
        ReactiveFormsModule
    ],
    providers: [

    ],
    bootstrap:[AppComponent]
})
export class AppModule { }