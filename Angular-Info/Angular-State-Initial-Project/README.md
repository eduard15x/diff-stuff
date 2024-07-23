# license-ui-angular

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 15.2.11.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via a platform of your choice. To use this command, you need to first add a package that implements end-to-end testing capabilities.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.


-tutorial https://www.youtube.com/watch?v=vcfZ0EQpYTA&t=30s&ab_channel=MonsterlessonsAcademy
-install node
-install angular CLI - will help u create the projects and other needs
    -npx - p @angular/cli@15 ng (this will allow you to use any version of angular) https://v17.angular.io/cli

-create project
npx -p @angular/cli@15 ng new license-ui-angular --skip-git (move content in desired folder) (skip-git doesnt initialize a repository if you are already in one)

-install store and store devtools, ngrx effects
npm install @ngrx/store@15
npm install @ngrx/store-devtools@15
npm install @ngrx/effects@15


-generate environments (for storing secrets variables)
-npx -p @angular/cli@15 ng generate environments


*standalone: true/false ??*
*module / no more modules ??*
*why NGRX ??? - state management tool*
*reactive forms*

*IMPORTANT -> every component that you create, in the decorator you must have a unique and same key when declaring components, ex: 'LUA-register', 'LUA-login', 'LUA-account'::::: LUA-license-ui-angular*