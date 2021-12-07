import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LabappointmentComponent } from './labappointment.component';

describe('LabappointmentComponent', () => {
  let component: LabappointmentComponent;
  let fixture: ComponentFixture<LabappointmentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LabappointmentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LabappointmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
