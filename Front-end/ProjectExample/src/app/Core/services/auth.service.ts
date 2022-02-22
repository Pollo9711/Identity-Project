import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {loginUser} from "../../Model/loginUser";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http : HttpClient) { }

  login(loginUser : loginUser) : Observable<string> {
    return this.http.post<string>('https://localhost:44363/api/Auth/login', loginUser)
  }
}
