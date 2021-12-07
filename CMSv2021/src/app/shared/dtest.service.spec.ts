import { TestBed } from '@angular/core/testing';

import { DtestService } from './dtest.service';

describe('DtestService', () => {
  let service: DtestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DtestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
