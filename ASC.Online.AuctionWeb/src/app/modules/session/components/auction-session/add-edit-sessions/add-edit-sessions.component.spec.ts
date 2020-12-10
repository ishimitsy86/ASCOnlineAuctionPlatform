import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditSessionsComponent } from './add-edit-sessions.component';

describe('AddEditSessionsComponent', () => {
  let component: AddEditSessionsComponent;
  let fixture: ComponentFixture<AddEditSessionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditSessionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditSessionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
