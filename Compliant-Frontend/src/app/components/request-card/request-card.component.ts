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
  queries: string | undefined = '';
  response = '';

  @Input() req: Req = {
    url: '',
    verb: 'GET',
    queries: '',
  };

  ngOnInit(): void {
    this.URL = this.req.url;
    this.queries = this.req.queries || '';
  }

  fetchRequest() {
    const URL = `${environment.BASE_URL + this.URL}?${this.queries}`;
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
  queries?: string;
}
