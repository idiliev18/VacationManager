import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { AuthGuard } from './Authentication/helpers/authentication.guard';
import { LoginComponent } from './Authentication/login/login.component';
import { RegisterComponent } from './Authentication/register/register.component';
import { HomepageComponent } from './homepage/homepage.component';

const routes: Routes = [
  {component: LoginComponent, path: 'login'},
  {component: RegisterComponent, path: 'register'},
  {component: HomepageComponent,  
    path: '',
    canActivate: [AuthGuard],
    data: {role: "CEO"}
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
