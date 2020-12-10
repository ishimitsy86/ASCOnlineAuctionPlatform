import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { AuctionSessionService } from 'src/app/modules/session/services/auction-session.service';
import { AuctionSession } from 'src/app/modules/session/models/auctionsession-data-model';
import { ShowSessionsComponent } from './show-sessions/show-sessions.component';

@Component({
  selector: 'app-auction-session',
  templateUrl: './auction-session.component.html',
  styleUrls: ['./auction-session.component.css']
})
export class AuctionSessionComponent implements OnInit {

  auctionSessions: AuctionSession[];
  selectedSession: AuctionSession;
  activateShowSessionComponent: boolean = false;
 

  constructor(private sessionService: AuctionSessionService) { }

  ngOnInit(): void {    
    this.refreshAuctionSessionsList();
  }

  refreshAuctionSessionsList() {
    this.sessionService.getAuctionSessions().subscribe(data => {
      console.log(data);
      this.auctionSessions = data;
    });
  }

  showSession(item: AuctionSession) {
    this.selectedSession = item;
    this.activateShowSessionComponent = true;   
  }

}
