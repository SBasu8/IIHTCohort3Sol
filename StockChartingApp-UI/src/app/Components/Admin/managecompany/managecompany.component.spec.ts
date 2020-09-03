import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagecompanyComponent } from './managecompany.component';

describe('ManagecompanyComponent', () => {
  let component: ManagecompanyComponent;
  let fixture: ComponentFixture<ManagecompanyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManagecompanyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagecompanyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
