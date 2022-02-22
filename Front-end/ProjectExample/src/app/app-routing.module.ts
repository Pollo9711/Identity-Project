import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: 'employee', loadChildren : () => import('./Features/Employee/employee.module').then(m => m.EmployeeModule)},
  {path: 'login', loadChildren : () => import('./Features/login/login.module').then(m => m.LoginModule)},
  {path: 'signup', loadChildren : () => import('./Features/sign-up/sign-up.module').then(m => m.SignUpModule)},
  {path: 'profile', loadChildren : () => import('./Features/profile/profile.module').then(m => m.ProfileModule)},
  { path: '', redirectTo: 'employee', pathMatch: 'full'},
  { path: '**', redirectTo: 'employee', pathMatch: 'full'}
];



@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
