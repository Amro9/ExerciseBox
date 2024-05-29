import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AdminViewComponent } from "./Components/admin-view/admin-view.component";
import { AppComponent } from "./app.component";
import { QuestionCreationFormComponent } from "./question-form/question-form.component";


const routes: Routes = [
  { path: "adminView", component: AdminViewComponent },
  {path: 'questionForm', component: QuestionCreationFormComponent},
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: "home", component: AppComponent },
  ];

  
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }
  export const routingComponents = 
  [ 
    AdminViewComponent,
    QuestionCreationFormComponent
  ]
  