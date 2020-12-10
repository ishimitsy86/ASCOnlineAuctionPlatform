import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuctionSessionComponent } from './auction-session.component';

describe('AuctionSessionComponent', () => {
  let component: AuctionSessionComponent;
  let fixture: ComponentFixture<AuctionSessionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuctionSessionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AuctionSessionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
