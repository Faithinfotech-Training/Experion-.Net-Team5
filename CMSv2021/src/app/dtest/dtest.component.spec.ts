import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DtestComponent } from './dtest.component';

describe('DtestComponent', () => {
  let component: DtestComponent;
  let fixture: ComponentFixture<DtestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DtestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DtestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
