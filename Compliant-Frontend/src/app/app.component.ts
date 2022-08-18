import { Component, Output } from '@angular/core';
import { environment } from 'src/environments/environment';
import  configurl from 'src/assets/config.json';
import { Req } from './components/request-card/request-card.component';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent {
  base = environment.BASE_URL;
  
  constructor() {}
}
