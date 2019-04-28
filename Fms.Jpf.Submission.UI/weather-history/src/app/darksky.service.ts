import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LocationItem } from './models/LocationItem';

@Injectable({
  providedIn: 'root'
})
export class DarkSkyService {
  // include the exclude part to minimize the size of the returning payload
  urlMask = 'https://cors-anywhere.herokuapp.com/' + // Get around the CORS issue by using this lovely piece of code
            'https://api.darksky.net/forecast/[KEY]/[LAT],[LONG],[TIME]?exclude=minutely,hourly,daily,alerts,flags';
  july4AtNoon = '2018-07-04T12:00:00';

  // secret key - specific to user...
  secretKey = '[FILL_IN]';

  constructor(private http: HttpClient) { }

  getWeatherDetails(locationItem: LocationItem, time?: string) {
    const timeStamp = this.useTimeProvidedOrDefaultToJuly42018AtNoon(time);
    const url = this.getUrl(this.secretKey, locationItem.latitude, locationItem.longitude, timeStamp);
    return this.http.get(url);
  }

  useTimeProvidedOrDefaultToJuly42018AtNoon(time?: string) {
    return time ? time : this.july4AtNoon;
  }

  getUrl(key: string, lat: number, long: number, time: string) {
    let url = this.urlMask.replace('[KEY]', key);
    url = url.replace('[LAT]', lat.toString());
    url = url.replace('[LONG]', long.toString());
    url = url.replace('[TIME]', time.toString());
    return url;
  }
}
