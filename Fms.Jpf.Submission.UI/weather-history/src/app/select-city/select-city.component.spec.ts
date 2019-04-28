import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectCityComponent } from './select-city.component';
import { FormsModule } from '@angular/forms';
import { WeatherDetailsComponent } from '../weather-details/weather-details.component';
import { HttpClientModule } from '@angular/common/http';

describe('SelectCityComponent', () => {
  let component: SelectCityComponent;
  let fixture: ComponentFixture<SelectCityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        FormsModule,
        HttpClientModule
      ],
      declarations: [
        SelectCityComponent,
        WeatherDetailsComponent
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectCityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
