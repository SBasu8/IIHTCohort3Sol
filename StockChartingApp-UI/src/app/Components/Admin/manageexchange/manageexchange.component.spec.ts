import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageexchangeComponent } from './manageexchange.component';

describe('ManageexchangeComponent', () => {
  let component: ManageexchangeComponent;
  let fixture: ComponentFixture<ManageexchangeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManageexchangeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageexchangeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
