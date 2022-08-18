import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RequestCardComponent } from './components/request-card/request-card.component';
import { ResponseCardComponent } from './components/response-card/response-card.component';
import { ResponseHomepageComponent } from './components/response-homepage/response-homepage.component';

const routes: Routes = [
        {
          path: "",
          component: ResponseHomepageComponent,
        },
        {
          path: 'response',
          component: ResponseCardComponent,
        },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
