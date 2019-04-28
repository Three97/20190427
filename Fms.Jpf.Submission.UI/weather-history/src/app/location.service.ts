import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LocationService implements OnInit {
  // this url could be stored in a config file, or be
  // environment specific..
  url = 'http://localhost:5000/api/locations';

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  getLocations() {
    return this.http.get(this.url);
  }
}
