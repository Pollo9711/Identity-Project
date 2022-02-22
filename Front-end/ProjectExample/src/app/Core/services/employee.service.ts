import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Employee} from "../../Model/employee";




@Injectable({
  providedIn: 'root'
})
export class EmployeeService {


//chiamata alla mia API ci siamo iniettatti l'HTTP client per effettuare la chiamata che ci tornerà un observable

  constructor(private http : HttpClient) { }

  getAll() : Observable<Employee[]> {
    return this.http.get<Employee[]>('https://localhost:5001/api/Employee')
  }

  add(employee : Employee) : Observable<Employee> {
    return this.http.post<Employee>('https://localhost:5001/api/Employee', employee)
  }

  delete(id : number) : Observable<any>{
    return this.http.delete('https://localhost:5001/api/Employee/' + id);

  }
}
