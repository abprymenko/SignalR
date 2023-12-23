import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IPrivateMessage } from '../interfaces/iprivate-message';

@Component({
  selector: 'app-login-form-dialog',
  templateUrl: './login-form-dialog.component.html',
  styleUrl: './login-form-dialog.component.css'
})
export class LoginFormDialogComponent {
  currentPrivateMessage: IPrivateMessage = {} as IPrivateMessage;

  constructor(public dialogRef: MatDialogRef<LoginFormDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { contactStructure: IPrivateMessage }) {
    if (data && data.contactStructure) {
      this.currentPrivateMessage = { ...data.contactStructure };
    }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSignedInClick(): void {
    this.dialogRef.close(this.currentPrivateMessage);
  }
}
