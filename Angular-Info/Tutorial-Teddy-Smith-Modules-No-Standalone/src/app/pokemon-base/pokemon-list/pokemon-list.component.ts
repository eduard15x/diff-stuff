import {
  AfterContentInit,
  AfterViewInit,
  Component,
  ElementRef,
  OnInit,
  Renderer2,
  ViewChild,
  ViewChildren,
} from '@angular/core'; // angular core is a module in node_modules
import { Pokemon } from '../../models/pokemon';
import { PokemonService } from '../../services/pokemon.service';

// Decorator pattern
@Component({
  selector: 'PokemonList',
  templateUrl: './pokemon-list.component.html',
  styleUrl: './pokemon-list.component.css',
})
export class PokemonListComponent
  implements OnInit, AfterViewInit, AfterContentInit
{
  pokemonListTitle: string = 'Pokemon List';
  pokemonList: Pokemon[] = [];

  // to use @ViewChild decorator you need to create a ref inside html using # (ex: #pokemonRef)
  // @ViewChild('pokemonRef') pokemonRef!: ElementRef; // -> this doesnt work because the ref is inside a loop, to there are more ref , use @ViewChildrean instead
  @ViewChildren('pokemonRef') pokemonRef!: ElementRef;
  @ViewChild('pokemonListDescription') pokemonListDescription!: ElementRef;

  // Render2 is almost the same with ElementRef, but more safe because you need to create it from scratch
  constructor(
    private pokemonService: PokemonService,
    private renderer: Renderer2
  ) {}
  ngOnInit(): void {
    console.log('ngOnInit');
    // lifecycle method (like onMounted in react/vue -> the first thing that happens, but not before constructor :), constructor initializes class)
    // throw new Error('Method not implemented.');
    //  this.pokemonList =
    this.pokemonService.getPokemons().subscribe((data: Pokemon[]) => {
      console.log(data);
      console.table(data);
      this.pokemonList = data;
    });
  }

  ngAfterContentInit(): void {
    console.log('ngAfterContentInit');
  }

  ngAfterViewInit(): void {
    console.log('ngAfterViewInit');
    console.log(this.pokemonRef);
    this.pokemonListDescription.nativeElement.innerText =
      'This is the description added by Element Ref ';

    // using a more safely Renderer2, to avoid inserting scripting in our browser and get access to the ElementRefs
    const div = this.renderer.createElement('div');
    const text = this.renderer.createText(
      'Pokemon Description List By Renderer2'
    );
    this.renderer.appendChild(div, text);
    this.renderer.appendChild(this.pokemonListDescription, div);
  }

  handleRemove(event: Pokemon): void {
    this.pokemonList = this.pokemonList.filter(
      (pokemon: Pokemon) => pokemon.id !== event.id
    );
  }
}
