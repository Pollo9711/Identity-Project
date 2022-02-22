import {Component, EventEmitter, OnInit} from '@angular/core';
import {EmployeeService} from "../../../../Core/services/employee.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Router, Routes} from "@angular/router";
import {Role} from "../../../../Model/role";




@Component({
  selector: 'app-add-employee-form',
  templateUrl: './add-employee-form.component.html',
  styleUrls: ['./add-employee-form.component.scss']
})

export class AddEmployeeFormComponent implements OnInit {

  addEmployeeForm = this.formBuilder.group({
    name: ['', Validators.compose([Validators.required])],
    lastname: ['', Validators.compose([Validators.required])],
    birthday: ['', Validators.compose([Validators.required])],
    email: ['', Validators.compose([Validators.required, Validators.email])],
    roleJob: ['', Validators.compose([Validators.required])],
    message: ['', Validators.compose([Validators.required])]

  });

  role = new Role()

  constructor(private employeeService : EmployeeService,
              private formBuilder : FormBuilder,
              private router : Router,
              ) {console.log(this.role)}

  ngOnInit(): void {
  }



addEmployee() {
    this.employeeService.add(this.addEmployeeForm.value).subscribe(
      next => console.log('Success!!!'),
        err => console.log(err),
      () => this.router.navigateByUrl('/employee/list')
        )
  }
}
