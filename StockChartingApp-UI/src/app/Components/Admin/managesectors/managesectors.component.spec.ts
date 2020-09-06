import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagesectorsComponent } from './managesectors.component';

describe('ManagesectorsComponent', () => {
  let component: ManagesectorsComponent;
  let fixture: ComponentFixture<ManagesectorsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManagesectorsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagesectorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
