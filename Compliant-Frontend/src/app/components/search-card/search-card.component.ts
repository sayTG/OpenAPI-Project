import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-search-card',
  templateUrl: './search-card.component.html',
  styleUrls: ['./search-card.component.scss'],
})
export class SearchCardComponent implements OnInit {
  URL: string | null = '';
  queries: string | null = '';
  responses: any;
  chuck: any;
  swapi: any;
  userInput: string = '';
  first: number = 1;
  second: number = 10;
  total: any;
  next: any;
  previous: any;
  disablePrev: boolean = true;
  disableNext: boolean = true;
  openTab = 1;
  page: number = 1;

  constructor(
    private activatedRoute: ActivatedRoute,
    private http: HttpClient
  ) {}

  ngOnInit(): void {
    this.URL = this.activatedRoute.snapshot.queryParamMap.get('reqUrl');
    this.queries = this.activatedRoute.snapshot.queryParamMap.get('reqQuery');
  }

  search(): void {
    const URL = `${environment.BASE_URL + this.URL}?query=${this.userInput}`;
    this.http.get(URL).subscribe({
      next: (res: any) => {
        this.chuck = res.chuckNorris != null ? res.chuckNorris.result : '';
        this.swapi = res.swapi.results.length != 0 ? res.swapi.results : '';
        this.total = res.swapi.count;
        this.next = res.swapi.next;
        this.previous = res.swapi.previous;
        this.disablePrev = this.previous == null ? true : false;
        this.disableNext = this.next == null ? true : false;
      },
    });
  }
  toggleTabs($tabNumber: number) {
    this.openTab = $tabNumber;
  }
  fetchNext(): void {
    this.page++;
    const URL = `${environment.BASE_URL + this.URL}?query=${
      this.userInput
    }&page=${this.page}`;
    this.http.get(URL).subscribe({
      next: (res: any) => {
        this.swapi = res.swapi.results;
        this.disablePrev = res.swapi.previous == null ? true : false;
        this.disableNext = res.swapi.next == null ? true : false;
      },
    });
    this.first += 10;
    this.second += 10;
  }
  fetchPrevious(): void {
    this.page--;
    const URL = `${environment.BASE_URL + this.URL}?query=${
      this.userInput
    }&page=${this.page}`;
    this.http.get(URL).subscribe({
      next: (res: any) => {
        this.swapi = res.swapi.results;
        this.disablePrev = res.swapi.previous == null ? true : false;
        this.disableNext = res.swapi.next == null ? true : false;
      },
    });
    this.first -= 10;
    this.second -= 10;
  }
}
