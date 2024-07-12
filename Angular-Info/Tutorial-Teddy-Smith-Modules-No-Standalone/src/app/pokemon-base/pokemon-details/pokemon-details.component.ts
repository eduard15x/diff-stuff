import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Pokemon } from '../../models/pokemon';

@Component({
  selector: 'PokemonDetails',
  templateUrl: './pokemon-details.component.html',
  styleUrl: './pokemon-details.component.css',
})
export class PokemonDetailsComponent implements OnInit {
  @Input()
  details!: Pokemon;
  @Input()
  pokemonIndex!: number;
  @Output()
  remove: EventEmitter<any> = new EventEmitter(); // eventEmitter is an observable
  // TODO build your own observable to understand better

  constructor() {}

  ngOnInit(): void {
    // throw new Error('Method not implemented.');
  }

  onRemove(): void {
    this.remove.emit(this.details);
  }
}
