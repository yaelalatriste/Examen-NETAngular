import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ClienteComponent } from './pages/clientes/cliente.component';

import { AuthService } from './services/auth.service';

declare var $: any; 

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ClienteComponent],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('ExamenFront');
  constructor(private auth: AuthService) {
    console.log(auth.isLoggedIn());
  }
    logout(): void {
      this.auth.logout();
    }
}
