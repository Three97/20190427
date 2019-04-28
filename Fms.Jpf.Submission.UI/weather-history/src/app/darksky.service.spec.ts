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

  it('should create a proper URL', () => {
    const service: DarkSkyService = TestBed.get(DarkSkyService);
    const url = service.getUrl('key', 15, 13, 69);
    expect(url).toBe('https://cors-anywhere.herokuapp.com/' +
                     'https://api.darksky.net/forecast/key/15,13,69?exclude=minutely,hourly,daily,alerts,flags');
  });
});
