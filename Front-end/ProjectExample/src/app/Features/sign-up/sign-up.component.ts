import { Component, OnInit } from '@angular/core';
import {FormBuilder, Validators} from "@angular/forms";
import {User} from "../../Model/user";
import {RegisterService} from "../../Core/services/register.service";
import {Router} from "@angular/router";
import {MatSnackBar, MatSnackBarModule} from '@angular/material/snack-bar';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})


export class SignUpComponent implements OnInit {

  addUserForm = this.formBuilder.group({
    username: ['', Validators.compose([Validators.required])],
    email: ['', Validators.compose([Validators.required, Validators.email])],
    password: ['', Validators.compose([Validators.required])],
    isAdmin: ['', Validators.compose([Validators.required])]

  });



  constructor(private formBuilder : FormBuilder,
              private registerService: RegisterService,
              private router: Router,
              private matSnack : MatSnackBar) { }


  ngOnInit(): void {
  }


  addUser() {
    const user = this.addUserForm.value as User
    console.log(user)
    this.registerService.register(user).subscribe(
      next => this.matSnack.open("Registration succesfully!", "Ok"),
      err => console.log(err),
      () => this.router.navigateByUrl('/login')
    )
  }


}
