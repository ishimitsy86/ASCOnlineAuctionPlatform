import { TestBed } from '@angular/core/testing';

import { AuctionSessionService } from './auction-session.service';

describe('AuctionSessionService', () => {
  let service: AuctionSessionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuctionSessionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
