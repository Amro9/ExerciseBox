import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { routingComponents } from "./app.routing.module";
import { BrowserModule } from "@angular/platform-browser";

@NgModule({
    declarations:[
        AppComponent,
        routingComponents
    ],
    imports: [
        BrowserModule
    ],
    providers: [

    ],
    bootstrap:[AppComponent]
})
export class AppModule { }