import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { ToastService } from './toast-service';
import { User } from '../../types/user';
import {
  HubConnection,
  HubConnectionBuilder,

} from '@microsoft/signalr';

@Injectable({
  providedIn: 'root',
})
export class PresenceService {

  private hubUrl = environment.hubUrl;

  private toast = inject(ToastService);

  private hubConnection? : HubConnection

  createHubConnection(user: User) {
    this.hubConnection = new HubConnectionBuilder()

  }
  
}
