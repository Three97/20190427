import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { SelectCityComponent } from './select-city/select-city.component';
import { WeatherDetailsComponent } from './weather-details/weather-details.component';

import { DarkSkyService } from './darksky.service';
import { LocationService } from './location.service';

@NgModule({
  declarations: [
    AppComponent,
    SelectCityComponent,
    WeatherDetailsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    DarkSkyService,
    LocationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
