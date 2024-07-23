import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegisterRequestInterface } from '../types/registerRequest.interface';
import { Observable, map, tap } from 'rxjs';
import { CurrentUserInterface } from 'src/app/shared/types/currentUser.interface';
import { AuthResponseInterface } from '../types/authResponse.interface';
import { environment } from 'src/environments/environment';
import { LoginRequestInterface } from '../types/loginRequest.interface';
import { LoginResponseInterface } from '../types/loginResponse.interface';
@Injectable({
  providedIn: 'root', // this will make it available everywhere
})
export class AuthService {
  private static readonly key = 'JWT_KEY';

  constructor(private http: HttpClient) {}

  get jwt(): string {
    return sessionStorage.getItem(AuthService.key) ?? ' ';
  }

  private set jwt(value: string) {
    sessionStorage.setItem(AuthService.key, value);
  }

  isLoggedIn(): boolean {
    return !!this.jwt;
  }

  register(
    payload: RegisterRequestInterface
  ): Observable<CurrentUserInterface> {
    const url = environment.apiUrl + '/users';

    return this.http
      .post<AuthResponseInterface>(url, payload)
      .pipe(map((response) => response.user));
  }

  login(payload: LoginRequestInterface): Observable<Date> {
    const url = environment.loginUrl;

    return this.http
      .post<LoginResponseInterface>(url + '/api/Authentication/Login', payload)
      .pipe(
        tap((response) => (this.jwt = response.jwtToken)),
        map((response) => response.expiration)
      );
  }
}
