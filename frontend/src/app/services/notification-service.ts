import { Component, Inject, Injectable } from '@angular/core';
import { MAT_SNACK_BAR_DATA, MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  constructor(public snackBar: MatSnackBar) {}

    showSuccess(msg: string) {
        let config = new MatSnackBarConfig();
        config.data = msg;
        config.panelClass = ['successSnackBar'];
        config.duration = 5 * 1000;

        this.snackBar.openFromComponent(SnackBarComponent, config);
    }

    showError(msg: string) {
        let config = new MatSnackBarConfig();
        config.data = msg;
        config.panelClass = ['errorSnackBar'];
        config.duration = 5 * 1000;

        this.snackBar.openFromComponent(SnackBarComponent, config);
    }

}

@Component({
    selector: 'snack-bar',
    template: '{{data}}',
})
export class SnackBarComponent {
    constructor(@Inject(MAT_SNACK_BAR_DATA) public data: any) { }
}
