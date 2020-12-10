import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuctionSessionComponent } from './components/auction-session/auction-session.component';
import { ShowSessionsComponent } from './components/auction-session/show-sessions/show-sessions.component';
import { AddEditSessionsComponent } from './components/auction-session/add-edit-sessions/add-edit-sessions.component';
import {AuctionSessionService} from 'src/app/modules/session/services/auction-session.service';



@NgModule({
  declarations: [
    AuctionSessionComponent,    
    AddEditSessionsComponent,
    ShowSessionsComponent
    
  ],
  imports: [
    CommonModule
        
  ],
  providers:[
    AuctionSessionService
  ]
})
export class SessionModule { }
