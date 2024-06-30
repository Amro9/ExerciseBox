import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AdminViewComponent } from "./Components/admin-view/admin-view.component";
import { AppComponent } from "./app.component";
import { QuestionCreationFormComponent } from "./Components/question-form/question-form.component"
import { LoginComponent } from "./Components/login/login.component";
import { QuestionsPoolComponent } from "./Components/questions-pool-components/questions-pool/questions-pool.component"
import { SchoolViewComponent } from "./Components/school-view/school-view.component";
import { ExerciseSheetGenerationComponent } from "./Components/exercise-sheet-generation/exercise-sheet-generation.component";
import { QuestionComponent } from "./Components/question/question.component";
import { AuthGuard } from "./Services/AuthGuard";
import { Roles } from "./Infrastucture/enums";
import { HomeComponent } from "./Components/home/home.component";
import { ProfileComponent } from "./Components/user-profile/profile/profile.component";
import { TeacherManagerComponent } from "./Components/teacher-manager/teacher-manager.component";
import { ChangePasswordComponent } from "./Components/change-password/change-password.component";
import { PasswordGuard } from "./Services/PasswordGuard";

const routes: Routes = [
  { path: "adminView", component: AdminViewComponent },
  { path: 'questionForm', component: QuestionCreationFormComponent, canActivate: [AuthGuard], data: { expectedRole: Roles.Teacher }},
  { path: 'questionsPool', component: QuestionsPoolComponent, canActivate: [AuthGuard], data: { expectedRole: Roles.Teacher }},
  { path: "login", component: LoginComponent},
  { path: "schoolView", component: SchoolViewComponent, canActivate: [AuthGuard], data: { expectedRole: Roles.School }},
  { path: "ExerciseSheet", component: ExerciseSheetGenerationComponent, canActivate: [AuthGuard], data: { expectedRole: Roles.Teacher }},
  { path: "profile", component: ProfileComponent, canActivate: [AuthGuard], data: { expectedRole: Roles.Teacher }},
  { path: 'home', component: HomeComponent, canActivate: [PasswordGuard], data: { expectedRole: Roles.Teacher }},
  { path: 'teacherManager', component: TeacherManagerComponent, canActivate: [AuthGuard], data: { expectedRole: Roles.School }},
  { path: 'changePassword', component: ChangePasswordComponent},
  { path: '', redirectTo: '/home', pathMatch: 'full' },
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
    QuestionComponent,
    HomeComponent,
    TeacherManagerComponent,
    ProfileComponent,
    ChangePasswordComponent
  ]
  