import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageipodetailsComponent } from './manageipodetails.component';

describe('ManageipodetailsComponent', () => {
  let component: ManageipodetailsComponent;
  let fixture: ComponentFixture<ManageipodetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManageipodetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageipodetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
