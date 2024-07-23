import {
  HTTP_INTERCEPTORS,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from '../auth/services/auth.service';
import { environment } from 'src/environments/environment';

@Injectable()
export class JwtAuthenticationInterceptor implements HttpInterceptor {
  private authService = inject(AuthService); // Use inject() for standalone components
  // constructor(private authService: AuthService) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    console.log('axa');
    const isLoggedIn = this.authService.isLoggedIn();
    const isToServer = req.url.startsWith(environment.loginUrl);
    console.log('axa');

    if (isLoggedIn && isToServer) {
      console.log('axa');
      req = req.clone({
        setHeaders: { Authorization: `Bearer ${this.authService.jwt}` },
      });
    }

    return next.handle(req);
  }
}

export const JwtAuthenticationInterceptorProvider = {
  provide: HTTP_INTERCEPTORS,
  useClass: JwtAuthenticationInterceptor,
  multi: true,
};
