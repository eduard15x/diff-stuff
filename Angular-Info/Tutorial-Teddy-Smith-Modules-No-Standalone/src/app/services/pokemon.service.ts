import { Injectable } from '@angular/core';
import { Pokemon } from '../models/pokemon';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const POKEMON_API = 'http://localhost:3000/pokemons';

@Injectable({
  providedIn: 'root',
})
export class PokemonService {
  constructor(private http: HttpClient) {}

  getPokemons(): Observable<Pokemon[]> {
    // make call into db.json file
    return this.http.get<Pokemon[]>(POKEMON_API);
  }

  getPokemon(id: number): Observable<Pokemon> {
    return this.http.get<Pokemon>(`${POKEMON_API}/${id}`);
  }
}
