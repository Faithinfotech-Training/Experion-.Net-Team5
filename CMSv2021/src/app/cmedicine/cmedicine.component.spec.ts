import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CmedicineComponent } from './cmedicine.component';

describe('CmedicineComponent', () => {
  let component: CmedicineComponent;
  let fixture: ComponentFixture<CmedicineComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CmedicineComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CmedicineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
