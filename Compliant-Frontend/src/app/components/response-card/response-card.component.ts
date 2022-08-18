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
      },
    });
  }
}
