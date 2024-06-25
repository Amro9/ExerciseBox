import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AdminViewComponent } from "./Components/admin-view/admin-view.component";
import { AppComponent } from "./app.component";
import { QuestionCreationFormComponent } from "./Components/question-form/question-form.component"
import { LoginComponent } from "./Components/login/login.component";
import { QuestionsPoolComponent } from "./Components/questions-pool/questions-pool.component"
import { SchoolViewComponent } from "./Components/school-view/school-view.component";
import { ExerciseSheetGenerationComponent } from "./Components/exercise-sheet-generation/exercise-sheet-generation.component";
import { QuestionComponent } from "./Components/question/question.component";
import { AuthGuard } from "./Services/AuthGuard";

const routes: Routes = [
  { path: "adminView", component: AdminViewComponent },
  { path: 'questionForm', component: QuestionCreationFormComponent, canActivate: [AuthGuard]},
  { path: 'questionsPool', component: QuestionsPoolComponent, canActivate: [AuthGuard]},
  { path: "login", component: LoginComponent, canActivate: [AuthGuard]},
  { path: "schoolView", component: SchoolViewComponent, canActivate: [AuthGuard]},
  { path: "ExerciseSheet", component: ExerciseSheetGenerationComponent, canActivate: [AuthGuard]},
  //{ path: "question", component: QuestionComponent},
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
    LoginComponent,
    SchoolViewComponent,
    ExerciseSheetGenerationComponent,
    QuestionComponent
  ]
  