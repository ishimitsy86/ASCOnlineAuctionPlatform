import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AuctionSessionComponent} from 'src/app/modules/session/components/auction-session/auction-session.component'
import {ShowSessionsComponent} from 'src/app/modules/session/components/auction-session/show-sessions/show-sessions.component';
import { AuctionSessionService } from './modules/session/services/auction-session.service';

const routes: Routes = [
  {path:'',component:AuctionSessionComponent},
  {path:'sessions',component:AuctionSessionComponent},
  {path:'showsession',component:ShowSessionsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
