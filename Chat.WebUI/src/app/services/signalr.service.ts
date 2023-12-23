import { Injectable, Input } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { IPrivateMessage } from '../interfaces/iprivate-message';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {
  @Input() hubConnection!: signalR.HubConnection;
  messages: IPrivateMessage[] = [];
  constructor() { }

  public async startConnection(): Promise<void> {
    try {
      this.hubConnection = new signalR.HubConnectionBuilder()
        .withUrl('https://localhost:7047/hubs/chat', {
          skipNegotiation: true,
          transport: signalR.HttpTransportType.WebSockets
        })
        .withAutomaticReconnect()
        .build();
      this.hubConnection.onclose(() => {
        console.log(`Connection closed. Reconnecting...`);
        console.log(`Current connectionId: ${this.hubConnection.connectionId}`);
      });
      this.hubConnection.on('ReceiveMessage', (username: string, message: string) => {
        const privateMessage: IPrivateMessage = { Username: username, Message: message };
        this.messages.push(privateMessage);
      });
      await this.hubConnection.start();
      console.log(`SignalR connection success! connectionId: ${this.hubConnection.connectionId}`);
    }
    catch (error) {
      console.log('Error while starting connection: ' + error);
    }
  }
  public async sendMessage(message: IPrivateMessage): Promise<void> {
    try {
      await this.hubConnection.invoke('SendMessage', message.Username, message.Message);
      message.Message = '';
    }
    catch (error) {
      console.log('Error while sending message: ' + error);
    }
  }
  stopConnection = () => {
    this.hubConnection.off('');
  }
}