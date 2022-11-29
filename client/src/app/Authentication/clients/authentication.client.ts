import { environment } from '../../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationClient {
  constructor(private http: HttpClient) {}
  privatehttpOptions = {
    headers: new HttpHeaders ({
      "Access-Control-Allow-Origin": "**"
    })
  }
  public login(username: string, password: string): Observable<string> {
    return this.http.post(
      'https://localhost:7295/api/authentication/login',
      {
        useraname: username,
        password: password,
      },
      { responseType: 'text' }
    );
  }

  public register(
    username: string,
    firstName: string,
    lastName: string,
    password: string
  ): Observable<string> {

    return this.http.post(
      'https://localhost:7295/api/authentication/register',
      {
        useraname:username,
        firstName,
        lastName,
        password
      },
      { responseType: 'text'}
    );
  }
}