import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PokemonBaseModule } from './pokemon-base/pokemon-base.module';
import { FormsModule } from '@angular/forms';
import { NotFoundComponent } from './not-found/not-found.component';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [AppComponent, NotFoundComponent, HomeComponent],
  imports: [BrowserModule, AppRoutingModule, FormsModule, PokemonBaseModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
