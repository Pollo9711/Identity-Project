import { Injectable } from '@angular/core';
import jwt_decode from "jwt-decode";


@Injectable({
  providedIn: 'root'
})
export class AuthStore {

  constructor() { }


  getToken() : any{
    const accessToken = sessionStorage.getItem('accessToken')
    if (accessToken) {
      return JSON.parse(accessToken)
    }
    else {
      return null
    }
  }


  setToken(x : string) : void{
    sessionStorage.setItem('accessToken', JSON.stringify(x))
}


  decriptToken() : any {
    const accessToken =  sessionStorage.getItem('accessToken')
    return jwt_decode(<string>accessToken)
  }
}
