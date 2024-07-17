import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './not-found/not-found.component';

// you must have <base href='/'> inside index.html
// you must have  <app-root></app-root> inside body
const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  {
    path: 'pokemon',
    loadChildren: () =>
      import('./pokemon-base/pokemon-base.module').then(
        (m) => m.PokemonBaseModule
      ),
  },
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
