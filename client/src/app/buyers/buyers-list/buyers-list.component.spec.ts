import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BuyersListComponent } from './buyers-list.component';

describe('BuyersListComponent', () => {
  let component: BuyersListComponent;
  let fixture: ComponentFixture<BuyersListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BuyersListComponent]
    });
    fixture = TestBed.createComponent(BuyersListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
