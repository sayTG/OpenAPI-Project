import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResponseHomepageComponent } from './response-homepage.component';

describe('ResponseHomepageComponent', () => {
  let component: ResponseHomepageComponent;
  let fixture: ComponentFixture<ResponseHomepageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResponseHomepageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResponseHomepageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
