import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RequestCardComponent } from './components/request-card/request-card.component';
import { ResponseCardComponent } from './components/response-card/response-card.component';
import { ResponseHomepageComponent } from './components/response-homepage/response-homepage.component';
import { SearchCardComponent } from './components/search-card/search-card.component';

const routes: Routes = [
  {
    path: '',
    component: ResponseHomepageComponent,
  },
  {
    path: 'people',
    component: ResponseCardComponent,
  },
  {
    path: 'search',
    component: SearchCardComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
