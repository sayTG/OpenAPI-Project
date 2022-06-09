import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-request-card',
  templateUrl: './request-card.component.html',
})
export class RequestCardComponent implements OnInit {
  constructor(private http: HttpClient) {}

  @Input() req = { title: '', verb: 'GET', url: '' };
  response = '';

  ngOnInit(): void {}

  fetchRequest() {
    this.http.get(this.req.url).subscribe({
      next: (res: any) => {
        this.response = JSON.stringify(res, null, 4);
      },
    });
  }

  reset() {
    this.response = '';
  }
}
