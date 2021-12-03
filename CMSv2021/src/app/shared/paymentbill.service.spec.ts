import { TestBed } from '@angular/core/testing';

import { PaymentbillService } from './paymentbill.service';

describe('PaymentbillService', () => {
  let service: PaymentbillService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PaymentbillService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
