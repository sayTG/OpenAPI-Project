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
  requests = environment.REQUESTS;

  constructor(private http: HttpClient) {}
  
  req: Req = {
    url: '',
    verb: 'GET',
    queries: '',
  };
  responses : any;

  show = false;

  getNotification(evt : Req) {
    const URL = `${environment.BASE_URL + evt.url}?${evt.queries}`;
    this.http.get(URL).subscribe({
      next: (res: any) => {
        this.responses = res;
      },
    });
    this.show = !this.show;
  }
  getUpdatedModal(evt : any) {
    this.show = evt;
  }
}
