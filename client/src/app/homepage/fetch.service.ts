import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Team } from './Team';

@Injectable({
  providedIn: 'root',
})
export class FetchService {
  constructor(private http: HttpClient) {}
  privatehttpOptions = {
    headers: new HttpHeaders ({
      "Access-Control-Allow-Origin": "**"
    })
  }


  getTeams(): Observable<Team[]> {
    return this.http.get<Team[]>("https://localhost:7295/api/teams");
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