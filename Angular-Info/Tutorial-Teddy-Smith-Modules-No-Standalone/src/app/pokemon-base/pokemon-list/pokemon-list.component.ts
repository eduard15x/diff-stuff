import { Component, OnInit } from '@angular/core'; // angular core is a module in node_modules
import { Pokemon } from '../../models/pokemon';
import { PokemonService } from '../../services/pokemon.service';

// Decorator pattern
@Component({
  selector: 'PokemonList',
  templateUrl: './pokemon-list.component.html',
  styleUrl: './pokemon-list.component.css',
})
export class PokemonListComponent implements OnInit {
  pokemonListTitle: string = 'Pokemon List';
  pokemonList: Pokemon[] = [];

  constructor(private pokemonService: PokemonService) {}
  ngOnInit(): void {
    // lifecycle method (like onMounted in react/vue -> the first thing that happens, but not before constructor :), constructor initializes class)
    // throw new Error('Method not implemented.');
    //  this.pokemonList =
    this.pokemonService.getPokemons().subscribe((data: Pokemon[]) => {
      console.log(data);
      console.table(data);
      this.pokemonList = data;
    });
  }

  handleRemove(event: Pokemon): void {
    this.pokemonList = this.pokemonList.filter(
      (pokemon: Pokemon) => pokemon.id !== event.id
    );
  }
}
