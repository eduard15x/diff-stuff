import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { BackendErrorMessages } from 'src/app/shared/components/backendErrorMessages/backendErrorMessages.component';
import { AuthService } from '../../services/auth.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'LUA-login',
  templateUrl: './login.component.html',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    RouterLink,
    CommonModule,
    BackendErrorMessages,
    FormsModule,
  ],
})
export class LoginComponent {
  loginComponentTitle: string = 'This is login page';

  username = '';
  password = '';
  expiration$?: Observable<Date>;

  constructor(private fb: FormBuilder, private authService: AuthService) {}

  login(): void {
    this.expiration$ = this.authService.login({
      username: this.username,
      password: this.password,
    });
  }
}
