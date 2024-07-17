import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PokemonListComponent } from './pokemon-list/pokemon-list.component';
import { PokemonDetailsComponent } from './pokemon-details/pokemon-details.component';
import { PokemonService } from '../services/pokemon.service';
import { HttpClientModule } from '@angular/common/http';
import { PokemonTemplateFormComponent } from './pokemon-template-form/pokemon-template-form.component';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',

    children: [
      { path: '', component: PokemonListComponent },
      // { path: 'form', component: ReactiveFormsComponent },
      { path: ':id', component: PokemonTemplateFormComponent },
    ],
  },
];

@NgModule({
  declarations: [
    PokemonListComponent,
    PokemonDetailsComponent,
    PokemonTemplateFormComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forChild(routes),
  ],
  exports: [
    PokemonListComponent,
    PokemonDetailsComponent,
    PokemonTemplateFormComponent,
  ],
  providers: [PokemonService],
})
export class PokemonBaseModule {}
