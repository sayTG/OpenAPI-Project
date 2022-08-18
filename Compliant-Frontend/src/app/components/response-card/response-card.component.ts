import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-response-card',
  templateUrl: './response-card.component.html',
  styleUrls: ['./response-card.component.scss'],
})
export class ResponseCardComponent implements OnInit {
  URL: string | null = '';
  queries: string | null = '';
  responses: any;
  first: number = 1;
  second: number = 10;
  total: any;
  page: number = 1;
  disablePrev: boolean = false;
  disableNext: boolean = false;

  constructor(
    private activatedRoute: ActivatedRoute,
    private http: HttpClient
  ) {}

  ngOnInit(): void {
    this.URL = this.activatedRoute.snapshot.queryParamMap.get('reqUrl');
    this.queries = this.activatedRoute.snapshot.queryParamMap.get('reqQuery');
    const URL = `${environment.BASE_URL + this.URL}?${this.queries}`;
    this.http.get(URL).subscribe({
      next: (res: any) => {
        this.responses = res;
        this.total = res.count;
      },
    });
    this.disablePrev = this.first == 1 ? true : false;
    this.disableNext = this.second >= this.total ? true : false;
  }

  fetchNext(): void {
    this.page++;
    const URL = `${environment.BASE_URL + this.URL}?pages=${this.page}`;
    this.http.get(URL).subscribe({
      next: (res: any) => {
        this.responses = res;
      },
    });
    this.first += 10;
    this.second += 10;
    this.disablePrev = this.first == 1 ? true : false;
    this.disableNext = this.second >= this.total ? true : false;
  }
  fetchPrevious(): void {
    this.page--;
    const URL = `${environment.BASE_URL + this.URL}?pages=${this.page}`;
    this.http.get(URL).subscribe({
      next: (res: any) => {
        this.responses = res;
      },
    });
    this.first -= 10;
    this.second -= 10;
    this.disablePrev = this.first == 1 ? true : false;
    this.disableNext = this.second >= this.total ? true : false;
  }
}
