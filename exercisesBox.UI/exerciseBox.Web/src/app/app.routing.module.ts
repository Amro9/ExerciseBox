import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AdminViewComponent } from "./Components/admin-view/admin-view.component";
import { AppComponent } from "./app.component";
import { QuestionCreationFormComponent } from "./Components/question-form/question-form.component"
import { LoginComponent } from "./Components/login/login.component";
import { QuestionsPoolComponent } from "./Components/questions-pool/questions-pool.component"

const routes: Routes = [
  { path: "adminView", component: AdminViewComponent },
  { path: 'questionForm', component: QuestionCreationFormComponent},
  { path: 'questionsPool', component: QuestionsPoolComponent},
  { path: "login", component: LoginComponent},
  //{ path: 'home', component: AppComponent },
  //{ path: '', redirectTo: '/home', pathMatch: 'full' },
  ];

  
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }
  export const routingComponents = 
  [ 
    AdminViewComponent,
    QuestionCreationFormComponent,
    LoginComponent
  ]
  