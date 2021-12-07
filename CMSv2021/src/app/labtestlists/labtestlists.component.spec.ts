import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LabtestlistsComponent } from './labtestlists.component';

describe('LabtestlistsComponent', () => {
  let component: LabtestlistsComponent;
  let fixture: ComponentFixture<LabtestlistsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LabtestlistsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LabtestlistsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
