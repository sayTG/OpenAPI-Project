import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-request-card',
  templateUrl: './request-card.component.html',
})
export class RequestCardComponent implements OnInit {
  constructor(private http: HttpClient) {}

  URL = '';
  response = '';
  @Input() req: Req = {
    url: '',
    query: '',
    verb: 'GET',
  };

  ngOnInit(): void {
    this.URL = this.req.url;

    if (this.req.query) {
      this.URL += `?${this.req.query}`;
    }
  }

  fetchRequest() {
    const URL = environment.BASE_URL + this.URL;
    this.http.get(URL).subscribe({
      next: (res: any) => {
        this.response = JSON.stringify(res, null, 4);
      },
    });
  }

  reset() {
    this.response = '';
  }
}

interface Req {
  url: string;
  verb: string;
  query?: string;
}
