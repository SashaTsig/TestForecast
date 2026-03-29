import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule  } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormField, MatInput, MatLabel } from '@angular/material/input';
import { MatProgressBar } from '@angular/material/progress-bar';
import { RouterOutlet } from '@angular/router';
import { ForecastService } from './services';
import { DateTimeDto, ForecastDto } from './api';
import { MatCard, MatCardHeader, MatCardTitle, MatCardContent } from '@angular/material/card';
import { UtilsService } from './services/utils-service';
import { MatChip, MatChipSet } from '@angular/material/chips';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ReactiveFormsModule, MatButtonModule, MatInput, MatFormField, MatLabel, MatProgressBar,
    MatCard, MatCardHeader, MatCardTitle, MatCardContent, MatChipSet, MatChip ],
  templateUrl: './app.html',
  styleUrl: './app.scss',
})
export class App  {
  protected title = 'forecast-web';

  protected isSubmitting: boolean = false;

  protected data: ForecastDto | undefined;

  protected isError: boolean = false;

  protected formGroup: FormGroup = new FormGroup({
    latFormControl: new FormControl({value: 55.7558, disabled: true}, []),
    lonFormControl: new FormControl({value: 37.6173, disabled: true}, []),
  })

  constructor(private forecastService: ForecastService, private utils: UtilsService) { }

  onSubmit() {
    this.data = undefined;
    this.isSubmitting = true;
    this.isError = false;

    this.forecastService.getForecast(this.formGroup.controls['latFormControl'].value, this.formGroup.controls['lonFormControl'].value)
      .subscribe({
        next: (result) => {
          this.isSubmitting = false;
          this.data = result;
        },
         error: (error) => {
          this.isSubmitting = false;
          this.isError = true;
         }
      });
  }

  formatDate(date: DateTimeDto | undefined): string {
    if (!date) return "";

    return this.utils.formatDate(date);
  }

  formatDateTime(date: DateTimeDto | undefined): string {
    if (!date) return "";

    return this.utils.formatDateTime(date);
  }

  formatHour(date: DateTimeDto | undefined): string {
    if (!date) return "";

    return this.utils.formatHour(date);
  }

  formatTemperature(val: number | undefined): string  {
    if (!val)
        return "";
    return this.utils.formatTemperature(val);
  }
}
