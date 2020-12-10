import { Component, Input, OnInit } from '@angular/core';
import { AuctionSessionService } from 'src/app/modules/session/services/auction-session.service';
import { AuctionSession } from '../../../models/auctionsession-data-model';


@Component({
  selector: 'app-show-sessions',
  templateUrl: './show-sessions.component.html',
  styleUrls: ['./show-sessions.component.css']
})
export class ShowSessionsComponent implements OnInit {

  sessionToView:AuctionSession;
  @Input() selectedSession: AuctionSession;

  // sessionId: number;
  // sessionName: string;
  // sessionDescription:string;
  showSession: boolean = false;

  constructor(private sessionService: AuctionSessionService) { }

  ngOnInit(): void {
    this.sessionToView = this.selectedSession;
  }

  

}
