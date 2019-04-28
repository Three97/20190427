import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LocationItem } from './models/LocationItem';

@Injectable({
  providedIn: 'root'
})
export class DarkSkyService {
  // include the exclude part to minimize the size of the returning payload
  urlMask = 'https://cors-anywhere.herokuapp.com/' + // Get around the CORS issue by using this lovely piece of code
            'https://api.darksky.net/forecast/[KEY]/[LAT],[LONG],[EPOCH]?exclude=minutely,hourly,daily,alerts,flags';
  epoch = 1530662400; // July 4, 2018 == 1530662400

  // secret key - specific to user...
  secretKey = '[FILL_IN]';

  constructor(private http: HttpClient) { }

  getWeatherDetails(locationItem: LocationItem) {
    const url = this.getUrl(this.secretKey, locationItem.latitude, locationItem.longitude, this.epoch);
    return this.http.get(url);
  }

  getUrl(key: string, lat: number, long: number, time: number) {
    let url = this.urlMask.replace('[KEY]', key);
    url = url.replace('[LAT]', lat.toString());
    url = url.replace('[LONG]', long.toString());
    url = url.replace('[EPOCH]', time.toString());
    return url;
  }
}
