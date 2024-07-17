import { Component, EventEmitter, OnInit } from '@angular/core';
import { PokemonService } from '../../services/pokemon.service';
import { Pokemon, PokemonType } from '../../models/pokemon';
import { ActivatedRoute, Params, Router } from '@angular/router';

@Component({
  selector: 'PokemonTemplateForm',
  templateUrl: './pokemon-template-form.component.html',
  styleUrl: './pokemon-template-form.component.css',
})
export class PokemonTemplateFormComponent implements OnInit {
  singlePokemon!: Pokemon;
  pokemonTypeList: PokemonType[] = [
    { key: 0, value: 'Fire' },
    { key: 1, value: 'Water' },
    { key: 2, value: 'Electric' },
    { key: 3, value: 'strong' },
  ];

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private pokemonService: PokemonService
  ) {}

  ngOnInit() {
    this.singlePokemon = {} as Pokemon;
    this.route.params.subscribe((data: Params) => {
      return this.pokemonService
        .getPokemon(data['id'])
        .subscribe((data: Pokemon) => {
          this.singlePokemon = data;
        });
    });
  }

  navigateBack(): void {
    this.router.navigate(['/pokemon']);
  }

  toggleIsCool(e: EventEmitter<any>) {
    console.log(e);
  }

  handleSubmit(payload: any) {
    console.log(payload);
  }
}
