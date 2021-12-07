import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DtestListComponent } from './dtest-list.component';

describe('DtestListComponent', () => {
  let component: DtestListComponent;
  let fixture: ComponentFixture<DtestListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DtestListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DtestListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
