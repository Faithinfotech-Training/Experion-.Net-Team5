import { TestBed } from '@angular/core/testing';

import { LabTechnitionService } from './lab-technition.service';

describe('LabTechnitionService', () => {
  let service: LabTechnitionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LabTechnitionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
