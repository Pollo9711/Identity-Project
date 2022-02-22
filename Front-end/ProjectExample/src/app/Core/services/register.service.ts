import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {User} from "../../Model/user";


@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private http : HttpClient) { }

  register(user : User) : Observable<User> {
    return this.http.post<User>('https://localhost:44363/api/Auth/register', user)
  }

}
