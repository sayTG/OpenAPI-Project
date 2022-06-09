import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
import  configurl from 'src/assets/config.json';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent {
  //base = environment.BASE_URL;
  base = configurl.apiServer.url;
  requests = environment.REQUESTS;
}
