import { Component, OnInit, OnDestroy } from '@angular/core';
import { SignalrService } from './services/signalr.service';
import { IPrivateMessage } from './interfaces/iprivate-message'
import { LoginFormDialogComponent } from './login-form-dialog/login-form-dialog.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'Chat.WebUI';
  currentUserMessage: IPrivateMessage = {} as IPrivateMessage;
  constructor(
    public signalrService: SignalrService,
    public dialog: MatDialog
  ) {
  }

  ngOnInit() {
    this.openLoginFormDialog();
    this.signalrService.startConnection();
  }

  openLoginFormDialog(): void {
    const dialogRef = this.dialog.open(LoginFormDialogComponent, {
      width: '480px',
      data: { contactStructure: {} as IPrivateMessage }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.currentUserMessage.Username = (result as IPrivateMessage)?.Username;
      }
    });
  }
  ngOnDestroy() {
    this.signalrService.stopConnection();
  }
}
