import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { RequestCardComponent } from './components/request-card/request-card.component';
import { ResponseCardComponent } from './components/response-card/response-card.component';
import { ResponseModalComponent } from './components/response-modal/response-modal.component';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [AppComponent, RequestCardComponent, ResponseCardComponent, ResponseModalComponent],
  imports: [BrowserModule, HttpClientModule, AppRoutingModule, FormsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
