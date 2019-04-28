import { Component, OnInit } from '@angular/core';
import { LocationService } from '../location.service';
import { LocationItem } from '../models/LocationItem';

@Component({
  selector: 'app-select-city',
  templateUrl: './select-city.component.html',
  styleUrls: []
})
export class SelectCityComponent implements OnInit {
  locations: Array<LocationItem>;
  selectedLocation: LocationItem;
  constructor(private locService: LocationService) { }

  ngOnInit() {
    this.locService.getLocations()
      .subscribe((data) => {
        this.locations = data as Array<LocationItem>;
        // add some functionality to make things nicer for the user..
        this.locations.unshift({ id: 0, name: 'Select a location'} as LocationItem);
        this.selectedLocation = this.locations[0];
        // console.log(this.locations);
      });
  }
}
