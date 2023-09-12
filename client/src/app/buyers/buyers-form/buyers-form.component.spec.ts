import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BuyersFormComponent } from './buyers-form.component';

describe('BuyersFormComponent', () => {
  let component: BuyersFormComponent;
  let fixture: ComponentFixture<BuyersFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BuyersFormComponent]
    });
    fixture = TestBed.createComponent(BuyersFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
