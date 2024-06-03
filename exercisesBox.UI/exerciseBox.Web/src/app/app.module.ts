import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { AppRoutingModule, routingComponents } from "./app.routing.module";
import { BrowserModule } from "@angular/platform-browser";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NavbarComponent } from "./Components/navbar/navbar.component";

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
        HttpClientModule
    ],
    providers: [

    ],
    bootstrap:[AppComponent]
})
export class AppModule { }