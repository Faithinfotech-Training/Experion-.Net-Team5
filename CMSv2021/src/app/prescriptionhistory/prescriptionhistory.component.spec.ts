import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrescriptionhistoryComponent } from './prescriptionhistory.component';

describe('PrescriptionhistoryComponent', () => {
  let component: PrescriptionhistoryComponent;
  let fixture: ComponentFixture<PrescriptionhistoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrescriptionhistoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrescriptionhistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
