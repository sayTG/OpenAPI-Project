import { Component, Output, OnInit, Input, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-response-modal',
  templateUrl: './response-modal.component.html',
  styleUrls: ['./response-modal.component.scss']
})
export class ResponseModalComponent implements OnInit {

  @Output() notifyParent: EventEmitter<any> = new EventEmitter();
  
  @Input() showModal = false;

  @Input() res : any;

  constructor() { }

  ngOnInit(): void {
  }
  toggleModal(){
    this.showModal = !this.showModal;
    this.notifyParent.emit(this.showModal);
  }
}

