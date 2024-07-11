import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';

interface Pokemon {
  id: number;
  name: string;
  type: string;
  isCool: boolean;
  isStylish: boolean;
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title: string = 'Tutorial-Teddy-Smith-1';
  nrOne: number;
  nrTwo: number;
  togglePokemon: boolean = false;
  imageSrc: string = 'test.jpg';
  favoriteAnimal: string = 'Dog';
  pokemonName: string = '';
  pokemonList: Pokemon[] = [
    {
      id: 1,
      name: 'Pikachu1',
      type: 'electric1',
      isCool: false,
      isStylish: true,
    },
    {
      id: 2,
      name: 'Pikachu2',
      type: 'electric2',
      isCool: true,
      isStylish: false,
    },
    {
      id: 3,
      name: 'Pikachu3',
      type: 'electric3',
      isCool: false,
      isStylish: true,
    },
  ];

  firstName: string = '';

  constructor() {
    this.nrOne = 1;
    this.nrTwo = 2;
  }

  handleClick(inputEl: HTMLInputElement) {
    console.log(inputEl);
    console.log(this.pokemonName);
    console.log(inputEl.value);
    inputEl.value = '';
  }

  handleChange(event: Event) {
    const inputElement = event.target as HTMLInputElement;
    this.firstName = inputElement.value;
  }
}
