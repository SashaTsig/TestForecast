import { Injectable } from '@angular/core';
import { DateTimeDto } from '../api';
import dayjs from 'dayjs';

@Injectable({
  providedIn: 'root',
})
export class UtilsService {
  private DATE_FORMAT:string = "DD/MM/YYYY";
  private DATE_TIME_FORMAT:string = "DD/MM/YYYY HH:mm";
  private HOUR_FORMAT:string = "HH:";

  formatDate(date: DateTimeDto): string {
    const dt = new Date(date.year!, date.month!, date.day);


    return dayjs(dt).format(this.DATE_FORMAT);
  }

  formatDateTime(date: DateTimeDto): string {
    const dt = new Date(date.year!, date.month!, date.day, date.hour, date.minute);


    return dayjs(dt).format(this.DATE_TIME_FORMAT);
  }

  formatHour(date: DateTimeDto): string {
    const dt = new Date(date.year!, date.month!, date.day, date.hour, date.minute);


    return dayjs(dt).format(this.HOUR_FORMAT);
  }

  formatTemperature(temp: number): string {
    var preffix = temp > 0 ? "+" : "";
    return preffix + Math.round(temp);
  }
}
