import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { routingComponents } from "./app.routing.module";
import { BrowserModule } from "@angular/platform-browser";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
    declarations:[
        AppComponent,
        routingComponents
    ],
    imports: [
        BrowserModule,
        NgbModule
    ],
    providers: [

    ],
    bootstrap:[AppComponent]
})
export class AppModule { }