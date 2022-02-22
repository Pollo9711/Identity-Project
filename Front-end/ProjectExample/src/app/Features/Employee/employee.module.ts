import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {AddEmployeeFormComponent} from "./Components/add-employee-form/add-employee-form.component";
import {RouterModule, Routes} from "@angular/router";
import { EmployeeListComponent } from './Components/employee-list/employee-list.component';
import {ReactiveFormsModule} from "@angular/forms";
import {MatSnackBarModule} from '@angular/material/snack-bar';

const route : Routes = [{
  path: 'add', component: AddEmployeeFormComponent
}, {
  path: 'list', component: EmployeeListComponent
}]

@NgModule({
  declarations: [
    AddEmployeeFormComponent,
    EmployeeListComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild(route),
    MatSnackBarModule

  ]
})
export class EmployeeModule { }
