import { TestBed } from '@angular/core/testing';

import { DarkSkyService } from './darksky.service';
import { HttpClientModule } from '@angular/common/http';

describe('DarkSkyService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [
      HttpClientModule
    ]
  }));

  it('should be created', () => {
    const service: DarkSkyService = TestBed.get(DarkSkyService);
    expect(service).toBeTruthy();
  });

  it('should create a proper URL if time is provided', () => {
    const service: DarkSkyService = TestBed.get(DarkSkyService);
    const url = service.getUrl('key', 15, 13, '2018-07-22');
    expect(url).toBe('https://cors-anywhere.herokuapp.com/' +
                     'https://api.darksky.net/forecast/key/15,13,2018-07-22?exclude=minutely,hourly,daily,alerts,flags');
  });

  it('should return a default timestamp of July 4, 2018 @ Noon if none is provided', () => {
    const service: DarkSkyService = TestBed.get(DarkSkyService);
    const url = service.useTimeProvidedOrDefaultToJuly42018AtNoon();
    expect(url).toBe('2018-07-04T12:00:00');
  });

  it('should return the timestamp provided if provided', () => {
    const service: DarkSkyService = TestBed.get(DarkSkyService);
    const url = service.useTimeProvidedOrDefaultToJuly42018AtNoon('2018-08-04');
    expect(url).toBe('2018-08-04');
  });
});
