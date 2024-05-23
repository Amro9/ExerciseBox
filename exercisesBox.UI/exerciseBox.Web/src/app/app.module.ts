import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { routingComponents } from "./app.routing.module";

@NgModule({
    declarations:[
        AppComponent,
        routingComponents
    ],
    imports: [

    ],
    providers: [

    ],
    bootstrap:[AppComponent]
})
export class AppModule { }