import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InvoicesInfoComponent } from './invoices-info.component';

describe('InvoicesInfoComponent', () => {
  let component: InvoicesInfoComponent;
  let fixture: ComponentFixture<InvoicesInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InvoicesInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InvoicesInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
