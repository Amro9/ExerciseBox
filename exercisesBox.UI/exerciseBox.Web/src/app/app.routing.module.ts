import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AdminViewComponent } from "./Components/admin-view/admin-view.component";
import { AppComponent } from "./app.component";
import { QuestionFormularComponent } from "./question-formular/question-formular.component";
const routes: Routes = [
    { path: "home", component: AppComponent },
    { path: "adminView", component: AdminViewComponent },
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    {path: '', redirectTo: '/question-formular', pathMatch: 'full'}
  ];

  
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }
  export const routingComponents = 
  [ 
    AdminViewComponent
  ]
  