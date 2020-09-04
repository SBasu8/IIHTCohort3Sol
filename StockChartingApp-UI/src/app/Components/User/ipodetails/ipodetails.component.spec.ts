import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IpodetailsComponent } from './ipodetails.component';

describe('IpodetailsComponent', () => {
  let component: IpodetailsComponent;
  let fixture: ComponentFixture<IpodetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IpodetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IpodetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
