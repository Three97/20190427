import { Component, OnChanges, Input, SimpleChange } from '@angular/core';
import { LocationItem } from '../models/LocationItem';
import { DarkSkyService } from '../darksky.service';

@Component({
  selector: 'app-weather-details',
  templateUrl: './weather-details.component.html',
  styleUrls: []
})
export class WeatherDetailsComponent implements OnChanges {
  @Input() selectedLocation: LocationItem;
  @Input() details: object;

  constructor(private darkSkyService: DarkSkyService) { }

  ngOnChanges(changes: {[propKey: string]: SimpleChange}) {
    // console.log(changes);
    // console.log(this.selectedLocation);
    if (this.selectedLocation && this.selectedLocation.id !== 0) {
      // console.log('Valid selection.');
      this.darkSkyService.getWeatherDetails(this.selectedLocation)
        .subscribe((data) => {
          this.details = data;
          // console.log('WeatherDetailItem', this.details);
        });
    } else {
      this.details = null;
    }
  }

}
