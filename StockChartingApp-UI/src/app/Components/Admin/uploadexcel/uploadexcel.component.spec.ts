import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UploadexcelComponent } from './uploadexcel.component';

describe('UploadexcelComponent', () => {
  let component: UploadexcelComponent;
  let fixture: ComponentFixture<UploadexcelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UploadexcelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UploadexcelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
