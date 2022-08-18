import { Component, OnInit, Output } from '@angular/core';
import { environment } from 'src/environments/environment';
import  configurl from 'src/assets/config.json';
import { HttpClient } from '@angular/common/http';
import { Req } from '../request-card/request-card.component';

@Component({
  selector: 'app-response-homepage',
  templateUrl: './response-homepage.component.html',
  styleUrls: ['./response-homepage.component.scss']
})
export class ResponseHomepageComponent implements OnInit {
  requests = environment.REQUESTS;

  constructor(private http: HttpClient) {}
  ngOnInit(): void {
  }
  
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
