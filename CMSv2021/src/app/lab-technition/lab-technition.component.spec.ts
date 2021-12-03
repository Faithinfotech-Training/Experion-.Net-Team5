import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LabTechnitionComponent } from './lab-technition.component';

describe('LabTechnitionComponent', () => {
  let component: LabTechnitionComponent;
  let fixture: ComponentFixture<LabTechnitionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LabTechnitionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LabTechnitionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
