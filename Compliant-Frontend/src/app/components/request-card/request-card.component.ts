import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import  { Router } from '@angular/router';

@Component({
  selector: 'app-request-card',
  templateUrl: './request-card.component.html',
})
export class RequestCardComponent implements OnInit {
  constructor(private http: HttpClient, private router : Router) {}

  @Output() notifyParent: EventEmitter<any> = new EventEmitter();

  URL = '';
  queries: string | undefined = '';
  response = '';
  showModal = false;

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

  routeRequest(req : Req) : void{
    if(!req.queries){
      this.notifyParent.emit(req);
    }
    else{
      this.router.navigate(['/response']);
    }
  }

  reset() {
    this.response = '';
  }
}

export interface Req {
  url: string;
  verb: string;
  queries?: string;
}
