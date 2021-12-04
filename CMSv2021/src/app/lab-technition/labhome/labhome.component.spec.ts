import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LabhomeComponent } from './labhome.component';

describe('LabhomeComponent', () => {
  let component: LabhomeComponent;
  let fixture: ComponentFixture<LabhomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LabhomeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LabhomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
