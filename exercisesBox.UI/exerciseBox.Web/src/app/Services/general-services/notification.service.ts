import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarRef, SimpleSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private snackBar: MatSnackBar) {}

  showSuccess(message: string) {
    this.snackBar.open(message, 'Schließen', {
      duration: 5000,
      panelClass: ['success-snackbar']
    });
  }
  showPersistentError(message: string) {
    const snackBarRef: MatSnackBarRef<SimpleSnackBar> = this.snackBar.open(message, undefined, {
      duration: 0,
      panelClass: ['error-snackbar'],
    });

    // Optional: Handle manual closing logic
    snackBarRef.onAction().subscribe(() => {
      snackBarRef.dismiss();
    });
  }
  showError(message: string) {
    this.snackBar.open(message, 'Schließen', {
      duration: 5000,
      panelClass: ['error-snackbar']
    });
  }
}
