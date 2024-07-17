import { Component } from '@angular/core';

interface Nav {
  link: string;
  name: string;
  exact: boolean;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'Tutorial-Teddy-Smith-Modules-No-Standalone';
  nav: Nav[] = [
    { link: '/', name: 'Home', exact: true },
    { link: '/bad-route', name: 'Bad Route', exact: false },
  ];

  constructor() {}
}
