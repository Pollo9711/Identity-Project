import {Component, OnDestroy, OnInit} from '@angular/core';
import {Employee} from "../../../../Model/employee";
import {EmployeeService} from "../../../../Core/services/employee.service";
import {Subscription} from "rxjs";
import {Role} from "../../../../Model/role";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit, OnDestroy {

  employeeList : Employee[] = [];

  employee : Employee;

  subscriptionGetAll : Subscription;

  role = new Role()

  constructor(private employeeService : EmployeeService,
              private snackBar : MatSnackBar) { }



  ngOnInit(): void {
    this.subscriptionGetAll = this.getAll();
  }

  getAll() : Subscription {
    return this.employeeService.getAll().subscribe(e => {
      this.employeeList = [...e]
    }, error => {
      console.log(error)
    }, () => {

    })
  }


  delete(id : number) {
    this.employeeService.delete(id).subscribe(next => {
      this.getAll();
      this.snackBar.open("Delete successfully!", "Ok")
    }, err =>{
      console.log(err)
    }, () => {

    })
    /*const index = this.employeeList.indexOf(x);
    this.employeeList.splice(index, 1);*/

  }


  ngOnDestroy(): void {
    this.subscriptionGetAll?.unsubscribe();
  }
}
