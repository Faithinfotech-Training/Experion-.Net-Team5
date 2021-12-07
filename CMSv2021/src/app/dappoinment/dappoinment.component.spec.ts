import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DappoinmentComponent } from './dappoinment.component';

describe('DappoinmentComponent', () => {
  let component: DappoinmentComponent;
  let fixture: ComponentFixture<DappoinmentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DappoinmentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DappoinmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
