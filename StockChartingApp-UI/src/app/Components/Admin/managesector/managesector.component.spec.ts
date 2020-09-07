import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagesectorComponent } from './managesector.component';

describe('ManagesectorComponent', () => {
  let component: ManagesectorComponent;
  let fixture: ComponentFixture<ManagesectorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManagesectorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagesectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
