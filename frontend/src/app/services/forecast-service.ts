import { Injectable } from '@angular/core';
import { ForecastClient, ForecastDto } from '../api';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ForecastService {
  constructor(private apiClient: ForecastClient) { }

  public getForecast(lat: number, lon: number): Observable<ForecastDto> {
    return this.apiClient.forecast_Get(lat, lon);
  }
}
