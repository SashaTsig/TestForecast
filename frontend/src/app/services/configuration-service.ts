import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ConfigurationService {
  getApiBaseUrl(): string{
        return environment.ENV_API_URL;
    }
}
