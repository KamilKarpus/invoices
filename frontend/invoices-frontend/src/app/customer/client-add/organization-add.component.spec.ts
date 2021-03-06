import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { OrganizationAddComponent } from './organization-add.component';


describe('ClientAddComponent', () => {
  let component: OrganizationAddComponent;
  let fixture: ComponentFixture<OrganizationAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OrganizationAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OrganizationAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
