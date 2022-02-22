import { Component, OnInit } from '@angular/core';
import {User} from "../../Model/user";
import {FormBuilder, Validators} from "@angular/forms";
import {RegisterService} from "../../Core/services/register.service";
import {Router} from "@angular/router";
import {AuthService} from "../../Core/services/auth.service";
import {loginUser} from "../../Model/loginUser";
import {AuthStore} from "../../Core/stores/auth.store";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginUserForm = this.formBuilder.group({
    username: ['', Validators.compose([Validators.required])],
    password: ['', Validators.compose([Validators.required])]

  });


  constructor(private formBuilder : FormBuilder,
              private authService: AuthService,
              private router: Router,
              private authStore: AuthStore) { }


  ngOnInit(): void {
  }


  loginUser() {
    const user = this.loginUserForm.value as loginUser
    console.log(user)
    this.authService.login(user).subscribe(
      next => this.authStore.setToken(next),
      err => console.log(err),
      () => this.router.navigateByUrl('/profile')
    )
  }

}
