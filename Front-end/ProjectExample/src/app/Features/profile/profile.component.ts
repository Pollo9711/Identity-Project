import { Component, OnInit } from '@angular/core';
import {AuthStore} from "../../Core/stores/auth.store";

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  userLogged : any

  constructor(private authStore : AuthStore) { }

  ngOnInit(): void {
    this.userLogged = this.authStore.decriptToken()
  }





}
