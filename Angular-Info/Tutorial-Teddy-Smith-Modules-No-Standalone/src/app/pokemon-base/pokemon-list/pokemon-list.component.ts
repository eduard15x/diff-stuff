import { Component, OnInit } from '@angular/core'; // angular core is a module in node_modules
import { Pokemon } from '../../models/pokemon';

// Decorator pattern
@Component({
  selector: 'PokemonList',
  templateUrl: './pokemon-list.component.html',
  styleUrl: './pokemon-list.component.css',
})
export class PokemonListComponent implements OnInit {
  pokemonListTitle: string = 'Pokemon List';
  pokemonList: Pokemon[];

  constructor() {
    this.pokemonList = [
      { id: 1, name: 'Pikachu', type: 'strong', isCool: true, isStylish: true },
      { id: 2, name: 'Rudolph', type: 'weak', isCool: true, isStylish: false },
    ];
  }
  ngOnInit(): void {
    // lifecycle method (like onMounted in react/vue -> the first thing that happens, but not before constructor :), constructor initializes class)
    throw new Error('Method not implemented.');
  }

  handleRemove(event: Pokemon): void {
    this.pokemonList = this.pokemonList.filter(
      (pokemon: Pokemon) => pokemon.id !== event.id
    );
  }
}
